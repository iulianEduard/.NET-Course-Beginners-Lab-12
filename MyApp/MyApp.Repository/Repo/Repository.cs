using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace MyApp.Repository.Repo
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        #region Attributes

        private IDbTransaction sqlTransaction = null;

        private readonly string connectionString = null;

        #endregion Attributes

        #region Constructor

        public Repository()
        {
            connectionString = "";
        }

        #endregion Constructor

        #region Public Methods

        public int Add(T entity)
        {
            long generatedId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                generatedId = conn.Insert(entity);

                conn.Close();
            }

            return Convert.ToInt32(generatedId);
        }

        public void Delete(T entity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Delete(entity);

                conn.Close();
            }
        }

        public T Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var entity = conn.Get<T>(id);

                conn.Close();

                return entity;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var entityList = conn.GetAll<T>();

                conn.Close();

                return entityList;
            }
        }

        public void Update(T entity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Update<T>(entity);

                conn.Close();
            }
        }

        public IEnumerable<R> ExecuteQuery<R>(string name, bool? usingTransaction = null, int? timeout = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                dynamic result;

                if (usingTransaction.HasValue && usingTransaction.Value == true)
                {
                    if (sqlTransaction == null)
                        throw new Exception("Transaction not set");

                    result = conn.Query<R>(name, null, sqlTransaction, true, timeout, CommandType.Text);
                }
                else
                {
                    result = conn.Query<R>(name, null, null, true, timeout, CommandType.Text);
                }

                conn.Close();
                return result;
            }
        }

        public IEnumerable<R> SingleSetStoredProcedure<R>(string name, DynamicParameters parameters = null, bool? usingTransaction = null, int? timeout = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                dynamic result;

                if (usingTransaction.HasValue && usingTransaction.Value == true)
                {
                    if (sqlTransaction == null)
                        throw new Exception("Transaction not set");

                    result = conn.Query<R>(name, parameters, sqlTransaction, true, timeout, CommandType.StoredProcedure);
                }
                else
                {
                    result = conn.Query<R>(name, parameters, null, true, timeout, CommandType.StoredProcedure);
                }

                conn.Close();
                return result;
            }
        }

        public R MultipleSetStoredProcedure<R>(string name, Func<GridReader, R> readerFuncs, DynamicParameters parameters = null, bool? usingTransaction = null, int? timeout = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (usingTransaction.HasValue && usingTransaction.Value == true)
                {
                    if (sqlTransaction == null)
                        throw new Exception("Transaction not set");

                    var gridReader = conn.QueryMultiple(name, parameters, sqlTransaction, timeout, CommandType.StoredProcedure);

                    return readerFuncs(gridReader);
                }
                else
                {
                    var gridReader = conn.QueryMultiple(name, parameters, null, timeout, CommandType.StoredProcedure);

                    return readerFuncs(gridReader);
                }
            }
        }

        #endregion Public Methods
    }
}
