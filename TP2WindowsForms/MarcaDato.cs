using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP2WindowsForms
{
    internal class MarcaDato
    {
        public List<Marca> listaDeMarcas()
        {
            List<Marca> listaMarca = new List<Marca>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando=new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated segurity=true";
                comando.CommandType=System.Data.CommandType.Text;
                comando.CommandText = "select ID, Descripcion as 'Categoria' from MARCAS";
                comando.Connection = conexion;

                conexion.Open();
                lector=comando.ExecuteReader();

                while (lector.Read())
                {
                    Marca marcaAux = new Marca();
                    marcaAux.IdMarca = (int)lector["ID"];
                    marcaAux.NombreMarca = (String)lector["Descripcion"];


                }

                return listaMarca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            
        }
    }
}
