using Backend.Application;
using Backend.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();

    var connectionString = builder.Configuration.GetConnectionString("Connection");
    builder.Services
        .AddApplication()
        .AddInfrastructure(connectionString);
};

var app = builder.Build();
{
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
