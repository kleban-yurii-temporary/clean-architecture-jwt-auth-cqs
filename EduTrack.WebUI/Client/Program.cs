using Blazored.LocalStorage;
using EduTrack.WebUI.Client;
using EduTrack.WebUI.Client.HttpServices;
using EduTrack.WebUI.Client.HttpServices.Authentification;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<HttpAuthenticationService>();
builder.Services.AddScoped<HttpTeacherCoursesService>();
builder.Services.AddScoped<HttpInviteService>();
builder.Services.AddScoped<HttpCourseTypeService>();
builder.Services.AddScoped<HttpStudentRecordService>();
builder.Services.AddScoped<HttpSubGroupService>();
builder.Services.AddScoped<HttpTeacherOtherCoursesService>();
builder.Services.AddScoped<HttpLessonService>();
builder.Services.AddScoped<TokenManagerService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzcyOTI3QDMyMzAyZTMzMmUzMEtNUU81MmxwMmt5S1Mzd2ZjTkVFTlpNMmNvdCtJMGwzSlA5VFpDejYzeEk9");

await builder.Build().RunAsync();
