using DevBlog.Service.IRepo;
using DevBlog.Service.Repo;
using DevBlog.Shared.Models;
using DevBlog.Web.Middlewares;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services
    .AddSingleton<IAccountService, AccountService>()
    .AddSingleton<ICategoryService, CategoryService>()
    .AddSingleton<ICommentService, CommentService>()
    .AddSingleton<ITagService, TagService>()
    .AddSingleton<IPostService<BlogPost>, BlogPostService>()
    .AddSingleton<IPostService<PortfolioPost>, PortfolioPostService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "DBC";
});

builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue;
    x.MultipartHeadersLengthLimit = int.MaxValue;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.UseAuthMiddleware();

app.Run();
