namespace Actividad_practica_III
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textCliente = new TextBox();
            textProveedores = new TextBox();
            textProductos = new TextBox();
            comboBoxCategoria = new ComboBox();
            btnInsertar = new Button();
            btnMostrar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            dataGridView1 = new DataGridView();
            Clientes = new DataGridViewTextBoxColumn();
            Categorias = new DataGridViewTextBoxColumn();
            Proveedores = new DataGridViewTextBoxColumn();
            Productos = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 41);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 109);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Categoria";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 176);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 2;
            label3.Text = "Proveedor";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(10, 234);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 3;
            label4.Text = "Producto";
            label4.Click += label4_Click;
            // 
            // textCliente
            // 
            textCliente.Location = new Point(10, 58);
            textCliente.Margin = new Padding(3, 2, 3, 2);
            textCliente.Name = "textCliente";
            textCliente.Size = new Size(110, 23);
            textCliente.TabIndex = 4;
            textCliente.TextChanged += textCliente_TextChanged;
            // 
            // textProveedores
            // 
            textProveedores.Location = new Point(10, 193);
            textProveedores.Margin = new Padding(3, 2, 3, 2);
            textProveedores.Name = "textProveedores";
            textProveedores.Size = new Size(110, 23);
            textProveedores.TabIndex = 5;
            textProveedores.TextChanged += textProveedores_TextChanged;
            // 
            // textProductos
            // 
            textProductos.Location = new Point(10, 251);
            textProductos.Margin = new Padding(3, 2, 3, 2);
            textProductos.Name = "textProductos";
            textProductos.Size = new Size(110, 23);
            textProductos.TabIndex = 6;
            textProductos.TextChanged += textProductos_TextChanged;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(10, 126);
            comboBoxCategoria.Margin = new Padding(3, 2, 3, 2);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(133, 23);
            comboBoxCategoria.TabIndex = 7;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(168, 288);
            btnInsertar.Margin = new Padding(3, 2, 3, 2);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(82, 22);
            btnInsertar.TabIndex = 9;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(431, 288);
            btnMostrar.Margin = new Padding(3, 2, 3, 2);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(82, 22);
            btnMostrar.TabIndex = 10;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(301, 288);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(82, 22);
            btnActualizar.TabIndex = 11;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(555, 288);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(10, 288);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(82, 22);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Clientes, Categorias, Proveedores, Productos });
            dataGridView1.Location = new Point(168, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(444, 216);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Clientes
            // 
            Clientes.HeaderText = "Clientes";
            Clientes.Name = "Clientes";
            // 
            // Categorias
            // 
            Categorias.HeaderText = "Categorias";
            Categorias.Name = "Categorias";
            // 
            // Proveedores
            // 
            Proveedores.HeaderText = "Proveedores";
            Proveedores.Name = "Proveedores";
            // 
            // Productos
            // 
            Productos.HeaderText = "Productos";
            Productos.Name = "Productos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 345);
            Controls.Add(dataGridView1);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnMostrar);
            Controls.Add(btnInsertar);
            Controls.Add(comboBoxCategoria);
            Controls.Add(textProductos);
            Controls.Add(textProveedores);
            Controls.Add(textCliente);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textCliente;
        private TextBox textProveedores;
        private TextBox textProductos;
        private ComboBox comboBoxCategoria;
        private Button btnInsertar;
        private Button btnMostrar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnAgregar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Clientes;
        private DataGridViewTextBoxColumn Categorias;
        private DataGridViewTextBoxColumn Proveedores;
        private DataGridViewTextBoxColumn Productos;
    }
}
