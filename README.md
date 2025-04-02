# 基本
1. 採用 .NET Core 8 框架
2. 採用 SQL Server 資料庫(Local)
3. 採用 Entity Framework Core ORM 套件
4. 採用 NLog 套件(另搭配 Middleware 設計)

# 專案
- Template.WebApi：API服務
- Template.BussinessLogic：商業邏輯層
- Template.DataAccess：資料存取層(另搭配 UnitOfWork 和 Repository pattern 設計)
