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
    public class ContadoresController : BaseController<IContadoresBL>
    {
        public ContadoresController(IContadoresBL BLInjectable) : base(BLInjectable)
        {
        }

        [HttpPost]
        public Contadores BucarContadoresProduto(PaginaProduto PaginaProduto) =>
            this.BLInjected.BuscarContadoresProduto(PaginaProduto);
    }
}
