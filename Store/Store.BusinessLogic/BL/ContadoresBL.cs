using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.BL.Interfaces;
using Store.Model.Entities;
using Store.Model.Infrastucture.DataAcess;

namespace Store.BusinessLogic.BL
{
    public class ContadoresBL : IContadoresBL
    {
        private ContadoresDao _contadoresDAO;

        public ContadoresBL()
        {
            this._contadoresDAO = new ContadoresDao();
        }

        public Contadores BuscarContadoresProduto(PaginaProduto PaginaProduto)
        {
            if (PaginaProduto.Contadores.TamanhoPagina == 0)
                throw new InvalidOperationException("Numero de elementos por pagina deve ser fornecido");
            return this._contadoresDAO.SelectNumeroPaginasProduto(PaginaProduto);
        }

        public void Dispose()
        {
            this._contadoresDAO.Dispose();
        }
    }
}
