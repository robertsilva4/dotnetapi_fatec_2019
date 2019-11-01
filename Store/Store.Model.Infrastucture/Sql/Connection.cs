using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Infrastucture.Sql
{
    public class Connection : IDisposable
    {
        private readonly SqlConnection _sqlConnection;

        public Connection()
        {
            this._sqlConnection = new SqlConnection(Configuration.Config.ConnectionString);
            this._sqlConnection.Open();
        }

        public object Command(StringBuilder Sql, List<SqlParameter> Parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(Sql.ToString(), _sqlConnection);
                command.Parameters.AddRange(Parameters.ToArray());
                return command.ExecuteScalar();

            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                Sql.Clear();
                Parameters.Clear();
            }
        }

        public SqlDataReader Reader(StringBuilder Sql, List<SqlParameter> Parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(Sql.ToString(), _sqlConnection);
                command.Parameters.AddRange(Parameters.ToArray());
                return command.ExecuteReader();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                Sql.Clear();
                Parameters.Clear();
            }
        }

        public void Dispose()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
                _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}
