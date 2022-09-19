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
    public partial class FormVerDetalle : Form
    {
        private Articulo AuxArt = new Articulo();

        public FormVerDetalle()
        {
            InitializeComponent();
        }
        public FormVerDetalle(Articulo Detalle)
        {
            InitializeComponent();
            AuxArt = Detalle;

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

        private void FormVerDetalle_Load(object sender, EventArgs e)
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
        }
    }
