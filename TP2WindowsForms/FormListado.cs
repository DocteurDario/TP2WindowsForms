﻿using System;
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
        public FormListado()
        {
            InitializeComponent();
        }

        private void FormListado_Load(object sender, EventArgs e)
        {
            ArticuloDato dato = new ArticuloDato();
            dgvListaArticulo.DataSource = dato.listarArticulos();
        }
    }
}
