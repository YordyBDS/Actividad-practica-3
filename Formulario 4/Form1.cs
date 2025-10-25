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


        public void Eliminar_Datos(int productoID)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    string query = "DELETE FROM Producto WHERE ProductoID = @ProductoID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue(@"ProductoID", productoID);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Mostrar_Datos();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro para eliminara", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int proveedorID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Producto"].Value);
                Eliminar_Datos(proveedorID);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Mostrar_Datos()
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";


                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    string query = "SELECT ProductoID, Nombre, Descripcion, Precio, Stock, CategoriaID FROM Producto";

                    SqlDataAdapter da = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar_Datos();
        }


        public void Actualizar_Datos(int productoID, DataGridViewRow fila)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string query = "UPDATE Producto SET Nombre=@Nombre, Descripcion=@Descripcion, Precio=@Precio, Stock=@Stock, " +
                        " CategoriaID=@CategoriaID WHERE ProductoID=@ProductoID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ProductoID", productoID);
                    cmd.Parameters.AddWithValue("@Nombre", fila.Cells["Producto"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Descripcion", fila.Cells["Descripcion"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Precio", fila.Cells["Precio"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stock", fila.Cells["Stock"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoriaID", fila.Cells["ID Categoria"].Value ?? DBNull.Value);


                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
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


        public void Insertar_Datos(DataGridViewRow fila)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string query = "INSERT INTO Producto (Nombre, Descripcion, Precio, Stock, CategoriaID) " +
                                   "VALUES (@Nombre, @Descripcion, @Precio, @Stock, @CategoriaID)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Nombre", fila.Cells["Producto"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Descripcion", fila.Cells["Descripcion"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Precio", fila.Cells["Precio"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stock", fila.Cells["Stock"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoriaID", fila.Cells["ID Categoria"].Value ?? DBNull.Value);


                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Mostrar_Datos();
                    }
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
