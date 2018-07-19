using Everis.Teste.Domain.Entities;
using Everis.Teste.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Everis.Teste.Infrastructure.EntityMapping
{
    internal class PedidoMap : DbEntityConfiguration<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> entity)
        {
            // Table Mapping
            entity.ToTable("Pedido");

            //// PK
            entity.HasKey(c => c.Id);

            //// Fields
            entity.Property(c => c.Id).HasColumnName("idPedido").IsRequired();
            entity.Property(c => c.Cpf).HasColumnName("cpf").IsRequired();
            entity.Property(c => c.DataPedido).HasColumnName("dataPedido").IsRequired();
            entity.Property(c => c.Email).HasColumnName("email").HasMaxLength(128);
            entity.Property(c => c.NomeCliente).HasColumnName("nomeCliente").HasMaxLength(128).IsRequired();
            entity.Property(c => c.ValorTotal).HasColumnName("valorTotal").IsRequired();
        }

    }
}
