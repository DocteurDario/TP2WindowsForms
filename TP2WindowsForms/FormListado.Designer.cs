namespace TP2WindowsForms
{
    partial class FormListado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListaArticulo = new System.Windows.Forms.DataGridView();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaArticulo
            // 
            this.dgvListaArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulo.Location = new System.Drawing.Point(12, 24);
            this.dgvListaArticulo.Name = "dgvListaArticulo";
            this.dgvListaArticulo.Size = new System.Drawing.Size(726, 248);
            this.dgvListaArticulo.TabIndex = 0;
            this.dgvListaArticulo.SelectionChanged += new System.EventHandler(this.dgvListaArticulo_SelectionChanged);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(744, 24);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(206, 248);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 1;
            this.pbxArticulo.TabStop = false;
            // 
            // FormListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 307);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.dgvListaArticulo);
            this.Name = "FormListado";
            this.Text = "Listado De Articulos";
            this.Load += new System.EventHandler(this.FormListado_Load);
            this.SizeChanged += new System.EventHandler(this.FormListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaArticulo;
        private System.Windows.Forms.PictureBox pbxArticulo;
    }
}