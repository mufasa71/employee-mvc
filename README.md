## Employee Management System Sample V 1.0


### Introduction

The intent of this system is to provide access to employee data based on Entity Framework. It:
* Is a complete MVC solution based on Microsoft MVC 3 Framework
* Allow to view, create and modify employees
* Generate and download salary report 

### Bug reports

If you discover a problem with the system, I would like to know about it. However, I ask that you please to submit a bug report:
https://github.com/mukimov/employee-mvc/wiki/Bug-reports

### Usage

EMS works with 
* Microsoft ASP.NET MVC3 Framework v3.02 
* Microsoft .NET Framework v4.03
* Microsoft ADO.NET Entity Framework 4.1 RC
* Microsoft C#
* Microsoft SQL Server 2008 v10
* Microsoft Visual Studio 2010
* Kickstarter Ultra–Lean HTML Building Blocks for Rapid Website Production
* HTML5 Boilerplate

TDD and tests are working with
* Dependency Injection Ninject
* Moq
* NUnit

To start using EMS execute in Database\employees_management_sql_query.sql SQL script

Please make sure that connection string is compatible with yours environment.

```console
<connectionStrings>
    <add name="EFDbContext" connectionString="Data Source=.\SQLEXPRESS; Initial Catalog=EmployeesManagement; Integrated Security=SSPI" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
 
### Screenshots
![Index page](/mukimov/employee-mvc/Screenshots/IndexPage.png "Index page")
![Edit page](/mukimov/employee-mvc/Screenshots/EditPage.png "Edit page")


