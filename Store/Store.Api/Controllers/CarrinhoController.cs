using Store.BusinessLogic.BL.Interfaces;
using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.Api.Controllers
{
    public class CarrinhoController : BaseController<ICarrinhoBL>
    {
        public CarrinhoController(ICarrinhoBL BLInjectable) : base(BLInjectable) { }

        /// <summary>
        /// Consultar lista de carrinho por cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpGet]
        public List<Carrinho> ConsultarPorCliente([FromUri] int id) =>
            base.BLInjected.ConsultarPorCliente(id);

        [HttpPost]
        public Carrinho Inserir([FromBody] Carrinho carrinho) =>
            base.BLInjected.Inserir(carrinho);
    }
}
