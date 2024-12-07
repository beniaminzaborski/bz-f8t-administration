var builder = DistributedApplication.CreateBuilder(args);

var postgresUsername = builder.AddParameter("postgresUsername", "postgres", secret: true);
var postgresPassword = builder.AddParameter("postgresPassword", "postgres", secret: true);
var postgresDb = builder.AddPostgres("f8t-postgres", postgresUsername, postgresPassword)
                        .WithPgAdmin()
                        .AddDatabase("f8t-admin-db");

var rabbitmqUsername = builder.AddParameter("rabbitmqUsername", "guest", secret: true);
var rabbitmqPassword = builder.AddParameter("rabbitmqPassword", "guest", secret: true);
var rabbitmq = builder.AddRabbitMQ("f8t-rabbitmq", rabbitmqUsername, rabbitmqPassword)
                      .WithManagementPlugin();

builder.AddProject<Projects.Bz_F8t_Administration_WebAPI>("f8t-admin")
    .WithEnvironment("MessageBus__UseRabbitMq", "true")
    .WithEnvironment("OpenTelemetry__UseOtlpExporter", "true")
    .WithReference(postgresDb, "Postgres")
    .WaitFor(postgresDb)
    .WithReference(rabbitmq, "RabbitMQ")
    .WaitFor(rabbitmq);

builder.Build().Run();
