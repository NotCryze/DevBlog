using DevBlog.Domain.IRepo;
using DevBlog.Domain.Repo;
using DevBlog.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services
    .AddSingleton<IAccountRepository, AccountRepository>()
    .AddSingleton<ICategoryRepository, CategoryRepository>()
    .AddSingleton<ICommentRepository, CommentRepository>()
    .AddSingleton<ITagRepository, TagRepository>()
    .AddSingleton<IPost<BlogPost>, BlogPostRepository>()
    .AddSingleton<IPost<PortfolioPost>, PortfolioPostRepository>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "DB";
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

app.Run();
