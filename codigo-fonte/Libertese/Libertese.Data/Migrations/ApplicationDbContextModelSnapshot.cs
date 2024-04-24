﻿// <auto-generated />
using System;
using Libertese.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Libertese.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Libertese.Domain.Entities.Cadastro.EmpresaParceira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmpresasParceiras");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Cadastro.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CursoLibertese")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DiasMes")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HorasDia")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Penitenciaria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pessoareclusa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Remuneracao")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Salario")
                        .HasColumnType("numeric");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Cadastro.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PermissaoID")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.ControleAcesso.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Financeiro.Classificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Classificacoes");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Financeiro.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("DadosBancarios")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Financeiro.ContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Agencia")
                        .HasColumnType("text");

                    b.Property<string>("Conta")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pix")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContasBancarias");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Financeiro.Despesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassificacaoId")
                        .HasColumnType("integer");

                    b.Property<int>("ContaBancariaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTimeOffset?>("DataPagamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("integer");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Financeiro.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FormaPagamentos");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Financeiro.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("DadosBancarios")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Financeiro.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassificacaoId")
                        .HasColumnType("integer");

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<int>("ContaBancariaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTimeOffset?>("DataEmissao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DataPrevisao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DataRecebimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.CapacidadeProdutiva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("integer");

                    b.Property<decimal>("Custo")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Mes")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("Tempo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CapacidadeProdutivas");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.Preco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("RateioId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Vigencia")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Precos");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Empresa")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("TempoProducao")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.ProdutoMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MateriaiId")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProdutoMaterial");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.Rateio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CapacidadeProdutivaId")
                        .HasColumnType("integer");

                    b.Property<decimal>("CustoFixo")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CustoUnitario")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Percentual")
                        .HasColumnType("real");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Rateios");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Venda.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
