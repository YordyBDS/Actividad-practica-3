using Biblioteca_de_clases;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace Formulario_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //_____________________Eliminar Datos_____________________\\
        public void Eliminar_Datos(int productoID)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var producto = db.Productos.FirstOrDefault(p => p.ProductoID == productoID);

                    if (producto != null)
                    {
                        db.Productos.Remove(producto);
                        db.SaveChanges();

                        MessageBox.Show("Registro eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Mostrar_Datos();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // ✅ Conversión segura sin errores decimal → int
                    int productoID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Producto"].Value);
                    Eliminar_Datos(productoID);
                }
                else
                {
                    MessageBox.Show("Seleccione una fila para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //__________________________________________________________\\



        //_____________________Mostrar Datos_____________________\\
        public void Mostrar_Datos()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var productos = db.Productos
                        .Select(p => new
                        {
                            p.ProductoID,
                            p.Nombre,
                            p.Descripcion,
                            p.Precio,
                            p.Stock,
                            p.CategoriaID
                        })
                        .ToList();

                    dataGridView1.DataSource = productos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar_Datos();
        }
        //__________________________________________________________\\



        //_____________________Actualizar Datos_____________________\\
        public void Actualizar_Datos(int productoID, DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var producto = db.Productos.FirstOrDefault(p => p.ProductoID == productoID);

                    if (producto != null)
                    {
                        producto.Nombre = fila.Cells["Producto"].Value?.ToString();
                        producto.Descripcion = fila.Cells["Descripcion"].Value?.ToString();
                        producto.Precio = Convert.ToInt32(fila.Cells["Precio"].Value);
                        producto.Stock = Convert.ToInt32(fila.Cells["Stock"].Value);
                        producto.CategoriaID = Convert.ToInt32(fila.Cells["ID Categoria"].Value);

                        db.SaveChanges();
                        MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Mostrar_Datos();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                int productoID = Convert.ToInt32(fila.Cells["ID Producto"].Value);
                Actualizar_Datos(productoID, fila);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //__________________________________________________________\\



        //_____________________Insertar Datos_____________________\\
        public void Insertar_Datos(DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var producto = new Producto
                    {
                        Nombre = fila.Cells["Producto"].Value?.ToString(),
                        Descripcion = fila.Cells["Descripcion"].Value?.ToString(),
                        Precio = Convert.ToInt32(fila.Cells["Precio"].Value),
                        Stock = Convert.ToInt32(fila.Cells["Stock"].Value),
                        CategoriaID = Convert.ToInt32(fila.Cells["ID Categoria"].Value)
                    };

                    db.Productos.Add(producto);
                    db.SaveChanges();

                    MessageBox.Show("Registro insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar_Datos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;
                if (fila.Cells["ID Producto"].Value == null || string.IsNullOrEmpty(fila.Cells["ID Producto"].Value.ToString()))
                {
                    Insertar_Datos(fila);
                }
            }
        }
        //__________________________________________________________\\


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 6;

            dataGridView1.Columns[0].Name = "ID Producto";
            dataGridView1.Columns[0].DataPropertyName = "ProductoID";

            dataGridView1.Columns[1].Name = "Producto";
            dataGridView1.Columns[1].DataPropertyName = "Nombre";

            dataGridView1.Columns[2].Name = "Descripcion";
            dataGridView1.Columns[2].DataPropertyName = "Descripcion";

            dataGridView1.Columns[3].Name = "Precio";
            dataGridView1.Columns[3].DataPropertyName = "Precio";

            dataGridView1.Columns[4].Name = "Stock";
            dataGridView1.Columns[4].DataPropertyName = "Stock";

            dataGridView1.Columns[5].Name = "ID Categoria";
            dataGridView1.Columns[5].DataPropertyName = "CategoriaID";
        }
    }
}
