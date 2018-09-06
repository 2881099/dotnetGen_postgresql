﻿# .NETCore + PostgreSQL 生成器


作者面向web应用开发13年，在项目实践与学习中去旧换新，吸取优点，从高质量、强规范、快速开发方向累积，形成生成器工具减少项目后端开发难度。

> navicat 模型工具创建和管理ER图，从数据库导入/同步结构到数据库，后使用本生成器一键同步c#实体，以及各种规范的花式和你想象不到的语法，支持缓存，支持数据库99%类型，挖掘数据库特性，避免过多重复劳动和不规范、不健壮的代码。

优势：
 * 1、根据主键、唯一键、外键（1对1，1对多，多对多）生成功能丰富的数据库 SDK；
 * 2、严格把控数据库，避免随意创建表或字段，有标准的ER图数据库规范；
 * 3、统一规范数据库操作类与方法(相比EF太随意的用法好管理很多)，一条心堆业务；
 * 4、优化每一个细节，决不允许低级错误干扰我们的业务逻辑(相比ORM，生成的代码更专注)；

适合场境：
 * 1、新项目开发，只管设计数据ER图，无须考虑db相关代码；
 * 2、老项目数据库访问方式不堪入目的，表数量越多收益越大；

[下载生成器winform客户端](https://files.cnblogs.com/files/kellynic/%E7%94%9F%E6%88%90%E5%99%A8pgsql.zip)，或者安装命令工具 dotnet tool install -g GenPg

新人指导教学链接：https://pan.baidu.com/s/1gx8ClLF7AzL06j2D43kBWQ 密码：lr6n

学习QQ群：8578575

----

## 在已有的项目上生成

```shell
dotnet new mvc
GenPg 数据库ip[:5432] -U 登陆名 -P 密码 -D 数据库1 -N 命名空间
```

## 生成完整的模块化解决方案

```shell
GenPg 数据库ip[:5432] -U 登陆名 -P 密码 -D 数据库1 -N 命名空间 -R -S -A
```

dotnetGen 保持相同的开发与使用习惯，现实了面向 mysql、SQLServer、PostgreSQL 三种数据库快速开发，也可混合使用。

| <font color=gray>功能对比</font> | [dotnetGen_mysql](https://github.com/2881099/dotnetGen_mysql) | [dotnetGen_sqlserver](https://github.com/2881099/dotnetGen_sqlserver) | [dotnetGen_postgresql](https://github.com/2881099/dotnetGen_postgresql) |
| ----------------: | --------------: | -------------------: | -------------------: |
| windows            | √ | √ | √ |
| linux              | √ | √ | √ |
| 连接池             | √ | √ | √ |
| 事务               | √ | √ | √ |
| 多数据库            | √ | - | - |
| 表                 | √ | √ | √ |
| 表关系(1对1)        | √ | √ | √ |
| 表关系(1对多)       | √ | √ | √ |
| 表关系(多对多)      | √ | √ | √ |
| 表主键             | √ | √ | √ |
| 表唯一键           | √ | √ | √ |
| 存储过程           | - | √ | - |
| 视图               | √ | √ | √ |
| 软删除             | √ | √ | √ |
| 类型映射           | √ | √ | √ |
| 枚举               | √ | - | √ |
| 自定义类型         | - | - | √ |
| gis               | √ | - | √ |
| 数组               | - | - | √ |
| 字典               | - | - | √ |
| xml               | - | - | - |
| json              | - | - | √ |
| 缓存               | √ | √ | √ |
| 命令行生成         | √ | √ | √ |
| RESTful           | √ | √ | √ |
| 后台管理功能       | √ | √ | √ |



# 模块化框架目录结构介绍

## Module

	所有业务接口约定在 Module 划分并行开发，互不依赖

	Module/Admin
	生成的后台管理模块，http://localhost:5001/module/Admin 可访问

	Module/Test
	生成的测试模块

## WebHost

	WebHost 编译的时候，会将 Module/* 编译结果复制到当前目录
	WebHost 只当做主引擎运行时按需加载相应的 Module
	WebHost 依赖 npm ，请安装 node，并在目录执行 npm install
	WebHost 依赖 gulp-cli，请执行全局安装 npm install --global gulp-cli
	运行步骤：
    1、打开 vs 右击 Module 目录全部编译；
    2、cd WebHost && npm install && dotnet build && dotnet run

## Infrastructure

	Module 里面每个子模块的依赖所需

#### xx.db

	包含一切数据库操作的封装
	xx.Model(实体映射)
	xx.BLL(静态方法封装)
	xx.DAL(数据访问)
	生成名特征取数据库名首字母大写(如: 表 test 对应 xx.Model.TestInfo、xx.BLL.Test、xx.DAL.Test)

	数据库设计命名习惯：所有命名(username, stats_click)、外键字段(user_id)
	仅支持主键作为外键，不支持组合字段，不支持唯一键作为外键
	修改数据库后，双击“./GenPg只更新db.bat”可快速覆盖，所有类都使用 partial，方便扩展亦不会被二次生成覆盖

# 数据库相关方法

## 添加记录

```csharp
// 如有 create_time 字段并且类型为日期，内部会初始化
TestInfo newitem1 = Test.Insert(Title: "添加的标题", Content: "这是一段添加的内容");
TestInfo newitem2 = Test.Insert(new TestInfo { Title = "添加的标题", Content = "这是一段添加的内容" });
```

## 添加记录(批量)

```csharp
List<TestInfo> newitems1 = Test.Insert(new [] {
	new TestInfo { Title = "添加的标题1", Content = "这是一段添加的内容1" },
	new TestInfo { Title = "添加的标题2", Content = "这是一段添加的内容2" }
});
```

## 更新记录

```csharp
// 更新 id = 1 所有字段
Test.Update(new TestInfo { Id: 1, Title = "添加的标题", Content = "这是一段添加的内容", Clicks = 1 });
// 更新 id = 1 指定字段
Test.UpdateDiy(1).SetTitle("修改后的标题").SetContent("修改后的内容").SetClicks(1).ExecuteNonQuery();
// update 表名 set clicks = clicks + 1 where id = 1
Test.UpdateDiy(1).SetClicksIncrement(1).ExecuteNonQuery();
// 使用实体层修改
new TestInfo { Id = 1 }.UpdateDiy.SetClicksIncrement(1).ExecuteNonQuery();
```

## 更新记录(批量)

```csharp
//先查找 clicks 在 0 - 100 的记录
List<TestInfo> newitems1 = Test.Select.WhereClicksRange(0, 100).ToList();
// update 表名 set clicks = clicks + 1 where id in (newitems1所有id)
newitems1.UpdateDiy().SetClicksIncrement(1).ExecuteNonQuery();
```

> 警告：批量更新的方法，在事务中使用会导致死锁

## 删除记录

```csharp
// 删除 id = 1 的记录
Test.Delete(1);
```

## 按主键/唯一键获取单条记录

> appsettings可配置缓存时间，以上所有增、改、删都会删除缓存保障同步

```csharp
//按主键获取
UserInfo user1 = User.GetItem(1);
//按唯一键
UserInfo user2 = User.GetItemByUsername("2881099@qq.com");
// 返回 null 或 UserInfo
```

## 查询(核心)

```csharp
//BLL.表名.Select 是一个链式查询对象，几乎支持所有查询，包括 group by、inner join等等，最终 ToList ToOne Aggregate 执行 sql
List<UserInfo> users1 = User.Select.WhereUsername("2881099@qq.com").WherePassword("******").WhereStatus(正常).ToList();
//返回 new List<UserInfo>() 或 有元素的 List，永不返回 null

//返回指定列，返回List<元组>
var users2 = User.Select.WhereStatus(正常).Aggregate<(int id, string title)>("id,title");

//多表查询，只返回 a 表字段
var users3 = User.Select.From<User_group>("b").Where("a.group_id = b.id").ToList();

//join查询，返回 a, b 表字段 ，b 表结果填充至 a.Obj_user_group 对象，类似 ef.Include
var users4 = User.Select.InnerJoin<User_group>("b", "a.group_id = b.id").ToList();

//分组查询
var users5 = User.Select.GroupBy("group_id").Aggregate<(int groupId, int count)>("group_id, count(1)");

//等等...
```

## 事务

```csharp
//错误会回滚，事务内支持所有生成的同步方法（不支持生成对应的Async方法）
var user = User.GetItem(1);
PSqlHelper.Transaction(() => {
	if (user.UpdateDiy.SetAmountIncrement(-num).Where("amount > {0}", num).ExecuteNonQuery() <= 0)
		throw new Exception("余额不足");

	var order = user.AddOrder(Amount: 1, Count: num, Count_off: num);
});
```

## 缓存

1、根据主键、唯一键缓存

BLL GetItem、GetItemBy唯一键，使用了默认缓存策略180秒，用来缓存一条记录，db 层自动维护缓存同步，例如：

```csharp
//只有第一次查询了数据库，后面99次读取redis的缓存值
UserInfo u;
for (var a = 0; a < 100; a++)
	u = User.GetItemByUsername("2881099@qq.com");

//执行类似以下的数据变动方法，会删除redis对应的缓存
u.UpdateDiy.SetLogin_time(DateTime.Now).ExecuteNonQuery();
```

2、缓存一个查询结果

BLL Select.ToList(10, "cache_key")，将查询结果缓存10秒，需要手工删除redis对应的键


# 生成规则

## 不会生成

* 没有主键，不会生成 增、改、删 方法

## 特别规则

* 字段类型 point，会生成
	> 表.Select.Where字段MbrContains(查找地理位置多少米范围内的记录，距离由近到远排序)
* 字段类型 string 相关并且长度 <= 300，会生成
	> 表.Select.Where字段Like
* 字段类型 数组，会生成
	> 表.Select.Where字段Any、表.UpdateDiy(1).Set字段Join
* 字段类型 jsonb，会生成
	> 表.Select.Where字段Contain

	> 表.Select.Where字段ContainKey

	> 表.Select.Where字段ContainKeys
	
	> 表.Select.Where字段ContainKeysAny
* 字段类型 hstore，会生成
	> 表.Select.Where字段Contain

	> 表.Select.Where字段ContainKey

	> 表.Select.Where字段ContainKeys

	> 表.Select.Where字段ContainKeysAny
* 100%的数据类型被支持