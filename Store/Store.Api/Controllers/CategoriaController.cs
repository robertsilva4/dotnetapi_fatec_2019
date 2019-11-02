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
    public class CategoriaController : BaseController<ICategoriaBL>
    {
        public CategoriaController(ICategoriaBL BLInjectable) : base(BLInjectable) { }

        [HttpGet]
        public List<Categoria> Listar() =>
            base.BLInjected.Listar();
    }
}
