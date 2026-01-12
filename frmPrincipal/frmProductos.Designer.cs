using System.Windows.Forms;

namespace frmPrincipal
{
    partial class frmProductos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tbxFiltro = new System.Windows.Forms.TextBox();
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecioNro = new System.Windows.Forms.Label();
            this.pbxProducto = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPrecioTexto = new System.Windows.Forms.Label();
            this.gbxNombre = new System.Windows.Forms.GroupBox();
            this.gbxBusquedaAvanzada = new System.Windows.Forms.GroupBox();
            this.lblValorABuscar = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnBusquedaAvanzada = new System.Windows.Forms.Button();
            this.tbxBusquedaAvanzada = new System.Windows.Forms.TextBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProducto)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbxNombre.SuspendLayout();
            this.gbxBusquedaAvanzada.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.AllowUserToAddRows = false;
            this.dgvPrincipal.AllowUserToDeleteRows = false;
            this.dgvPrincipal.AllowUserToResizeRows = false;
            this.dgvPrincipal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrincipal.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPrincipal.Location = new System.Drawing.Point(13, 243);
            this.dgvPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPrincipal.MaximumSize = new System.Drawing.Size(937, 388);
            this.dgvPrincipal.MultiSelect = false;
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.ReadOnly = true;
            this.dgvPrincipal.RowHeadersWidth = 51;
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.Size = new System.Drawing.Size(646, 206);
            this.dgvPrincipal.TabIndex = 0;
            this.dgvPrincipal.SelectionChanged += new System.EventHandler(this.dgvPrincipal_SelectionChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Bahnschrift Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(6, 30);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(265, 50);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Buscar productos:";
            // 
            // tbxFiltro
            // 
            this.tbxFiltro.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.tbxFiltro.Location = new System.Drawing.Point(6, 28);
            this.tbxFiltro.MaxLength = 50;
            this.tbxFiltro.Name = "tbxFiltro";
            this.tbxFiltro.Size = new System.Drawing.Size(201, 27);
            this.tbxFiltro.TabIndex = 9;
            this.tbxFiltro.TextChanged += new System.EventHandler(this.tbxFiltro_TextChanged);
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnLimpiarFiltro.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(213, 24);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(95, 34);
            this.btnLimpiarFiltro.TabIndex = 10;
            this.btnLimpiarFiltro.Text = "Limpiar filtro";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Bahnschrift Condensed", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblNombre.ForeColor = System.Drawing.Color.Aqua;
            this.lblNombre.Location = new System.Drawing.Point(1, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(360, 75);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblDescripcion.Font = new System.Drawing.Font("Bahnschrift Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.Aqua;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 104);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(359, 82);
            this.lblDescripcion.TabIndex = 12;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecioNro
            // 
            this.lblPrecioNro.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblPrecioNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblPrecioNro.ForeColor = System.Drawing.SystemColors.Window;
            this.lblPrecioNro.Location = new System.Drawing.Point(82, 186);
            this.lblPrecioNro.Name = "lblPrecioNro";
            this.lblPrecioNro.Size = new System.Drawing.Size(277, 37);
            this.lblPrecioNro.TabIndex = 13;
            this.lblPrecioNro.Tag = "Precio";
            this.lblPrecioNro.Text = "            ";
            this.lblPrecioNro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbxProducto
            // 
            this.pbxProducto.Location = new System.Drawing.Point(14, 457);
            this.pbxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.pbxProducto.Name = "pbxProducto";
            this.pbxProducto.Size = new System.Drawing.Size(238, 237);
            this.pbxProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProducto.TabIndex = 1;
            this.pbxProducto.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuGestion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 31);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmMenuGestion
            // 
            this.tsmMenuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProductoToolStripMenuItem,
            this.modificarProductoToolStripMenuItem,
            this.eliminarProductoToolStripMenuItem});
            this.tsmMenuGestion.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmMenuGestion.Name = "tsmMenuGestion";
            this.tsmMenuGestion.Size = new System.Drawing.Size(106, 27);
            this.tsmMenuGestion.Text = "Menú gestión";
            // 
            // agregarProductoToolStripMenuItem
            // 
            this.agregarProductoToolStripMenuItem.Name = "agregarProductoToolStripMenuItem";
            this.agregarProductoToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.agregarProductoToolStripMenuItem.Text = "Agregar producto";
            this.agregarProductoToolStripMenuItem.Click += new System.EventHandler(this.agregarProductoToolStripMenuItem_Click);
            // 
            // modificarProductoToolStripMenuItem
            // 
            this.modificarProductoToolStripMenuItem.Name = "modificarProductoToolStripMenuItem";
            this.modificarProductoToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.modificarProductoToolStripMenuItem.Text = "Modificar producto";
            this.modificarProductoToolStripMenuItem.Click += new System.EventHandler(this.modificarProductoToolStripMenuItem_Click);
            // 
            // eliminarProductoToolStripMenuItem
            // 
            this.eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            this.eliminarProductoToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.eliminarProductoToolStripMenuItem.Text = "Eliminar producto";
            this.eliminarProductoToolStripMenuItem.Click += new System.EventHandler(this.eliminarProductoToolStripMenuItem_Click);
            // 
            // lblPrecioTexto
            // 
            this.lblPrecioTexto.AutoSize = true;
            this.lblPrecioTexto.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblPrecioTexto.Font = new System.Drawing.Font("Bahnschrift Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTexto.ForeColor = System.Drawing.Color.Aqua;
            this.lblPrecioTexto.Location = new System.Drawing.Point(2, 188);
            this.lblPrecioTexto.Name = "lblPrecioTexto";
            this.lblPrecioTexto.Size = new System.Drawing.Size(74, 33);
            this.lblPrecioTexto.TabIndex = 26;
            this.lblPrecioTexto.Tag = "";
            this.lblPrecioTexto.Text = "Precio:";
            this.lblPrecioTexto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbxNombre
            // 
            this.gbxNombre.BackColor = System.Drawing.Color.LightSeaGreen;
            this.gbxNombre.Controls.Add(this.lblPrecioTexto);
            this.gbxNombre.Controls.Add(this.lblPrecioNro);
            this.gbxNombre.Controls.Add(this.lblNombre);
            this.gbxNombre.Controls.Add(this.lblDescripcion);
            this.gbxNombre.Font = new System.Drawing.Font("Bahnschrift Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxNombre.Location = new System.Drawing.Point(285, 457);
            this.gbxNombre.Name = "gbxNombre";
            this.gbxNombre.Size = new System.Drawing.Size(374, 237);
            this.gbxNombre.TabIndex = 27;
            this.gbxNombre.TabStop = false;
            this.gbxNombre.Text = "DETALLES";
            // 
            // gbxBusquedaAvanzada
            // 
            this.gbxBusquedaAvanzada.BackColor = System.Drawing.Color.LightSeaGreen;
            this.gbxBusquedaAvanzada.Controls.Add(this.lblValorABuscar);
            this.gbxBusquedaAvanzada.Controls.Add(this.lblCriterio);
            this.gbxBusquedaAvanzada.Controls.Add(this.lblCampo);
            this.gbxBusquedaAvanzada.Controls.Add(this.btnBusquedaAvanzada);
            this.gbxBusquedaAvanzada.Controls.Add(this.tbxBusquedaAvanzada);
            this.gbxBusquedaAvanzada.Controls.Add(this.cboCriterio);
            this.gbxBusquedaAvanzada.Controls.Add(this.cboCampo);
            this.gbxBusquedaAvanzada.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.gbxBusquedaAvanzada.ForeColor = System.Drawing.SystemColors.Window;
            this.gbxBusquedaAvanzada.Location = new System.Drawing.Point(14, 149);
            this.gbxBusquedaAvanzada.Name = "gbxBusquedaAvanzada";
            this.gbxBusquedaAvanzada.Size = new System.Drawing.Size(645, 87);
            this.gbxBusquedaAvanzada.TabIndex = 28;
            this.gbxBusquedaAvanzada.TabStop = false;
            this.gbxBusquedaAvanzada.Text = "Búsqueda avanzada:";
            // 
            // lblValorABuscar
            // 
            this.lblValorABuscar.AutoSize = true;
            this.lblValorABuscar.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblValorABuscar.Location = new System.Drawing.Point(356, 29);
            this.lblValorABuscar.Name = "lblValorABuscar";
            this.lblValorABuscar.Size = new System.Drawing.Size(89, 19);
            this.lblValorABuscar.TabIndex = 6;
            this.lblValorABuscar.Text = "Valor a buscar:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblCriterio.Location = new System.Drawing.Point(179, 29);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(51, 19);
            this.lblCriterio.TabIndex = 5;
            this.lblCriterio.Text = "Criterio:";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblCampo.Location = new System.Drawing.Point(6, 29);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(48, 19);
            this.lblCampo.TabIndex = 4;
            this.lblCampo.Text = "Campo:";
            // 
            // btnBusquedaAvanzada
            // 
            this.btnBusquedaAvanzada.AutoSize = true;
            this.btnBusquedaAvanzada.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnBusquedaAvanzada.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnBusquedaAvanzada.Location = new System.Drawing.Point(565, 48);
            this.btnBusquedaAvanzada.Name = "btnBusquedaAvanzada";
            this.btnBusquedaAvanzada.Size = new System.Drawing.Size(75, 33);
            this.btnBusquedaAvanzada.TabIndex = 3;
            this.btnBusquedaAvanzada.Text = "Buscar";
            this.btnBusquedaAvanzada.UseVisualStyleBackColor = true;
            this.btnBusquedaAvanzada.Click += new System.EventHandler(this.btnBusquedaAvanzada_Click);
            // 
            // tbxBusquedaAvanzada
            // 
            this.tbxBusquedaAvanzada.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.tbxBusquedaAvanzada.Location = new System.Drawing.Point(360, 50);
            this.tbxBusquedaAvanzada.Name = "tbxBusquedaAvanzada";
            this.tbxBusquedaAvanzada.Size = new System.Drawing.Size(171, 27);
            this.tbxBusquedaAvanzada.TabIndex = 2;
            this.tbxBusquedaAvanzada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBusquedaAvanzada_KeyPress);
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(183, 50);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(166, 27);
            this.cboCriterio.TabIndex = 1;
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(6, 50);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(166, 27);
            this.cboCampo.TabIndex = 0;
            this.cboCampo.SelectionChangeCommitted += new System.EventHandler(this.cboCampo_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Controls.Add(this.btnLimpiarFiltro);
            this.groupBox1.Controls.Add(this.tbxFiltro);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(14, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 63);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda rápida:";
            // 
            // frmProductos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(666, 704);
            this.Controls.Add(this.pbxProducto);
            this.Controls.Add(this.dgvPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbxNombre);
            this.Controls.Add(this.gbxBusquedaAvanzada);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de Kiosco";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Shown += new System.EventHandler(this.frmProductos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProducto)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxNombre.ResumeLayout(false);
            this.gbxNombre.PerformLayout();
            this.gbxBusquedaAvanzada.ResumeLayout(false);
            this.gbxBusquedaAvanzada.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.PictureBox pbxProducto;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox tbxFiltro;
        private System.Windows.Forms.Button btnLimpiarFiltro;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecioNro;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmMenuGestion;
        private ToolStripMenuItem agregarProductoToolStripMenuItem;
        private ToolStripMenuItem modificarProductoToolStripMenuItem;
        private ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private Label lblPrecioTexto;
        private GroupBox gbxNombre;
        private GroupBox gbxBusquedaAvanzada;
        private ComboBox cboCampo;
        private Button btnBusquedaAvanzada;
        private TextBox tbxBusquedaAvanzada;
        private ComboBox cboCriterio;
        private Label lblValorABuscar;
        private Label lblCriterio;
        private Label lblCampo;
        private GroupBox groupBox1;
    }
}

