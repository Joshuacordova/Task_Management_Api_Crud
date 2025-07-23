# Task_Management_Api_Crud

# Teck stack

- asp.net web API 2 (.NET Framework 4.8)
- Dapper + Dapper.Contrib (Micro ORM)
- MySql
- AutoFac (for Dependency Injection)
- Postman or Thunder (for API testing)

Clean Architecture Strucuture

- Project follows **Clean Architecture principles**

- **Domain Layer**: Core business logic and entities
- **Application Layer**: Interfaces, services, use cases (DTOs, validations)
- **Infrastructure Layer**: Data access (Dapper), external services
- **API Layer**: ASP.NET Web API controllers and filters

Host - http://localhost:4300

API Calls

- GetAll
  - use GET Request method
    http://localhost:4300/api/task/GetAll?pageNumber=0&pageSize=10
- Create

  - use POST Request method
    http://localhost:4300/api/task/Create

- Update

  - use PUT Request method
    http://localhost:4300/api/task/Update

- Delete

  - use DELETE Request method
    http://localhost:4300/api/task/Delete?Id=1

- GetAllByStatus

  - use GET Request method
    http://localhost:4300/api/task/GetAllByStatus?status=0&pageNumber=0&pageSize=10

- GetByStatus

  - use GET Request method
    http://localhost:4300/api/task/GetByStatus?status=0

- GetById
  - use GET Request method
    http://localhost:4300/api/task/GetById?Id=3
