### Scrooge Rental API is Azure Cloud hosted, .NET 6 application supporting GraphQL & using free SQL Server from AppHarbor. To sparkle the idea basic example of  Azure Service Bus & Azure Function is included in the demo.

Banana Cake Pop: https://scrooge-rental-api.azurewebsites.net/graphql/

GraphQL Voyager: <a href="https://scrooge-rental-api.azurewebsites.net/graphql-voyager/" target="_blank"></a>
***
# The Big Picture
- The user via Scrooge Rental Web application requests a `rent a car order`
- Since Scrooge Rental API doesn't have email service it should rely on external one to send a `rent a car order confirmation email`.
- `Email service` is notifyed via Azure Service Bus
- The user should receive actual email with data provided by Scrooge Rental Web
- Sent `rent a car order confirmation email` details are returned back to a message queue
- Azure function writes the email data from the queue in the database used by the originator of the event

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




