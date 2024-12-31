var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CarRentalApp>("carrentalapp");

builder.Build().Run();
