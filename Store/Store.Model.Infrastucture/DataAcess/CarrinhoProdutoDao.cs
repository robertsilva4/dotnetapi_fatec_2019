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
    public class CarrinhoProdutoDao : BaseDao<CarrinhoProduto>
    {
        public CarrinhoProdutoDao() { }
        public CarrinhoProdutoDao(Connection connection) : base(connection) { }
        public override List<CarrinhoProduto> CastToObject(SqlDataReader Reader)
        {
            List<CarrinhoProduto> Itens = new List<CarrinhoProduto>();
            while (Reader.Read())
            {
                Itens.Add(DataCast.CasCarrinhoProduto(Reader));
            }
            return Itens;
        }

        public void Insert(CarrinhoProduto carrinhoProduto)
        {
            base.Sql.Append(" INSERT INTO TB_CARRINHO_PRODUTO (ID_PRODUTO, ID_CARRINHO, QUANTIDADE) ");
            base.Sql.Append(" VALUES (@ID_PRODUTO, @ID_CARRINHO, @QUANTIDADE) ");

            base.AddParameter("@ID_PRODUTO", carrinhoProduto.Produto.Id);
            base.AddParameter("@ID_CARRINHO", carrinhoProduto.Carrinho.Id);
            base.AddParameter("@QUANTIDADE", carrinhoProduto.Quantidade);

            base.ExecuteComand();
        }

        public List<CarrinhoProduto> Select(int idCarrinho)
        {
            this.SqlBase();
            base.Sql.Append(" WHERE TB_CARRINHO_PRODUTO.ID_CARRINHO = @ID_CARRINHO ");

            base.AddParameter("@ID_CARRINHO", idCarrinho);

            using(var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("   TB_CARRINHO_PRODUTO.ID_PRODUTO AS CARRINHO_PRODUTO_ID_PRODUTO, ");
            base.Sql.Append("   TB_CARRINHO_PRODUTO.ID_CARRINHO AS CARRINHO_PRODUTO_ID_CARRINHO, ");
            base.Sql.Append("   TB_CARRINHO_PRODUTO.QUANTIDADE AS CARRINHO_PRODUTO_QUANTIDADE, ");
            base.Sql.Append("   TB_PRODUTO.DESCRICAO AS PRODUTO_DESCRICAO, ");
            base.Sql.Append("   TB_PRODUTO.ID AS PRODUTO_ID, ");
            base.Sql.Append("   TB_PRODUTO.ID_CATEGORIA AS PRODUTO_ID_CATEGORIA, ");
            base.Sql.Append("   TB_PRODUTO.IMAGEM AS PRODUTO_IMAGEM, ");
            base.Sql.Append("   TB_PRODUTO.NOME AS PRODUTO_NOME, ");
            base.Sql.Append("   TB_PRODUTO.VALOR AS PRODUTO_VALOR, ");
            base.Sql.Append("   TB_CATEGORIA.ID AS CATEGORIA_ID, ");
            base.Sql.Append("   TB_CATEGORIA.DESCRICAO AS CATEGORIA_DESCRICAO ");
            base.Sql.Append(" FROM TB_CARRINHO_PRODUTO ");
            base.Sql.Append(" JOIN TB_PRODUTO ON TB_PRODUTO.ID = TB_CARRINHO_PRODUTO.ID_PRODUTO ");
            base.Sql.Append(" JOIN TB_CATEGORIA ON TB_CATEGORIA.ID = TB_PRODUTO.ID_CATEGORIA ");
        }
    }
}
