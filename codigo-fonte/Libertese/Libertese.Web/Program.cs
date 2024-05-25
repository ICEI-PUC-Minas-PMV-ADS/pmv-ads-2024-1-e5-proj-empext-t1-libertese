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
              options.AccessDeniedPath = "/Home/Login";
              options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
          });

builder.Services.AddAuthorization(options =>
{
    // Cadastro
    options.AddPolicy("RequireEmpresasParceiras", policy => policy.RequireClaim("EmpresasParceiras", "EMPP"));
    options.AddPolicy("RequireFuncionarios", policy => policy.RequireClaim("Funcionarios", "FUNC"));

    // Financeiro
    options.AddPolicy("RequireClassificacoes", policy => policy.RequireClaim("Classificacoes", "CLAF"));
    options.AddPolicy("RequireClientes", policy => policy.RequireClaim("Clientes", "CLIE"));
    options.AddPolicy("RequireContaBancarias", policy => policy.RequireClaim("ContaBancarias", "COBA"));
    options.AddPolicy("RequireDespesas", policy => policy.RequireClaim("Despesas", "DESP"));
    options.AddPolicy("RequireFormaPagamentos", policy => policy.RequireClaim("FormaPagamentos", "FOPA"));
    options.AddPolicy("RequireFornecedores", policy => policy.RequireClaim("Fornecedores", "FORN"));
    options.AddPolicy("RequireReceitas", policy => policy.RequireClaim("Receitas", "RECE"));

    // Precificacao
    options.AddPolicy("RequireCapacidadeProdutivas", policy => policy.RequireClaim("CapacidadeProdutivas", "CAPP"));
    options.AddPolicy("RequireCategorias", policy => policy.RequireClaim("Categorias", "CATE"));
    options.AddPolicy("RequireMateriais", policy => policy.RequireClaim("Materiais", "MATE"));
    options.AddPolicy("RequirePrecos", policy => policy.RequireClaim("Precos", "PREC"));
    options.AddPolicy("RequireProdutos", policy => policy.RequireClaim("Produtos", "PROD"));
    options.AddPolicy("RequireVendas", policy => policy.RequireClaim("Vendas", "VEND"));
    options.AddPolicy("RequireRateios", policy => policy.RequireClaim("Rateios", "RATE"));

    // Relatórios
    options.AddPolicy("RequireRelatorios", policy => policy.RequireClaim("Relatorios", "RELA"));
    options.AddPolicy("RequireHome", policy => policy.RequireClaim("Home", "HOME"));

    // Vendas
    options.AddPolicy("RequireVendas", policy => policy.RequireClaim("Vendas", "VEND"));
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
