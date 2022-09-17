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
    public partial class FormAgregar : Form
    {
        private Articulo AuxArt = null;

        public FormAgregar()
        {
            InitializeComponent();
        }

        public FormAgregar(Articulo articulo)
        {
            InitializeComponent();
            this.AuxArt = articulo;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ArticuloDato articuloDato = new ArticuloDato(); 

            try
            {
                if (AuxArt == null)
                {
                    AuxArt = new Articulo();
                }

                AuxArt.Codigo = textCodigo.Text;
                AuxArt.NombreArticulo = textNombre.Text;
                AuxArt.Descripcion = textDescripcion.Text;
                AuxArt.Marca = (Marca)cBoxMarca.SelectedItem;
                AuxArt.Categoria = (Categoria)cBoxCategoria.SelectedItem;
                AuxArt.Imagen = textUrl.Text;
                AuxArt.Precio = decimal.Parse(textPrecio.Text);

                if(AuxArt.IdArtículo != 0)
                {
                    MessageBox.Show(AuxArt.IdArtículo.ToString());
                    articuloDato.Modificar(AuxArt);
                    MessageBox.Show("ARTICULO MODIFICADO EXITOSAMENTE");
                    Close();

                }
                else
                {
                    articuloDato.Agregar(AuxArt);
                    MessageBox.Show("Agregado exitosamente");
                    Close();
                }

                

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
                PicBoxAdd.Load(imagen);
            }
            catch (Exception)
            {
                PicBoxAdd.Load(ValidacionesGenerales.ErrroImagenNoEncontrada());
            }
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {

            CategoriaDato datoCat = new CategoriaDato();
            MarcaDato datoMarca = new MarcaDato();

            try
            {
                cBoxCategoria.DataSource = datoCat.ListaDeCategorias();
                cBoxCategoria.ValueMember = "IdCategoria";
                cBoxCategoria.DisplayMember = "NombreCategoria";

                cBoxMarca.DataSource = datoMarca.listaDeMarcas();
                cBoxMarca.ValueMember = "IdMarca";
                cBoxMarca.DisplayMember = "NombreMarca";

                if (AuxArt != null)
                { 

                    textCodigo.Text = AuxArt.Codigo;
                    textDescripcion.Text = AuxArt.Descripcion;
                    textNombre.Text = AuxArt.NombreArticulo;
                    textPrecio.Text = AuxArt.Precio.ToString();
                    textUrl.Text = AuxArt.Imagen;
                    cargarImagen(AuxArt.Imagen);
                    cBoxCategoria.SelectedValue = AuxArt.Categoria.IdCategoria;
                    cBoxMarca.SelectedValue = AuxArt.Marca.IdMarca;
                   
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        private void textUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(textUrl.Text);
        }
        
    }
}
