var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("f8t-postgres");

var appInsights = builder.AddAzureApplicationInsights("f8t-appinsights");

var serviceBus = builder.AddAzureServiceBus("f8t-servicebus");

builder.AddProject<Projects.Bz_F8t_Administration_WebAPI>("f8t-admin")
    .WithReference(postgres)
    .WaitFor(postgres)
    .WithReference(appInsights)
    .WaitFor(appInsights)
    .WithReference(serviceBus)
    .WaitFor(serviceBus);

builder.Build().Run();
