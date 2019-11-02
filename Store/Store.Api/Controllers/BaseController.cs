using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Store.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController<TIBLInjected> : ApiController, IDisposable
        where TIBLInjected : IDisposable
    {
        protected TIBLInjected BLInjected;

        public BaseController(TIBLInjected BLInjectable)
        {
            this.BLInjected = BLInjectable;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void Dispose()
        {
            this.BLInjected.Dispose();
        }
    }
}
