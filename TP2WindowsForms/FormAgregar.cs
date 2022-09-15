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
    public partial class FormAgregar : Form
    {
        public FormAgregar()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Articulo nuevoArt = new Articulo();
            try
            {
                nuevoArt.Codigo = textCodigo.Text;
                nuevoArt.NombreArticulo = textNombre.Text;
                nuevoArt.Descripcion = textDescripcion.Text;
                //nuevoArt.Marca = cBoxMarca.Text;
                //nuevoArt.Categoria = cBoxCategoria.Text;
                nuevoArt.Imagen = textUrl.Text;
                nuevoArt.Precio = Decimal.Parse(textPrecio.Text);

                //ArticuloDato.Agregar(nuevoArt);
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
