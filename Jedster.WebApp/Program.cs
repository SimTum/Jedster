using Jedster.Plugins.InMemory;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Professores;
using Jedster.UseCases.Professores.Interfaces;
using Jedster.UseCases.Teachers;
using Jedster.WebApp.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();

builder.Services.AddTransient<IViewTeacherUseCase, ViewTeacherUseCase>();
builder.Services.AddTransient<IRegisterTeacherUsecase, RegisterTeacherUsecase>();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
