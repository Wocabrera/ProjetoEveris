using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Everis.Teste.Domain.Entities;
using Everis.Teste.Domain.Repository.Interfaces;
using Everis.Teste.Infrastructure.DataContext;
using Everis.Teste.Infrastructure.Repository.Common;

namespace Everis.Teste.Infrastructure.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(EverisContext context) 
            : base(context)
        {
        }
    }
}
