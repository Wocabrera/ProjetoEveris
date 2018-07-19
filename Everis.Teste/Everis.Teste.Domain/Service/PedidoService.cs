using Everis.Teste.Domain.Entities;
using Everis.Teste.Domain.Repository.Interfaces;
using Everis.Teste.Domain.Service.Common;
using Everis.Teste.Domain.Service.Interfaces;

namespace Everis.Teste.Domain.Service
{
    public class PedidoService : Service<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository) 
            : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
    }
}
