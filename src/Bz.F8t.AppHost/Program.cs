var builder = DistributedApplication.CreateBuilder(args);

var postgresDb = builder.AddPostgres("f8t-postgres")
                        .AddDatabase("f8t-admin-db");

//var appInsights = builder.AddAzureApplicationInsights("f8t-appinsights");

var jaeger = builder.AddContainer("jaeger", "jaegertracing/all-in-one")
    .WithHttpEndpoint(16686, targetPort: 16686, name: "jaegerPortal")
    .WithHttpEndpoint(6831, targetPort: 6831, name: "jaegerDefaultEndpoint")
    .WithHttpEndpoint(4317, targetPort: 4317, name: "jaegerEndpoint");

var serviceBus = builder.AddAzureServiceBus("f8t-servicebus");

builder.AddProject<Projects.Bz_F8t_Administration_WebAPI>("f8t-admin")
    .WithReference(postgresDb, "Postgres")
    .WaitFor(postgresDb)
    //.WithReference(jaeger)
    .WaitFor(jaeger)
    /*.WithReference(appInsights)
    .WaitFor(appInsights)
    .WithReference(serviceBus)
    .WaitFor(serviceBus)*/;

builder.Build().Run();
