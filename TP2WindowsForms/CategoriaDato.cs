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
            try
            {
                return listaCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
