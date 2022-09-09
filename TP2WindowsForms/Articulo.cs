using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2WindowsForms
{
    class Articulo
    {
        public int IdArtículo { get; set; } 
        public String NombreArticulo { get; set; }
        public String Descripcion { get; set; }
        public Marca MarcaArticulo { get; set; }    
        public Categoria CategoriaArticulo { get; set; }    
        public String Imagen { get; set; }  
        public float Precio { get; set; }   
    }
}
