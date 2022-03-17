- _Scrooge Rental API is Azure Cloud hosted, .NET 6 application supporting GraphQL & using free SQL Server from AppHarbor_
- _To sparkle the idea basic example of  Azure Service Bus & Azure Function is included in the demo_

***
# The Big Picture
- The user `John Doe` wants to rent a car for the weekend via Scrooge Rental Web application. Steps allowed:
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

<a href="https://raw.githubusercontent.com/BaiGanio/scrooge-rental-api/master/Docs/scrooge_rental_microservices.png" target="_blank">
    <img src="https://raw.githubusercontent.com/BaiGanio/scrooge-rental-api/master/Docs/scrooge_rental_microservices.png" width="100%" alt="scrooge-rental"/>
</a>

***
# Getting Started (local setup)
---
- Navigate to `API -> appsentings.json` & update `dbconn` by your own preference
- Navigate to `API -> Properties -> launchSentings.json` & update `sslPort` to be `44381`
- Upon `API` folder run:
  - `update-database` - this will create the db schema
  - then `dotnet build`
  - if all goes fine then execute `dotnet run`
- Seeding & manipulating initial data is achieved by uncommented two lines in `Program.cs`
  - `builder.Services.AddDbContext<AppDbCtx>(opt => opt.UseSqlServer(configuration.GetConnectionString("dbconn")));`
  - `PrepDb.PopulateDb(app);`
  - also can change the pre-populated collections in `PrepDb.cs` by own preferences
- Try it out at local env
  - Banana Cake Pop: https://scrooge-rental-api.azurewebsites.net/graphql/
  - GraphQL Voyager: <a href="https://scrooge-rental-api.azurewebsites.net/graphql-voyager/" target="_blank">https://scrooge-rental-api.azurewebsites.net/graphql-voyager/</a> 
***
# Qurious of live demo?
- Banana Cake Pop: https://scrooge-rental-api.azurewebsites.net/graphql/
- GraphQL Voyager: <a href="https://scrooge-rental-api.azurewebsites.net/graphql-voyager/" target="_blank">https://scrooge-rental-api.azurewebsites.net/graphql-voyager/</a>
- Use the queries from the `Getting Started (local setup)` section
- Use real email if you want to receive example email
- Use `Scrooge Rental` web application keeping in mind the rules for using real email if intrested of the email template. Can change the name either for fun ;)
***
# How to?
- Include Azure Service Bus (tutorial)
- Trigger Azure Function (tutorial)
***




