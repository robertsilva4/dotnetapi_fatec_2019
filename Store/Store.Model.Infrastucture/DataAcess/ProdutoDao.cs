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
    public class ProdutoDao : BaseDao<Produto>
    {
        public ProdutoDao() { }
        public ProdutoDao(Connection connection) : base(connection) { }

        public override List<Produto> CastToObject(SqlDataReader Reader)
        {
            List<Produto> Produtos = new List<Produto>();
            while (Reader.Read())
            {
                Produtos.Add(DataCast.CastProduto(Reader));
            }
            return Produtos;
        }

        public void Delete(int id)
        {
            base.Sql.Append(" DELETE FROM TB_PRODUTO WHERE ID = @ID ");
            base.AddParameter("@ID", id);
            base.ExecuteComand();
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("    TB_PRODUTO.DESCRICAO AS PRODUTO_DESCRICAO, ");
            base.Sql.Append("    TB_PRODUTO.ID AS PRODUTO_ID, ");
            base.Sql.Append("    TB_PRODUTO.ID_CATEGORIA AS PRODUTO_ID_CATEGORIA, ");
            base.Sql.Append("    TB_PRODUTO.IMAGEM AS PRODUTO_IMAGEM, ");
            base.Sql.Append("    TB_PRODUTO.NOME AS PRODUTO_NOME, ");
            base.Sql.Append("    TB_PRODUTO.VALOR AS PRODUTO_VALOR, ");
            base.Sql.Append("    TB_CATEGORIA.ID AS CATEGORIA_ID, ");
            base.Sql.Append("    TB_CATEGORIA.DESCRICAO AS CATEGORIA_DESCRICAO ");
            base.Sql.Append(" FROM TB_PRODUTO ");
            base.Sql.Append(" JOIN TB_CATEGORIA ON TB_CATEGORIA.ID = TB_PRODUTO.ID_CATEGORIA ");
        }

        public List<Produto> Select()
        {
            this.SqlBase();

            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }

        public Produto Select(int id)
        {
            this.SqlBase();
            base.Sql.Append(" WHERE TB_PRODUTO.ID = @ID_PRODUTO ");

            base.AddParameter("@ID_PRODUTO", id);

            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader).FirstOrDefault();
            }
        }

        public List<Produto> SelectByCategoria(int idCategoria)
        {
            this.SqlBase();
            base.Sql.Append(" WHERE TB_PRODUTO.ID_CATEGORIA = @ID_CATEGORIA ");

            base.AddParameter("@ID_CATEGORIA", idCategoria);

            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }
    }
}
