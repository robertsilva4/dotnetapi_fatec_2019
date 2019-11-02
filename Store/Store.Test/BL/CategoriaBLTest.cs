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
    public class CategoriaBLTest
    {
        [TestMethod]
        public void Listar()
        {
            using(var bl = new CategoriaBL())
            {
                var categorias = bl.Listar();
            }
        }
    }
}
