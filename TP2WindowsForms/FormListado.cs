using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2WindowsForms
{
    public partial class FormListado : Form
    {
        private List<Articulo> listaArticulo;
        public FormListado()
        {
            InitializeComponent();
        }

        private void FormListado_Load(object sender, EventArgs e)
        {
            ArticuloDato dato = new ArticuloDato();
            listaArticulo=dato.listarArticulos();
            dgvListaArticulo.DataSource = listaArticulo;
            //pbxArticulo.Load(listaArticulo[0].Imagen);
            cargarImagen(listaArticulo[0].Imagen);
        }
        private void dgvListaArticulo_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvListaArticulo.CurrentRow.DataBoundItem;
            //pbxArticulo.Load(seleccionado.Imagen);
            cargarImagen(seleccionado.Imagen);

        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                //throw ex;
                pbxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }
    }
}
