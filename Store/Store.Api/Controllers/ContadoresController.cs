using System.Web.Http;
using Store.BusinessLogic.BL.Interfaces;
using Store.Model.Entities;

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
