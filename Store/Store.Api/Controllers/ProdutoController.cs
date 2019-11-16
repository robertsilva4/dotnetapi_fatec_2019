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
    public class ProdutoController : BaseController<IProdutoBL>
    {
        public ProdutoController(IProdutoBL BLInjected) : base(BLInjected) { }

        [HttpGet]
        public List<Produto> Listar() =>
            base.BLInjected.Listar();

        [HttpDelete]
        public void Deletar([FromUri] int id) =>
            base.BLInjected.Deletar(id);

        [HttpGet]
        public Produto Consultar([FromUri] int id) =>
            base.BLInjected.Consultar(id);

        [HttpPost]
        public PaginaProduto Pagina([FromBody] PaginaProduto PaginaProduto) =>
            base.BLInjected.ConsultarPorCategoria(PaginaProduto);
    }
}
