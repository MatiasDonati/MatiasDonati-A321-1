using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Archivo
{
    public class Sql : IArchivo
    {
        private SqlCommand _comando;
        private SqlConnection _conexion;

        /// <summary>
        /// Unico constructor q inicializa y establece la conexion a la base de datos.
        /// </summary>
        public Sql()
        {
            string cadenaConexion = "Data Source=MATO-DELL\\SQLEXPRESS;Initial Catalog=lab_sp;Integrated Security=True";

            _conexion = new SqlConnection(cadenaConexion);
            _comando = new SqlCommand();
            _comando.CommandType = CommandType.Text;
            _comando.Connection = _conexion;
        }

        /// <summary>
        /// MEtodo que guarda en la base de datos, en la tabla patentes. 
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                _conexion.Open();
                foreach (var patente in datos)
                {
                    _comando.CommandText = "INSERT INTO patentes (codigoPatente, tipoCodigo) VALUES (@codigoPatente, @tipoCodigo)";
                    _comando.Parameters.Clear();
                    _comando.Parameters.AddWithValue("@codigoPatente", patente.CodigoPatente);
                    _comando.Parameters.AddWithValue("@tipoCodigo", patente.TipoCodigo);

                    _comando.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _conexion.Close();
            }
        }

        /// <summary>
        /// lee las patentes de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Patente> Leer()
        {
            List<Patente> listaPatentes = new List<Patente>();

            try
            {
                _conexion.Open();
                _comando.CommandText = "SELECT patente,tipo FROM patentes";

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string codigoPatente = reader["patente"].ToString();
                        Tipo tipoCodigo = (Tipo)Enum.Parse(typeof(Tipo), reader["tipo"].ToString());
                        listaPatentes.Add(new Patente(codigoPatente, tipoCodigo));
                    }
                }
            }
            catch (Exception)
            {
               
            }
            finally
            {
                _conexion.Close();
            }

            return listaPatentes;
        }
    }
}
