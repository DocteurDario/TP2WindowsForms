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
                comando.CommandText = "Select A.Id as 'Id P', A.Codigo, A.Nombre, A.Descripcion, M.id, M.Descripcion as 'Marca', C.id, C.Descripcion as 'Categoria', A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria";
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
                        Aux.Marca = new Marca();
                        Aux.Marca.IdMarca = (int)lector["Id"];
                        Aux.Marca.NombreMarca = (string)lector["Marca"];
                        Aux.Categoria = new Categoria();
                        Aux.Categoria.IdCategoria = (int)lector["Id"];
                        Aux.Categoria.NombreCategoria = (String)lector["Categoria"];
                        Aux.Imagen = (String)lector["ImagenUrl"];
                        Aux.Precio = (Decimal)lector["Precio"];
                       
                       lista.Add(Aux);

                    }
                return lista;
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

        public void Eliminar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated segurity=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "delete from ARTICULOS where Id = @ID";
                comando.Parameters.AddWithValue("@ID", articulo.IdArtículo);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Agregar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated segurity=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) Values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @PP";
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.NombreArticulo);
                comando.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("@IdMarca", articulo.Marca.IdMarca);
                comando.Parameters.AddWithValue("@IdCategoria", articulo.Categoria.IdCategoria);
                comando.Parameters.AddWithValue("@ImagenUrl", articulo.Imagen);
                comando.Parameters.AddWithValue("@PP", articulo.Precio);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }

        }
    }
}
