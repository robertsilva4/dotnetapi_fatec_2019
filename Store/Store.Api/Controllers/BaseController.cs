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
    public class BaseController<TIBLInjected> : ApiController
    {
        protected TIBLInjected BLInjected;

        public BaseController(TIBLInjected BLInjectable)
        {
            this.BLInjected = BLInjectable;
        }
    }
}
