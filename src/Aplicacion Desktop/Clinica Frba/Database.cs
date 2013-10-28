﻿using System;
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
                return dt;
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

        /**
         * Recibe el nombre del parametro y luego el objeto, por cada parametro.
         * Ej: generarParamentros("uno", 1, "dos", 2, "tres", 3)
         */
        public static List<SqlParameter> GenerarListaParametros(params object[] values)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            for (int i = 0; i < values.Length; i ++)
            {
                if (i % 2 == 0)
                {
                    String nombreParam = values[i].ToString();
                    object paramValue = values[i + 1];
                    if (paramValue != null)
                    {
                        paramList.Add(new SqlParameter(nombreParam, paramValue));
                    }
                    else
                    {
                        throw new ArgumentNullException("Valor del parametro " + nombreParam); 
                    }
                }
            }
            return paramList;
        }
    }
}
