using System.Net.Security;
using Jedster.Plugins.EntityFrameworkCorePSQL;
using Jedster.UseCases.Groups;
using Jedster.UseCases.Materials;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Professores.Interfaces;
using Jedster.UseCases.Students;
using Jedster.UseCases.Students.Interfaces;
using Jedster.UseCases.Teachers;
using Jedster.UseCases.Teachers.Interfaces;
using Jedster.WebApp.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();

//EFCore
builder.Services.AddDbContextFactory<JedsterContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("JedsterDB"));
});

builder.Services.AddTransient<ITeacherRepository, TeachersEfCoreRepository>();
builder.Services.AddTransient<IGroupRepository, GroupsEfCoreRepository>();
builder.Services.AddTransient<IStudentRepository, StudentsEfCoreRepository>();
builder.Services.AddTransient<IMaterialRepository, MaterialEfCoreRepository>();

builder.Services.AddTransient<IViewTeacherUseCase, ViewTeacherUseCase>();
builder.Services.AddTransient<IRegisterTeacherUsecase, RegisterTeacherUsecase>();
builder.Services.AddTransient<IEditTeacherUseCase, EditTeacherUseCase>();
builder.Services.AddTransient<IDeleteTeacherUseCase, DeleteTeacherUseCase>();
builder.Services.AddMudServices();


builder.Services.AddTransient<IViewGroupUseCase, ViewGroupUseCase>();
builder.Services.AddTransient<IRegisterGroupUseCase, RegisterGroupUseCase>();
builder.Services.AddTransient<IEditGroupUseCase, EditGroupUseCase>();
builder.Services.AddTransient<IDeleteGroupUseCase, DeleteGroupUseCase>();
builder.Services.AddMudServices();


builder.Services.AddTransient<IViewStudentsUseCase, ViewStudentsUseCase>();
builder.Services.AddTransient<IRegisterStudentsUseCase, RegisterStudentsUseCase>();
builder.Services.AddTransient<IEditStudentsUseCase, EditStudentsUseCase>();
builder.Services.AddTransient<IDeleteStudentsUseCase, DeleteStudentsUseCase>();
builder.Services.AddMudServices();


builder.Services.AddTransient<IViewMaterialUseCase, ViewMaterialUseCase>();
builder.Services.AddTransient<IRegisterMaterialUseCase, RegisterMaterialUseCase>();
builder.Services.AddTransient<IEditMaterialUseCase, EditMaterialUseCase>();
builder.Services.AddTransient<IDeleteMaterialUseCase, DeleteMaterialUseCase>();
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
