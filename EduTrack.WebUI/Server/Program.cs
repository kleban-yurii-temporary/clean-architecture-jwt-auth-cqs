using EduTrack.Application;
using EduTrack.Infrastracture;
using EduTrack.WebUI.Server;
using EduTrack.WebUI.Server.Common.Mapping;
using EduTrack.WebUI.Server.Errors;
using EduTrack.WebUI.Server.Swagger;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Define the list of cultures your app will support 
    var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("uk-UA")
                };

    // Set the default culture 
    options.DefaultRequestCulture = new RequestCulture("uk-UA");
    options.DefaultRequestCulture.Culture.NumberFormat.CurrencySymbol = supportedCultures[1].NumberFormat.CurrencySymbol;

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>() {
                 new QueryStringRequestCultureProvider()
                };
});

builder.Services.AddCors(options =>
    {
        // this defines a CORS policy called "default"
        options.AddPolicy("default", policy =>
        {
            policy.WithOrigins("https://localhost:44303", "https://*.zoom.us")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "EduTrack Project API",
        Description = "Ostroh Academy Education Process Tracking Application",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Email = "yuriy.kleban@oa.edu.ua",
            Name = "Yurii Kleban",
            Url = new Uri("https://kleban.page")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

    options.SchemaFilter<ExampleSchemaFilter>();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseExceptionHandler("/api/error");

/*app.Map("/api/error", (HttpContext httpContext) =>
{
    Exception? ex = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem();
});*/

app.UseCors("default");
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
