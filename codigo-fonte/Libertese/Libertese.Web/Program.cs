using Libertese.Data;
using Libertese.Data.Repositories.Interfaces;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Data.Repositories;
using Libertese.Data.Services;
using Libertese.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<ICategoriaRepository<Categoria>, CategoriaRepository>();
builder.Services.AddScoped<IMaterialRepository<Material>, MaterialRepository>();
builder.Services.AddScoped<IProdutoRepository<Produto>, ProdutoRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		  .AddCookie(options =>
		  {
			  options.LoginPath = "/Home/Login";
              options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
              options.SlidingExpiration = false;
              options.Cookie.HttpOnly = true;
              options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
              options.Cookie.SameSite = SameSiteMode.Strict;
          });

builder.Services.AddAuthorization(options =>
{
    // Cadastro
    options.AddPolicy("EmpresasParceiras", policy => policy.RequireClaim("EmpresasParceiras", "EMPP"));
    options.AddPolicy("Funcionarios", policy => policy.RequireClaim("Funcionarios", "FUNC"));

    // Financeiro
    options.AddPolicy("Classificacoes", policy => policy.RequireClaim("Classificacoes", "CLAF"));
    options.AddPolicy("Clientes", policy => policy.RequireClaim("Clientes", "CLIE"));
    options.AddPolicy("ContaBancarias", policy => policy.RequireClaim("ContaBancarias", "COBA"));
    options.AddPolicy("Despesas", policy => policy.RequireClaim("Despesas", "DESP"));
    options.AddPolicy("FormaPagamentos", policy => policy.RequireClaim("FormaPagamentos", "FOPA"));
    options.AddPolicy("Fornecedores", policy => policy.RequireClaim("Fornecedores", "FORN"));
    options.AddPolicy("Receitas", policy => policy.RequireClaim("Receitas", "RECE"));

    // Precificacao
    options.AddPolicy("CapacidadeProdutivas", policy => policy.RequireClaim("CapacidadeProdutivas", "CAPP"));
    options.AddPolicy("Categorias", policy => policy.RequireClaim("Categorias", "CATE"));
    options.AddPolicy("Materiais", policy => policy.RequireClaim("Materiais", "MATE"));
    options.AddPolicy("Precos", policy => policy.RequireClaim("Precos", "PREC"));
    options.AddPolicy("Produtos", policy => policy.RequireClaim("Produtos", "PROD"));
    options.AddPolicy("Vendas", policy => policy.RequireClaim("Vendas", "VEND"));
    options.AddPolicy("Rateios", policy => policy.RequireClaim("Rateios", "RATE"));

    // Relatórios
    options.AddPolicy("Relatorios", policy => policy.RequireClaim("Relatorios", "RELA"));

    // Vendas
    options.AddPolicy("Vendas", policy => policy.RequireClaim("Vendas", "VEND"));
});

builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "keys")));



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
