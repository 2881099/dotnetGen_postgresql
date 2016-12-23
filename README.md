# dotnetGen_postgresql
.NETCore + PostgreSQL 生成器

开发初期，它可以选择数据库表创建项目；

开发阶段，它可以即时更新项目中数据层 SDK，提供业务开发基础；

类型映射参考 http://www.postgres.cn/docs/9.4/datatype.html 开发；

优势：
 * 1、根据主键、唯一键、外键（1对1，1对多，多对多）生成功能丰富的数据库 SDK；
 * 2、避免随意创建表，严格把控数据库，有标准的ER图；
 * 3、统一规范数据库操作类与方法，一条心堆业务；

部署：
 * 运行环境：.net 2.0+
 * 安装 ServerWinService 服务，启动前设置服务端口
 * 配置 MakeCode 服务器，向开发者发送 MakeCode 生成器

> MakeCode 已支持命令行，输入 cmd -> makecode ?

> C:/Users/Administrator/Desktop/生成器PgSql/MakeCode 10.17.65.88:5432 -U postgres -P 123456 -D 数据库 -N 项目名 -O "X:/git.oa.com/xteam/dyschool/"

> 开发过程中，修改表后执行命令可以快速生成SDK；

共勉，一起学习QQ群：8578575
