using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP2WindowsForms
{
    internal class CategoriaDato
    {
        public List<Categoria> ListaDeCategorias()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated segurity=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select ID, Descripcion as 'Categorias' from CATEGORIAS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Categoria Aux = new Categoria();
                    Aux.IdCategoria = (int)lector["ID"];
                    Aux.NombreCategoria= (String)lector["Descripcion"];

                    listaCategoria.Add(Aux);

                }

                return listaCategoria;
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
