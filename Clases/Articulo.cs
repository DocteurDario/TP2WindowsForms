using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Articulo
    {
        public int IdArtículo { get; set; } 
        public string Codigo { get; set; } 
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }    
        public Categoria Categoria { get; set; }    
        public string Imagen { get; set; }  
        public decimal Precio { get; set; }   
    }   
}
