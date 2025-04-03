# 基本
1. 採用 .NET Core 8 框架
2. 採用 SQL Server 資料庫(Local)
3. 採用 Entity Framework Core ORM 套件

# 專案(三層式架構)
- Template.WebApi：應用層(API服務)
- Template.BussinessLogic：商業邏輯層
- Template.DataAccess：資料存取層(另搭配 UnitOfWork 和 Repository pattern 設計)
- Template.Infra：基礎設施層
- Template.Database：資料庫專案