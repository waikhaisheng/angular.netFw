# angular.netFw
angular .netFramework

# Database
Microsoft SQL Server
>Create Database AngularNetFw


# Backend
Web Api .Net Framework 4.7.2
### NetFramework
Web Api
>nuget install "Microsoft.AspNet.WebApi.Cors"
#### Controllers
CustomerController.cs
### Common
Class Library (.Net Framework)
### Models
Class Library (.Net Framework)
### Database
Class Library (.Net Framework)
>nuget install "System.Configuration.ConfigurationManager"
### Services
Class Library (.Net Framework)

### UnitTestNetFramework
Setup HttpServer
>nuget install "Microsoft.AspNet.WebApi.Core"

# Frontend
nebular angular framework "https://github.com/akveo/ngx-admin"

## Install Package
>npm install --save-dev @angular-devkit/build-angular

## Start angular
>ng serve -o

Generate component
>ng g c \pages\entities\customer\profile --flat 

Customer Profile
Id, Name, Phone, Email, Address, Mailing Address

Generate Model
customer-profile.model.ts
Id, Name, Phone, Email, Address, Mailing Address

Generate Service
customer.service.ts