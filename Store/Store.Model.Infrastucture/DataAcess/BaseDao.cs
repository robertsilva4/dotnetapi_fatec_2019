using Store.Model.Infrastucture.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Infrastucture.DataAcess
{
    public abstract class BaseDao<TObject> : IDisposable
        where TObject : class
    {
        private readonly Connection _connectionSql;
        private List<SqlParameter> _sqlParameters;

        public BaseDao()
        {
            this._connectionSql = new Connection();
            this.Sql = new StringBuilder();
            this._sqlParameters = new List<SqlParameter>();
        }

        public BaseDao(Connection Connection)
        {
            this._connectionSql = Connection;
            this.Sql = new StringBuilder();
            this._sqlParameters = new List<SqlParameter>();
        }

        public StringBuilder Sql { get; }

        public void AddParameter(string ParameterName, object Value) => 
            this._sqlParameters.Add(new SqlParameter(ParameterName, Value));

        protected object ExecuteComand() => 
            _connectionSql.Command(this.Sql, this._sqlParameters);

        protected SqlDataReader ExecuteReader() => 
            _connectionSql.Reader(this.Sql, this._sqlParameters);

        public abstract List<TObject> CastToObject(SqlDataReader Reader);
        protected abstract void SqlBase();

        public void Transaction(params Action<Connection>[] actions)
        {
            try
            {
                this._connectionSql.BeginTransaction();
                actions.ToList().ForEach(a => a.Invoke(this._connectionSql));
                this._connectionSql.Commit();
            }
            catch (Exception error)
            {
                this._connectionSql.RollBack();
                throw error;
            }
        }

        public void Dispose() => 
            _connectionSql.Dispose();
    }
}
