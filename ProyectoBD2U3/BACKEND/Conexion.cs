using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;

namespace ProyectoBD2U3.BACKEND
{
    public class Conexion
    {
        static SqlConnection conexion;
        /// <summary>
        /// Abrir una conexión a SQL Server
        /// </summary>
        /// <returns>True si pudo establecer la conexión y False en caso contrario</returns>
        public static bool conectar()
        {
            string parametrosConexion = "";

            try
            {
                conexion = new SqlConnection(parametrosConexion);
                conexion.Open(); 
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Libera la conexión para no ocupar recursos innecesarios del servidor de BD
        /// </summary>
        public static void desconectar()
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
                conexion.Close();
        }

        //Consulta de información (SELECT)
        public static DataTable ejecutarConsulta(SqlCommand consulta)
        {
            if (conectar())
            {
                try
                {
                    consulta.Connection = conexion;
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta);
                    DataTable resultado = new DataTable();
                    adaptador.Fill(resultado);
                    return resultado;
                }
                catch (SqlException ex)
                {
                    throw new NoControllerException();
                }
                finally
                {
                    desconectar();
                }
            }
            else
            {
                throw new ConnectionException();
            }
        }

        //Ejecutar operaciones que afecten los datos
        //(INSERT, UPDATE, DELETE)
        public static int ejecutarSentencia(SqlCommand sentencia)
        {
            if (conectar())
            {
                try
                {
                    sentencia.Connection = conexion;
                    return sentencia.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new NoControllerException();
                }
                finally
                {
                    desconectar();
                }
            }
            else
            {
                throw new ConnectionException();
            }
        }
    }
}