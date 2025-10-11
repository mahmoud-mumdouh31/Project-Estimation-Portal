
//namespace ProjectEstimationPortal
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services
//    .AddAPI()
//    .AddApplication()
//    .AddInfrastructure(builder.Configuration)
//    .AddDomain()
//    .AddLocalizationServices()
//    .AddCachingService();

//builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

//app.UseLocalization();
//app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
    c.SwaggerEndpoint("public/swagger.json", "EGC.GIZ Public");
    c.SwaggerEndpoint("admin/swagger.json", "EGC.GIZ Admin");
    c.SwaggerEndpoint("shared/swagger.json", "EGC.GIZ Shared");
});

app.UseCors("AllowAll");

app.UseStaticFiles();

//app.UseHangfireDashboard("/hangfire");

app.UseHttpsRedirection();

app.UseExceptionHandler();
//app.UseSerilogRequestLogging(config =>
//{
//    config.IncludeQueryInRequestPath = true;
//    config.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
//    {
//        diagnosticContext.Set("ApplicationName", "EGC.GIZ");
//    };
//});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
