namespace _2026_2C_Clase2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCargarGrilla = new Button();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            lblProducto = new Label();
            cboProducto = new ComboBox();
            cboComercio1 = new ComboBox();
            lblComercio1 = new Label();
            lblPrecio1 = new Label();
            lblPrecio2 = new Label();
            lblComercio2 = new Label();
            cboComercio2 = new ComboBox();
            txtPrecio1 = new TextBox();
            txtPrecio2 = new TextBox();
            dgvComparacion = new DataGridView();
            fecha = new DataGridViewTextBoxColumn();
            producto = new DataGridViewTextBoxColumn();
            comercio1 = new DataGridViewTextBoxColumn();
            precio1 = new DataGridViewTextBoxColumn();
            comercio2 = new DataGridViewTextBoxColumn();
            precio2 = new DataGridViewTextBoxColumn();
            btnRefrescarGrilla = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvComparacion).BeginInit();
            SuspendLayout();
            // 
            // btnCargarGrilla
            // 
            btnCargarGrilla.Location = new Point(12, 218);
            btnCargarGrilla.Name = "btnCargarGrilla";
            btnCargarGrilla.Size = new Size(156, 43);
            btnCargarGrilla.TabIndex = 16;
            btnCargarGrilla.Text = "Registrar Valor";
            btnCargarGrilla.UseVisualStyleBackColor = true;
            btnCargarGrilla.Click += btnCargarGrilla_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(12, 38);
            dtpFecha.MaxDate = new DateTime(2030, 1, 1, 0, 0, 0, 0);
            dtpFecha.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(114, 23);
            dtpFecha.TabIndex = 2;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(154, 20);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(56, 15);
            lblProducto.TabIndex = 4;
            lblProducto.Text = "Producto";
            // 
            // cboProducto
            // 
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(154, 38);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(329, 23);
            cboProducto.TabIndex = 5;
            cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
            // 
            // cboComercio1
            // 
            cboComercio1.FormattingEnabled = true;
            cboComercio1.Location = new Point(12, 119);
            cboComercio1.Name = "cboComercio1";
            cboComercio1.Size = new Size(156, 23);
            cboComercio1.TabIndex = 6;
            cboComercio1.SelectedIndexChanged += cboComercio1_SelectedIndexChanged;
            // 
            // lblComercio1
            // 
            lblComercio1.AutoSize = true;
            lblComercio1.Location = new Point(12, 101);
            lblComercio1.Name = "lblComercio1";
            lblComercio1.Size = new Size(68, 15);
            lblComercio1.TabIndex = 7;
            lblComercio1.Text = "Comercio 1";
            // 
            // lblPrecio1
            // 
            lblPrecio1.AutoSize = true;
            lblPrecio1.Location = new Point(12, 153);
            lblPrecio1.Name = "lblPrecio1";
            lblPrecio1.Size = new Size(49, 15);
            lblPrecio1.TabIndex = 9;
            lblPrecio1.Text = "Precio 1";
            // 
            // lblPrecio2
            // 
            lblPrecio2.AutoSize = true;
            lblPrecio2.Location = new Point(225, 153);
            lblPrecio2.Name = "lblPrecio2";
            lblPrecio2.Size = new Size(49, 15);
            lblPrecio2.TabIndex = 13;
            lblPrecio2.Text = "Precio 2";
            // 
            // lblComercio2
            // 
            lblComercio2.AutoSize = true;
            lblComercio2.Location = new Point(225, 101);
            lblComercio2.Name = "lblComercio2";
            lblComercio2.Size = new Size(68, 15);
            lblComercio2.TabIndex = 11;
            lblComercio2.Text = "Comercio 2";
            // 
            // cboComercio2
            // 
            cboComercio2.FormattingEnabled = true;
            cboComercio2.Location = new Point(225, 119);
            cboComercio2.Name = "cboComercio2";
            cboComercio2.Size = new Size(156, 23);
            cboComercio2.TabIndex = 10;
            cboComercio2.SelectedIndexChanged += cboComercio2_SelectedIndexChanged;
            // 
            // txtPrecio1
            // 
            txtPrecio1.Location = new Point(12, 171);
            txtPrecio1.Name = "txtPrecio1";
            txtPrecio1.Size = new Size(156, 23);
            txtPrecio1.TabIndex = 14;
            // 
            // txtPrecio2
            // 
            txtPrecio2.Location = new Point(225, 171);
            txtPrecio2.Name = "txtPrecio2";
            txtPrecio2.Size = new Size(156, 23);
            txtPrecio2.TabIndex = 15;
            // 
            // dgvComparacion
            // 
            dgvComparacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComparacion.Columns.AddRange(new DataGridViewColumn[] { fecha, producto, comercio1, precio1, comercio2, precio2 });
            dgvComparacion.Location = new Point(12, 267);
            dgvComparacion.Name = "dgvComparacion";
            dgvComparacion.Size = new Size(703, 202);
            dgvComparacion.TabIndex = 20;
            dgvComparacion.TabStop = false;
            // 
            // fecha
            // 
            fecha.HeaderText = "Fecha";
            fecha.Name = "fecha";
            fecha.ReadOnly = true;
            // 
            // producto
            // 
            producto.HeaderText = "Producto";
            producto.Name = "producto";
            producto.ReadOnly = true;
            // 
            // comercio1
            // 
            comercio1.HeaderText = "Comercio 1";
            comercio1.Name = "comercio1";
            comercio1.ReadOnly = true;
            // 
            // precio1
            // 
            precio1.HeaderText = "Precio 1";
            precio1.Name = "precio1";
            precio1.ReadOnly = true;
            precio1.ToolTipText = "Precio que corresponde al prodcto en el comercio 1";
            // 
            // comercio2
            // 
            comercio2.HeaderText = "Comercio 2";
            comercio2.Name = "comercio2";
            comercio2.ReadOnly = true;
            // 
            // precio2
            // 
            precio2.HeaderText = "Precio 2";
            precio2.Name = "precio2";
            precio2.ReadOnly = true;
            precio2.ToolTipText = "Precio que corresponde al producto en el comercio 2";
            // 
            // btnRefrescarGrilla
            // 
            btnRefrescarGrilla.Location = new Point(225, 218);
            btnRefrescarGrilla.Name = "btnRefrescarGrilla";
            btnRefrescarGrilla.Size = new Size(156, 43);
            btnRefrescarGrilla.TabIndex = 21;
            btnRefrescarGrilla.Text = "Refrescar Grilla";
            btnRefrescarGrilla.UseVisualStyleBackColor = true;
            btnRefrescarGrilla.Click += btnRefrescarGrilla_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 481);
            Controls.Add(btnRefrescarGrilla);
            Controls.Add(dgvComparacion);
            Controls.Add(txtPrecio2);
            Controls.Add(txtPrecio1);
            Controls.Add(lblPrecio2);
            Controls.Add(lblComercio2);
            Controls.Add(cboComercio2);
            Controls.Add(lblPrecio1);
            Controls.Add(lblComercio1);
            Controls.Add(cboComercio1);
            Controls.Add(cboProducto);
            Controls.Add(lblProducto);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(btnCargarGrilla);
            Name = "Form1";
            Text = "Comparador de Precios";
            ((System.ComponentModel.ISupportInitialize)dgvComparacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargarGrilla;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private Label lblProducto;
        private ComboBox cboProducto;
        private ComboBox cboComercio1;
        private Label lblComercio1;
        private Label lblPrecio1;
        private Label lblPrecio2;
        private Label lblComercio2;
        private ComboBox cboComercio2;
        private TextBox txtPrecio1;
        private TextBox txtPrecio2;
        private DataGridView dgvComparacion;
        private DataGridViewTextBoxColumn fecha;
        private DataGridViewTextBoxColumn producto;
        private DataGridViewTextBoxColumn comercio1;
        private DataGridViewTextBoxColumn precio1;
        private DataGridViewTextBoxColumn comercio2;
        private DataGridViewTextBoxColumn precio2;
        private Button btnRefrescarGrilla;
    }
}
