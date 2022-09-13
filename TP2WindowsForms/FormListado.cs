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
            DatosGrid();
            CategoriaDato categoria = new CategoriaDato();
            MarcaDato marca = new MarcaDato();

            CbCategoria.DataSource = categoria.ListaDeCategorias();
            CbCategoria.ValueMember = "Id";
            CbCategoria.DisplayMember = "Categoria";
            CbMarca.DataSource = marca.listaDeMarcas();
            CbMarca.ValueMember = "Id";
            CbMarca.DisplayMember = "Marca";
            CbOrdenar.Items.Add("Código A-Z");
            CbOrdenar.Items.Add("Código Z-A");
            CbOrdenar.Items.Add("Menor precio");
            CbOrdenar.Items.Add("Mayor precio");

        }
        private void dgvListaArticulo_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvListaArticulo.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.Imagen);

        }

        private void OcultarColumns()
        {
            dgvListaArticulo.Columns["ImagenURL"].Visible = false;
            dgvListaArticulo.Columns["ID"].Visible = false;
        }

        private void DatosGrid()
        {
            try
            {
                ArticuloDato dato = new ArticuloDato();
                listaArticulo = dato.listarArticulos();
                dgvListaArticulo.DataSource = listaArticulo;
                cargarImagen(listaArticulo[0].Imagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception )
            {
                pbxArticulo.Load(ValidacionesGenerales.ErrroImagenNoEncontrada());
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormAgregar agregar = new FormAgregar();
            agregar.ShowDialog();
            DatosGrid();
        }
    }
}
