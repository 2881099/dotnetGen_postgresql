using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using Model;

namespace Server {

	internal partial class CodeBuild {
		public void SetOutput(bool[] outputs) {
			if (this._tables.Count == outputs.Length) {
				for (int a = 0; a < outputs.Length; a++) {
					this._tables[a].IsOutput = outputs[a];
				}
			}
		}

		public List<BuildInfo> Build(string solutionName, bool isSolution, bool isMakeAdmin, bool isDownloadRes) {
			Logger.remotor.Info("Build: " + solutionName + ",isSolution: " + isSolution + ",isMakeAdmin: " + isMakeAdmin + ",isDownloadRes: " + isDownloadRes + "(" + _client.Server + "," + _client.Username + "," + _client.Password + "," + _client.Database + ")");
			List<BuildInfo> loc1 = new List<BuildInfo>();

			//solutionName = CodeBuild.UFString(solutionName);
			string dbName = CodeBuild.UFString(CodeBuild.GetCSName(_client.Database));
			string connectionStringName = _client.Database + "ConnectionString";
			string basicName = "Build";

			string srcGuid = Guid.NewGuid().ToString().ToUpper();
			string slnGuid = Guid.NewGuid().ToString().ToUpper();
			string commonGuid = Guid.NewGuid().ToString().ToUpper();
			string dbGuid = Guid.NewGuid().ToString().ToUpper();
			string adminGuid = Guid.NewGuid().ToString().ToUpper();
			string wwwroot_sitemap = "";

			Dictionary<string, bool> isMakedHtmlSelect = new Dictionary<string, bool>();
			StringBuilder Model_Build__ExtensionMethods_cs = new StringBuilder();
			List<string> admin_controllers_syscontroller_init_sysdir = new List<string>();

			StringBuilder sb1 = new StringBuilder();
			StringBuilder sb2 = new StringBuilder();
			StringBuilder sb3 = new StringBuilder();
			StringBuilder sb4 = new StringBuilder();
			StringBuilder sb5 = new StringBuilder();
			StringBuilder sb6 = new StringBuilder();
			StringBuilder sb7 = new StringBuilder();
			StringBuilder sb8 = new StringBuilder();
			StringBuilder sb9 = new StringBuilder();
			StringBuilder sb10 = new StringBuilder();
			StringBuilder sb11 = new StringBuilder();
			StringBuilder sb12 = new StringBuilder();
			StringBuilder sb13 = new StringBuilder();
			StringBuilder sb14 = new StringBuilder();
			StringBuilder sb15 = new StringBuilder();
			StringBuilder sb16 = new StringBuilder();
			StringBuilder sb17 = new StringBuilder();
			StringBuilder sb18 = new StringBuilder();
			StringBuilder sb19 = new StringBuilder();
			StringBuilder sb20 = new StringBuilder();
			StringBuilder sb21 = new StringBuilder();
			StringBuilder sb22 = new StringBuilder();
			StringBuilder sb23 = new StringBuilder();
			StringBuilder sb24 = new StringBuilder();
			StringBuilder sb25 = new StringBuilder();
			StringBuilder sb26 = new StringBuilder();
			StringBuilder sb27 = new StringBuilder();
			StringBuilder sb28 = new StringBuilder();
			StringBuilder sb29 = new StringBuilder();
			AnonymousHandler clearSb = delegate () {
				sb1.Remove(0, sb1.Length);
				sb2.Remove(0, sb2.Length);
				sb3.Remove(0, sb3.Length);
				sb4.Remove(0, sb4.Length);
				sb5.Remove(0, sb5.Length);
				sb6.Remove(0, sb6.Length);
				sb7.Remove(0, sb7.Length);
				sb8.Remove(0, sb8.Length);
				sb9.Remove(0, sb9.Length);
				sb10.Remove(0, sb10.Length);
				sb11.Remove(0, sb11.Length);
				sb12.Remove(0, sb12.Length);
				sb13.Remove(0, sb13.Length);
				sb14.Remove(0, sb14.Length);
				sb15.Remove(0, sb15.Length);
				sb16.Remove(0, sb16.Length);
				sb17.Remove(0, sb17.Length);
				sb18.Remove(0, sb18.Length);
				sb19.Remove(0, sb19.Length);
				sb20.Remove(0, sb20.Length);
				sb21.Remove(0, sb21.Length);
				sb22.Remove(0, sb22.Length);
				sb23.Remove(0, sb23.Length);
				sb24.Remove(0, sb24.Length);
				sb25.Remove(0, sb25.Length);
				sb26.Remove(0, sb26.Length);
				sb27.Remove(0, sb27.Length);
				sb28.Remove(0, sb28.Length);
				sb29.Remove(0, sb29.Length);
			};

			if (isSolution) {
				#region solution.sln
				sb1.AppendFormat(CONST.sln, srcGuid, slnGuid, commonGuid, dbGuid, adminGuid, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\", solutionName, ".sln"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region global.json
				sb1.AppendFormat(CONST.global_json);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\", "global.json"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				#region Project Common
				#region Lib/BmwNet.cs
				sb1.AppendFormat(CONST.Common_BmwNet_cs, solutionName);
				//loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Lib\BmwNet.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Lib/IniHelper.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Lib\IniHelper.cs"), Deflate.Compress(Properties.Resources.Lib_IniHelper_cs)));
				clearSb();
				#endregion
				#region Lib/JSDecoder.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Lib\JSDecoder.cs"), Deflate.Compress(Properties.Resources.Lib_JSDecoder_cs)));
				clearSb();
				#endregion
				#region Lib/Lib.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Lib\Lib.cs"), Deflate.Compress(Properties.Resources.Lib_Lib_cs)));
				clearSb();
				#endregion

				#region WinFormClass/Socket/BaseSocket.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\WinFormClass\Socket\BaseSocket.cs"), Deflate.Compress(Properties.Resources.WinFormClass_Socket_BaseSocket_cs)));
				clearSb();
				#endregion
				#region WinFormClass/Socket/ClientSocket.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\WinFormClass\Socket\ClientSocket.cs"), Deflate.Compress(Properties.Resources.WinFormClass_Socket_ClientSocket_cs)));
				clearSb();
				#endregion
				#region WinFormClass/Socket/ServerSocket.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\WinFormClass\Socket\ServerSocket.cs"), Deflate.Compress(Properties.Resources.WinFormClass_Socket_ServerSocket_cs)));
				clearSb();
				#endregion
				#region WinFormClass/Robot.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\WinFormClass\Robot.cs"), Deflate.Compress(Properties.Resources.WinFormClass_Robot_cs)));
				clearSb();
				#endregion
				#region WinFormClass/WorkQueue.cs
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\WinFormClass\WorkQueue.cs"), Deflate.Compress(Properties.Resources.WinFormClass_WorkQueue_cs)));
				clearSb();
				#endregion

				#region CSRedis
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\ConnectionPool.cs"), Deflate.Compress(Properties.Resources.CSRedis_ConnectionPool_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Events.cs"), Deflate.Compress(Properties.Resources.CSRedis_Events_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Exceptions.cs"), Deflate.Compress(Properties.Resources.CSRedis_Exceptions_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\IRedisClient.cs"), Deflate.Compress(Properties.Resources.CSRedis_IRedisClient_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\IRedisClientAsync.cs"), Deflate.Compress(Properties.Resources.CSRedis_IRedisClientAsync_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\IRedisClientSync.cs"), Deflate.Compress(Properties.Resources.CSRedis_IRedisClientSync_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\QuickHelperBase.cs"), Deflate.Compress(Properties.Resources.CSRedis_QuickHelperBase_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisClient.Async.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisClient_Async_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisClient.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisClient_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisClient.Sync.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisClient_Sync_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisConnectionPool.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisConnectionPool_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisSentinelClient.Async.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisSentinelClient_Async_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisSentinelClient.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisSentinelClient_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisSentinelClient.Sync.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisSentinelClient_Sync_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\RedisSentinelManager.cs"), Deflate.Compress(Properties.Resources.CSRedis_RedisSentinelManager_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Types.cs"), Deflate.Compress(Properties.Resources.CSRedis_Types_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\MonitorListener.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_MonitorListener_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\RedisCommand.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_RedisCommand_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\RedisConnector.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_RedisConnector_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\RedisListener.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_RedisListener_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\RedisPipeline.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_RedisPipeline_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\RedisTransaction.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_RedisTransaction_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\SubscriptionListener.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_SubscriptionListener_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisArray.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisArray_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisBool.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisBool_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisBytes.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisBytes_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisDate.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisDate_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisFloat.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisFloat_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisHash.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisHash_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisInt.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisInt_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisIsMasterDownByAddrCommand.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisIsMasterDownByAddrCommand_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisObject.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisObject_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisRoleCommand.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisRoleCommand_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisScanCommand.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisScanCommand_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisSlowLogCommand.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisSlowLogCommand_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisStatus.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisStatus_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisString.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisString_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisSubscription.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisSubscription_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Commands\RedisTuple.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Commands_RedisTuple_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Fakes\FakeRedisSocket.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Fakes_FakeRedisSocket_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Fakes\FakeStream.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Fakes_FakeStream_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\AsyncConnector.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_AsyncConnector_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\IRedisSocket.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_IRedisSocket_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\RedisAsyncCommandToken.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_RedisAsyncCommandToken_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\RedisIO.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_RedisIO_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\RedisPooledSocket.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_RedisPooledSocket_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\RedisReader.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_RedisReader_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\RedisSocket.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_RedisSocket_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\RedisWriter.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_RedisWriter_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\SocketAsyncPool.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_SocketAsyncPool_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\IO\SocketPool.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_IO_SocketPool_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Utilities\RedisArgs.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Utilities_RedisArgs_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\CSRedis\Internal\Utilities\Serializer.cs"), Deflate.Compress(Properties.Resources.CSRedis_Internal_Utilities_Serializer_cs)));
				#endregion
				#region Microsoft.Extensions.Caching.Redis
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Microsoft.Extensions.Caching.Redis\RedisCache.cs"), Deflate.Compress(Properties.Resources.Microsoft_Extensions_Caching_Redis_RedisCache_cs)));
				clearSb();
				#endregion

