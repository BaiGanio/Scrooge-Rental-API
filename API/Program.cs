using API;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

IConfiguration configuration =
   new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddUserSecrets(Assembly.GetExecutingAssembly(), true, reloadOnChange: true)
       .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<AppDbCtx>(opt => opt.UseSqlServer(configuration.GetConnectionString("dbconn")));
// Uncomment only when seeding the database for the first time
builder.Services.AddDbContext<AppDbCtx>(opt => opt.UseSqlServer(configuration.GetConnectionString("dbconn")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(
    new VoyagerOptions() { GraphQLEndPoint = "/graphql" },
    "/graphql-voyager"
);

// Uncomment only when seeding the database for the first time
PrepDb.PopulateDb(app);

app.Run();
