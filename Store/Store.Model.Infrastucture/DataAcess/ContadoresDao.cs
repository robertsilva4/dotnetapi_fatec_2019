using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Store.Model.Entities;
using Store.Model.Infrastucture.Casts;

namespace Store.Model.Infrastucture.DataAcess
{
    public class ContadoresDao : BaseDao<Contadores>
    {
        public override List<Contadores> CastToObject(SqlDataReader Reader)
        {
            List<Contadores> Contadores = new List<Contadores>();
            while (Reader.Read())
            {
                Contadores.Add(DataCast.CastContadores(Reader));
            }
            return Contadores;
        }

        public Contadores SelectNumeroPaginasProduto(PaginaProduto Pagina)
        {
            this.SqlBase();

            base.Sql.Append(" WHERE TB_CATEGORIA.ID = @ID_CATEGORIA ");

            this.AddParameter("@ID_CATEGORIA", Pagina.Categoria.Id);
            this.AddParameter("@TAMANHO_PAGINA", Pagina.Contadores.TamanhoPagina);

            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader).FirstOrDefault();
            }
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("     COUNT(*) AS TOTAL_ITENS, ");
            base.Sql.Append("     CEILING(CAST(COUNT(*) AS FLOAT) / @TAMANHO_PAGINA) AS TOTAL_PAGINAS, ");
            base.Sql.Append("     @TAMANHO_PAGINA AS TAMANHO_PAGINA ");
            base.Sql.Append(" FROM TB_PRODUTO ");
            base.Sql.Append(" JOIN TB_CATEGORIA ON TB_CATEGORIA.ID = TB_PRODUTO.ID_CATEGORIA ");            
        }
    }
}
