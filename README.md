- ### _Scrooge Rental API is Azure Cloud hosted .NET 6 application supporting GraphQL_
- ### _Using free SQL Server from AppHarbor_
- ### _To sparkle the idea basic demo of Azure Service Bus & Azure Function is included in this example_

***
# `The Big Picture`
<a href="https://raw.githubusercontent.com/BaiGanio/scrooge-rental-api/master/Docs/scrooge_rental_microservices.png" target="_blank">
    <img src="https://raw.githubusercontent.com/BaiGanio/scrooge-rental-api/master/Docs/scrooge_rental_microservices.png" width="100%" alt="scrooge-rental"/>
</a>

***
# `The Story`
- `John Doe` wants to rent a car for the weekend via Scrooge Rental Web application. Steps allowed:
  - get all cars available for renting
  - get all self created rent-orders
  - create a `rent a car order`
- Scrooge Rental API doesn't have own email service & should rely on external one. Steps allowed: 
  - add `rent a car order` details in own database
  - send a `rent a car order confirmation email` event to a Azure Service Bus mesage queue
- Email service is notifyed via Azure Service Bus. Steps allowed:
  - bake the email template upon received data
  - send email to the user `John Doe`
  - `rent a car order confirmation email sent` details are returned back to Azure Service Bus message queue
- The user `John Doe` should receive actual confirmation email by that time with included vizualisations
- Azure function is triggered. Steps allowed:
  - receives `rent a car order confirmation email sent` details returned back in the Azure Service Bus message queue
  - writes the data in the database used by the originator of the event
***
# `Getting Started (local setup)`
---
- Navigate to `API -> appsentings.json` & update `dbconn` by your own preference
- Navigate to `API -> Properties -> launchSentings.json` & update `sslPort` to be `44381`
- Upon `API` folder run:
  - `update-database` - this will create the db schema
  - then `dotnet build`
  - if all goes fine then execute `dotnet run`
- SQL Server setup, EF migrations & seeding manipulations can be achieved by reading our wiki page 
  - <a href="https://github.com/BaiGanio/scrooge-rental-api/wiki/Set-up-SQL-Server" target="_blank">Set up SQL Server, execute migrations & seed initial data</a>    
- Try it out at local env
  - GraphQL Voyager: <a href="https://github.com/BaiGanio/scrooge-rental-api/wiki/Set-up-SQL-Server" target="_blank">https://localhost:44381/graphql-voyager/</a> 
  - Open Banana Cake Pop at https://localhost:44381/graphql/ & execute the following query:
  ```
  query{
    cars{
      id
      maker
      maker
      year
      fuelType
      imageUrl
    }
  }
  ```
***
# `Qurious of live demo?`
- GraphQL Voyager: <a href="https://scrooge-rental-api.azurewebsites.net/graphql-voyager/" target="_blank">https://scrooge-rental-api.azurewebsites.net/graphql-voyager/</a>
- Open Banana Cake Pop at https://scrooge-rental-api.azurewebsites.net/graphql/ & execute the following mutation:
  ```
  TODO: add mutation here
  ```
- Use real email if you want to receive the actual email
- Use `Scrooge Rental` web application keeping in mind the rules for using real email if intrested of the email template. Can change the name either for fun ;)
***
# `How to?`
- Set up Azure Service Bus (<a href="https://github.com/BaiGanio/scrooge-rental-api/wiki/Set-up-Azure-Service-Bus" target="_blank">wiki tutorial</a>)
- Trigger Azure Function (<a href="https://github.com/BaiGanio/scrooge-rental-api/wiki/Trigger-Azure-Function-via-Azure-Service-Bus" target="_blank">wiki tutorial</a>)
***




