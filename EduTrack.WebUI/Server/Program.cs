using EduTrack.Application;
using EduTrack.Infrastracture;
using EduTrack.WebUI.Server;
using EduTrack.WebUI.Server.Common.Mapping;
using EduTrack.WebUI.Server.Errors;
using EduTrack.WebUI.Server.Swagger;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

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

app.UseExceptionHandler("/api/error");

/*app.Map("/api/error", (HttpContext httpContext) =>
{
    Exception? ex = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem();
});*/


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

//app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
