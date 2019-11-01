using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Model.Infrastucture.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Test.Dao
{
    [TestClass]
    public class CategoriaDaoTest
    {
        [TestMethod]
        public void Select()
        {
            using (var dao = new CategoriaDao())
            {
                var Categorias = dao.Select();
            }
        }
    }
}
