# **Angular.NetFramework**
Frontend `Angular`, Backend `.NetFramework`, for CRUD.

# **Database**
>Microsoft SQL Server

- Created database `AngularNetFw`, table `CustomerProfile`, fields `Id`, `Name`, `Phone`, `Email`, `Address`, `MailingAddress`, `Created`, `Updated`.
- Created store procedure, `uspCustomerProfileList`, `uspCustomerProfileAdd`, `uspCustomerProfileUpdate`, `uspCustomerProfileDelete` for CRUD operations.

# **Backend Projects**
### **NetFramework**
>Web Api .Net Framework 4.7.2
- Packages installed on nuget `Microsoft.AspNet.WebApi.Cors` for CORS, `Newtonsoft.Json` for json convertion, `Swashbuckle` for swagger.
- Controllers, `CustomerController` for CRUD customer profile data.
- Filters, `ApiUnhandledExceptionFilterAttribute` handles exception on request. `ApiCorsPolicyAttribute` enables cros call. `ApiBaseActionFilter` validates model state.
- Base response model `ResponseBase.cs` used on every response.
### **Common**
>Class Library (.Net Framework 4.7.2)
- Created Helpers for DB null data handle. Utils for validate on email and phone.
### **Models**
>Class Library (.Net Framework 4.7.2)
- Collection of models for these projects use. 
### **Database**
>Class Library (.Net Framework 4.7.2)
- nuget installed `System.Configuration.ConfigurationManager` for store connection string. Database context for customer profile, CRUD store procedures used on here. Create methods `GetCustomerProfiles` uses retrieve list customer profile. `AddCustomerProfile`, `UpdateCustomerProfile`, `DeleteCustomerProfile` methods for add, update, delete respectively.
### **Services**
>Class Library (.Net Framework)
- `CustomerService` class for CRUD. Validation held on here.

## **UnitTest**
### **UnitTestCommon**
>UnitTest Project (.Net Framework 4.7.2)
- Test common methods.
### **UnitTestDatabase**
>UnitTest Project (.Net Framework 4.7.2)
- Test methods related to database.
### **UnitTestService**
>UnitTest Project (.Net Framework 4.7.2)
- Test service methods.
### **UnitTestNetFramework**
>UnitTest Project (.Net Framework 4.7.2)
- Setup HttpServer by installed nuget package `Microsoft.AspNet.WebApi.Core` for test request call.
- Test request on `CustomerController`. Get, Post, Put, Delete for url `api/Customer/Profile`.

# **Frontend**
- ngx-admin angular framework from "https://github.com/akveo/ngx-admin" used for frontend.
- Install Package `npm install --save-dev @angular-devkit/build-angular`.
- Command start project `ng serve -o`.
- Command to generate component customer profile `ng g c \pages\entities\customer\profile --flat`. Smart table layout used on UI display. Validation fields check before submit request. Alert message prompts for success, warning, danger status.
- Customer profile model `customer-profile.model.ts` contains Id, Name, Phone, Email, Address, Mailing Address
- Generate service component `customer.service.ts` for call web api to carry out CRUD operations.
- Enum `ng-alert-status-enum.ts` for alert message uses.