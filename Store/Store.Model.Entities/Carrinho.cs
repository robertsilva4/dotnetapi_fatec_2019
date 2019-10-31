using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public double ValorTotal { get; set; }

        public Cliente Cliente { get; set; }
    }
}
