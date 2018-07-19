using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Everis.Teste.Application.Interfaces;
using Everis.Teste.Application.Interfaces.Common;
using Everis.Teste.Domain.Entities;
using Everis.Teste.Domain.Service.Interfaces;
using Everis.Teste.Domain.Validation;

namespace Everis.Teste.Application
{
    public class PedidoApp : IPedidoApp
    {
        private readonly IPedidoService _pedidoService;

        public PedidoApp(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        public ValidationResult validationResult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ValidationResult Create(Pedido entity)
        {
            return _pedidoService.Add(entity);
        }
        public void Dispose(){}
        public IEnumerable<Pedido> Find(Expression<Func<Pedido, bool>> predicateb)
        {
            return _pedidoService.Find(predicateb);
        }
        public ValidationResult Update(Pedido entity)
        {
            return _pedidoService.Update(entity);
        }
        Pedido IAppService<Pedido>.Get(int id)
        {
            return _pedidoService.Find(a => a.Id == id).FirstOrDefault();
        }
    }
}
