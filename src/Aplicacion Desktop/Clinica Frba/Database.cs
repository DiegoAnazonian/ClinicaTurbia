using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clinica_Frba
{
    class Database
    {
        private static Database instance;
        private static SqlConnection connection;

        private Database(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public static Database GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Database(Configuration.getConnectionString());
                return instance;
            }
        }

        public void ExecuteNonQuery(string spName, List<SqlParameter> parameters)
        {
            SqlCommand cmd = null;
            try
            {
                connection.Open();
                cmd = new SqlCommand(spName, connection);
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo inconvenientes al querer ejecutar el SP", ex);
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }
        }

        public DataTable ExecuteQuery(string spName, List<SqlParameter> parameters)
        {
            SqlDataAdapter da = null;
            try
            {
                connection.Open();
                da = new SqlDataAdapter(spName, connection);
                da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo inconvenientes al querer ejecutar el SP", ex);
            }
            finally
            {
                if (da != null) da.SelectCommand.Connection.Close();
            }
        }

        public DataTable ExecuteCustomQuery(string strQuery, List<SqlParameter> parameters)
        {
            SqlDataAdapter da = null;
            try
            {
                connection.Open();
                da = new SqlDataAdapter(strQuery, connection);
                da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                da.SelectCommand.CommandType = CommandType.Text;

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo inconvenientes al querer ejecutar la query: '" + strQuery + "'", ex);
            }
            finally
            {
                if (da != null) da.SelectCommand.Connection.Close();
            }
        }
    }
}
