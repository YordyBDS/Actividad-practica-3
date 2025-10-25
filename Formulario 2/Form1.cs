using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Formulario_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        
        public void Mostrar_Datos()
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";


                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    string query = "SELECT CategoriaID, Nombre FROM Categoria";

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

        public void Insertar_Datos(DataGridViewRow fila)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string query = "INSERT INTO Categoria (Nombre) " +
                                   "VALUES (@Nombre)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    //cmd.Parameters.AddWithValue("@CategoriaID", fila.Cells["ID Categoria"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nombre", fila.Cells["Nombre"].Value ?? DBNull.Value);
                    

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

        public void Actualizar_Datos(int categoriaID, DataGridViewRow fila)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string query = "UPDATE Categoria SET Nombre=@Nombre WHERE CategoriaID=@CategoriaID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    cmd.Parameters.AddWithValue("@Nombre", fila.Cells["Nombre"].Value ?? DBNull.Value);
                    

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


        public void Eliminar_Datos(int categoriaID)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    string query = "DELETE FROM Categoria WHERE CategoriaID = @CategoriaID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue(@"CategoriaID", categoriaID);

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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar_Datos();
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;
                if (fila.Cells["ID Categoria"].Value == null || string.IsNullOrEmpty(fila.Cells["ID Categoria"].Value.ToString()))
                {
                    Insertar_Datos(fila);
                }
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                int categoriaID = Convert.ToInt32(fila.Cells["ID Categoria"].Value);

                Actualizar_Datos(categoriaID, fila);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int categoriaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Categoria"].Value);
                Eliminar_Datos(categoriaID);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 2;

            dataGridView1.Columns[0].Name = "ID Categoria";
            dataGridView1.Columns[0].DataPropertyName = "CategoriaID";

            dataGridView1.Columns[1].Name = "Nombre";
            dataGridView1.Columns[1].DataPropertyName = "Nombre";

        }
    }
}

