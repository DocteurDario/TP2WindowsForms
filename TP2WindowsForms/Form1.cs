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
            FormListado ventanaListado = new FormListado();
            ventanaListado.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBusqueda VentanaBusqueda = new FormBusqueda();
            VentanaBusqueda.Show();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgregar VentanaAgregar = new FormAgregar();
            VentanaAgregar.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModificar ventanaModificar = new FormModificar();
            ventanaModificar.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEliminar ventanaEliminar =new FormEliminar();
            ventanaEliminar.Show();
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVerDetalle ventanaVerDetalle = new FormVerDetalle();
            ventanaVerDetalle.Show();
        }
    }
}
