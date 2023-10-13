using Bz.F8t.Administration.Application;
using Bz.F8t.Administration.Infrastructure;
using Bz.F8t.Administration.WebAPI;

const string serviceName = "Fott-Administration";
const string serviceVersion = "1.0.0";

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

// Add services to the container.
services
    .AddObservability(config, serviceName, serviceVersion)
    .AddApplication()
    .AddInfrastructure(config)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCustomControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
       .UseSwaggerUI();
}

app.UseHttpsRedirection()
   .UseAuthorization();

app.MapControllers();

app.MigrateDb();

app.Run();
