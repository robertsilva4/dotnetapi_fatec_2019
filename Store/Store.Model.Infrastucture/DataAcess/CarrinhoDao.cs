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
    public class CarrinhoDao : BaseDao<Carrinho>
    {
        public CarrinhoDao() { }
        public CarrinhoDao(Connection connection) : base(connection) { }

        public override List<Carrinho> CastToObject(SqlDataReader Reader)
        {
            List<Carrinho> Carrinhos = new List<Carrinho>();
            while (Reader.Read())
            {
                var carrinho = DataCast.CasCarrinho(Reader);
                using(var CarrinhoProdutoDao = new CarrinhoProdutoDao())
                {
                    carrinho.Produtos = CarrinhoProdutoDao.Select(carrinho.Id);
                }
                Carrinhos.Add(carrinho);
            }
            return Carrinhos;
        }

        public Carrinho Insert(Carrinho carrinho)
        {
            base.Sql.Append(" INSERT INTO TB_CARRINHO (ID_CLIENTE, DATA_COMPRA, VALOR_TOTAL) ");
            base.Sql.Append(" OUTPUT inserted.ID ");
            base.Sql.Append(" VALUES (@ID_CLIENTE, @DATA_COMPRA, @VALOR_TOTAL) ");

            base.AddParameter("@ID_CLIENTE", carrinho.Cliente.Id);
            base.AddParameter("@DATA_COMPRA", carrinho.DataCompra);
            base.AddParameter("@VALOR_TOTAL", carrinho.ValorTotal);

            carrinho.Id = (int)base.ExecuteComand();

            return carrinho;
        }

        public List<Carrinho> Select()
        {
            this.SqlBase();

            using(var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }

        public List<Carrinho> SelectByIdCliente(int idCliente)
        {
            this.SqlBase();
            base.Sql.Append(" WHERE TB_CARRINHO.ID_CLIENTE = @ID_CLIENTE ");
            base.AddParameter("@ID_CLIENTE", idCliente);

            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }

        public Carrinho Select(int id)
        {
            this.SqlBase();
            base.Sql.Append(" WHERE TB_CARRINHO.ID = @ID ");
            base.AddParameter("@ID", id);

            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader).FirstOrDefault();
            }
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("   TB_CARRINHO.ID AS CARRINHO_ID, ");
            base.Sql.Append("   TB_CARRINHO.ID_CLIENTE AS CARRINHO_ID_CLIENTE, ");
            base.Sql.Append("   TB_CARRINHO.DATA_COMPRA AS CARRINHO_DATA_COMPRA, ");
            base.Sql.Append("   TB_CARRINHO.VALOR_TOTAL AS CARRINHO_VALOR_TOTAL, ");
            base.Sql.Append("   TB_CLIENTE.CPF AS CLIENTE_CPF, ");
            base.Sql.Append("   TB_CLIENTE.EMAIL AS CLIENTE_EMAIL, ");
            base.Sql.Append("   TB_CLIENTE.ID AS CLIENTE_ID, ");
            base.Sql.Append("   TB_CLIENTE.NOME AS CLIENTE_NOME, ");
            base.Sql.Append("   TB_CLIENTE.SENHA AS CLIENTE_SENHA ");
            base.Sql.Append(" FROM TB_CARRINHO ");
            base.Sql.Append(" JOIN TB_CLIENTE ON TB_CLIENTE.ID = TB_CARRINHO.ID_CLIENTE ");
        }
    }
}
