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
    public class AutenticacaoController : BaseController<IClienteBL>
    {
        public AutenticacaoController(IClienteBL BLInjectable) : base(BLInjectable) { }

        [HttpPost]
        public Cliente Logar([FromBody] Cliente cliente) =>
            base.BLInjected.Logar(cliente);
    }
}
