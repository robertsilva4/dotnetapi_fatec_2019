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
            this.Sql.Append("INSERT INTO TB_CLIENTE (NOME, CPF, EMAIL, SENHA)");
            this.Sql.Append(" OUTPUT inserted.ID ");
            this.Sql.Append(" VALUES ( @NOME, @CPF, @EMAIL, @SENHA ) ");

            this.AddParameter("@NOME", cliente.Nome);
            this.AddParameter("@CPF", cliente.Cpf);
            this.AddParameter("@EMAIL", cliente.Email);
            this.AddParameter("@SENHA", cliente.Senha);

            cliente.Id = (int)this.ExecuteComand();

            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            this.Sql.Append(" UPDATE TB_CLIENTE SET");
            this.Sql.Append("         NOME = @NOME, ");
            this.Sql.Append("            CPF = @CPF, ");
            this.Sql.Append("        EMAIL = @EMAIL ");
            this.Sql.Append("WHERE TB_CLIENTE.ID = @ID");

            this.AddParameter("@NOME", cliente.Nome);
            this.AddParameter("@CPF", cliente.Cpf);
            this.AddParameter("@EMAIL", cliente.Email);
            this.AddParameter("@ID", cliente.Id);

            this.ExecuteComand();

            return cliente;
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
