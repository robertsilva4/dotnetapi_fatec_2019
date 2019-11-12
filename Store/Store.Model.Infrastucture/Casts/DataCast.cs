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
                Id = Convert.ToInt32(Reader["PRODUTO_ID"]),
                Imagem = Convert.ToString(Reader["PRODUTO_IMAGEM"]),
                Nome = Convert.ToString(Reader["PRODUTO_NOME"]),
                Valor = Convert.ToDouble(Reader["PRODUTO_VALOR"])
            };
        }

        public static Carrinho CasCarrinho(SqlDataReader Reader)
        {
            return new Carrinho()
            {
                Cliente = CastCliente(Reader),
                DataCompra = Convert.ToDateTime(Reader["CARRINHO_DATA_COMPRA"]),
                Id = Convert.ToInt32(Reader["CARRINHO_ID"]),
                ValorTotal = Convert.ToDouble(Reader["CARRINHO_VALOR_TOTAL"])
            };
        }

        public static CarrinhoProduto CasCarrinhoProduto(SqlDataReader Reader)
        {
            return new CarrinhoProduto()
            {
                Produto = CastProduto(Reader),
                Quantidade = Convert.ToInt32(Reader["CARRINHO_PRODUTO_QUANTIDADE"])
            };
        }

        public static Contadores CastContadores(SqlDataReader Reader)
        {
            return new Contadores()
            {
                NumeroPagina = Convert.ToInt32(Reader["TOTAL_PAGINAS"]),
                TamanhoPagina = Convert.ToInt32(Reader["TAMANHO_PAGINA"]),
                Total = Convert.ToInt32(Reader["TOTAL_ITENS"])
            };
        }
    }
}
