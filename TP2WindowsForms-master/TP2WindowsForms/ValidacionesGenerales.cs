using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2WindowsForms
{
    static class ValidacionesGenerales
    {    
        public static bool ExisteVentanaAbierta(Type FormType)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == FormType)
                {
                    return true;
                }
            }
            return false;
        }
        public static String ErrroImagenNoEncontrada()
        {
            return "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
        }

    }
}
