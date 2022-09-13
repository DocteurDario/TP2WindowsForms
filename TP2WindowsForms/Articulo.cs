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
        public String Codigo { get; set; } 
        public String NombreArticulo { get; set; }
        public String Descripcion { get; set; }
        public Marca Marca { get; set; }    
        public Categoria Categoria { get; set; }    
        public String Imagen { get; set; }  
        public Decimal Precio { get; set; }   
    }   
}
