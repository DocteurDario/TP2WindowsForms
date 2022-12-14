using System;
using System.Collections;
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
            catch (Exception)
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
                if (result == DialogResult.Yes)
                {

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
            DatosGrid();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Articulo Select = new Articulo();
            Select = (Articulo)dgvListaArticulo.CurrentRow.DataBoundItem;
            // Agregar una exepcion que indique que elija una opcion -- no funciona bien corregir
            try
            {
                FormAgregar formAgregar = new FormAgregar(Select);
                formAgregar.ShowDialog();
                DatosGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Tiene que elegir un articulo " + ex);
            }

        }

        private void Lista(List<Articulo> articulos)
        {
            dgvListaArticulo.DataSource = null;
            dgvListaArticulo.DataSource = articulos;
            OcultarColumns();
        }

       

        

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = textBoxBuscar.Text;

            if (filtro != "")
            {
                listaFiltrada = listaArticulo.FindAll(x => x.NombreArticulo.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }
            dgvListaArticulo.DataSource = null;
            dgvListaArticulo.DataSource = listaFiltrada;
            OcultarColumns();

        }

        private void dgvListaArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo Select = new Articulo();
            Select = (Articulo)dgvListaArticulo.CurrentRow.DataBoundItem;

            FormVerDetalle Lal = new FormVerDetalle(Select);
            Lal.ShowDialog();
            DatosGrid();
        }

        private void CbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Articulo Aux = new Articulo();
            List<Articulo> lista;
            Aux.Categoria = (Categoria)CbCategoria.SelectedItem;
            Aux.Marca = (Marca)CbMarca.SelectedItem;
            if (CbMarca.SelectedIndex == -1)
            {

                lista = listaArticulo.FindAll(x => x.Categoria.IdCategoria == Aux.Categoria.IdCategoria);
            }

            else
            {
                lista = listaArticulo.FindAll(x => x.Categoria.IdCategoria == Aux.Categoria.IdCategoria && x.Marca.IdMarca == Aux.Marca.IdMarca);
            }

                Lista(lista);
                OcultarColumns();
        }

        private void CbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CbMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Articulo Aux = new Articulo();
            List<Articulo> lista;
            Aux.Categoria = (Categoria)CbCategoria.SelectedItem;
            Aux.Marca = (Marca)CbMarca.SelectedItem;
            if (CbCategoria.SelectedIndex == -1)
            {

                lista = listaArticulo.FindAll(x => x.Marca.IdMarca == Aux.Marca.IdMarca);
            }
            else
            {
                lista = listaArticulo.FindAll(x => x.Categoria.IdCategoria == Aux.Categoria.IdCategoria && x.Marca.IdMarca == Aux.Marca.IdMarca);
            }

            Lista(lista);
            OcultarColumns();
        }
    }

}
        


        
       
        
       
