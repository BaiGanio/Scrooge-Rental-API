### Scrooge Rental API is Azure Cloud hosted, .NET 6 application supporting GraphQL & using free SQL Server from AppHarbor. To sparkle the idea basic example of  Azure Service Bus & Azure Function is included in the demo.

Banana Cake Pop: https://scrooge-rental-api.azurewebsites.net/graphql/

GraphQL Voyager: <a href="https://scrooge-rental-api.azurewebsites.net/graphql-voyager/" target="_blank">https://scrooge-rental-api.azurewebsites.net/graphql-voyager/</a>
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
- The user `John Doe` should receive actual email by that time
- Azure function is triggered. Steps allowed:
  - receives `rent a car order confirmation email sent` details returned back in the Azure Service Bus message queue
  - writes the data in the database used by the originator of the event

<a href="https://raw.githubusercontent.com/BaiGanio/scrooge-rental-api/master/Docs/scrooge_rental_microservices.png" target="_blank">
    <img src="https://raw.githubusercontent.com/BaiGanio/scrooge-rental-api/master/Docs/scrooge_rental_microservices.png" width="100%" alt="scrooge-rental"/>
</a>

***
# Getting Started (local setup)
---
   - Navigate to `API` folder and run 
   ```
   dotnet build
   ```
   - If all is fine, run:
   ```
   dotnet run
   ```
   
---




