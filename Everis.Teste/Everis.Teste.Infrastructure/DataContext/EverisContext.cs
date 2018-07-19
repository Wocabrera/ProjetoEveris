using System.IO;
using Everis.Teste.Domain.Entities;
using Everis.Teste.Infrastructure.EntityMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Everis.Teste.Infrastructure.DataContext
{
    public class EverisContext : DbContext
    {
        public EverisContext(DbContextOptions<EverisContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new PedidoMap());
        }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
