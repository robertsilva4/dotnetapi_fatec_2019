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
    public class CarrinhoBL : ICarrinhoBL
    {
        private CarrinhoDao _carrinhoDao;

        public CarrinhoBL()
        {
            this._carrinhoDao = new CarrinhoDao();
        }

        public Carrinho Consultar(int id)
        {
            return this._carrinhoDao.Select(id);
        }

        public List<Carrinho> ConsultarPorCliente(int idCliente)
        {
            return _carrinhoDao.SelectByIdCliente(idCliente);
        }

        public Carrinho Inserir(Carrinho carrinho)
        {
            carrinho.DataCompra = DateTime.Now;
            carrinho.Produtos.ForEach(p =>
            {
                carrinho.ValorTotal += (p.Quantidade * p.Produto.Valor);
            });

            this._carrinhoDao.Transaction(
                conn =>
                {
                    carrinho = this._carrinhoDao.Insert(carrinho);
                },
                conn =>
                {
                    carrinho.Produtos.ForEach(produto =>
                    {
                        produto.Carrinho = carrinho;
                        new CarrinhoProdutoDao(conn).Insert(produto);
                    });
                }
            );

            return carrinho;
        }

        public void Dispose()
        {
            this._carrinhoDao.Dispose();
        }
    }
}
