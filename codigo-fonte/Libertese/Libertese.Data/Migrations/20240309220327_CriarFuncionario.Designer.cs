﻿// <auto-generated />
using System;
using Libertese.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Libertese.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240309220327_CriarFuncionario")]
    partial class CriarFuncionario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DiasMes")
                        .HasColumnType("integer");

                    b.Property<int>("HorasDia")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Remuneracao")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Salario")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("RateioId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Vigencia")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Precos");
                });

            modelBuilder.Entity("Libertese.Domain.Entities.Precificacao.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Percentual")
                        .HasColumnType("real");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Rateios");
                });
#pragma warning restore 612, 618
        }
    }
}
