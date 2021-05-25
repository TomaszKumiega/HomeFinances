using Dapper;
using HomeFinances.Model.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinances.Model.Repositories
{
    public class DapperRepository<T> : IRepository<T> where T : IDatabaseEntity
    {
        protected string _tableName;

        public DapperRepository(string tableName)
        {
            _tableName = tableName;
        }

        #region Protected methods
        protected string GetConnectionString() => "Data Source=.\\home_finances.db;Version=3;";
        protected IDbConnection GetConnection() => new SqliteConnection(GetConnectionString());

        protected List<string> GetProperties()
        {
            return (from prop in typeof(T).GetProperties()
                    select prop.Name).ToList();
        }

        protected string GetInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");
            insertQuery.Append("(");

            var properties = GetProperties();
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1) // remove last comma
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1) // remove last comma
                .Append(")");

            return insertQuery.ToString();
        }

        protected string GetUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GetProperties();

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); // remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }
        #endregion

        public async Task AddAsync(T entity)
        {
            using (var conn = GetConnection())
            {
                await conn.ExecuteAsync(GetInsertQuery(), entity);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            foreach (var t in entities) await AddAsync(t);
        }

        public async Task<IEnumerable<T>> FindAsync(Predicate<T> predicate)
        {
            T entity = (T)predicate.Target;
            var methodInfo = predicate.Method;

            using (var conn = GetConnection())
            {
                return (await conn.QueryAsync<T>($"SELECT * FROM {_tableName} WHERE {methodInfo.Name}=@{methodInfo.Name}", entity)).ToList();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (IDbConnection conn = GetConnection())
            {
                return await conn.QueryAsync<T>($"SELECT * FROM {_tableName}");
            }
        }

        public async Task RemoveAsync(T entity)
        {
            using (var conn = GetConnection())
            {
                await conn.ExecuteAsync($"DELETE FROM {_tableName} WHERE Id=@Id", new { entity.Id });
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            foreach (var t in entities) await RemoveAsync(t);
        }

        public async Task UpdateAsync(T entity)
        {
            using (var conn = GetConnection())
            {
                await conn.ExecuteAsync(GetUpdateQuery(), entity);
            }
        }
    }
}
