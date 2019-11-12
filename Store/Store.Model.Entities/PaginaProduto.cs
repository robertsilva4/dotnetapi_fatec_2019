using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Entities
{
    public class PaginaProduto
    {
        public Categoria Categoria { get; set; }
        public Contadores Contadores { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
