using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.BusinessLogic.BL;
using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Test.BL
{
    [TestClass]
    public class CarrinhoBLTest
    {
        [TestMethod]
        public void Inserir()
        {
            using (var bl = new CarrinhoBL())
            {
                var carrinho = new Carrinho()
                {
                    Cliente = new Cliente() { Id = 1},
                    Produtos = new List<CarrinhoProduto>()
                    {
                        new CarrinhoProduto()
                        {
                            Produto = new Produto(){Id = 1, Valor = 889.00},
                            Quantidade = 2
                        },
                        new CarrinhoProduto()
                        {
                            Produto = new Produto(){Id = 2, Valor = 1999.00},
                            Quantidade = 1
                        }
                    }
                };

                carrinho = bl.Inserir(carrinho);
            }
        }

        [TestMethod]
        public void Consultar()
        {
            using (var bl = new CarrinhoBL())
            {
                var carrinho = bl.Consultar(2);
            }
        }

        [TestMethod]
        public void ConsultarPorCliente()
        {
            using (var bl = new CarrinhoBL())
            {
                var carrinhos = bl.ConsultarPorCliente(1);
            }
        }
    }
}
