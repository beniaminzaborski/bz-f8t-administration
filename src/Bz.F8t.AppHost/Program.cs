var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Bz_F8t_Administration_WebAPI>("f8t-admin");

builder.Build().Run();
