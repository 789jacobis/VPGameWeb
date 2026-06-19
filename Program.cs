using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Reflection;
using VpGameWeb.Data;
using VpGameWeb.Middleware;
using VpGameWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Logging.AddDebug();

//
// 1️⃣ DB
//
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//
// 2️⃣ Services
//
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IMonsterService, MonsterService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<LoreService>();

//
// 3️⃣ MVC + API
//
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "VPGameWeb API",
        Version = "v1",
        Description = "Backend API for VPGameWeb portfolio data."
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

//
// 4️⃣ Seed（初始化資料）
//
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    DbInitializer.Seed(context);
}

//
// 5️⃣ HTTP pipeline
//
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "VPGameWeb API v1");
        options.DocumentTitle = "VPGameWeb API Docs";
    });
}

app.UseHttpsRedirection();
app.UseWhen(
    context => context.Request.Path.StartsWithSegments("/api"),
    branch => branch.UseMiddleware<ApiExceptionHandlingMiddleware>());
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
).WithStaticAssets();

app.Run();
