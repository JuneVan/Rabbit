AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var routePrefix = configuration["Settings:RoutePrefix"];


builder.Services.AddCatalog(configuration, routePrefix);


var app = builder.Build();
app.UseCatalog(configuration, app.Environment, routePrefix);
app.MapControllers();
app.MapHealthChecks($"{routePrefix}/health/base");
app.Run("http://*:5000"); // ����Ĭ��ָ��5000