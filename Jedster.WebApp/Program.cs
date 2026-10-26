using System.Net.Security;
using Jedster.CoreBuisness;
using Jedster.Plugins.EntityFrameworkCorePSQL;
using Jedster.Plugins.InMemory;
using Jedster.UseCases.Attendances;
using Jedster.UseCases.Core.Contracts;
using Jedster.UseCases.Core.Contracts.Interfaces;
using Jedster.UseCases.Core.Scheduling;
using Jedster.UseCases.Core.TextbookTypes;
using Jedster.UseCases.Groups;
using Jedster.UseCases.Lessons;
using Jedster.UseCases.Materials;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Professores.Interfaces;
using Jedster.UseCases.Students;
using Jedster.UseCases.Students.Interfaces;
using Jedster.UseCases.Teachers;
using Jedster.UseCases.Teachers.Interfaces;
using Jedster.WebApp.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
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

//Blazor Authentication State
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingServerAuthenticationStateProvider>();
// 2. Identity & Cookies
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<JedsterUser>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<JedsterContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// 3. Authorization Policies (Hierarchical or Exact)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy("RequireTeacher", policy => policy.RequireRole(UserRoles.Teacher, UserRoles.Admin));
    options.AddPolicy("RequireStudent", policy => policy.RequireRole(UserRoles.Student));
});

builder.Services.AddTransient<ITeacherRepository, TeachersEfCoreRepository>();
builder.Services.AddTransient<IGroupRepository, GroupsEfCoreRepository>();
builder.Services.AddTransient<IStudentRepository, StudentsEfCoreRepository>();
builder.Services.AddTransient<IMaterialRepository, MaterialEfCoreRepository>();
builder.Services.AddTransient<IAttendanceRepository, AttendanceEfCoreRepository>();
builder.Services.AddTransient<ILessonsRepository, LessonsEfCoreRepository>();
builder.Services.AddTransient<IContractRepository, ContractsEfCoreRepository>();
builder.Services.AddTransient<ITextBookTypesRepository, TextBookTypesEFCoreRepository>();

// builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();
// builder.Services.AddSingleton<IGroupRepository, GroupRepository>();
// builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
// builder.Services.AddSingleton<IMaterialRepository, MaterialRepository>();
// builder.Services.AddSingleton<ILessonsRepository, LessonRepository>();
// builder.Services.AddSingleton<IAttendanceRepository, AttendanceRepository>();

builder.Services.AddTransient<IViewContractUseCase, ViewContractUseCase>();
builder.Services.AddTransient<IAddContractUseCase, AddContractUseCase>();
builder.Services.AddTransient<IEditContractUseCase, EditContractUseCase>();
builder.Services.AddTransient<IDeleteContractUseCase, DeleteContractUseCase>();

builder.Services.AddTransient<IViewTextbookTypesUseCase, ViewTextbookTypesUseCase>();
builder.Services.AddTransient<IEditTextBookTypeUseCase, EditTextBookTypeUseCase>();
builder.Services.AddTransient<IRegisterTextBookTypeUseCase, RegisterTextBookTypeUseCase>();
builder.Services.AddTransient<IDeleteTextBookTypeUseCase, DeleteTextBookTypeUseCase>();

builder.Services.AddTransient<IViewTeacherUseCase, ViewTeacherUseCase>();
builder.Services.AddTransient<IRegisterTeacherUsecase, RegisterTeacherUsecase>();
builder.Services.AddTransient<IEditTeacherUseCase, EditTeacherUseCase>();
builder.Services.AddTransient<IDeleteTeacherUseCase, DeleteTeacherUseCase>();

builder.Services.AddTransient<IViewGroupUseCase, ViewGroupUseCase>();
builder.Services.AddTransient<IRegisterGroupUseCase, RegisterGroupUseCase>();
builder.Services.AddTransient<IEditGroupUseCase, EditGroupUseCase>();
builder.Services.AddTransient<IDeleteGroupUseCase, DeleteGroupUseCase>();


builder.Services.AddTransient<IViewStudentsUseCase, ViewStudentsUseCase>();
builder.Services.AddTransient<IRegisterStudentsUseCase, RegisterStudentsUseCase>();
builder.Services.AddTransient<IEditStudentsUseCase, EditStudentsUseCase>();
builder.Services.AddTransient<IDeleteStudentsUseCase, DeleteStudentsUseCase>();

builder.Services.AddTransient<IViewMaterialUseCase, ViewMaterialUseCase>();
builder.Services.AddTransient<IRegisterMaterialUseCase, RegisterMaterialUseCase>();
builder.Services.AddTransient<IEditMaterialUseCase, EditMaterialUseCase>();
builder.Services.AddTransient<IDeleteMaterialUseCase, DeleteMaterialUseCase>();

builder.Services.AddTransient<IGenerateAttendaceUseCase, GenerateAttendaceUseCase>();
builder.Services.AddTransient<IViewAttendanceUseCase, ViewAttendanceUseCase>();
builder.Services.AddTransient<IUpdateAttendanceUseCase, UpdateAttendanceUseCase>();
builder.Services.AddTransient<IGenerateAttendanceFromSchedule, GenerateAttendanceFromSchedule>();

builder.Services.AddTransient<GenerateLessonsAndAttendace>();
builder.Services.AddTransient<IGenerateLessonsUseCase, GenerateLessonsUseCase>();
builder.Services.AddTransient<IViewLessonsUseCase, ViewLessonsUseCase>();
builder.Services.AddTransient<IUpdateLessonUseCase, UpdateLessonUseCase>();
builder.Services.AddTransient<ILessonExistsUseCase, LessonExistsUseCase>();
builder.Services.AddTransient<IDeleteLessonUseCase, DeleteLessonUseCase>();


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

//Auth middleware
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
