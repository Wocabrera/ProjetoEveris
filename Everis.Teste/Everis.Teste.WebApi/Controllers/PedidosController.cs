using System;
using System.Collections.Generic;
using Everis.Teste.Application.Interfaces;
using Everis.Teste.Application.Utils;
using Everis.Teste.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Everis.Teste.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Pedidos")]
    public class PedidosController : Controller
    {
        private readonly IPedidoApp _pedidoApp;

        public PedidosController(IPedidoApp pedidoApp)
        {
            _pedidoApp = pedidoApp;
        }

        // GET: api/Pedidos/1
        [HttpGet("{id:int}", Name ="GetById")]

        public IActionResult GetById(int id)
        {
            var retorno = _pedidoApp.Find(a => a.Id == id);

            if (retorno == null)
                return BadRequest();

            return Json(new { sucesso = true, pedidos = retorno });
        }

        // GET: api/Pedidos/getbydate/2018-01-01
        [HttpGet]
        [Route("getbydate/{date}", Name = "GetByDate")]
        public IActionResult GetByDate(string date)
        {
            try
            {
                DateTime dtPedido = DateTime.Parse(date);

                var retorno = _pedidoApp.Find(a => a.DataPedido.Date == dtPedido.Date);

                return Json(new { sucesso = true, pedidos = retorno });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            try
            {
                Validation.NameValidation(pedido.NomeCliente);
                Validation.MailAddresValidation(pedido.Email);

                var retorno = _pedidoApp.Create(pedido);

                var url = new Uri(Url.Link("GetById", new { id = pedido.Id }));
                return Created(url, retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            try
            {
                Validation.NameValidation(pedido.NomeCliente);
                Validation.MailAddresValidation(pedido.Email);

                var retorno = _pedidoApp.Update(pedido);

                var url = new Uri(Url.Link("GetById", new { id = pedido.Id }));
                return Created(url, retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}
