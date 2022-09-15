using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2WindowsForms
{
    internal class Categoria
    {
        public int IdCategoria { get; set; }    
        public String NombreCategoria { set; get; }

        public override string ToString()
        {
            return NombreCategoria;
        }
    }
}
