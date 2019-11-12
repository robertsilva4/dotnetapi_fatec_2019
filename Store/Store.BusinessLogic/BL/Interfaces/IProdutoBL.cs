using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.BL.Interfaces
{
    public interface IProdutoBL : IDisposable
    {
        void Deletar(int idProduto);
        List<Produto> Listar();
        Produto Consultar(int idProduto);
        PaginaProduto ConsultarPorCategoria(PaginaProduto pagina);
    }
}
