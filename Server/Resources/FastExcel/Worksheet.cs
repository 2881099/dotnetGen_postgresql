﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Xml.Linq;

namespace FastExcel
{
    public class Worksheet
    {
        /// <summary>
        /// Collection of rows in this worksheet
        /// </summary>
        public IEnumerable<Row> Rows { get; set; }

        public IEnumerable<string> Headings { get; set; }

        public int Index { get; internal set; }
        public string Name { get; set; }
        public int ExistingHeadingRows { get; set; }
        private int? InsertAfterIndex { get; set; }
        public bool Template { get; set; }

        internal string Headers { get; set; }
        internal string Footers { get; set; }

        public FastExcel FastExcel { get; private set; }

        internal string FileName
        {
            get
            {
                return Worksheet.GetFileName(this.Index);
            }
        }

        public static string GetFileName(int index)
        {
            return string.Format("xl/worksheets/sheet{0}.xml", index);
        }

        private const string DEFAULT_HEADERS = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\"><sheetData>";
        private const string DEFAULT_FOOTERS = "</sheetData></worksheet>";

        public Worksheet() { }

        public Worksheet(FastExcel fastExcel)
        {
            FastExcel = fastExcel;
        }

        public void PopulateRows<T>(IEnumerable<T> rows, int existingHeadingRows = 0, bool usePropertiesAsHeadings = false)
        {
            if ((rows.FirstOrDefault() as IEnumerable<object>) == null)
            {
                PopulateRowsFromObjects(rows, existingHeadingRows, usePropertiesAsHeadings);
            }
            else
            {
                PopulateRowsFromIEnumerable(rows as IEnumerable<IEnumerable<object>>, existingHeadingRows);
            }
        }


        private string GetHeaderName(PropertyInfo propertyInfo)
        {
            var descriptionAttribute = propertyInfo.GetCustomAttribute(typeof (DescriptionAttribute)) as DescriptionAttribute;
            if (descriptionAttribute != null && !string.IsNullOrWhiteSpace(descriptionAttribute.Description))
            {
                return descriptionAttribute.Description;
            }
            return propertyInfo.Name;
        }

        private void PopulateRowsFromObjects<T>(IEnumerable<T> rows, int existingHeadingRows = 0, bool usePropertiesAsHeadings = false)
        {
            int rowNumber = existingHeadingRows + 1;

            // Get all properties
            PropertyInfo[] properties = typeof(T).GetTypeInfo().GetProperties();
            List<Row> newRows = new List<Row>();
            
            if (usePropertiesAsHeadings)
            {
                this.Headings = properties.Select(GetHeaderName);

                int headingColumnNumber = 1;
                IEnumerable<Cell> headingCells = (from h in this.Headings
                                                   select new Cell(headingColumnNumber++, h)).ToArray();

                Row headingRow = new Row(rowNumber++, headingCells);

                newRows.Add(headingRow);
            }

            foreach (T rowObject in rows)
            {
                List<Cell> cells = new List<Cell>();
                
                int columnNumber = 1;

                // Get value from each property
                foreach (PropertyInfo propertyInfo in properties)
                {
                    object value = propertyInfo.GetValue(rowObject, null);
                    if(value != null)
                    {
                        Cell cell = new Cell(columnNumber, value);
                        cells.Add(cell);
                    }
                    columnNumber++;
                }

                Row row = new Row(rowNumber++, cells);
                newRows.Add(row);
            }

            this.Rows = newRows;
        }

        private void PopulateRowsFromIEnumerable(IEnumerable<IEnumerable<object>> rows, int existingHeadingRows = 0)
        {
            int rowNumber = existingHeadingRows + 1;
            
            List<Row> newRows = new List<Row>();

            foreach (IEnumerable<object> rowOfObjects in rows)
            {
                List<Cell> cells = new List<Cell>();

                int columnNumber = 1;

                foreach (object value in rowOfObjects)
                {
                    if (value != null)
                    {
                        Cell cell = new Cell(columnNumber, value);
                        cells.Add(cell);
                    }
                    columnNumber++;
                }

                Row row = new Row(rowNumber++, cells);
                newRows.Add(row);
            }

            this.Rows = newRows;
        }

