using Store.BusinessLogic.BL.Interfaces;
using Store.Model.Entities;
using Store.Model.Infrastucture.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.BL
{
    public class ProdutoBL : IProdutoBL
    {
        private ProdutoDao _produtoDao;

        public ProdutoBL()
        {
            this._produtoDao = new ProdutoDao();
        }

        public Produto Consultar(int idProduto)
        {
            return this._produtoDao.Select(idProduto);
        }

        public PaginaProduto ConsultarPorCategoria(PaginaProduto PaginaProduto)
        {
            PaginaProduto.Produtos = this._produtoDao.SelectByCategoria(PaginaProduto);
            return PaginaProduto;
        }

        public void Deletar(int idProduto)
        {
            this._produtoDao.Delete(idProduto);
        }
        public List<Produto> Listar()
        {
            return this._produtoDao.Select();
        }

        public void Dispose()
        {
            this._produtoDao.Dispose();
        }
    }
}
