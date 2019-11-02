using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.BL.Interfaces
{
    public interface ICarrinhoBL : IDisposable
    {
        Carrinho Inserir(Carrinho carrinho);
        List<Carrinho> ConsultarPorCliente(int idCliente);
        Carrinho Consultar(int id);
    }
}
