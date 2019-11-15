﻿using Store.BusinessLogic.BL.Interfaces;
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


        //[HttpGet]
        //public Carrinho Consultar([FromUri] int id) =>
        //    base.BLInjected.Consultar(id);

        [HttpGet]
        public List<Carrinho> ConsultarPorCliente([FromUri] int idCliente) =>
            base.BLInjected.ConsultarPorCliente(idCliente);

        [HttpPost]
        public Carrinho Inserir([FromBody] Carrinho carrinho) =>
            base.BLInjected.Inserir(carrinho);
    }
}
