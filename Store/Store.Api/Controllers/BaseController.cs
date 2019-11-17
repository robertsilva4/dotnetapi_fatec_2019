using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Store.Api.Models;
using Store.Model.Entities;

namespace Store.Api.Controllers
{
    public class BaseController<TIBLInjected> : ApiController
    {
        protected TIBLInjected BLInjected;

        public BaseController(TIBLInjected BLInjectable)
        {
            this.BLInjected = BLInjectable;
        }

        protected Cliente Cliente { get; private set; }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public void SetCliente(Cliente cliente)
        {
            this.Cliente = cliente;
        }
    }
}
