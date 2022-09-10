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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(FormListado))
                {
                    MessageBox.Show("Ya existe una ventana abierta, termine de trabajar allí!.. ");
                    return;
                }
            }            
            FormListado ventanaListado = new FormListado()  ;
            ventanaListado.MdiParent = this;
            ventanaListado.Show();
        }
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(FormBusqueda))
                {
                    MessageBox.Show("Ya existe una ventana abierta, termine de trabajar allí!.. ");
                    return;
                }
            }
            FormBusqueda ventanaBusqueda = new FormBusqueda();
            ventanaBusqueda.MdiParent = this;
            ventanaBusqueda.Show();
        }
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(FormAgregar))
                {
                    MessageBox.Show("Ya existe una ventana abierta, termine de trabajar allí!.. ");
                    return;
                }
            }
            FormAgregar ventanaAgregar = new FormAgregar();
            ventanaAgregar.MdiParent = this;
            ventanaAgregar.Show();
        }
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(FormModificar))
                {
                    MessageBox.Show("Ya existe una ventana abierta, termine de trabajar allí!.. ");
                    return;
                }
            }

            FormModificar ventanaModificar = new FormModificar();
            ventanaModificar.MdiParent = this;
            ventanaModificar.Show();
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(FormEliminar))
                {
                    MessageBox.Show("Ya existe una ventana abierta, termine de trabajar allí!.. ");
                    return;
                }
            }
            FormEliminar ventanaEliminar = new FormEliminar();
            ventanaEliminar.MdiParent = this;
            ventanaEliminar.Show();
        }
        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(FormVerDetalle))
                {
                    MessageBox.Show("Ya existe una ventana abierta, termine de trabajar allí!.. ");
                    return;
                }
            }
            FormVerDetalle ventanaVerDetalle = new FormVerDetalle();
            ventanaVerDetalle.MdiParent = this;
            ventanaVerDetalle.Show();
        }
    }
}