        /// <summary>
        /// Add a row using a collection of value objects
        /// </summary>
        /// <param name="cellValues">Collection of objects</param>
        public void AddRow(params object[] cellValues)
        {
            if (this.Rows == null)
            {
                this.Rows = new List<Row>();
            }

            List<Cell> cells = new List<Cell>();

            int columnNumber = 1;
            foreach (object value in cellValues)
	        {
                if (value != null)
                {
		            Cell cell = new Cell(columnNumber++, value);
                    cells.Add(cell);
                }
                else
                {
                    columnNumber++;
                }
	        }

            Row row = new Row(this.Rows.Count() + 1, cells);
            (this.Rows as List<Row>).Add(row);
        }

        /// <summary>
        /// Note: This method is slow
        /// </summary>
        public void AddValue(int rowNumber, int columnNumber, object value)
        {
            if (this.Rows == null)
            {
                this.Rows = new List<Row>();
            }

            Row row = (from r in this.Rows
                       where r.RowNumber == rowNumber
                       select r).FirstOrDefault();
            Cell cell = null;

            if (row == null)
            {
                cell = new Cell(columnNumber, value);
                row = new Row(rowNumber, new List<Cell>{ cell });
                (this.Rows as List<Row>).Add(row);
            }

            if (cell == null)
            {
                cell = (from c in row.Cells
                        where c.ColumnNumber == columnNumber
                        select c).FirstOrDefault();

                if (cell == null)
                {
                    cell = new Cell(columnNumber, value);
                    (row.Cells as List<Cell>).Add(cell);
                }
            }

        }

        /// <summary>
        /// Merges the parameter into the current DatSet object, the parameter takes precedence
        /// </summary>
        /// <param name="data">A DataSet to merge</param>
        public void Merge(Worksheet data)
        {
            // Merge headings
            if (this.Headings == null || !this.Headings.Any())
            {
                this.Headings = data.Headings;
            }

            // Merge rows
            data.Rows = MergeRows(data.Rows);
        }

        private IEnumerable<Row> MergeRows(IEnumerable<Row> rows)
        {
            foreach (var row in this.Rows.Union(rows).GroupBy(r => r.RowNumber))
            {
                int count = row.Count();
                if (count == 1)
                {
                    yield return row.First();
                }
                else
                {
                    row.First().Merge(row.Skip(1).First());

                    yield return row.First();
                }
            }
        }
        
        public bool Exists
        {
            get
            {
                return !string.IsNullOrEmpty(this.FileName);
            }
        }

        internal void Read(int? sheetNumber = null, string sheetName = null, int existingHeadingRows = 0)
        {
            GetWorksheetProperties(FastExcel, sheetNumber, sheetName);
            Read(existingHeadingRows);
        }

        public void Read(int existingHeadingRows = 0)
        {
            FastExcel.CheckFiles();
            FastExcel.PrepareArchive();
            
            ExistingHeadingRows = existingHeadingRows;
            
            IEnumerable<Row> rows = null;

            List<string> headings = new List<string>();
            using (Stream stream = FastExcel.Archive.GetEntry(FileName).Open())
            {
                XDocument document = XDocument.Load(stream);
                int skipRows = 0;

                Row possibleHeadingRow = new Row(document.Descendants().Where(d => d.Name.LocalName == "row").FirstOrDefault(), FastExcel.SharedStrings);
                if (ExistingHeadingRows == 1 && possibleHeadingRow.RowNumber == 1)
                {
                    foreach (Cell headerCell in possibleHeadingRow.Cells)
                    {
                        headings.Add(headerCell.Value.ToString());
                    }
                }
                rows = GetRows(document.Descendants().Where(d => d.Name.LocalName == "row").Skip(skipRows));
            }

            Headings = headings;
            Rows = rows;
        }

        private IEnumerable<Row> GetRows(IEnumerable<XElement> rowElements)
        {
            foreach (var rowElement in rowElements)
            {
                yield return new Row(rowElement, FastExcel.SharedStrings);
            }
        }

