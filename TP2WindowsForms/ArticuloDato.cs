using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP2WindowsForms
{
    class ArticuloDato
    {
        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista= new List<Articulo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Id,Codigo,Nombre,Descripcion,ImagenUrl,Precio from Articulos";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Articulo Aux = new Articulo();
                        
                        Aux.IdArtículo = (int)lector["Id"];
                        Aux.Codigo= (String)lector["Codigo"];
                        Aux.NombreArticulo = (String)lector["Nombre"];
                        Aux.Descripcion = (String)lector["Descripcion"];
                        //Aux.IdMarca = (Marca)lector["IdMarca"];
                        //Aux.IdCategoria = (Categoria) ["IdCategoria"];
                        Aux.Imagen = (String)lector["ImagenUrl"];
                        Aux.Precio = (Decimal)lector["Precio"];// Revisar que tipo de dalo tiene C# para money
                       
                       lista.Add(Aux);

                    }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
