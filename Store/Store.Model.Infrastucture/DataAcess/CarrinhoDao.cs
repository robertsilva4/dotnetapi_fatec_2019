using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Infrastucture.DataAcess
{
    public class CarrinhoDao : BaseDao<Carrinho>
    {
        public override List<Carrinho> CastToObject(SqlDataReader Reader)
        {
            throw new NotImplementedException();
        }

        protected override void SqlBase()
        {
            throw new NotImplementedException();
        }
    }
}
