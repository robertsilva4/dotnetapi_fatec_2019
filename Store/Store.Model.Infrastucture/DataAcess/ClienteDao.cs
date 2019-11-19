using Store.Model.Entities;
using Store.Model.Infrastucture.Casts;
using Store.Model.Infrastucture.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Infrastucture.DataAcess
{
    public class ClienteDao : BaseDao<Cliente>
    {
        public ClienteDao() { }
        public ClienteDao(Connection connection) : base(connection) { }

        public override List<Cliente> CastToObject(SqlDataReader Reader)
        {
            throw new NotImplementedException();
        }

        public Cliente Insert(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente UpdatePassword(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        protected override void SqlBase()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Select()
        {
            throw new NotImplementedException();
        }

        public Cliente Select(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Select(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
