using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Entities
{
    public class CarrinhoProduto
    {
        public int Quantidade { get; set; }

        public Produto Produto { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
