using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.BusinessLogic.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Test.BL
{
    [TestClass]
    public class ProdutoBLTest
    {
        [TestMethod]
        public void Consultar()
        {
            using(var bl = new ProdutoBL())
            {
                var produto = bl.Consultar(1);
            }
        }

        [TestMethod]
        public void ConsultarPorCategoria()
        {
            using (var bl = new ProdutoBL())
            {
                // var produtos = bl.ConsultarPorCategoria(1);
            }
        }

        [TestMethod]
        public void Deletar()
        {
            using (var bl = new ProdutoBL())
            {
                bl.Deletar(4);
            }
        }

        [TestMethod]
        public void Listar()
        {
            using (var bl = new ProdutoBL())
            {
                var produtos = bl.Listar();
            }
        }
    }
}
