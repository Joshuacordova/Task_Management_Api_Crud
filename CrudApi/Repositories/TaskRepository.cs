using CrudApi.Infrastructure.Helpers;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CrudApi.Repositories
{
    public class TaskRepository<T> : ITaskRepository<T> where T : class
    {
        private readonly string _tableName;
        private readonly string _connectionString;

        public TaskRepository()
        {
            _tableName = TableNameResolver.GetTableName<T>(); //table name
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Create(T entity)
        {
            using(var db = Connection)
            {
                var insertQuery = $@"INSERT INTO {_tableName} ({string.Join(", ", typeof(T).GetProperties().Select(p => p.Name))}) 
VALUES ({string.Join(", ", typeof(T).GetProperties().Select(p => "@" + p.Name))})";

                await db.ExecuteAsync(insertQuery, entity);
            }
        }

        /// <summary>
        /// Deletes an entity from the database by its Id.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Delete(T entity)
        {
            using (var db = Connection)
            {
                var idProp = typeof(T).GetProperty("Id") ?? throw new Exception("Entity must have an Id property");
                var id = idProp.GetValue(entity);
                await db.ExecuteAsync($"DELETE FROM {_tableName} WHERE Id = @Id", new { Id = id });
            }
        }

        /// <summary>
        /// Retrieves all entities from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            using (var db = Connection)
            {
                return await db.QueryAsync<T>($"SELECT * FROM {_tableName}");
            }
        }

        /// <summary>
        /// Retrieves an entity by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(int id)
        {
            using (var db = Connection)
            {
                return await db.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Id = @Id", new { Id = id });
            }
        }

        /// <summary>
        /// Retrieves an entity by its status.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<T> GetByStatus(int status)
        {
            using(var db = Connection)
            {
                return await db.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Status = @Status", new { Status = status });

            }

        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(T entity)
        {
            using(var db = Connection)
            {
                var props = typeof(T).GetProperties().Where(p => p.Name != "Id");
                var setClause = string.Join(",", props.Select(p => $"{p.Name} = @{p.Name}"));
                var sql = $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";

                await db.ExecuteAsync(sql, entity);
            }
        }
    }
}