        /// <summary>
        /// Read the existing sheet and copy some of the existing content
        /// </summary>
        /// <param name="stream">Worksheet stream</param>
        /// <param name="worksheet">Saves the header and footer to the worksheet</param>
        internal void ReadHeadersAndFooters(StreamReader stream, ref Worksheet worksheet)
        {
            StringBuilder headers = new StringBuilder();
            StringBuilder footers = new StringBuilder();

            bool headersComplete = false;
            bool rowsComplete = false;

            int existingHeadingRows = worksheet.ExistingHeadingRows;

            while (stream.Peek() >= 0)
            {
                string line = stream.ReadLine();
                int currentLineIndex = 0;

                if (!headersComplete)
                {
                    if (line.Contains("<sheetData/>"))
                    {
                        currentLineIndex = line.IndexOf("<sheetData/>");
                        headers.Append(line.Substring(0, currentLineIndex));
                        //remove the read section from line
                        line = line.Substring(currentLineIndex, line.Length - currentLineIndex);

                        headers.Append("<sheetData>");

                        // Headers complete now skip any content and start footer
                        headersComplete = true;
                        footers = new StringBuilder();
                        footers.Append("</sheetData>");

                        //There is no rows
                        rowsComplete = true;
                    }
                    else if (line.Contains("<sheetData>"))
                    {
                        currentLineIndex = line.IndexOf("<sheetData>");
                        headers.Append(line.Substring(0, currentLineIndex));
                        //remove the read section from line
                        line = line.Substring(currentLineIndex, line.Length - currentLineIndex);

                        headers.Append("<sheetData>");

                        // Headers complete now skip any content and start footer
                        headersComplete = true;
                        footers = new StringBuilder();
                        footers.Append("</sheetData>");
                    }
                    else
                    {
                        headers.Append(line);
                    }
                }

                if (headersComplete && !rowsComplete)
                {
                    if (existingHeadingRows == 0)
                    {
                        rowsComplete = true;
                    }

                    if (!rowsComplete)
                    {
                        while (!string.IsNullOrEmpty(line) && existingHeadingRows != 0)
                        {
                            if (line.Contains("<row"))
                            {
                                if (line.Contains("</row>"))
                                {
                                    int index = line.IndexOf("<row");
                                    currentLineIndex = line.IndexOf("</row>") + "</row>".Length;
                                    headers.Append(line.Substring(index, currentLineIndex - index));

                                    //remove the read section from line
                                    line = line.Substring(currentLineIndex, line.Length - currentLineIndex);
                                    existingHeadingRows--;
                                }
                                else
                                {
                                    int index = line.IndexOf("<row");
                                    headers.Append(line.Substring(index, line.Length - index));
                                    line = string.Empty;
                                }
                            }
                            else if (line.Contains("</row>"))
                            {
                                currentLineIndex = line.IndexOf("</row>") + "</row>".Length;
                                headers.Append(line.Substring(0, currentLineIndex));

                                //remove the read section from line
                                line = line.Substring(currentLineIndex, line.Length - currentLineIndex);
                                existingHeadingRows--;
                            }
                        }
                    }

                    if (existingHeadingRows == 0)
                    {
                        rowsComplete = true;
                    }
                }

                if (rowsComplete)
                {
                    if (line.Contains("</sheetData>"))
                    {
                        int index = line.IndexOf("</sheetData>") + "</sheetData>".Length;
                        footers.Append(line.Substring(index, line.Length - index));
                    }
                    else if (line.Contains("<sheetData/>"))
                    {
                        int index = line.IndexOf("<sheetData/>") + "<sheetData/>".Length;
                        footers.Append(line.Substring(index, line.Length - index));
                    }
                    else
                    {
                        footers.Append(line);
                    }
                }
            }
            worksheet.Headers = headers.ToString();
            worksheet.Footers = footers.ToString();
        }


        /// <summary>
        /// Get worksheet file name from xl/workbook.xml
        /// </summary>
        internal void GetWorksheetProperties(FastExcel fastExcel, int? sheetNumber = null, string sheetName = null)
        {
            GetWorksheetPropertiesAndValidateNewName(fastExcel, sheetNumber, sheetName);
        }