				#region MySql.Data.MySqlClient
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\MySql.Data.MySqlClient\ConnectionPool.cs"), Deflate.Compress(Properties.Resources.MySql_Data_MySqlClient_ConnectionPool_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\MySql.Data.MySqlClient\Executer.cs"), Deflate.Compress(Properties.Resources.MySql_Data_MySqlClient_Executer_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\MySql.Data.MySqlClient\SelectBuild.cs"), Deflate.Compress(Properties.Resources.MySql_Data_MySqlClient_SelectBuild_cs)));
				clearSb();
				#endregion
				#region Npgsql
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Npgsql\ConnectionPool.cs"), Deflate.Compress(Properties.Resources.Npgsql_ConnectionPool_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Npgsql\Executer.cs"), Deflate.Compress(Properties.Resources.Npgsql_Executer_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Npgsql\SelectBuild.cs"), Deflate.Compress(Properties.Resources.Npgsql_SelectBuild_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Npgsql\NpgsqlTypesConverter.cs"), Deflate.Compress(Properties.Resources.Npgsql_NpgsqlTypesConverter_cs)));
				clearSb();
				#endregion

				#region NPinyin
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\NPinyin\Pinyin.cs"), Deflate.Compress(Properties.Resources.NPinyin_Pinyin_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\NPinyin\PyCode.cs"), Deflate.Compress(Properties.Resources.NPinyin_PyCode_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\NPinyin\PyHash.cs"), Deflate.Compress(Properties.Resources.NPinyin_PyHash_cs)));
				clearSb();
				#endregion

				#region plist-cil
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\ASCIIPropertyListParser.cs"), Deflate.Compress(Properties.Resources.plist_cil_ASCIIPropertyListParser_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\BinaryPropertyListParser.cs"), Deflate.Compress(Properties.Resources.plist_cil_BinaryPropertyListParser_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\BinaryPropertyListWriter.cs"), Deflate.Compress(Properties.Resources.plist_cil_BinaryPropertyListWriter_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSArray.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSArray_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSArray.IList.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSArray_IList_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSData.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSData_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSDate.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSDate_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSDictionary.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSDictionary_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSNumber.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSNumber_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSObject.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSObject_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSSet.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSSet_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\NSString.cs"), Deflate.Compress(Properties.Resources.plist_cil_NSString_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\PropertyListException.cs"), Deflate.Compress(Properties.Resources.plist_cil_PropertyListException_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\PropertyListFormatException.cs"), Deflate.Compress(Properties.Resources.plist_cil_PropertyListFormatException_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\PropertyListParser.cs"), Deflate.Compress(Properties.Resources.plist_cil_PropertyListParser_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\UID.cs"), Deflate.Compress(Properties.Resources.plist_cil_UID_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\plist-cil\XmlPropertyListParser.cs"), Deflate.Compress(Properties.Resources.plist_cil_XmlPropertyListParser_cs)));
				clearSb();
				#endregion

				#region FastExcel
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\Cell.cs"), Deflate.Compress(Properties.Resources.FastExcel_Cell_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\FastExcel.Add.cs"), Deflate.Compress(Properties.Resources.FastExcel_FastExcel_Add_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\FastExcel.cs"), Deflate.Compress(Properties.Resources.FastExcel_FastExcel_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\FastExcel.Delete.cs"), Deflate.Compress(Properties.Resources.FastExcel_FastExcel_Delete_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\FastExcel.Read.cs"), Deflate.Compress(Properties.Resources.FastExcel_FastExcel_Read_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\FastExcel.Update.cs"), Deflate.Compress(Properties.Resources.FastExcel_FastExcel_Update_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\FastExcel.Worksheets.cs"), Deflate.Compress(Properties.Resources.FastExcel_FastExcel_Worksheets_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\FastExcel.Write.cs"), Deflate.Compress(Properties.Resources.FastExcel_FastExcel_Write_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\Row.cs"), Deflate.Compress(Properties.Resources.FastExcel_Row_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\SharedStrings.cs"), Deflate.Compress(Properties.Resources.FastExcel_SharedStrings_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\WorksheetAddSettings.cs"), Deflate.Compress(Properties.Resources.FastExcel_WorksheetAddSettings_cs)));
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\FastExcel\Worksheet.cs"), Deflate.Compress(Properties.Resources.FastExcel_Worksheet_cs)));
				clearSb();
				#endregion

				#region Common.xproj
				sb1.AppendFormat(CONST.xproj, commonGuid, "Common");
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\Common.xproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region project.json
				sb1.AppendFormat(CONST.Common_project_json);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Common\project.json"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#endregion
			}

			string PSqlHelperMapTypeGlobally = "";

			#region �����Զ���ö�� _Enum.cs
			List<string> owners = new List<string>();
			foreach (TableInfo t in _tables) {
				string ow = string.IsNullOrEmpty(t.Owner) ? "public" : t.Owner;
				if (!owners.Contains(ow)) owners.Add(ow);
			}
			string sql = string.Format(@"
select
ns.nspname || '.' || a.typname,
b.enumlabel
from pg_type a
inner join pg_enum b on b.enumtypid = a.oid
inner join pg_namespace ns on ns.oid = a.typnamespace
where a.typtype = 'e' and ns.nspname in ('{0}')", string.Join("','", owners.ToArray()));
			DataSet ds = this.GetDataSet(sql);
			Dictionary<string, string>  _types = new Dictionary<string, string>();
			int unknow_idx = 0;
			foreach (DataRow dr in ds.Tables[0].Rows) {
				string dr1 = string.Concat(dr[0]);
				string dr2 = string.Concat(dr[1]);
				dr1 = UFString(dr1.StartsWith("public.") ? dr1.Substring(7) : dr1.Replace(".", "_"));
				bool isFirst = !_types.ContainsKey(dr1);
				if (isFirst) _types.Add(dr1, "");

				string str2 = UFString(dr2);
				if (Regex.IsMatch(str2, @"^[\u0391-\uFFE5a-zA-Z_\$][\u0391-\uFFE5a-zA-Z_\$\d]*$"))
					_types[dr1] += ", " + str2;
				else
					_types[dr1] += string.Format(@", 
		/// <summary>
		/// {0}
		/// </summary>
		[PgName(""{0}"")]
		Unknow{1}", str2.Replace("\"", "\\\""), ++unknow_idx);

				if (isFirst) {
					_types[dr1] += " = 1";
					PSqlHelperMapTypeGlobally += string.Format(@"
			NpgsqlConnection.MapEnumGlobally<Model.{0}ENUM>(""{1}"");", dr1, dr[0]);
				}
			}
			string code = string.Format(@"using System;

namespace {0}.Model {{
", solutionName);
			foreach (string xxx in _types.Keys) {
				code += string.Format(@"
	public enum {0}ENUM {{
		{1}
	}}", xxx, _types[xxx].Substring(2).TrimStart('\r', '\n', '\t'));
			}
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\_Enum.cs"), Deflate.Compress(code + "\r\n}")));
			#endregion

			#region �����Զ���ģ�� _Composite.cs
			sql = string.Format(@"
select
ns.nspname || '.' || a.typname,
c.attname,
d.typname,
d.typtype,
c.attndims,
ns2.nspname
from pg_type a
inner join pg_class b on b.reltype = a.oid and b.relkind = 'c'
inner join pg_attribute c on c.attrelid = b.oid and c.attnum > 0
inner join pg_type d on d.oid = c.atttypid
inner join pg_namespace ns on ns.oid = a.typnamespace
left join pg_namespace ns2 on ns2.oid = d.typnamespace
where ns.nspname in ('{0}')", string.Join("','", owners.ToArray()));
			ds = this.GetDataSet(sql);
			_types = new Dictionary<string, string>();
			foreach (DataRow dr in ds.Tables[0].Rows) {
				string dr1 = string.Concat(dr[0]);
				string dr2 = string.Concat(dr[1]);
				string type = string.Concat(dr[2]);
				string typ = string.Concat(dr[3]);
				int attndims;
				int.TryParse(string.Concat(dr[4]), out attndims);
				if (type.StartsWith("_")) {
					type = type.Substring(1);
					if (attndims == 0) attndims++;
				}
				string dr5 = string.Concat(dr[5]);
				string enumType = UFString(dr5 == "public" ? type : (dr5 + "_" + type));
				if (typ == "c") enumType += "TYPE";
				if (typ == "e") enumType += "ENUM";
				dr1 = UFString(dr1.StartsWith("public.") ? dr1.Substring(7) : dr1.Replace(".", "_"));
				bool isFirst = !_types.ContainsKey(dr1);
				if (isFirst) _types.Add(dr1, "");

				_types[dr1] += string.Format(@"
		[JsonProperty] public {0} {1} {{ get; set; }}", GetCSType(GetDBType(type, typ), attndims, enumType), UFString(dr2));

				if (isFirst) {
					PSqlHelperMapTypeGlobally += string.Format(@"
			NpgsqlConnection.MapCompositeGlobally<Model.{0}TYPE>(""{1}"");", dr1, dr[0]);
				}
			}
			code = string.Format(@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using NpgsqlTypes;

namespace {0}.Model {{
", solutionName);
			foreach (string xxx in _types.Keys) {
				code += string.Format(@"
	[JsonObject(MemberSerialization.OptIn)]
	public partial struct {0}TYPE {{{1}
	}}", xxx, _types[xxx]);
			}
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\_Composite.cs"), Deflate.Compress(code + "\r\n}")));
			#endregion

			foreach (TableInfo table in _tables) {
				if (table.IsOutput == false) continue;
				if (table.Type == "P") continue;

				//if (table.Uniques.Count == 0)
				//	throw new Exception("��鵽�� ��" + table.Owner + "." + table.Name + "�� û���趨Ωһ����");
				if (table.Columns.Count == 0) continue;

				#region commom variable define
				string uClass_Name = CodeBuild.UFString(table.ClassName);
				string nClass_Name = table.ClassName;
				string nTable_Name = string.Concat(string.IsNullOrEmpty(table.Owner) ? string.Empty : string.Concat(@"""""", table.Owner, @"""""."), @"""""", table.Name, @"""""");
				string Class_Name_BLL_Full = string.Format(@"{0}.BLL.{1}", solutionName, uClass_Name);
				string Class_Name_Model_Full = string.Format(@"{0}.Model.{1}", solutionName, uClass_Name);

				string pkCsParam = "";
				string pkCsParamNoType = "";
				string pkCsParamNoTypeByval = "";
				string pkSqlParamFormat = "";
				string pkSqlParam = "";
				string pkEvalsQuerystring = "";
				string CsParam1 = "";
				string CsParamNoType1 = "";
				string CsParam2 = "";
				string CsParamNoType2 = "";
				string csItemAllFieldCopy = "";
				string pkMvcRoute = "";
				string orderBy = table.Clustereds.Count > 0 ?
					string.Join(", ", table.Clustereds.ConvertAll<string>(delegate (ColumnInfo cli) {
						return @"a.""""" + cli.Name + @"""""" + (cli.Orderby == DataSort.ASC ? string.Empty : string.Concat(" ", cli.Orderby));
					}).ToArray()) :
						table.Uniques.Count > 0 ?
							string.Join(", ", table.Uniques[0].ConvertAll<string>(delegate (ColumnInfo cli) {
								return @"a.""""" + cli.Name + @"""""" + (cli.Orderby == DataSort.ASC ? string.Empty : string.Concat(" ", cli.Orderby));
							}).ToArray()) : "";

				int pkSqlParamFormat_idx = -1;
				if (table.PrimaryKeys.Count > 0) {
					foreach (ColumnInfo columnInfo in table.PrimaryKeys) {
						pkCsParam += columnInfo.CsType + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
						pkCsParamNoType += CodeBuild.UFString(columnInfo.Name) + ", ";
						pkCsParamNoTypeByval += string.Format(GetCSTypeValue(columnInfo.Type), CodeBuild.UFString(columnInfo.Name)) + ", ";
						pkSqlParamFormat += @"""""" + columnInfo.Name + @""""" = {" + ++pkSqlParamFormat_idx + "} AND ";
						pkSqlParam += @"""""" + columnInfo.Name + @""""" = ?" + columnInfo.Name + " AND ";
						pkEvalsQuerystring += string.Format("{0}=<%# Eval(\"{0}\") %>&", CodeBuild.UFString(columnInfo.Name));
						pkMvcRoute += "{" + CodeBuild.UFString(columnInfo.Name) + "}/";
					}
					pkCsParam = pkCsParam.Substring(0, pkCsParam.Length - 2);
					pkCsParamNoType = pkCsParamNoType.Substring(0, pkCsParamNoType.Length - 2);
					pkCsParamNoTypeByval = pkCsParamNoTypeByval.Substring(0, pkCsParamNoTypeByval.Length - 2);
					pkSqlParamFormat = pkSqlParamFormat.Substring(0, pkSqlParamFormat.Length - 5);
					pkSqlParam = pkSqlParam.Substring(0, pkSqlParam.Length - 5);
					pkEvalsQuerystring = pkEvalsQuerystring.Substring(0, pkEvalsQuerystring.Length - 1);
				}
				foreach (ColumnInfo columnInfo in table.Columns) {
					CsParam1 += columnInfo.CsType + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
					CsParamNoType1 += CodeBuild.UFString(columnInfo.Name) + ", ";
					csItemAllFieldCopy += string.Format(@"
			item.{0} = newitem.{0};", UFString(columnInfo.Name));
					if (columnInfo.IsIdentity) {
						//CsParamNoType2 += "0, ";
					} else {
						CsParam2 += columnInfo.CsType + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
						CsParamNoType2 += string.Format("\r\n				{0} = {0}, ", CodeBuild.UFString(columnInfo.Name));
					}
				}
				CsParam1 = CsParam1.Substring(0, CsParam1.Length - 2);
				CsParamNoType1 = CsParamNoType1.Substring(0, CsParamNoType1.Length - 2);
				if (CsParam2.Length > 0) CsParam2 = CsParam2.Substring(0, CsParam2.Length - 2);
				if (CsParamNoType2.Length > 0) CsParamNoType2 = CsParamNoType2.Substring(0, CsParamNoType2.Length - 2);
				#endregion

				#region Model *.cs
				sb1.AppendFormat(
	@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NpgsqlTypes;
using {0}.BLL;

namespace {0}.Model {{
	[JsonObject(MemberSerialization.OptIn)]
	public partial class {1}Info {{
		#region fields
", solutionName, uClass_Name);
				bool Is_System_ComponentModel = false;
				int column_idx = -1;
				foreach (ColumnInfo column in table.Columns) {
					column_idx++;
					string csType = column.CsType;
					string nColumn_Name = column.Name;
					string uColumn_Name = CodeBuild.UFString(column.Name);
					string comment = _column_coments[table.FullName][column.Name];
					string prototype_comment = comment == column.Name ? "" : string.Format(@"/// <summary>
		/// {0}
		/// </summary>
		", comment);

					sb1.AppendFormat(
	@"		private {0} _{1};
", csType, uColumn_Name);

					string tmpinfo = string.Empty;
					List<string> tsvarr = new List<string>();
					List<ForeignKeyInfo> fks = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk) {
						int fkc1idx = 0;
						string fkcsBy = "By";
						string fkcsParms = string.Empty;
						string fkcsIfNull = string.Empty;
						ColumnInfo fkc = fk.Columns.Find(delegate (ColumnInfo c1) {
							fkc1idx++;
							fkcsParms += string.Format(GetCSTypeValue(c1.Type), "_" + CodeBuild.UFString(c1.Name)) + ", ";
							fkcsIfNull += " && _" + CodeBuild.UFString(c1.Name) + " != null";
							return c1.Name == column.Name;
						});
						if (fk.ReferencedTable != null) {
							fk.ReferencedColumns.ForEach(delegate (ColumnInfo c1) {
								fkcsBy += CodeBuild.UFString(c1.Name) + "And";
							});
						} else {
							fk.ReferencedColumnNames.ForEach(delegate (string c1) {
								fkcsBy += CodeBuild.UFString(c1) + "And";
							});
						}
						if (fkc == null) return false;
						string FK_uClass_Name = fk.ReferencedTable != null ? CodeBuild.UFString(fk.ReferencedTable.ClassName) :
							CodeBuild.UFString(TableInfo.GetClassName(fk.ReferencedTableName));
						string FK_uClass_Name_full = fk.ReferencedTable != null ? FK_uClass_Name :
							string.Format(@"{0}.Model.{1}", solutionName, FK_uClass_Name);
						string FK_uEntry_Name = fk.ReferencedTable != null ? CodeBuild.GetCSName(fk.ReferencedTable.Name) :
							CodeBuild.GetCSName(TableInfo.GetEntryName(fk.ReferencedTableName));
						string tableNamefe3 = fk.ReferencedTable != null ? fk.ReferencedTable.Name : FK_uEntry_Name;
						string memberName = fk.Columns[0].Name.IndexOf(tableNamefe3) == -1 ? CodeBuild.LFString(tableNamefe3) :
							(CodeBuild.LFString(fk.Columns[0].Name.Substring(0, fk.Columns[0].Name.IndexOf(tableNamefe3)) + tableNamefe3));
						if (fk.Columns[0].Name.IndexOf(tableNamefe3) == 0 && fk.ReferencedTable != null) memberName = CodeBuild.LFString(fk.ReferencedTable.ClassName);

						tsvarr.Add(string.Format(@"_obj_{0} = null;", memberName));
						if (fkc1idx == fk.Columns.Count) {
							fkcsBy = fkcsBy.Remove(fkcsBy.Length - 3);
							fkcsParms = fkcsParms.Remove(fkcsParms.Length - 2);
							if (fk.ReferencedColumns.Count > 0 && fk.ReferencedColumns[0].IsPrimaryKey ||
								fk.ReferencedTable == null && fk.ReferencedIsPrimaryKey) {
								fkcsBy = string.Empty;
							}
							sb1.AppendFormat(
		@"		private {0}Info _obj_{1};
", FK_uClass_Name_full, memberName);
							tmpinfo += string.Format(
		@"		public {0}Info Obj_{1} {{
			get {{
				if (_obj_{1} == null{6}) _obj_{1} = {5}.GetItem{3}({4});
				return _obj_{1};
			}}
			internal set {{ _obj_{1} = value; }}
		}}
", FK_uClass_Name_full, memberName, solutionName, fkcsBy, fkcsParms, FK_uClass_Name, fkcsIfNull);
						}
						return fkc != null;
					});
					string JsonConverter = "";
					#region JsonConverter
					bool isJsonConverter = csType.Contains("BitArray") ||

						csType.Contains("NpgsqlPoint") ||
						csType.Contains("NpgsqlLine") ||
						csType.Contains("NpgsqlLSeg") ||
						csType.Contains("NpgsqlBox") ||
						csType.Contains("NpgsqlPath") ||
						csType.Contains("NpgsqlPolygon") ||
						csType.Contains("NpgsqlCircle") ||

						csType.Contains("NpgsqlInet") ||
						csType.Contains("IPAddress") ||
						csType.Contains("PhysicalAddress") ||

						csType.Contains("NpgsqlRange<int>") ||
						csType.Contains("NpgsqlRange<long>") ||
						csType.Contains("NpgsqlRange<decimal>") ||
						csType.Contains("NpgsqlRange<DateTime>");
					if (isJsonConverter)
						JsonConverter = "[JsonConverter(typeof(NpgsqlTypesConverter))]\r\n		";
					#endregion

					if (fks.Count > 0) {
						string tmpsetvalue = string.Format(
@"		{2}{3}[JsonProperty] public {0} {1} {{
			get {{ return _{1}; }}
			set {{
				if (_{1} != value) ", csType, uColumn_Name, prototype_comment, JsonConverter);
						string tsvstr = string.Join(@"
					", tsvarr.ToArray());
						if (fks.Count > 1) {
							tmpsetvalue += string.Format(@"{{
					{0}
				}}", tsvstr);
						} else {
							tmpsetvalue += tsvstr;
						}
						tmpsetvalue += string.Format(@"
				_{0} = value;
			}}
		}}
", uColumn_Name);
						sb2.Append(tmpsetvalue);
						sb2.Append(tmpinfo);
					} else {
						sb2.AppendFormat(
@"		{2}{3}[JsonProperty] public {0} {1} {{
			get {{ return _{1}; }}
			set {{ _{1} = value; }}
		}}
", csType, uColumn_Name, prototype_comment, JsonConverter);
					}
					sb3.AppendFormat("{0} {1}, ", csType, uColumn_Name);
					sb4.AppendFormat(
	@"			_{0} = {0};
", uColumn_Name);
					sb5.AppendFormat(@"
				__jsonIgnore.ContainsKey(""{0}"") ? string.Empty : string.Format("",{0}:{{0}}"", {1}),", uColumn_Name, CodeBuild.GetToStringFieldConcat(column, uClass_Name + column.Name.ToUpper()));

					sb10.AppendFormat(@"
			if (allField || !__jsonIgnore.ContainsKey(""{0}"")) ht[""{0}""] = {1};", uColumn_Name,
						csType.Contains("NpgsqlInet") ||
						csType.Contains("IPAddress") ||
						csType.Contains("PhysicalAddress") ? column.Attndims > 0 ?
							string.Format("NpgsqlTypesConverter.GetJObject({0}, new int[{1}], 0)", "_" + uColumn_Name, column.Attndims) :
							"_" + uColumn_Name + "?.ToString()" : ("_" + uColumn_Name));
					sb7.AppendFormat(@"
				{0}, ""|"",", GetToStringStringify(column));
					//		sb8.AppendFormat(@"
					//if (string.Compare(""null"", ret[{2}]) != 0) _{0} = {1};",
					//			uColumn_Name, string.Format(CodeBuild.GetStringifyParse(column.Type, column.CsType), "ret[" + column_idx + "]"), column_idx);
					sb8.AppendFormat(@"
			if (ht[""{0}""] != null) _{0} = {1};",
						uColumn_Name, string.Format(CodeBuild.GetObjectConvertToCsTypeMethod(column.Type, column.CsType), "ht[\"" + uColumn_Name + "\"]"));
				}

				if (sb2.Length != 0) {
					sb2.Remove(sb2.Length - 2, 2);
					sb3.Remove(sb3.Length - 2, 2);
					sb5.Remove(sb5.Length - 1, 1);
					sb7.Remove(sb7.Length - 6, 6);
				}

				Dictionary<string, string> dic_objs = new Dictionary<string, string>();
				// m -> n
				_tables.ForEach(delegate (TableInfo t2) {
					if (t2.ForeignKeys.Count > 2) {
						foreach (TableInfo t3 in _tables) {
							if (t3.FullName == t2.FullName) continue;
							ForeignKeyInfo fk3 = t3.ForeignKeys.Find(delegate (ForeignKeyInfo ffk3) {
								return ffk3.ReferencedTable.FullName == t2.FullName;
							});
							if (fk3 != null) {
								if (fk3.Columns[0].IsPrimaryKey) return;
							}
						}
					}
					ForeignKeyInfo fk_Common = null;
					ForeignKeyInfo fk = t2.ForeignKeys.Find(delegate (ForeignKeyInfo ffk) {
						if (ffk.ReferencedTable.FullName == table.FullName/* && 
							ffk.Table.FullName != table.FullName*/) { //ע����������Ϊ������ parent_id �� obj ����
							fk_Common = ffk;
							return true;
						}
						return false;
					});
					if (fk == null) return;
					//if (fk.Table.FullName == table.FullName) return; //ע����������Ϊ������ parent_id �� obj ����
					List<ForeignKeyInfo> fk2 = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk2) {
						return ffk2 != fk;
					});
					// 1 -> 1
					ForeignKeyInfo fk1v1 = table.ForeignKeys.Find(delegate (ForeignKeyInfo ffk2) {
						return ffk2.ReferencedTable.FullName == t2.FullName
							&& ffk2.ReferencedColumns[0].IsPrimaryKey && ffk2.Columns[0].IsPrimaryKey; //��������Ϊ������ parent_id �� obj ����
					});
					if (fk1v1 != null) return;

					//t2.Columns
					string t2name = t2.Name;
					string tablename = table.Name;
					string addname = t2name;
					if (t2name.StartsWith(tablename + "_")) {
						addname = t2name.Substring(tablename.Length + 1);
					} else if (t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(addname.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(t2name.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + fk2[0].ReferencedTable.Name)) {
						addname = t2name;
					}

					string parms1 = "";
					string parmsNoneType1 = "";
					string parms2 = "";
					string parmsNoneType2 = "";
					string parms3 = "";
					string parmsNoneType3 = "";
					string parms4 = "";
					string parmsNoneType4 = "";
					string parmsNoneType5 = "";
					string pkNamesNoneType = "";
					string updateDiySet = "";
					string add_or_flag = "Add";
					int ms = 0;
					foreach (ColumnInfo columnInfo in t2.Columns) {
						if (columnInfo.Name == fk.Columns[0].Name) {
							parmsNoneType2 += string.Format("\r\n			{0} = this.{1}, ", CodeBuild.UFString(columnInfo.Name), CodeBuild.UFString(table.PrimaryKeys[0].Name));
							parmsNoneType4 += string.Format(GetCSTypeValue(columnInfo.Type), "this." + CodeBuild.UFString(table.PrimaryKeys[0].Name)) + ", ";
							parmsNoneType5 += string.Format("\r\n			item.{0} = this.{1};", CodeBuild.UFString(columnInfo.Name), CodeBuild.UFString(table.PrimaryKeys[0].Name));
							if (columnInfo.IsPrimaryKey) pkNamesNoneType += string.Format(GetCSTypeValue(table.PrimaryKeys[0].Type), "this." + CodeBuild.UFString(table.PrimaryKeys[0].Name)) + ", ";
							//"this." + CodeBuild.UFString(table.PrimaryKeys[0].Name) + ", ";
							continue;
						}
						if (columnInfo.IsPrimaryKey) pkNamesNoneType += string.Format(GetCSTypeValue(columnInfo.Type), CodeBuild.UFString(columnInfo.Name)) + ", ";
						//CodeBuild.UFString(columnInfo.Name) + ", ";
						else updateDiySet += string.Format("\r\n\t\t\t\t\t.Set{0}({0})", CodeBuild.UFString(columnInfo.Name));

						if (columnInfo.IsIdentity) {
							//parmsNoneType2 += "0, ";
							continue;
						}
						parms2 += columnInfo.CsType + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
						parmsNoneType2 += string.Format("\r\n			{0} = {0}, ", CodeBuild.UFString(columnInfo.Name));

						ForeignKeyInfo fkk3 = t2.ForeignKeys.Find(delegate (ForeignKeyInfo fkk33) {
							return fkk33.Columns[0].Name == columnInfo.Name;
						});
						if (fkk3 == null) {
							parms1 += columnInfo.CsType + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
							parmsNoneType1 += CodeBuild.UFString(columnInfo.Name) + ", ";
						} else {
							string fkk3_ReferencedTable_ObjName = fkk3.ReferencedTable.Name;
							string endStr = "_" + fkk3.ReferencedTable.Name + "_" + fkk3.ReferencedColumns[0].Name;
							if (columnInfo.Name.EndsWith(endStr))
								fkk3_ReferencedTable_ObjName = columnInfo.Name.Remove(columnInfo.Name.Length - fkk3.ReferencedColumns[0].Name.Length - 1);

							fkk3_ReferencedTable_ObjName = CodeBuild.UFString(fkk3_ReferencedTable_ObjName);
							parms1 += CodeBuild.UFString(fkk3.ReferencedTable.ClassName) + "Info " + fkk3_ReferencedTable_ObjName + ", ";
							parmsNoneType1 += fkk3_ReferencedTable_ObjName + "." + CodeBuild.UFString(fkk3.ReferencedColumns[0].Name) + ", ";
							parms3 += CodeBuild.UFString(fkk3.ReferencedTable.ClassName) + "Info " + fkk3_ReferencedTable_ObjName + ", ";
							parmsNoneType3 += fkk3_ReferencedTable_ObjName + "." + CodeBuild.UFString(fkk3.ReferencedColumns[0].Name) + ", ";

							parms4 += columnInfo.CsType + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
							parmsNoneType4 += string.Format(GetCSTypeValue(columnInfo.Type), CodeBuild.UFString(columnInfo.Name)) + ", ";
							//CodeBuild.UFString(columnInfo.Name) + " ?? default(" + columnInfo.CsType.Replace("?", "") + "), ";
							if (add_or_flag != "Flag" && fk.Columns[0].IsPrimaryKey) //�м���ϵ��������Ϊ����
								t2.Uniques.ForEach(delegate (List<ColumnInfo> cs) {
									if (cs.Count < 2) return;
									ms = 0;
									foreach (ColumnInfo c in cs) {
										if (t2.ForeignKeys.Find(delegate (ForeignKeyInfo ffkk2) {
											return ffkk2.Columns[0].Name == c.Name;
										}) != null) ms++;
									}
									if (ms == cs.Count) {
										add_or_flag = "Flag";
									}
								});
						}
					}
					if (parms1.Length > 0) parms1 = parms1.Remove(parms1.Length - 2);
					if (parmsNoneType1.Length > 0) parmsNoneType1 = parmsNoneType1.Remove(parmsNoneType1.Length - 2);
					if (parms2.Length > 0) parms2 = parms2.Remove(parms2.Length - 2);
					if (parmsNoneType2.Length > 0) parmsNoneType2 = parmsNoneType2.Remove(parmsNoneType2.Length - 2);
					if (parms3.Length > 0) parms3 = parms3.Remove(parms3.Length - 2);
					if (parmsNoneType3.Length > 0) parmsNoneType3 = parmsNoneType3.Remove(parmsNoneType3.Length - 2);
					if (parms4.Length > 0) parms4 = parms4.Remove(parms4.Length - 2);
					if (parmsNoneType4.Length > 0) parmsNoneType4 = parmsNoneType4.Remove(parmsNoneType4.Length - 2);
					if (pkNamesNoneType.Length > 0) pkNamesNoneType = pkNamesNoneType.Remove(pkNamesNoneType.Length - 2);

					if (add_or_flag == "Flag") {
						if (parms1 != parms2)
							sb6.AppendFormat(@"
		public {0}Info Flag{1}({2}) => Flag{1}({3});", CodeBuild.UFString(t2.ClassName), CodeBuild.UFString(addname), parms1, parmsNoneType1);
						sb6.AppendFormat(@"
		public {0}Info Flag{1}({2}) {{
			{0}Info item = {0}.GetItem({5});
			if (item == null) item = {0}.Insert(new {0}Info {{{3}}});{6}
			return item;
		}}
", CodeBuild.UFString(t2.ClassName), CodeBuild.UFString(addname), parms2, parmsNoneType2, solutionName, pkNamesNoneType, updateDiySet.Length > 0 ? "\r\n\t\t\telse item.UpdateDiy" + updateDiySet + ".ExecuteNonQuery();" : string.Empty);
					} else {
						if (parms1 != parms2)
							sb6.AppendFormat(@"
		public {0}Info Add{1}({2}) => Add{1}({3});", CodeBuild.UFString(t2.ClassName), CodeBuild.UFString(addname), parms1, parmsNoneType1);
						sb6.AppendFormat(@"
		public {0}Info Add{1}({2}) => {0}.Insert(new {0}Info {{{3}}});
		public {0}Info Add{1}({0}Info item) {{{5}
			return item.Save();
		}}
", CodeBuild.UFString(t2.ClassName), CodeBuild.UFString(addname), parms2, parmsNoneType2, solutionName, parmsNoneType5);
					}

					if (add_or_flag == "Flag") {
						string deleteByUniqui = string.Empty;
						for (int deleteByUniqui_a = 0; deleteByUniqui_a < fk.Table.Uniques.Count; deleteByUniqui_a++)
							if (fk.Table.Uniques[deleteByUniqui_a].Count > 1 && fk.Table.Uniques[deleteByUniqui_a][0].IsPrimaryKey == false) {
								foreach (ColumnInfo deleteByuniquiCol in fk.Table.Uniques[deleteByUniqui_a])
									deleteByUniqui = deleteByUniqui + "And" + CodeBuild.UFString(deleteByuniquiCol.Name);
								deleteByUniqui = "By" + deleteByUniqui.Substring(3);
								break;
							}
						sb6.AppendFormat(@"
		public int Unflag{1}({2}) => Unflag{1}({3});
		public int Unflag{1}({4}) => {0}.Delete{9}({5});
		public int Unflag{1}ALL() => {0}.DeleteBy{8}(this.{7});
", CodeBuild.UFString(t2.ClassName), CodeBuild.UFString(addname), parms3, parmsNoneType3, parms4, parmsNoneType4,
	solutionName, string.Format(GetCSTypeValue(table.PrimaryKeys[0].Type), CodeBuild.UFString(table.PrimaryKeys[0].Name)),
							CodeBuild.UFString(fk.Columns[0].Name), deleteByUniqui);
						if (ms > 2) {

						} else {
							string civ = string.Format(GetCSTypeValue(table.PrimaryKeys[0].Type), "_" + CodeBuild.UFString(table.PrimaryKeys[0].Name));
							string f5 = t2name;
							//if (addname != f5) {
							string fk20_ReferencedTable_Name = fk2[0].ReferencedTable.Name;
							string fk_ReferencedTable_Name = fk.ReferencedTable.Name;
							if (f5.StartsWith(fk20_ReferencedTable_Name + "_"))
								f5 = f5.Substring(fk20_ReferencedTable_Name.Length + 1);
							else if (f5.EndsWith("_" + fk20_ReferencedTable_Name))
								f5 = f5.Remove(f5.Length - fk20_ReferencedTable_Name.Length - 1);
							else if (string.Compare(t2name, fk20_ReferencedTable_Name + "_" + fk_ReferencedTable_Name) != 0 &&
								string.Compare(t2name, fk_ReferencedTable_Name + "_" + fk20_ReferencedTable_Name) != 0)
								f5 = t2name;
							//}
							string objs_value = string.Format(@"
		private List<{0}Info> _obj_{1}s;
		public List<{0}Info> Obj_{1}s {{
			get {{
				if (_obj_{1}s == null) _obj_{1}s = {0}.SelectBy{5}_{4}({3}).ToList();
				return _obj_{1}s;
			}}
		}}", CodeBuild.UFString(fk2[0].ReferencedTable.ClassName), CodeBuild.LFString(addname), solutionName, civ, table.PrimaryKeys[0].Name, CodeBuild.UFString(f5));
							//����м���ֶ� > 2����ôӦ�ð����м��Ҳ��ѯ����
							if (t2.Columns.Count > 2) {
								string _f6 = fk.Columns[0].Name;
								string _f7 = fk.ReferencedTable.PrimaryKeys[0].Name;
								string _f8 = fk2[0].Columns[0].Name;
								string _f9 = fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", "");

								if (fk.ReferencedTable.ClassName == fk2[0].ReferencedTable.ClassName) {
									_f6 = fk2[0].Columns[0].Name;
									_f7 = fk2[0].ReferencedTable.PrimaryKeys[0].Name;
									_f8 = fk.Columns[0].Name;
									_f9 = fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", "");
								}

								objs_value = string.Format(@"
		public {2}Info Obj_{3} {{ set; get; }}
		private List<{0}Info> _obj_{1}s;
		/// <summary>
		/// ����ʱ����ͨ�� Obj_{3} �ɻ�ȡ�м������
		/// </summary>
		public List<{0}Info> Obj_{1}s {{
			get {{
				if (_obj_{1}s == null) _obj_{1}s = {0}.Select.InnerJoin<{2}>(""b"", @""b.""""{6}"""" = a.""""{5}"""""").Where(@""b.""""{4}"""" = {{0}}"", {7}).ToList();
				return _obj_{1}s;
			}}
		}}", CodeBuild.UFString(fk2[0].ReferencedTable.ClassName), CodeBuild.LFString(addname), CodeBuild.UFString(t2.ClassName), CodeBuild.LFString(t2.ClassName),
			_f6, _f7, _f8, civ);
							}
							string objs_key = string.Format("Obj_{0}s", CodeBuild.LFString(addname));
							if (dic_objs.ContainsKey(objs_key))
								dic_objs[objs_key] = objs_value;
							else
								dic_objs.Add(objs_key, objs_value);
						}
					} else {
						string f2 = fk.Columns[0].Name.CompareTo("parent_id") == 0 ? t2name : fk.Columns[0].Name.Replace(tablename + "_" + table.PrimaryKeys[0].Name, "") + CodeBuild.LFString(t2name);
						string objs_value = string.Format(@"
		private List<{0}Info> _obj_{1}s;
		public List<{0}Info> Obj_{1}s {{
			get {{
				if (_obj_{1}s == null) _obj_{1}s = {0}.SelectBy{3}(_{4}).Limit(500).ToList();
				return _obj_{1}s;
			}}
		}}", CodeBuild.UFString(t2.ClassName), f2, solutionName, CodeBuild.UFString(fk.Columns[0].Name), CodeBuild.UFString(table.PrimaryKeys[0].Name));
						string objs_key = string.Format("Obj_{0}s", f2);
						if (!dic_objs.ContainsKey(objs_key))
							dic_objs.Add(objs_key, objs_value);
					}
				});
				string[] dic_objs_values = new string[dic_objs.Count];
				dic_objs.Values.CopyTo(dic_objs_values, 0);
				sb9.Append(string.Join("", dic_objs_values));

				if (table.PrimaryKeys.Count > 0) {
					if (table.Columns.Count > table.PrimaryKeys.Count) {
						ColumnInfo colUpdateTime = table.Columns.Find(delegate (ColumnInfo fcc) { return fcc.Name.ToLower() == "update_time" || fcc.CsType == "DateTime"; });
						ColumnInfo colCreateTime = table.Columns.Find(delegate (ColumnInfo fcc) { return fcc.Name.ToLower() == "create_time" || fcc.CsType == "DateTime"; });
						sb6.Insert(0, string.Format(@"
		public {1}Info Save() {{{2}
			if (this.{4} != null) {{
				{1}.Update(this);
				return this;
			}}{3}
			return {1}.Insert(this);
		}}", solutionName, uClass_Name, colUpdateTime != null ? @"
			this." + UFString(colUpdateTime.Name) + " = DateTime.Now;" : "", colCreateTime != null ? @"
			this." + UFString(colCreateTime.Name) + " = DateTime.Now;" : "", pkCsParamNoType.Replace(", ", " != null && this.")));
					}
					sb6.Insert(0, string.Format(@"
		public {0}.DAL.{1}.SqlUpdateBuild UpdateDiy {{
			get {{ return {1}.UpdateDiy(this, _{2}); }}
		}}", solutionName, uClass_Name, pkCsParamNoTypeByval.Replace(", ", ", _")));
				}

				sb1.AppendFormat(
	@"		#endregion

		public {0}Info() {{ }}", uClass_Name);

				sb1.AppendFormat(@"
{1}{2}
		#region ���л��������л�
		public string Stringify() => JsonConvert.SerializeObject(this);
		public static {0}Info Parse(string stringify) {{
			if (string.IsNullOrEmpty(stringify)) return null;
			return JsonConvert.DeserializeObject<{0}Info>(stringify);
		}}
		#endregion

		#region override
		private static Lazy<Dictionary<string, bool>> __jsonIgnoreLazy = new Lazy<Dictionary<string, bool>>(() => {{
			FieldInfo field = typeof({0}Info).GetField(""JsonIgnore"");
			Dictionary<string, bool> ret = new Dictionary<string, bool>();
			if (field != null) string.Concat(field.GetValue(null)).Split(',').ToList().ForEach(f => {{
				if (!string.IsNullOrEmpty(f)) ret[f] = true;
			}});
			return ret;
		}});
		private static Dictionary<string, bool> __jsonIgnore => __jsonIgnoreLazy.Value;
		public override string ToString() => JsonConvert.SerializeObject(this.ToBson());
		public IDictionary ToBson(bool allField = false) {{
			IDictionary ht = new Hashtable();{10}
			return ht;
		}}
		{12}public object this[string key] {{
		{12}	get {{ return this.GetType().GetProperty(key).GetValue(this); }}
		{12}	set {{ this.GetType().GetProperty(key).SetValue(this, value); }}
		{12}}}
		#endregion

		#region properties
{4}{9}
		#endregion
{5}
	}}{11}
}}

", uClass_Name, "", "", sb5.ToString(), sb2.ToString(), sb6.ToString(), table.Columns.Count, sb7.ToString(), sb8.ToString(), sb9.ToString(), sb10.ToString(), sb16.ToString(), 
	table.Columns.Find(delegate(ColumnInfo fccc) {
		return fccc.Name.ToLower() == "item";
	}) == null ? "" : "//");

				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\", uClass_Name, "Info.cs"), Deflate.Compress(Is_System_ComponentModel ? sb1.ToString().Replace("using System.Reflection;", "using System.ComponentModel;\r\nusing System.Reflection;") : sb1.ToString())));
				clearSb();

				Model_Build__ExtensionMethods_cs.AppendFormat(@"
		public static string ToJson(this {0}Info item) => string.Concat(item);
		public static string ToJson(this {0}Info[] items) => GetJson(items);
		public static string ToJson(this IEnumerable<{0}Info> items) => GetJson(items);
		public static IDictionary[] ToBson(this {0}Info[] items, Func<{0}Info, object> func = null) => GetBson(items, func);
		public static IDictionary[] ToBson(this IEnumerable<{0}Info> items, Func<{0}Info, object> func = null) => GetBson(items, func);
", uClass_Name);
				#endregion

				#region DAL *.cs

				#region use t-sql
				string sqlFields = "";
				string sqlDelete = string.Format("DELETE FROM {0} ", nTable_Name);
				string sqlUpdate = string.Format("UPDATE {0} SET ", nTable_Name);
				string sqlInsert = string.Format("INSERT INTO {0}(", nTable_Name);
				string temp1 = string.Empty;
				string temp2 = string.Empty;
				string temp3 = string.Empty;
				string temp4 = string.Empty;
				foreach (ColumnInfo columnInfo in table.Columns) {
					if (columnInfo.IsIdentity == false) {
						temp1 += string.Format(@"""""{0}"""" = @{0}, ", columnInfo.Name);
						temp2 += string.Format(@"""""{0}"""", ", columnInfo.Name);
						temp3 += string.Format("@{0}, ", columnInfo.Name);
					}
					temp4 += string.Format(@"a.""""{0}"""", ", columnInfo.Name);
				}
				if (temp1.Length > 0) {
					temp1 = temp1.Substring(0, temp1.Length - 2);
					temp2 = temp2.Substring(0, temp2.Length - 2);
					temp3 = temp3.Substring(0, temp3.Length - 2);
				}
				temp4 = temp4.Substring(0, temp4.Length - 2);
				sqlFields = temp4;
				sqlDelete += "WHERE ";
				sqlUpdate += temp1 + string.Format(" WHERE {0}", pkSqlParam);
				sqlInsert += string.Format("{0}) VALUES({1})", temp2, temp3);

				temp1 = "";
				temp2 = "";
				temp3 = "";
				temp4 = "";

				sb1.AppendFormat(
	@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using {0}.Model;

namespace {0}.DAL {{

	public partial class {1} : IDAL {{
		#region transact-sql define
		public string Table {{ get {{ return TSQL.Table; }} }}
		public string Field {{ get {{ return TSQL.Field; }} }}
		public string Sort {{ get {{ return TSQL.Sort; }} }}
		internal class TSQL {{
			internal static readonly string Table = @""{3}"";
			internal static readonly string Field = @""{5}"";
			internal static readonly string Sort = @""{6}"";
			internal static readonly string Returning = @"" RETURNING "" + Field.Replace(@""a."""""", @"""""""");
			public static readonly string Delete = @""DELETE FROM {3} WHERE "";
			public static readonly string Insert = @""{2}{4}"" + Returning;
		}}
		#endregion

		#region common call
		protected static NpgsqlParameter[] GetParameters({1}Info item) {{
			return new NpgsqlParameter[] {{
{7}
			}};
		}}", solutionName, uClass_Name, string.Empty, nTable_Name, sqlInsert, sqlFields, orderBy, CodeBuild.AppendParameters(table, "				"));

				sb1.AppendFormat(@"
		public {0}Info GetItem(NpgsqlDataReader dr) {{
			int index = -1;
			return GetItem(dr, ref index) as {0}Info;
		}}
		public object GetItem(NpgsqlDataReader dr, ref int index) {{
			{0}Info item = new {0}Info();", uClass_Name);

				foreach (ColumnInfo columnInfo in table.Columns)
					sb1.AppendFormat(@"
			if (!dr.IsDBNull(++index)) item.{0} = {1};", CodeBuild.UFString(columnInfo.Name), CodeBuild.GetDataReaderMethod(columnInfo.Type, columnInfo.CsType));

				sb1.AppendFormat(@"
			return item;
		}}");
				sb1.Append(sb4.ToString());
				sb1.AppendFormat(@"
		public SelectBuild<{0}Info> Select {{
			get {{ return SelectBuild<{0}Info>.From(this, PSqlHelper.Instance); }}
		}}
		#endregion", uClass_Name, table.Columns.Count + 1);
				Dictionary<string, bool> del_exists = new Dictionary<string, bool>();
				foreach (List<ColumnInfo> cs in table.Uniques) {
					string parms = string.Empty;
					string parmsBy = "By";
					string sqlParms = string.Empty;
					string sqlParmsA = string.Empty;
					string sqlParmsANoneType = string.Empty;
					int sqlParmsAIndex = 0;
					foreach (ColumnInfo columnInfo in cs) {
						parms += columnInfo.CsType.Replace("?", "") + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
						parmsBy += CodeBuild.UFString(columnInfo.Name) + "And";
						sqlParms += @"""""" + columnInfo.Name + @""""" = @" + columnInfo.Name + " AND ";
						sqlParmsA += @"a.""""" + columnInfo.Name + @""""" = {" + sqlParmsAIndex++ + "} AND ";
						sqlParmsANoneType += CodeBuild.UFString(columnInfo.Name) + ", ";
					}
					parms = parms.Substring(0, parms.Length - 2);
					parmsBy = parmsBy.Substring(0, parmsBy.Length - 3);
					sqlParms = sqlParms.Substring(0, sqlParms.Length - 5);
					sqlParmsA = sqlParmsA.Substring(0, sqlParmsA.Length - 5);
					sqlParmsANoneType = sqlParmsANoneType.Substring(0, sqlParmsANoneType.Length - 2);
					if (del_exists.ContainsKey(parms)) continue;
					del_exists.Add(parms, true);
					sb2.AppendFormat(@"
		public int Delete{2}({0}) {{
			return PSqlHelper.ExecuteNonQuery(string.Concat(TSQL.Delete, @""{1}""), 
{3});
		}}", parms, sqlParms, cs[0].IsPrimaryKey ? string.Empty : parmsBy, CodeBuild.AppendParameters(cs, "				"));

					sb3.AppendFormat(@"
		public {0}Info GetItem{3}({1}) {{
			return this.Select.Where(@""{2}"", {4}).ToOne();
		}}", uClass_Name, parms, sqlParmsA, cs[0].IsPrimaryKey ? string.Empty : parmsBy, sqlParmsANoneType);
				}
				table.ForeignKeys.ForEach(delegate (ForeignKeyInfo fkk) {
					string parms = string.Empty;
					string parmsBy = "By";
					string sqlParms = string.Empty;
					foreach (ColumnInfo columnInfo in fkk.Columns) {
						parms += columnInfo.CsType.Replace("?", "") + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
						parmsBy += CodeBuild.UFString(columnInfo.Name) + "And";
						sqlParms += @"""""" + columnInfo.Name + @""""" = @" + columnInfo.Name + " AND ";
					}
					parms = parms.Substring(0, parms.Length - 2);
					parmsBy = parmsBy.Substring(0, parmsBy.Length - 3);
					sqlParms = sqlParms.Substring(0, sqlParms.Length - 5);
					if (del_exists.ContainsKey(parms)) return;
					del_exists.Add(parms, true);

					sb2.AppendFormat(@"
		public int Delete{2}({0}) {{
			return PSqlHelper.ExecuteNonQuery(string.Concat(TSQL.Delete, @""{1}""), 
{3});
		}}", parms, sqlParms, parmsBy, CodeBuild.AppendParameters(fkk.Columns, "				"));
				});

				if (table.PrimaryKeys.Count > 0) {
					#region ���û�������Ĵ���UpdateBuild
					foreach (ColumnInfo col in table.Columns) {
						if (col.IsIdentity ||
							col.IsPrimaryKey ||
							table.PrimaryKeys.FindIndex(delegate (ColumnInfo pkf) { return pkf.Name == col.Name; }) != -1) continue;
						string arrParm = "";
						string arrUnde = "";
						string arrUndeSql = "";
						string arrType = col.CsType;
						for (int a = 0; a < col.Attndims; a++) {
							arrParm += ", int " + (char)('i' + a);
							arrUnde += ", " + (char)('i' + a);
							arrUndeSql += ", {" + (char)('i' + a) + "}";
						}
						if (col.Attndims > 0) {
							arrUnde = "[{" + arrUnde.Substring(2) + "}]";
							arrUndeSql = "[" + arrUndeSql.Substring(2) + "]";
							arrType = GetCSType(col.Type, 0, col.SqlType);
						}
						string lname = CodeBuild.LFString(col.Name);
						string valueParm = CodeBuild.AppendParameters(col, "");
						valueParm = valueParm.Remove(valueParm.LastIndexOf("Value = ") + 8);
						string valueParm2 = valueParm.Replace("\"" + col.Name + "\"", "$\"@" + col.Name + "_{_parameters.Count}\"");
						if (col.Attndims > 0) {
							sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}({2} value) {{
				_setQs.Enqueue(ni => _item.{0} = ni.{0});
				return this.Set(@""""""{1}"""""", $""@{1}_{{_parameters.Count}}"", 
					{3}value }});
			}}
			public SqlUpdateBuild Set{0}Join({2} value) {{
				_setQs.Enqueue(ni => _item.{0} = ni.{0});
				return this.Set(@""""""{1}"""""", $@""""""{1}"""" || @{1}_{{_parameters.Count}}"", 
					{3}value }});
			}}", CodeBuild.UFString(col.Name), col.Name, col.CsType, valueParm2);
						}
						sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}({2} value{4}) {{
				_setQs.Enqueue(ni => _item.{0} = ni.{0});
				return this.Set({6}@""""""{1}""""{5}"", $""@{1}_{{_parameters.Count}}"", 
					{3}value }});
			}}", CodeBuild.UFString(col.Name), col.Name, arrType, valueParm2.Replace("NpgsqlDbType.Array | ", ""), arrParm, arrUndeSql, string.IsNullOrEmpty(arrUndeSql) ? "" : "$");
						if (table.ForeignKeys.FindIndex(delegate (ForeignKeyInfo fkf) { return fkf.Columns.FindIndex(delegate (ColumnInfo fkfpkf) { return fkfpkf.Name == col.Name; }) != -1; }) == -1) {
							string fptype = "";
							if (col.Type == NpgsqlDbType.Smallint || col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint ||
								col.Type == NpgsqlDbType.Numeric || col.Type == NpgsqlDbType.Real || col.Type == NpgsqlDbType.Double || col.Type == NpgsqlDbType.Money) {
								fptype = col.Attndims > 0 ? arrType : col.CsType.TrimEnd('?');
							}
							if ((col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint) && (lname == "status" || lname.StartsWith("status_") || lname.EndsWith("_status"))) {
								fptype = "";
								sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}Flag(int _0_16{4}, bool isUnFlag = false) {{
				_setQs.Enqueue(ni => _item.{0} = ni.{0});
				{2} tmp1 = ({2})Math.Pow(2, _0_16);
				return this.Set({7}@""""""{1}""""{5}"", $@""nullif(""""{1}""""{6},0) {{isUnFlag ? '^' : '|'}} @{1}_{{_parameters.Count}}"", 
					{3}tmp1 }});
			}}
			public SqlUpdateBuild Set{0}UnFlag(int _0_16{4}) {{
				return this.Set{0}Flag(_0_16{8}, true);
			}}", CodeBuild.UFString(col.Name), col.Name, arrType, valueParm2.Replace("NpgsqlDbType.Array | ", ""),
					arrParm, arrUndeSql, arrUndeSql, string.IsNullOrEmpty(arrUndeSql) ? "" : "$", col.Attndims > 0 ? " ," + arrUnde.Trim('[', ']') : "");
							}
							if (!string.IsNullOrEmpty(fptype)) {
								sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}Increment({2} value{4}) {{
				_setQs.Enqueue(ni => _item.{0} = ni.{0});
				return this.Set({7}@""""""{1}""""{5}"", $@""""""{1}""""{6} + @{1}_{{_parameters.Count}}"", 
					{3}value }});
			}}", CodeBuild.UFString(col.Name), col.Name, fptype, valueParm2.Replace("NpgsqlDbType.Array | ", ""),
					arrParm, arrUndeSql, arrUndeSql, string.IsNullOrEmpty(arrUndeSql) ? "" : "$", col.Attndims > 0 ? " ," + arrUnde.Trim('[', ']') : "");
							}
						}
						sb6.AppendFormat(@"
				.Set{0}(item.{0})", CodeBuild.UFString(col.Name));
					}

					string dal_insert_code = string.Format(@"
			{0}Info newitem = null;
			PSqlHelper.ExecuteReader(dr => {{ newitem = GetItem(dr); }}, TSQL.Insert, GetParameters(item));
			if (newitem == null) return null;{1}
			return item;", uClass_Name, csItemAllFieldCopy);
					sb1.AppendFormat(@"
{1}

		public int Update({0}Info item) {{
			return new SqlUpdateBuild(null, item.{7}){8}.ExecuteNonQuery();
		}}
		#region class SqlUpdateBuild
		public partial class SqlUpdateBuild {{
			protected {0}Info _item;
			protected string _fields;
			protected string _where;
			protected List<NpgsqlParameter> _parameters = new List<NpgsqlParameter>();
			protected Queue<Action<{0}Info>> _setQs = new Queue<Action<{0}Info>>();
			public SqlUpdateBuild({0}Info item, {3}) {{
				_item = item;
				_where = PSqlHelper.Addslashes(@""{4}"", {5});
			}}
			public SqlUpdateBuild() {{ }}
			public override string ToString() {{
				if (string.IsNullOrEmpty(_fields)) return string.Empty;
				if (string.IsNullOrEmpty(_where)) throw new Exception(""��ֹ {9}.DAL.{0}.SqlUpdateBuild ���޸ģ���������� where ������"");
				return string.Concat(""UPDATE "", TSQL.Table, "" SET "", _fields.Substring(1), "" WHERE "", _where);
			}}
			public int ExecuteNonQuery() {{
				string sql = this.ToString();
				if (string.IsNullOrEmpty(sql)) return 0;
				if (_item == null) return PSqlHelper.ExecuteNonQuery(sql, _parameters.ToArray());
				{0}Info newitem = null;
				PSqlHelper.ExecuteReader(dr => {{
					newitem = BLL.{0}.dal.GetItem(dr);
				}}, sql + TSQL.Returning, _parameters.ToArray());
				if (newitem == null) return 0;
				while (_setQs.Count > 0) _setQs.Dequeue()(newitem);
				return 1;
			}}
			public SqlUpdateBuild Where(string filterFormat, params object[] values) {{
				if (!string.IsNullOrEmpty(_where)) _where = string.Concat(_where, "" AND "");
				_where = string.Concat(_where, ""("", PSqlHelper.Addslashes(filterFormat, values), "")"");
				return this;
			}}
			public SqlUpdateBuild Set(string field, string value, params NpgsqlParameter[] parms) {{
				if (value.IndexOf('\'') != -1) throw new Exception(""{9}.DAL.{0}.SqlUpdateBuild ���ܴ���ע��©������������ ' ������ value����ʹ�������ַ�������ʹ�ò��������ݡ�"");
				_fields = string.Concat(_fields, "", "", field, "" = "", value);
				if (parms != null && parms.Length > 0) _parameters.AddRange(parms);
				return this;
			}}{6}
		}}
		#endregion

		public {0}Info Insert({0}Info item) {{{10}
		}}
{2}
	}}
}}", uClass_Name, sb2.ToString(), sb3.ToString(), pkCsParam.Replace("?", ""), pkSqlParamFormat, pkCsParamNoType, sb5.ToString(),
	pkCsParamNoTypeByval.Replace(", ", ", item."), sb6.ToString(), solutionName, dal_insert_code);
					#endregion
				} else {
					sb1.AppendFormat(@"
	}}
}}", uClass_Name);
				}
				#endregion

				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\DAL\", basicName, @"\", uClass_Name, ".cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				#region BLL *.cs
				sb1.AppendFormat(
	@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using {0}.Model;

namespace {0}.BLL {{

	public partial class {1} {{

		internal static readonly {0}.DAL.{1} dal = new {0}.DAL.{1}();
		internal static readonly int itemCacheTimeout;

		static {1}() {{
			if (!int.TryParse(RedisHelper.Configuration[""{0}_BLL_ITEM_CACHE:Timeout_{1}""], out itemCacheTimeout))
				int.TryParse(RedisHelper.Configuration[""{0}_BLL_ITEM_CACHE:Timeout""], out itemCacheTimeout);
		}}", solutionName, uClass_Name);

				string removeCacheCode = string.Format(@"
			if (itemCacheTimeout > 0) RemoveCache(GetItem({1}));", uClass_Name, pkCsParamNoType);
				Dictionary<string, bool> del_exists2 = new Dictionary<string, bool>();
				foreach (List<ColumnInfo> cs in table.Uniques) {
					string parms = string.Empty;
					string parmsBy = "By";
					string parmsNoneType = string.Empty;
					string parmsNodeTypeUpdateCacheRemove = string.Empty;
					string cacheCond = string.Empty;
					string cacheRemoveCode = string.Empty;
					foreach (ColumnInfo columnInfo in cs) {
						parms += columnInfo.CsType.Replace("?", "") + " " + CodeBuild.UFString(columnInfo.Name) + ", ";
						parmsBy += CodeBuild.UFString(columnInfo.Name) + "And";
						parmsNoneType += CodeBuild.UFString(columnInfo.Name) + ", ";
						parmsNodeTypeUpdateCacheRemove += "item." + CodeBuild.UFString(columnInfo.Name) + ", \"_,_\", ";
						cacheCond += CodeBuild.UFString(columnInfo.Name) + " == null || ";
					}
					parms = parms.Substring(0, parms.Length - 2);
					parmsBy = parmsBy.Substring(0, parmsBy.Length - 3);
					parmsNoneType = parmsNoneType.Substring(0, parmsNoneType.Length - 2);
					parmsNodeTypeUpdateCacheRemove = parmsNodeTypeUpdateCacheRemove.Substring(0, parmsNodeTypeUpdateCacheRemove.Length - 9);
					cacheCond = cacheCond.Substring(0, cacheCond.Length - 4);

					if (del_exists2.ContainsKey(parms)) continue;
					del_exists2.Add(parms, true);
					sb2.AppendFormat(@"
		public static int Delete{2}({0}) {{{3}
			return dal.Delete{2}({1});
		}}", parms, parmsNoneType, cs[0].IsPrimaryKey ? string.Empty : parmsBy, cs[0].IsPrimaryKey ? removeCacheCode : string.Empty);


					sb3.AppendFormat(@"
		public static {1}Info GetItem{2}({4}) {{
			if (itemCacheTimeout <= 0) return dal.GetItem{2}({5});
			string key = string.Concat(""{0}_BLL_{1}{2}_"", {3});
			string value = RedisHelper.Get(key);
			if (!string.IsNullOrEmpty(value))
				try {{ return {1}Info.Parse(value); }} catch {{ }}
			{1}Info item = dal.GetItem{2}({5});
			if (item == null) return null;
			RedisHelper.Set(key, item.Stringify(), itemCacheTimeout);
			return item;
		}}", solutionName, uClass_Name, cs[0].IsPrimaryKey ? string.Empty : parmsBy, parmsNodeTypeUpdateCacheRemove.Replace("item.", ""),
		parms, parmsNoneType, cacheCond);

					sb4.AppendFormat(@"
			RedisHelper.Remove(string.Concat(""{0}_BLL_{1}{2}_"", {3}));", solutionName, uClass_Name, cs[0].IsPrimaryKey ? string.Empty : parmsBy, parmsNodeTypeUpdateCacheRemove);
				}

				if (table.PrimaryKeys.Count > 0) {
					#region ���û�������Ĵ���
					sb2.AppendFormat(@"|deleteby_fk|");

					sb1.AppendFormat(@"

		#region delete, update, insert
{0}
", sb2.ToString());

					sb1.AppendFormat(@"
		public static int Update({1}Info item) {{
			if (itemCacheTimeout > 0) RemoveCache(item);
			return dal.Update(item);
		}}
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiy({2}) {{
			return UpdateDiy(null, {3});
		}}
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiy({1}Info item, {2}) {{
			if (itemCacheTimeout > 0) RemoveCache(item != null ? item : GetItem({3}));
			return new {0}.DAL.{1}.SqlUpdateBuild(item, {3});
		}}
		/// <summary>
		/// ������������
		/// </summary>
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiyDangerous {{
			get {{ return new {0}.DAL.{1}.SqlUpdateBuild(); }}
		}}
", solutionName, uClass_Name, pkCsParam.Replace("?", ""), pkCsParamNoType);
					if (table.Columns.Count > 5)
						sb1.AppendFormat(@"
		/// <summary>
		/// �����ֶν��ٵı��ܹ�����ı���գ��ֶ����ϴ������ {0}.Insert({0}Info item)
		/// </summary>
		[Obsolete]", uClass_Name);
					sb1.AppendFormat(@"
		public static {0}Info Insert({1}) {{
			return Insert(new {0}Info {{{2}}});
		}}", uClass_Name, CsParam2, CsParamNoType2);

					sb1.AppendFormat(@"
		public static {0}Info Insert({0}Info item) {{
			item = dal.Insert(item);
			if (itemCacheTimeout > 0) RemoveCache(item);
			return item;
		}}
		private static void RemoveCache({0}Info item) {{
			if (item == null) return;{2}
		}}
		#endregion
{1}
", uClass_Name, sb3.ToString(), sb4.ToString());
					#endregion
				}

				sb1.AppendFormat(@"
		public static List<{0}Info> GetItems() {{
			return Select.ToList();
		}}
		public static {0}SelectBuild Select {{
			get {{ return new {0}SelectBuild(dal); }}
		}}", uClass_Name, solutionName);

				Dictionary<string, bool> byItems = new Dictionary<string, bool>();
				foreach (ForeignKeyInfo fk in table.ForeignKeys) {
					string fkcsBy = string.Empty;
					string fkcsParms = string.Empty;
					string fkcsTypeParms = string.Empty;
					string fkcsFilter = string.Empty;
					int fkcsFilterIdx = 0;
					foreach (ColumnInfo c1 in fk.Columns) {
						fkcsBy += CodeBuild.UFString(c1.Name) + "And";
						fkcsParms += CodeBuild.UFString(c1.Name) + ", ";
						fkcsTypeParms += c1.CsType.Replace("?", "") + " " + CodeBuild.UFString(c1.Name) + ", ";
						fkcsFilter += @"a.""""" + c1.Name + @""""" = {" + fkcsFilterIdx++ + "} and ";
					}
					fkcsBy = fkcsBy.Remove(fkcsBy.Length - 3);
					fkcsParms = fkcsParms.Remove(fkcsParms.Length - 2);
					fkcsTypeParms = fkcsTypeParms.Remove(fkcsTypeParms.Length - 2);
					fkcsFilter = fkcsFilter.Remove(fkcsFilter.Length - 5);
					if (byItems.ContainsKey(fkcsBy)) continue;
					byItems.Add(fkcsBy, true);

					if (!del_exists2.ContainsKey(fkcsTypeParms)) {
						sb5.AppendFormat(@"
		public static int DeleteBy{2}({0}) {{
			return dal.DeleteBy{2}({1});
		}}", fkcsTypeParms, fkcsParms, fkcsBy);
						del_exists2.Add(fkcsTypeParms, true);
					}
					if (fk.Columns.Count > 1) {
						sb1.AppendFormat(
		@"
		public static List<{0}Info> GetItemsBy{1}({2}) {{
			return Select.Where{1}({3}).ToList();
		}}
		public static List<{0}Info> GetItemsBy{1}({2}, int limit) {{
			return Select.Where{1}({3}).Limit(limit).ToList();
		}}
		public static {0}SelectBuild SelectBy{1}({2}) {{
			return Select.Where{1}({3});
		}}", uClass_Name, fkcsBy, fkcsTypeParms, fkcsParms);
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}({2}) {{
			return base.Where(@""{4}"", {3}) as {0}SelectBuild;
		}}", uClass_Name, fkcsBy, fkcsTypeParms, fkcsParms, fkcsFilter, solutionName);
					} else if (fk.Columns.Count == 1/* && fk.Columns[0].IsPrimaryKey == false*/) {
						string csType = fk.Columns[0].CsType;
						sb1.AppendFormat(
		@"
		public static List<{0}Info> GetItemsBy{1}(params {2}[] {1}) {{
			return Select.Where{1}({1}).ToList();
		}}
		public static List<{0}Info> GetItemsBy{1}({2}[] {1}, int limit) {{
			return Select.Where{1}({1}).Limit(limit).ToList();
		}}
		public static {0}SelectBuild SelectBy{1}(params {2}[] {1}) {{
			return Select.Where{1}({1});
		}}", uClass_Name, fkcsBy, csType);
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}(params {2}[] {1}) {{
			return this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});
		}}", uClass_Name, fkcsBy, csType, fk.Columns[0].Name);
					}
				}
				// m -> n
				_tables.ForEach(delegate (TableInfo t2) {
					ForeignKeyInfo fk = t2.ForeignKeys.Find(delegate (ForeignKeyInfo ffk) {
						if (ffk.ReferencedTable.FullName == table.FullName) {
							return true;
						}
						return false;
					});
					if (fk == null) return;
					if (fk.Table.FullName == table.FullName) return;
					List<ForeignKeyInfo> fk2 = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk2) {
						return ffk2 != fk;
					});
					if (fk2.Count != 1) return;
					if (fk.Columns[0].IsPrimaryKey == false) return; //�м���ϵ��������Ϊ����

					//t2.Columns
					string t2name = t2.Name;
					string tablename = table.Name;
					string addname = t2name;
					if (t2name.StartsWith(tablename + "_")) {
						addname = t2name.Substring(tablename.Length + 1);
					} else if (t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(addname.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(t2name.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + fk2[0].ReferencedTable.Name)) {
						addname = t2name;
					}

					string orgInfo = CodeBuild.UFString(fk2[0].ReferencedTable.ClassName);
					string fkcsBy = CodeBuild.UFString(addname);
					if (byItems.ContainsKey(fkcsBy)) return;
					byItems.Add(fkcsBy, true);

					string civ = string.Format(GetCSTypeValue(fk2[0].ReferencedTable.PrimaryKeys[0].Type), CodeBuild.UFString(fk2[0].ReferencedTable.PrimaryKeys[0].Name));
					sb1.AppendFormat(@"
		public static {0}SelectBuild SelectBy{1}(params {2}Info[] items) {{
			return Select.Where{1}(items);
		}}
		public static {0}SelectBuild SelectBy{1}_{4}(params {3}[] ids) {{
			return Select.Where{1}_{4}(ids);
		}}", uClass_Name, fkcsBy, orgInfo, fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", ""), table.PrimaryKeys[0].Name);

					string _f6 = fk.Columns[0].Name;
					string _f7 = fk.ReferencedTable.PrimaryKeys[0].Name;
					string _f8 = fk2[0].Columns[0].Name;
					string _f9 = fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", "");

					if (fk.ReferencedTable.ClassName == fk2[0].ReferencedTable.ClassName) {
						_f6 = fk2[0].Columns[0].Name;
						_f7 = fk2[0].ReferencedTable.PrimaryKeys[0].Name;
						_f8 = fk.Columns[0].Name;
						_f9 = fk2[0].Table.PrimaryKeys[0].CsType.Replace("?", "");
					}
					sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}(params {2}Info[] items) {{
			if (items == null) return this;
			return Where{1}_{7}(items.Where<{2}Info>(a => a != null).Select<{2}Info, {9}>(a => a.{3}).ToArray());
		}}
		public {0}SelectBuild Where{1}_{7}(params {9}[] ids) {{
			if (ids == null || ids.Length == 0) return this;
			return base.Where(string.Format(@""EXISTS( SELECT """"{6}"""" FROM {4}""""{5}"""" WHERE """"{6}"""" = a.""""{7}"""" AND """"{8}"""" IN ({{0}}) )"", string.Join<{9}>("","", ids))) as {0}SelectBuild;
		}}", uClass_Name, fkcsBy, orgInfo, civ, string.Empty,  t2.FullName, _f6, _f7, _f8, _f9);
				});

				table.Columns.ForEach(delegate (ColumnInfo col) {
					if (col.Attndims > 1) return;
					string csType = col.CsType;
					string lname = col.Name.ToLower();
					//if (col.IsPrimaryKey) return;
					//if (lname == "create_time" ||
					//	lname == "update_time") return;
					string fkcsBy = CodeBuild.UFString(col.Name);
					if (byItems.ContainsKey(fkcsBy)) return;
					byItems.Add(fkcsBy, true);

					if (col.Attndims == 1) {
						csType = GetCSType(col.Type, 0, col.SqlType);
						if (col.Type == NpgsqlDbType.Enum) {
							sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}Any_IN(params {3}[] {1}s) {{
			return this.Where1Or(@""{{0}} ANY(a.""""{4}"""")"", {1}s);
		}}
		public {0}SelectBuild Where{1}Any({2} {1}1) {{
			return this.Where{1}Any_IN({1}1);
		}}
		#region Where{1}
		public {0}SelectBuild Where{1}Any({2} {1}1, {2} {1}2) {{
			return this.Where{1}Any_IN({1}1, {1}2);
		}}
		public {0}SelectBuild Where{1}Any({2} {1}1, {2} {1}2, {2} {1}3) {{
			return this.Where{1}Any_IN({1}1, {1}2, {1}3);
		}}
		public {0}SelectBuild Where{1}Any({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4) {{
			return this.Where{1}Any_IN({1}1, {1}2, {1}3, {1}4);
		}}
		public {0}SelectBuild Where{1}Any({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4, {2} {1}5) {{
			return this.Where{1}Any_IN({1}1, {1}2, {1}3, {1}4, {1}5);
		}}
		#endregion", uClass_Name, fkcsBy, csType.Replace("?", ""), csType, col.Name);
							return;
						}
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}Any(params {2}[] {1}) {{
			return this.Where1Or(@""{{0}} ANY(a.""""{3}"""")"", {1});
		}}", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name);
						return;
					}

					if (csType == "bool?") {
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}(params {2}[] {1}) {{
			return this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});
		}}", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name);
						return;
					}
					if (col.Type == NpgsqlDbType.Smallint || col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint ||
						col.Type == NpgsqlDbType.Numeric || col.Type == NpgsqlDbType.Real || col.Type == NpgsqlDbType.Double || col.Type == NpgsqlDbType.Money) {
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}(params {2}[] {1}) {{
			return this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});
		}}", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name);
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}Range({2} begin) {{
			return base.Where(@""a.""""{3}"""" >= {{0}}"", begin) as {0}SelectBuild;
		}}
		public {0}SelectBuild Where{1}Range({2} begin, {2} end) {{
			if (end == null) return Where{1}Range(begin);
			return base.Where(@""a.""""{3}"""" between {{0}} and {{1}}"", begin, end) as {0}SelectBuild;
		}}", uClass_Name, fkcsBy, csType, col.Name);
						return;
					}
					if (col.Type == NpgsqlDbType.Timestamp || col.Type == NpgsqlDbType.TimestampTZ || col.Type == NpgsqlDbType.Date ||
						col.Type == NpgsqlDbType.Time || col.Type == NpgsqlDbType.TimeTZ || col.Type == NpgsqlDbType.Interval) {
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}Range({2} begin) {{
			return base.Where(@""a.""""{3}"""" >= {{0}}"", begin) as {0}SelectBuild;
		}}
		public {0}SelectBuild Where{1}Range({2} begin, {2} end) {{
			if (end == null) return Where{1}Range(begin);
			return base.Where(@""a.""""{3}"""" between {{0}} and {{1}}"", begin, end) as {0}SelectBuild;
		}}", uClass_Name, fkcsBy, csType, col.Name);
						return;
					}
					if ((col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint) && (lname == "status" || lname.StartsWith("status_") || lname.EndsWith("_status"))) {
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}(params int[] _0_16) {{
			if (_0_16 == null || _0_16.Length == 0) return this;
			{2}[] copy = new {2}[_0_16.Length];
			for (int a = 0; a < _0_16.Length; a++) copy[a] = ({2})Math.Pow(2, _0_16[a]);
			return this.Where1Or(@""(a.""""{3}"""" & {{0}}) = {{0}}"", copy);
		}}", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name);
						return;
					}
					if (col.Type == NpgsqlDbType.Enum) {
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}_IN(params {3}[] {1}s) {{
			return this.Where1Or(@""a.""""{4}"""" = {{0}}"", {1}s);
		}}
		public {0}SelectBuild Where{1}({2} {1}1) {{
			return this.Where{1}_IN({1}1);
		}}
		#region Where{1}
		public {0}SelectBuild Where{1}({2} {1}1, {2} {1}2) {{
			return this.Where{1}_IN({1}1, {1}2);
		}}
		public {0}SelectBuild Where{1}({2} {1}1, {2} {1}2, {2} {1}3) {{
			return this.Where{1}_IN({1}1, {1}2, {1}3);
		}}
		public {0}SelectBuild Where{1}({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4) {{
			return this.Where{1}_IN({1}1, {1}2, {1}3, {1}4);
		}}
		public {0}SelectBuild Where{1}({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4, {2} {1}5) {{
			return this.Where{1}_IN({1}1, {1}2, {1}3, {1}4, {1}5);
		}}
		#endregion", uClass_Name, fkcsBy, csType.Replace("?", ""), csType, col.Name);
						return;
					}
					if (csType == "string") {
						if (col.Length > 0 && col.Length < 301)
							sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}(params {2}[] {1}) {{
			return this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});
		}}", uClass_Name, fkcsBy, csType, col.Name);
						sb6.AppendFormat(@"
		public {0}SelectBuild Where{1}Like(params {2}[] {1}) {{
			if ({1} == null) return this;
			return this.Where1Or(@""a.""""{3}"""" ILIKE {{0}}"", {1}.Select<{2}, string>(a => ""%"" + a + ""%"").ToArray());
		}}", uClass_Name, fkcsBy, csType, col.Name);
						return;
					}
				});

				sb1.AppendFormat(@"
	}}
	public partial class {0}SelectBuild : SelectBuild<{0}Info, {0}SelectBuild> {{{2}
		protected new {0}SelectBuild Where1Or(string filterFormat, Array values) {{
			return base.Where1Or(filterFormat, values) as {0}SelectBuild;
		}}
		public {0}SelectBuild(IDAL dal) : base(dal, PSqlHelper.Instance) {{ }}
	}}
}}", uClass_Name, solutionName, sb6.ToString());

				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\BLL\", basicName, @"\", uClass_Name, ".cs"), Deflate.Compress(sb1.ToString().Replace("|deleteby_fk|", sb5.ToString()))));
				clearSb();
				#endregion

				if (table.PrimaryKeys.Count == 0) continue;

				#region admin
				if (isMakeAdmin) {

					#region common define
					string pkNames = string.Empty;
					string pkUrlQuerys = string.Empty;
					string pkHiddens = string.Empty;
					for (int a = 0; a < table.PrimaryKeys.Count; a++) {
						ColumnInfo col88 = table.PrimaryKeys[a];
						pkNames += CodeBuild.UFString(col88.Name) + ",";
						pkUrlQuerys += string.Format(@"{0}={{#a.{0}}}&", CodeBuild.UFString(col88.Name));
						pkHiddens += string.Format(@"{{#a.{0}}},", CodeBuild.UFString(col88.Name));
					}
					if (pkNames.Length > 0) pkNames = pkNames.Remove(pkNames.Length - 1);
					if (pkUrlQuerys.Length > 0) pkUrlQuerys = pkUrlQuerys.Remove(pkUrlQuerys.Length - 1);
					if (pkHiddens.Length > 0) pkHiddens = pkHiddens.Remove(pkHiddens.Length - 1);

					ForeignKeyInfo ttfk = table.ForeignKeys.Find(delegate (ForeignKeyInfo fkk) {
						return fkk.ReferencedTable != null && fkk.ReferencedTable.FullName == table.FullName;
					});
					#endregion

					#region wwwroot_sitemap
					wwwroot_sitemap += string.Format(@"
			<li><a href=""/{0}/""><i class=""fa fa-circle-o""></i>{0}</a></li>", uClass_Name);
					#endregion

					#region init_sysdir
					admin_controllers_syscontroller_init_sysdir.Add(string.Format(@"

			dir2 = Sysdir.Insert(dir1.Id, DateTime.Now, ""{0}"", {1}, ""/{0}/"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""�б�"", 1, ""/{0}/"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""���"", 2, ""/{0}/add.aspx"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""�༭"", 3, ""/{0}/edit.aspx"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""ɾ��"", 4, ""/{0}/del.aspx"");", nClass_Name, admin_controllers_syscontroller_init_sysdir.Count + 1));
					#endregion

					#region Controller.cs
					string str_listTh = "";
					string str_listTd = "";
					string str_listTh1 = "";
					string str_listTd1 = "";
					string str_controller_list_join = "";
					byte str_controller_list_join_alias = 97;
					string str_controller_list_apireturn = "";
					string str_listFilter_js_array = "";
					string str_listJsonCombine = "";
					string str_listCms2FilterFK = "";
					int str_listCms2FilterAjaxs = 0;
					string keyLikes = string.Empty;
					string getListParamQuery = "";
					bool ttfk_flag = false;
					string str_addhtml_mn = "";
					string str_addjs_mn = "";
					string str_addjs_mn_initUI = "";
					string str_addjs_mn_geturl = "";
					string str_controller_insert_mn = "";
					string str_controller_update_mn = "";
					int wwwroo_xxx_add_html_ajaxs = 0;
					int wwwroo_xxx_add_html_ajaxs_update = 0;
					foreach (ColumnInfo col in table.Columns) {
						List<ColumnInfo> us = table.Uniques.Find(delegate (List<ColumnInfo> cs) {
							return cs.Find(delegate (ColumnInfo col88) {
								return col88.Name == col.Name;
							}) != null;
						});
						if (us == null) us = new List<ColumnInfo>();
						List<ForeignKeyInfo> fks_comb = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk2) {
							return fk2.Columns.Count == 1 && fk2.Columns[0].Name == col.Name;
						});

						string csType = col.CsType;
						string csUName = CodeBuild.UFString(col.Name);
						string comment = _column_coments[table.FullName][col.Name];
						if (csType == "string") {
							keyLikes += "a." + col.Name + " ilike {0} or ";
						}
						List<ForeignKeyInfo> fks = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk88) {
							return fk88.Columns.Find(delegate (ColumnInfo col88) {
								return col88.Name == col.Name;
							}) != null;
						});

						//���
						ForeignKeyInfo fk = null;
						string FK_uEntry_Name = string.Empty;
						string tableNamefe3 = string.Empty;
						string memberName = string.Empty;
						string strName = string.Empty;
						if (fks.Count > 0) {
							fk = fks[0];
							FK_uEntry_Name = fk.ReferencedTable != null ? CodeBuild.GetCSName(fk.ReferencedTable.Name) :
								CodeBuild.GetCSName(TableInfo.GetEntryName(fk.ReferencedTableName));
							tableNamefe3 = fk.ReferencedTable != null ? fk.ReferencedTable.Name : FK_uEntry_Name;
							memberName = fk.Columns[0].Name.IndexOf(tableNamefe3) == -1 ? CodeBuild.LFString(tableNamefe3) :
								(CodeBuild.LFString(fk.Columns[0].Name.Substring(0, fk.Columns[0].Name.IndexOf(tableNamefe3)) + tableNamefe3));
							if (fk.Columns[0].Name.IndexOf(tableNamefe3) == 0 && fk.ReferencedTable != null) memberName = CodeBuild.LFString(fk.ReferencedTable.ClassName);

							ColumnInfo strNameCol = null;
							if (fk.ReferencedTable != null) {
								strNameCol = fk.ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
									return col88.Name.ToLower().IndexOf("name") != -1 || col88.Name.ToLower().IndexOf("title") != -1;
								});
								if (strNameCol == null) strNameCol = fk.ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
									return col88.CsType == "string" && col88.Length > 0 && col88.Length < 128;
								});
							}
							strName = strNameCol != null ? "." + CodeBuild.UFString(strNameCol.Name) : string.Empty;
						}
						string Obj_name = string.Concat("Obj_", memberName, strName);

						if (!col.IsIdentity && fks.Count == 1) {
							ForeignKeyInfo fkcb = fks[0];
							string FK_uClass_Name = fkcb.ReferencedTable != null ? CodeBuild.UFString(fkcb.ReferencedTable.ClassName) :
								CodeBuild.UFString(TableInfo.GetClassName(fkcb.ReferencedTableName));

							getListParamQuery += string.Format(@"[FromQuery] {0}[] {1}, ", csType, csUName);
							sb3.AppendFormat(@"
			if ({0}.Length > 0) select.Where{0}({0});", csUName);
						} else if (!col.IsIdentity && us.Count == 1 || col.IsPrimaryKey && table.PrimaryKeys.Count == 1) {
							//������Ψһ�������Զ���ֵ
						}

						//ǰ��js����ģ��
						if (!col.IsIdentity && fks.Count == 1 && fks[0].Table.FullName != fks[0].ReferencedTable.FullName) {
							str_listTh += string.Format(@"<th scope=""col"">{0}</th>
						", comment);
							str_listTd += string.Format(@"<td>[{{#a.{0}}}]{{#a.Obj_{1}{2}}}</td>
							", csUName, memberName, strName);
							str_controller_list_join += string.Format(@"
				.InnerJoin<{0}>(""{3}"", ""{3}.{1} = a.{2}"")", CodeBuild.UFString(fks[0].ReferencedTable.ClassName), fks[0].ReferencedColumns[0].Name, fks[0].Columns[0].Name, (char)++str_controller_list_join_alias);
							str_controller_list_apireturn += string.Format(@", 
				""items_{0}"", items.Select<{2}Info, {1}Info>(a => a.Obj_{3}).ToBson()", fks[0].ReferencedTable.ClassName, CodeBuild.UFString(fks[0].ReferencedTable.ClassName), CodeBuild.UFString(fks[0].Table.ClassName), memberName, strName);
							str_listFilter_js_array += string.Format(@"
	if (qs.{0}) qs.{0} = qs.{0}.split('_');", CodeBuild.UFString(fks[0].Columns[0].Name));
							str_listJsonCombine += string.Format(@"
		for (var a = 0; a < rt.data.items_{0}.length; a++) rt.data.items[a].Obj_{1} = rt.data.items_{0}[a];", fks[0].ReferencedTable.ClassName, memberName, strName);
							str_listCms2FilterFK += string.Format(@"
	cms2FilterFK('{0}', '{1}', '{2}', '{3}', function (r) {{
		if (r.text.length) cms2FilterArray[{4}] = r;
		if (--cms2FilterAjaxs <= 0) cms2Filter(cms2FilterArray, fqs);
	}});", CodeBuild.UFString(fks[0].ReferencedTable.ClassName), strName.TrimStart('.'), CodeBuild.UFString(fks[0].ReferencedColumns[0].Name), CodeBuild.UFString(fks[0].Columns[0].Name), str_listCms2FilterAjaxs++);
						} else if (csType == "string" && !ttfk_flag) {
							ttfk_flag = true;
							string t1 = string.Format(@"<th scope=""col"">{0}</th>
						", comment);
							string t2 = string.Format(@"<td>{{#String(a.{0}).htmlencode()}}</td>
							", csUName);
							str_listTh1 += t1;
							str_listTd1 += t2;
							if (ttfk == null || ttfk.Columns[0].Name.ToLower() != "parent_id") {
								str_listTh += t1;
								str_listTd += t2;
							}
						} else {
							str_listTh += string.Format(@"<th scope=""col"">{0}</th>
						", comment);
							str_listTd += string.Format(@"<td>{{#a.{0}}}</td>
							", csUName);
						}
					}
					if (keyLikes.Length > 0) {
						keyLikes = keyLikes.Remove(keyLikes.Length - 4);
						getListParamQuery = "[FromQuery] string key, " + getListParamQuery;
						sb2.AppendFormat(@"
				.Where(!string.IsNullOrEmpty(key), ""{0}"", string.Concat(""%"", key, ""%""))", keyLikes);
					}

					string itemSetValuePK = "";
					string itemSetValuePKInsert = "";
					string itemSetValueNotPK = "";
					string itemCsParamInsertForm = "";
					string itemCsParamUpdateForm = "";
					table.Columns.ForEach(delegate (ColumnInfo col88) {
						string csLName = CodeBuild.LFString(col88.Name);
						string csUName = CodeBuild.UFString(col88.Name);
						string csType = col88.CsType;

						if (col88.IsPrimaryKey) {
							itemSetValuePK += string.Format(@"
			item.{0} = {0};", csUName);
							if (col88.IsIdentity) ;
							else {
								itemSetValuePKInsert += string.Format(@"
			item.{0} = {0};", csUName);
								itemCsParamInsertForm += string.Format(", [FromForm] {0} {1}", csType, csUName);
							}
						} else if (col88.IsIdentity) {
						} else {
							string colvalue = "";
							if (csType == "DateTime?" && (
	   string.Compare(csLName, "create_time", true) == 0 ||
	   string.Compare(csLName, "update_time", true) == 0
   )) {
								colvalue = "DateTime.Now";
							} else {
								string csType2 = csType;
								itemCsParamInsertForm += string.Format(", [FromForm] {0} {1}", csType2, csUName);
								itemCsParamUpdateForm += string.Format(", [FromForm] {0} {1}", csType2, csUName);
								colvalue = csUName;
							}
							itemSetValueNotPK += string.Format(@"
			item.{0} = {1};", csUName, colvalue);
						}
					});
					if (itemCsParamInsertForm.Length > 0) itemCsParamInsertForm = itemCsParamInsertForm.Substring(2);

					// m -> n
					_tables.ForEach(delegate (TableInfo t2) {
						ForeignKeyInfo fk = t2.ForeignKeys.Find(delegate (ForeignKeyInfo ffk) {
							if (ffk.ReferencedTable.FullName == table.FullName) {
								return true;
							}
							return false;
						});
						if (fk == null) return;
						if (fk.Table.FullName == table.FullName) return;
						List<ForeignKeyInfo> fk2 = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk2) {
							return ffk2 != fk;
						});
						if (fk2.Count != 1) return;
						if (fk.Columns[0].IsPrimaryKey == false) return; //�м���ϵ��������Ϊ����
						if (t2.Columns.Count != 2) return; //mn�������������ֶΣ��򲻴���

						//t2.Columns
						string t2name = t2.Name;
						string tablename = table.Name;
						string addname = t2name;
						if (t2name.StartsWith(tablename + "_")) {
							addname = t2name.Substring(tablename.Length + 1);
						} else if (t2name.EndsWith("_" + tablename)) {
							addname = t2name.Remove(addname.Length - tablename.Length - 1);
						} else if (fk2.Count == 1 && t2name.EndsWith("_" + tablename)) {
							addname = t2name.Remove(t2name.Length - tablename.Length - 1);
						} else if (fk2.Count == 1 && t2name.EndsWith("_" + fk2[0].ReferencedTable.Name)) {
							addname = t2name;
						}

						ColumnInfo strNameCol = fk2[0].ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
							return col88.Name.ToLower().IndexOf("name") != -1 || col88.Name.ToLower().IndexOf("title") != -1;
						});
						if (strNameCol == null) strNameCol = fk2[0].ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
							return col88.CsType == "string" && col88.Length > 0 && col88.Length < 128;
						});
						if (strNameCol == null) strNameCol = fk2[0].ReferencedTable.PrimaryKeys[0];
						string strName = CodeBuild.UFString(strNameCol.Name);

						getListParamQuery += string.Format(@"[FromQuery] {0}[] {1}_{2}, ", fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", ""), CodeBuild.UFString(addname), table.PrimaryKeys[0].Name);
						sb3.AppendFormat(@"
			if ({0}_{1}.Length > 0) select.Where{0}_{1}({0}_{1});", CodeBuild.UFString(addname), table.PrimaryKeys[0].Name);
				//		str_controller_list_apireturn += string.Format(@", 
				//""items_{0}s"", items.Select<{1}Info, IDictionary[]>(a => a.Obj_{0}s.ToBson())", addname, uClass_Name);
						str_listFilter_js_array += string.Format(@"
	if (qs.{0}_{1}) qs.{0}_{1} = qs.{0}_{1}.split('_');", CodeBuild.UFString(addname), table.PrimaryKeys[0].Name);
		//				str_listJsonCombine += string.Format(@"
		//for (var a = 0; a < rt.data.items_{0}s.length; a++) rt.data.items[a].Obj_{0}s = rt.data.items_{0}s[a];", addname);
						str_listCms2FilterFK += string.Format(@"
	cms2FilterFK('{0}', '{1}', '{2}', '{3}', function (r) {{
		if (r.text.length) cms2FilterArray[{4}] = r;
		if (--cms2FilterAjaxs <= 0) cms2Filter(cms2FilterArray, fqs);
	}});", CodeBuild.UFString(fk2[0].ReferencedTable.ClassName), strName, CodeBuild.UFString(fk2[0].ReferencedColumns[0].Name), CodeBuild.UFString(fk2[0].Columns[0].Name), str_listCms2FilterAjaxs++);
					//add.html ��ǩ����
					itemCsParamInsertForm += string.Format(", [FromForm] {0}[] mn_{1}", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), CodeBuild.UFString(addname));
					itemCsParamUpdateForm += string.Format(", [FromForm] {0}[] mn_{1}", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), CodeBuild.UFString(addname));
					str_controller_insert_mn += string.Format(@"
			//���� {1}
			foreach ({0} mn_{1}_in in mn_{1})
				item.Flag{1}(mn_{1}_in);", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), CodeBuild.UFString(addname));
						str_controller_update_mn += string.Format(@"
			//���� {1}
			if (mn_{1}.Length == 0) {{
				item.Unflag{1}ALL();
			}} else {{
				List<{0}> mn_{1}_list = mn_{1}.ToList();
				foreach (var Obj_{2} in item.Obj_{2}s) {{
					int idx = mn_{1}_list.FindIndex(a => a == Obj_{2}.Id);
					if (idx == -1) item.Unflag{1}(Obj_{2}.Id);
					else mn_{1}_list.RemoveAt(idx);
				}}
				mn_{1}_list.ForEach(a => item.Flag{1}(a));
			}}", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), CodeBuild.UFString(addname), addname);
						str_addhtml_mn += string.Format(@"
						<tr>
							<td>{1}</td>
							<td>
								<select name=""mn_{0}"" data-placeholder=""Select a {1}"" class=""form-control select2"" multiple>
									<option @for=""a in items"" value=""{{#a.{2}}}"">{{#a.{3}}}</option>
								</select>
							</td>
						</tr>", CodeBuild.UFString(addname), CodeBuild.UFString(addname), CodeBuild.UFString(fk2[0].ReferencedColumns[0].Name), strName);
						str_addjs_mn += string.Format(@"
	$.getJSON('/apiv0/{0}/', {{ limit: 2000 }}, function (rt) {{
		renderTpl(form.mn_{1}, rt.data);
		if (--ajaxs <= 0) initUI();
	}});", CodeBuild.UFString(addname), CodeBuild.UFString(addname));
						str_addjs_mn_initUI += string.Format(@"
		if (data.mn_{0}) for (var a = 0; a < data.mn_{0}.length; a++) $(form.mn_{0}).find('option[value=""{{0}}""]'.format(data.mn_{0}[a].{1})).attr('selected', 'selected');", CodeBuild.UFString(addname), CodeBuild.UFString(fk2[0].ReferencedColumns[0].Name));
						str_addjs_mn_geturl += string.Format(@"
		$.getJSON('/apiv0/{0}/', {{ {1}_{2}: top.mainViewNav.query.{3} }}, function (rt) {{
			if (rt.success) data.mn_{0} = rt.data.items;
			if (--ajaxs <= 0) initUI();
		}});", CodeBuild.UFString(addname), uClass_Name, table.PrimaryKeys[0].Name, CodeBuild.UFString(table.PrimaryKeys[0].Name));
						wwwroo_xxx_add_html_ajaxs_update++;
						wwwroo_xxx_add_html_ajaxs++;
						wwwroo_xxx_add_html_ajaxs++;
					});

					sb1.AppendFormat(CONST.Admin_Controllers, solutionName, uClass_Name, nClass_Name, pkMvcRoute, pkCsParam.Replace("?", ""), pkCsParamNoType, itemSetValuePK, itemSetValueNotPK, 
						sb2.ToString(), sb3.ToString(), itemCsParamInsertForm, itemCsParamUpdateForm, getListParamQuery, itemSetValuePKInsert, str_controller_list_join, str_controller_list_apireturn,
						str_controller_insert_mn, str_controller_update_mn);

					loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"\ApiV0Controllers\", uClass_Name, @"Controller.cs"), Deflate.Compress(sb1.ToString())));
					clearSb();
					#endregion

					if (ttfk == null || ttfk.Columns[0].Name.ToLower() != "parent_id") {
						#region wwwroot/xxx/index.html
						foreach (ColumnInfo col in table.Columns) {
							List<ForeignKeyInfo> ffks = new List<ForeignKeyInfo>();
							foreach (TableInfo fti in _tables) {
								ffks.AddRange(fti.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk) {
									if (ffk.ReferencedTable != null && ffk.ReferencedTable.FullName == table.FullName) {
										return ffk.ReferencedColumns.Find(delegate (ColumnInfo col88) {
											return col88.Name == col.Name;
										}) != null;
									}
									return false;
								}));
							}
							foreach (ForeignKeyInfo ffk in ffks) {
								string FFK_uClass_Name = CodeBuild.UFString(ffk.Table.ClassName);
								string FFK_nClass_Name = CodeBuild.UFString(ffk.Table.ClassName);

								string urlQuerys = string.Empty;
								ffk.Columns.ForEach(delegate (ColumnInfo col88) {
									string FFK_csUName = CodeBuild.UFString(col.Name);
									urlQuerys += string.Format("{0}={{#a.{1}}}&", CodeBuild.UFString(col88.Name), FFK_csUName);
								});
								if (urlQuerys.Length > 0) urlQuerys = urlQuerys.Remove(urlQuerys.Length - 1);

								str_listTh += string.Format(@"<th scope=""col"">&nbsp;</th>
						");
								str_listTd += string.Format(@"<td><a href=""../{0}/?{1}"">{0}</a></td>
							", FFK_nClass_Name, urlQuerys);
							}
						}
						sb1.AppendFormat(@"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<a href=""./"" class=""btn btn-primary"">����ɸѡ</a>
		<span class=""form-group mr15""></span><a href=""./add.html"" data-toggle=""modal"" class=""btn btn-success pull-right"">���</a>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_search"">
				<div id=""div_filter""></div>
			</form>
			<form id=""form_list"" runat=""server"">
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"" style=""width:2%;""><input type=""checkbox"" onclick=""$('#GridView1 tbody tr').each(function (idx, el) {{ var chk = $(el).find('td:first input[type=\'checkbox\']')[0]; if (chk) chk.checked = !chk.checked; }});"" /></th>
						{3}<th scope=""col"" style=""width:5%;"">&nbsp;</th>
					</tr>
					<tbody>
						<tr @for=""a in items"">
							<td><input type=""checkbox"" id=""id"" name=""id"" value=""{2}"" /></td>
							{4}<td><a href=""add.html?{1}"">�޸�</a></td>
						</tr>
					</tbody>
				</table>
			</form>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

<script type=""text/javascript"">
(function () {{
	var qs = _clone(top.mainViewNav.query);
	var pageindex = cint(qs.pageindex, 1);
	qs.limit = 20;
	qs.skip = (pageindex - 1) * qs.limit;{8}
	delete qs.pageindex;
	$.ajax({{ url: '/apiv0/{0}/', data: qs, traditional: true, success: function (rt) {{{5}
		renderTpl('#form_list', rt.data);
		delete qs.limit;
		delete qs.skip;
		$('#kkpager').html(cms2Pager(rt.data.count, pageindex, 20, qs, 'pageindex'));
		top.mainViewInit();
	}}}});
	// �����ǹ�����
	var fqs = _clone(top.mainViewNav.query);
	delete fqs.pageindex;
	var cms2FilterArray = [];
	var cms2FilterAjaxs = {7};{6}
}})();
</script>", uClass_Name, pkUrlQuerys, pkHiddens, str_listTh, str_listTd, str_listJsonCombine, str_listCms2FilterFK, str_listCms2FilterAjaxs, str_listFilter_js_array);
						loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"wwwroot\", uClass_Name, @"\index.html"), Deflate.Compress(sb1.ToString())));
						clearSb();
						#endregion
					} else {
						#region wwwroot/xxx/index.html(�ݹ��ϵ)
						sb1.AppendFormat(@"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<span class=""form-group mr15""></span><a href=""./add.html"" data-toggle=""modal"" class=""btn btn-success pull-right"">���</a>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">

			<form id=""form_list"" runat=""server"">
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						{8}{6}<th scope=""col"" style=""width:5%;"">&nbsp;</th>
						<th scope=""col"" style=""width:5%;"">ɾ��</th>
					</tr>
					<tbody>
						<tr data-tt-id=""{{#{1}}}"" data-tt-parent-id=""{{#{2}}}"">
							{9}{7}<td><a href=""add.html?{4}"">�޸�</a></td>
							<td><input id=""id"" name=""id"" type=""checkbox"" value=""{5}"" /></td>
						</tr>
					</tbody>
				</table>
			</form>

		</div>
	</div>
</div>

<div>
	<font color=""red"">*</font> ɾ������ʱ������ɾ�����������
	<a id=""btn_delete_sel"" href=""#"" class=""btn btn-danger pull-right"">ɾ��ѡ����</a>
</div>

<script type=""text/javascript"">
(function() {{
	$.getJSON('/apiv0/{0}/', {{ limit: 2000 }}, function(rt) {{{3}
		rt.items2 = yieldTreeArray(rt.data.items, null, '{1}', '{2}');
		var tpl = $('#GridView1 tbody:last').html();
		$('#GridView1 tbody:last').html(yieldTreeTable(rt.items2, tpl));
		$('table#GridView1').treetable({{ expandable: true }});
		$('table#GridView1').treetable('expandAll');
		top.mainViewInit();
	}});
}})();
</script>", uClass_Name, CodeBuild.UFString(table.PrimaryKeys[0].Name), CodeBuild.UFString(ttfk.Columns[0].Name), str_listJsonCombine, 
	pkUrlQuerys.Replace("a.", ""), pkHiddens.Replace("a.", ""), str_listTh.Replace("a.", ""), str_listTd.Replace("a.", ""), str_listTh1.Replace("a.", ""), str_listTd1.Replace("a.", ""));
						loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"wwwroot\", uClass_Name, @"\index.html"), Deflate.Compress(sb1.ToString())));
						clearSb();
						#endregion
					}

					#region wwwroot/xxx/add.html
					foreach (ColumnInfo col in table.Columns) {
						string csType = col.CsType;
						string csUName = CodeBuild.UFString(col.Name);
						string lname = col.Name.ToLower();
						string comment = _column_coments[table.FullName][col.Name];
						string rfvEmpty = string.Empty;
						List<ColumnInfo> us = table.Uniques.Find(delegate (List<ColumnInfo> cs) {
							return cs.Find(delegate (ColumnInfo col88) {
								return col88.Name == col.Name;
							}) != null;
						});
						if (us == null) us = new List<ColumnInfo>();
						List<ForeignKeyInfo> fks_comb = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk) {
							return fk.Columns.Count == 1 && fk.Columns[0].Name == col.Name;
						});

						if (csType == "bool?") {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td id=""{0}_td""><input name=""{0}"" type=""checkbox"" value=""1"" /></td>
						</tr>", csUName, comment);
						} else if (csType == "DateTime?" && (
							string.Compare(lname, "create_time", true) == 0 ||
							string.Compare(lname, "update_time", true) == 0
							)) {
							sb4.AppendFormat(@"
						<tr update-visible style=""display:none"">
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" readonly class=""datepicker"" style=""width:20%;background-color:#ddd;"" /></td>
						</tr>", csUName, comment);
						} else if (col.IsPrimaryKey && col.IsIdentity) {
							//�����Զ���ֵ
							sb4.AppendFormat(@"
						<tr update-visible style=""display:none"">
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" readonly class=""datepicker"" style=""width:20%;background-color:#ddd;"" /></td>
						</tr>", csUName, comment);
						} else if (fks_comb.Count == 1) {
							//���������
							ForeignKeyInfo fkcb = fks_comb[0];
							string FK_uClass_Name = fkcb.ReferencedTable != null ? CodeBuild.UFString(fkcb.ReferencedTable.ClassName) :
								CodeBuild.UFString(TableInfo.GetClassName(fkcb.ReferencedTableName));
							ForeignKeyInfo fkrr = fkcb.ReferencedTable != null ?
										fkcb.ReferencedTable.ForeignKeys.Find(delegate (ForeignKeyInfo fkkk) {
											return fkkk.ReferencedTable != null && fkcb.ReferencedTable.FullName == fkkk.ReferencedTable.FullName;
										}) : null;
							bool isParentSelect = fkcb.ReferencedTable != null && fkrr != null;
							string FK_Column = fkcb.ReferencedTable != null ?
										CodeBuild.UFString(fkcb.ReferencedColumns[0].Name) : CodeBuild.UFString(fkcb.ReferencedColumnNames[0]);

							ColumnInfo strCol = fkcb.ReferencedTable.Columns.Find(delegate (ColumnInfo col99) {
								return col99.Name.ToLower().IndexOf("name") != -1 || col99.Name.ToLower().IndexOf("title") != -1;
							});
							if (strCol == null) strCol = fkcb.ReferencedTable.Columns.Find(delegate (ColumnInfo col99) {
								return col99.CsType == "string" && col99.Length > 0 && col99.Length < 128;
							});
							string FK_Column_Text = fkcb.ReferencedTable != null && strCol != null ? CodeBuild.UFString(strCol.Name)
								 : FK_Column;

							if (isParentSelect) {
								sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td id=""{0}_td""></td>
						</tr>", csUName, comment);
								sb5.AppendFormat(@"
	$.getJSON('/apiv0/{0}/', {{ limit: 2000 }}, function(rt) {{
		rt.items2 = yieldTreeArray(rt.data.items, null, '{1}', '{2}');
		$('#{3}_td').html(yieldTreeSelect(rt.items2, '{{#{4}}}', '{1}')).find('select').attr('name', '{3}');
		if (--ajaxs <= 0) initUI();
	}});", FK_uClass_Name, CodeBuild.UFString(fkcb.ReferencedColumns[0].Name), CodeBuild.UFString(fkrr.Columns[0].Name), csUName, FK_Column_Text);
								wwwroo_xxx_add_html_ajaxs++;
							} else {
								sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<select name=""{0}"">
									<option value="""">------ ��ѡ�� ------</option>
									<option @for=""a in items"" value=""{{#a.{2}}}"">{{#a.{3}}}</option>
								</select>
							</td>
						</tr>", csUName, comment, CodeBuild.UFString(fkcb.ReferencedColumns[0].Name), FK_Column_Text);
								sb5.AppendFormat(@"
	$.getJSON('/apiv0/{0}/', {{ limit: 2000 }}, function (rt) {{
		renderTpl(form.{1}, rt.data);
		if (--ajaxs <= 0) initUI();
	}});", FK_uClass_Name, csUName);
								wwwroo_xxx_add_html_ajaxs++;
							}
						} else if ((col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint) && (lname == "status" || lname.StartsWith("status_") || lname.EndsWith("_status"))) {
							//���� multi ��״̬�ֶ�
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""hidden"" multi_status=""״̬1,״̬2,״̬3,״̬4,״̬5"" /></td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Smallint || col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint) {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" class=""form-control"" data-inputmask=""'mask': '9', 'repeat': 6, 'greedy': false"" data-mask style=""width:200px;"" /></td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Numeric || col.Type == NpgsqlDbType.Real || col.Type == NpgsqlDbType.Double || col.Type == NpgsqlDbType.Money) {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<div class=""input-group"" style=""width:200px;"">
									<span class=""input-group-addon"">��</span>
									<input name=""{0}"" type=""text"" class=""form-control"" data-inputmask=""'mask': '9', 'repeat': 10, 'greedy': false"" data-mask />
									<span class=""input-group-addon"">.00</span>
								</div>
							</td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Timestamp || col.Type == NpgsqlDbType.TimestampTZ) {
							//����
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" class=""datepicker"" /></td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Date) {
							//���ڿؼ�
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<div class=""input-group date"" style=""width:200px;"">
									<div class=""input-group-addon""><i class=""fa fa-calendar""></i></div>
									<input name=""{0}"" type=""text"" data-provide=""datepicker"" class=""form-control pull-right"" readonly />
								</div>
							</td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Text) {
							//���ذٶȱ༭��
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><textarea name=""{0}"" style=""width:100%;height:100px;"" editor=""ueditor""></textarea></td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Enum) {
							List<string> values = new List<string>();
							int quote_idx = 0;
							while(true) {
								int start = col.SqlType.IndexOf('\'', quote_idx);
								int end = quote_idx = start + 1;
								if (start == -1) break;
								while(true) {
									end = col.SqlType.IndexOf('\'', end);
									if (end == -1) break;
									int zy_c = 0;
									while (col.SqlType[end - 1] == '\\') zy_c++;
									if (zy_c % 2 == 0) break;
								}
								quote_idx = Math.Max(quote_idx, end + 1);
								values.Add(col.SqlType.Substring(start + 1, end - start - 1));
							}
							StringBuilder setenum_select = new StringBuilder();
							foreach(string v in values) {
								setenum_select.AppendFormat(@"<option value=""{0}"">{0}</option>", v);
							}
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><select name=""{0}""><option value="""">------ ��ѡ�� ------</option>{2}</select></td>
						</tr>", csUName, comment, setenum_select);
						} else {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" class=""datepicker"" style=""width:60%;"" /></td>
						</tr>", csUName, comment);
						}
					}
					sb4.Append(str_addhtml_mn);
					sb5.Append(str_addjs_mn);

					sb1.AppendFormat(@"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 class=""box-title"" id=""box-title""></h3>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">

			<form id=""form_add"">
				<div>
					<table cellspacing=""0"" rules=""all"" class=""table table-bordered table-hover"" border=""1"" style=""border-collapse:collapse;"">{0}
						<tr>
							<td width=""8%"">&nbsp</td>
							<td><input type=""submit"" value=""����"" />&nbsp;<input type=""button"" value=""ȡ��"" /></td>
						</tr>
					</table>
				</div>
			</form>

		</div>
	</div>
</div>

<script type=""text/javascript"">
(function () {{
	var ajaxs = {3};
	var data = {{}};
	var form = $('#form_add')[0];
	var geturl = '/apiv0/{2}/'; for (var a in top.mainViewNav.query) geturl += top.mainViewNav.query[a] + '/';

	function initUI() {{
		fillForm(form, data.item);{4}
		top.mainViewInit();
		$(form).submit(function () {{
			if (data.item)
				$.ajax({{ url: geturl, type: 'PUT', dataType: 'json', data: $(this).serialize(), success: function (rt) {{
					if (!rt.success) return alert(rt.message);
					top.mainViewNav.goto('./');
				}}}});
			else
				$.ajax({{ url: '/apiv0/{2}/', type: 'POST', dataType: 'json', data: $(this).serialize(), success: function (rt) {{
					if (!rt.success) return alert(rt.message);
					top.mainViewNav.goto('./');
				}}}});
			return false;
		}});
	}}

	if (geturl === '/apiv0/{2}/')
		{5}
	else{7}
		$.getJSON(geturl, function (rt) {{
			if (rt.success) data.item = rt.data.item;
			if (--ajaxs <= 0) initUI();
		}});{6}
{1}
}})();
</script>

", sb4.ToString(), sb5.ToString(), uClass_Name, wwwroo_xxx_add_html_ajaxs + 1, str_addjs_mn_initUI, 
	wwwroo_xxx_add_html_ajaxs_update == 0 ? (wwwroo_xxx_add_html_ajaxs == 0 ? "setTimeout(initUI, 1);" : "--ajaxs;") : string.Format("ajaxs -= {0};", wwwroo_xxx_add_html_ajaxs_update + 1), 
	str_addjs_mn_geturl + (wwwroo_xxx_add_html_ajaxs_update == 0 ? "" : @"
	}"), wwwroo_xxx_add_html_ajaxs_update == 0 ? "" : " {");
					loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"wwwroot\", uClass_Name, @"\add.html"), Deflate.Compress(sb1.ToString())));
					clearSb();
					#endregion
				}
				#endregion
			}

			#region BLL ItemCache.cs
			sb1.AppendFormat(CONST.BLL_Build_ItemCache_cs, solutionName);
			//loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\BLL\", basicName, @"\ItemCache.cs"), Deflate.Compress(sb1.ToString())));
			clearSb();
			#endregion
			#region BLL RedisHelper.cs
			sb1.AppendFormat(CONST.BLL_Build_RedisHelper_cs, solutionName);
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\BLL\", basicName, @"\RedisHelper.cs"), Deflate.Compress(sb1.ToString())));
			clearSb();
			#endregion
			#region Model ExtensionMethods.cs ��չ����
			sb1.AppendFormat(CONST.Model_Build__ExtensionMethods_cs, solutionName, Model_Build__ExtensionMethods_cs.ToString());
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\_ExtensionMethods.cs"), Deflate.Compress(sb1.ToString())));
			clearSb();
			#endregion

			if (isSolution) {

				#region db.xproj

				#region DBUtility/PSqlHelper.cs
				sb1.AppendFormat(CONST.DAL_DBUtility_PSqlHelper_cs, solutionName, connectionStringName, PSqlHelperMapTypeGlobally);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\DAL\DBUtility\PSqlHelper.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				sb1.AppendFormat(CONST.xproj, dbGuid, solutionName + ".db");
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\", solutionName, ".db.xproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#region project.json
				sb1.AppendFormat(CONST.Db_project_json);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\", @"project.json"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#endregion
			}

			if (isMakeAdmin) {
				#region Project Admin
				#region web.config
				sb1.AppendFormat(CONST.Admin_web_config, solutionName, connectionStringName);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"web.config"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region nlog.config
				sb1.AppendFormat(CONST.Admin_nlog_config, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"nlog.config"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region appsettings.json
				sb1.AppendFormat(CONST.Admin_appsettings_json, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"appsettings.json"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Program.cs
				sb1.AppendFormat(CONST.Admin_Program_cs, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"Program.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Startup.cs
				sb1.AppendFormat(CONST.Admin_Startup_cs, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"Startup.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				#region Controllers\BaseAdminController.cs
				sb1.AppendFormat(CONST.Admin_Controllers_BaseAdminController_cs, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"ApiV0Controllers\BaseAdminController.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				#region SysController.cs
				sb1.AppendFormat(CONST.Admin_Controllers_SysController, solutionName, string.Join(string.Empty, admin_controllers_syscontroller_init_sysdir.ToArray()));
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"ApiV0Controllers\SysController.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Admin.xproj
				sb1.AppendFormat(CONST.xproj, adminGuid, "Admin");
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"Admin.xproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region project.json
				sb1.AppendFormat(CONST.Admin_project_json, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"project.json"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region wwwroot\index.html
				sb1.AppendFormat(CONST.Admin_wwwroot_index_html, solutionName, wwwroot_sitemap);
				loc1.Add(new BuildInfo(string.Concat(CONST.adminPath, @"wwwroot\index.html"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#endregion
			}
			if (isDownloadRes) {
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\htm.zip"), Server.Properties.Resources.htm_zip));
			}

			GC.Collect();
			return loc1;
		}
	}
}
