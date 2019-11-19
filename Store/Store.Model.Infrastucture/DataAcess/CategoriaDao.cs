using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Store.Model.Infrastucture.Sql;
using Store.Model.Entities;

namespace Store.Model.Infrastucture.DataAcess
{
    public class CategoriaDao : BaseDao<Categoria>
    {
        public CategoriaDao() { }
        public CategoriaDao(Connection connection) : base(connection) { }

        public override List<Categoria> CastToObject(SqlDataReader Reader)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> Select()
        {
            throw new NotImplementedException();
        }

        protected override void SqlBase()
        {
            throw new NotImplementedException();
        }
    }
}