        private bool GetWorksheetPropertiesAndValidateNewName(FastExcel fastExcel, int? sheetNumber = null, string sheetName = null, string newSheetName = null)
        {
            FastExcel = fastExcel;
            bool newSheetNameExists = false;

            FastExcel.CheckFiles();
            FastExcel.PrepareArchive();

            //If index has already been loaded then we can skip this function
            if (this.Index != 0)
            {
                return true;
            }

            if (!sheetNumber.HasValue && string.IsNullOrEmpty(sheetName))
            {
                throw new Exception("No worksheet name or number was specified");
            }

            using (Stream stream = FastExcel.Archive.GetEntry("xl/workbook.xml").Open())
            {
                XDocument document = XDocument.Load(stream);

                if (document == null)
                {
                    throw new Exception("Unable to load workbook.xml");
                }

                List<XElement> sheetsElements = document.Descendants().Where(d => d.Name.LocalName == "sheet").ToList();

                XElement sheetElement = null;

                if (sheetNumber.HasValue)
                {
                    if (sheetNumber.Value <= sheetsElements.Count)
                    {
                        sheetElement = sheetsElements[sheetNumber.Value - 1];
                    }
                    else
                    {
                        throw new Exception(string.Format("There is no sheet at index '{0}'", sheetNumber));
                    }
                }
                else if (!string.IsNullOrEmpty(sheetName))
                {
                    sheetElement = (from sheet in sheetsElements
                                    from attribute in sheet.Attributes()
                                    where attribute.Name == "name" && attribute.Value.Equals(sheetName, StringComparison.CurrentCultureIgnoreCase)
                                    select sheet).FirstOrDefault();

                    if (sheetElement == null)
                    {
                        throw new Exception(string.Format("There is no sheet named '{0}'", sheetName));
                    }

                    if (!string.IsNullOrEmpty(newSheetName))
                    {
                        newSheetNameExists = (from sheet in sheetsElements
                                        from attribute in sheet.Attributes()
                                                    where attribute.Name == "name" && attribute.Value.Equals(newSheetName, StringComparison.CurrentCultureIgnoreCase)
                                        select sheet).Any();

                        if (FastExcel.MaxSheetNumber == 0)
                        {
                            FastExcel.MaxSheetNumber = (from sheet in sheetsElements
                                                        from attribute in sheet.Attributes()
                                                        where attribute.Name == "sheetId"
                                                        select int.Parse(attribute.Value)).Max();
                        }
                    }
                }
                               
                this.Index = sheetsElements.IndexOf(sheetElement)+1;
                
                this.Name = (from attribute in sheetElement.Attributes()
                              where attribute.Name == "name"
                              select attribute.Value).FirstOrDefault();
            }

            if (!this.Exists)
            {
                throw new Exception("No worksheet was found with the name or number was specified");
            }

            if (string.IsNullOrEmpty(newSheetName))
            {
                return false;
            }
            else
            {
                return !newSheetNameExists;
            }
        }

        internal void ValidateNewWorksheet(FastExcel fastExcel, int? insertAfterSheetNumber = null, string insertAfterSheetName = null)
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                // TODO possibly could calulcate a new worksheet name
                throw new Exception("Name for new worksheet is not specified");
            }

            // Get worksheet details
            Worksheet previousWorksheet = new Worksheet(fastExcel);
            bool isNameValid = previousWorksheet.GetWorksheetPropertiesAndValidateNewName(fastExcel, insertAfterSheetNumber, insertAfterSheetName, this.Name);
            this.InsertAfterIndex = previousWorksheet.Index;
            
            if (!isNameValid)
            {
                throw new Exception(string.Format("Worksheet name '{0}' already exists", this.Name));
            }

            fastExcel.MaxSheetNumber += 1;
            this.Index = fastExcel.MaxSheetNumber;

            if (string.IsNullOrEmpty(this.Headers))
            {
                this.Headers = DEFAULT_HEADERS;
            }

            if (string.IsNullOrEmpty(this.Footers))
            {
                this.Footers = DEFAULT_FOOTERS;
            }
        }

        internal WorksheetAddSettings AddSettings
        {
            get
            {
                if (this.InsertAfterIndex.HasValue)
                {
                    return new WorksheetAddSettings()
                    {
                        Name = this.Name,
                        SheetId = this.Index,
                        InsertAfterSheetId = this.InsertAfterIndex.Value
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
