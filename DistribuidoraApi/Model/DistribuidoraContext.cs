using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraApi.Model
{
    public class DistribuidoraContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }
        public DistribuidoraContext(DbContextOptions<DistribuidoraContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DistribuidoraContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(Configuration["Data:SqlConnections:ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.Property(c => c.Id).HasColumnName("ID").IsRequired().HasDefaultValueSql("newid()");
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Tipo).IsRequired();
                entity.Property(c => c.CnpjCpf).IsRequired().HasMaxLength(18);
                entity.Property(c => c.RgIe).IsRequired().HasMaxLength(14);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(255);
                entity.Property(c => c.DataNasc_fundacao);
                entity.Property(c => c.DataCadastro);
            });

            modelBuilder.Entity<Endereco>(entity => 
            {
                entity.ToTable("Enderecos");
                entity.Property(e => e.Id).HasColumnName("ID").IsRequired().HasDefaultValueSql("newid()");
                entity.Property(e => e.Tipo).IsRequired();
                entity.Property(e => e.Logradouro).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Numero).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Complemento).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Cidade).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Uf).IsRequired().HasMaxLength(2);
                entity.Property(e => e.Cep).IsRequired().HasMaxLength(10);
                entity.Property(e => e.ClienteId).IsRequired();

                entity.HasOne(e => e.Cliente)
                    .WithMany(r => r.Enderecos)
                    .HasForeignKey(r => r.ClienteId);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("Telefones");
                entity.Property(t => t.Id).HasColumnName("ID").IsRequired().HasDefaultValueSql("newid()");
                entity.Property(t => t.Tipo).IsRequired();
                entity.Property(t => t.Ddd).IsRequired().HasMaxLength(2);
                entity.Property(t => t.Numero).IsRequired().HasMaxLength(10);
                entity.Property(t => t.Observacao).IsRequired().HasMaxLength(255);
                entity.Property(t => t.ClienteId).IsRequired();

                entity.HasOne(t => t.Cliente)
                    .WithMany(r => r.Telefones)
                    .HasForeignKey(r => r.ClienteId);
            });
        }


        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
    }
}

/*

namespace DistribuidoraApi.Model
{
    public class DistribuidoraContext : DbContext
    {
        public DistribuidoraContext(DbContextOptions<DistribuidoraContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
    }
}
 
*/
