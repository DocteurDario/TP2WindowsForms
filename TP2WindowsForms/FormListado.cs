using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using Conexion_a_DB;


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

            try
            {
                CbCategoria.DataSource = categoria.ListaDeCategorias();
                CbCategoria.ValueMember = "IdCategoria";
                CbCategoria.DisplayMember = "NombreCategoria";

                CbMarca.DataSource = marca.listaDeMarcas();
                CbMarca.ValueMember = "IdMarca";
                CbMarca.DisplayMember = "NombreMarca";

                CbOrdenar.Items.Add("Código A-Z");
                CbOrdenar.Items.Add("Código Z-A");
                CbOrdenar.Items.Add("Menor precio");
                CbOrdenar.Items.Add("Mayor precio");

                Borrar_Cb();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Borrar_Cb()
        {
            CbCategoria.SelectedIndex = -1;
            CbMarca.SelectedIndex = -1;
            CbOrdenar.SelectedIndex = -1;
        }


        private void dgvListaArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaArticulo.CurrentRow != null)
            {
                Articulo select = (Articulo)dgvListaArticulo.CurrentRow.DataBoundItem;
                cargarImagen(select.Imagen);
            }

        }

        private void OcultarColumns()
        {
            dgvListaArticulo.Columns["Imagen"].Visible = false;
            dgvListaArticulo.Columns["IdArtículo"].Visible = false;
        }

        private void DatosGrid()
        {
            try
            {
                ArticuloDato dato = new ArticuloDato();
                listaArticulo = dato.listarArticulos();                
                dgvListaArticulo.DataSource = listaArticulo;
                OcultarColumns();
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ArticuloDato articulo = new ArticuloDato();
            Articulo Select;

            try
            {
                DialogResult result = MessageBox.Show("¿DESEA ELIMINAR EL ARTICULO SELECCIONADO?", "ELIMINADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes){

                    Select = (Articulo)dgvListaArticulo.CurrentRow.DataBoundItem;
                    articulo.Eliminar(Select);
                    DatosGrid();
                    
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Borrar_Cb();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Articulo Select = new Articulo();
            Select = (Articulo)dgvListaArticulo.CurrentRow.DataBoundItem;
            FormAgregar formAgregar = new FormAgregar(Select);
            formAgregar.ShowDialog();
            DatosGrid();
        }

        private void Lista(List<Articulo> articulos)
        {
            dgvListaArticulo.DataSource = null;
            dgvListaArticulo.DataSource = articulos;
            OcultarColumns();
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            if(CbOrdenar.SelectedIndex != -1)
            {
                ArticuloDato dato = new ArticuloDato();
                string criterio = CbOrdenar.Text;
                Lista(dato.Ordenar(criterio));
            }

            if(CbCategoria.SelectedIndex != -1 && CbMarca.SelectedIndex != -1)
            {

            }
            
        }
    }
}
