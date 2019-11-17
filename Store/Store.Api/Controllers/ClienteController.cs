using Store.Api.Models;
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
    [CarregarCliente]
    public class ClienteController : BaseController<IClienteBL>
    {
        public ClienteController(IClienteBL BLInjectable) : base(BLInjectable) { }

        [HttpPost]
        public Cliente Inserir([FromBody] Cliente cliente) =>
            base.BLInjected.Inserir(cliente);

        [HttpPut]
        [Authorize]
        public Cliente Atualizar([FromBody] Cliente cliente) =>
            base.BLInjected.Atualizar(cliente);

        [HttpGet]
        [Authorize]
        public Cliente Consultar() =>
            base.BLInjected.Consultar(base.Cliente.Id);
    }
}
