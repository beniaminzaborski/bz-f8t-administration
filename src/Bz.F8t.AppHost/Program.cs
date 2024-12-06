var builder = DistributedApplication.CreateBuilder(args);

var postgresDb = builder.AddPostgres("f8t-postgres")
                        .AddDatabase("f8t-admin-db");

var rabbitmq = builder.AddRabbitMQ("f8t-rabbitmq");

//var appInsights = builder.AddAzureApplicationInsights("f8t-appinsights");

var serviceBus = builder.AddAzureServiceBus("f8t-servicebus");

builder.AddProject<Projects.Bz_F8t_Administration_WebAPI>("f8t-admin")
    .WithReference(postgresDb, "Postgres")
    .WaitFor(postgresDb)
    .WithReference(rabbitmq, "RabbitMQ")
    .WaitFor(rabbitmq)
    /*.WithReference(appInsights)
    .WaitFor(appInsights)
    .WithReference(serviceBus)
    .WaitFor(serviceBus)*/;

builder.Build().Run();
