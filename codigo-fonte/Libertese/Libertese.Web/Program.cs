using Libertese.Data;
using Libertese.Data.Repositories.Interfaces;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Data.Repositories;
using Libertese.Data.Services;
using Libertese.Data.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<ICategoriaRepository<Categoria>, CategoriaRepository>();
builder.Services.AddScoped<IMaterialRepository<Material>, MaterialRepository>();
builder.Services.AddScoped<IProdutoRepository<Produto>, ProdutoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
