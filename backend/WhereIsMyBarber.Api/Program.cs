using WhereIsMyBarber.Api.Filters;
using WhereIsMyBarber.Application;
using WhereIsMyBarber.Infra;
using WhereIsMyBarber.Infra.Extensions;
using WhereIsMyBarber.Infra.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddMvc(opt => opt.Filters.Add<ExceptionFilter>());

builder.Services.AddApplication();
builder.Services.AddInfra(builder.Configuration);

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
MigrateDatabase();
app.Run();

void MigrateDatabase()
{
    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    DatabaseMigration.Migrate(builder.Configuration.ConnectionString(), serviceScope.ServiceProvider);
}
