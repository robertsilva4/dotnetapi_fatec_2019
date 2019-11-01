using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Infrastucture.Casts
{
    public static class DataCast
    {
        public static Categoria CastCategoria(SqlDataReader Reader)
        {
            return new Categoria()
            {
                Descricao = Convert.ToString(Reader["CATEGORIA_DESCRICAO"]),
                Id = Convert.ToInt32(Reader["CATEGORIA_ID"])
            };
        }

        public static Cliente CastCliente(SqlDataReader Reader)
        {
            return new Cliente()
            {
                Cpf = Convert.ToString(Reader["CLIENTE_CPF"]),
                Email = Convert.ToString(Reader["CLIENTE_EMAIL"]),
                Id = Convert.ToInt32(Reader["CLIENTE_ID"]),
                Nome = Convert.ToString(Reader["CLIENTE_NOME"])
            };
        }

        public static Produto CastProduto(SqlDataReader Reader)
        {
            return new Produto()
            {
                Categoria = CastCategoria(Reader),
                Descricao = Convert.ToString(Reader["PRODUTO_DESCRICAO"]),
                Id = Convert.ToInt32(Reader["PRODUTO_ID"]),
                Imagem = Convert.ToString(Reader["PRODUTO_IMAGEM"]),
                Nome = Convert.ToString(Reader["PRODUTO_NOME"]),
                Valor = Convert.ToDouble(Reader["PRODUTO_VALOR"])
            };
        }
    }
}
