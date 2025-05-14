using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaConexion
{
    public class CD_Categoria_Productos
    {
        public List<Categorias_Productos> Listar()
        {
            List<Categorias_Productos> lista = new List<Categorias_Productos>();
            string connectionString = ConfigurationManager.ConnectionStrings["KERLY6Entities"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("La cadena de conexión es nula o no está configurada.");


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("SELECT [ID_categoria],[nombre_categoria]", oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Categorias_Productos()
                                {
                                    ID_categoria = Convert.ToInt32(dr["ID_categoria"]),
                                    nombre_categoria = dr["nombre_categoria"].ToString(),
                                
                                }
                                );
                        }


                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;

                lista = new List<Categorias_Productos>();


            }
            return lista;
        }
    }
}
