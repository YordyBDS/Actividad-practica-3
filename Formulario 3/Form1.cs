using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;



namespace Formulario_3
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


        public void Eliminar_Datos(int proveedorID)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    string query = "DELETE FROM Proveedores WHERE ProveedorID = @ProveedorID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue(@"ProveedorID", proveedorID);

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
                int proveedorID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Proveedor"].Value);
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
                    string query = "SELECT ProveedorID, NombreProveedor, Telefono, CorreoElectronico FROM Proveedores";

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

        public void Actualizar_Datos(int proveedorID, DataGridViewRow fila)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string query = "UPDATE Proveedores SET NombreProveedor=@NombreProveedor, Telefono=@Telefono, " +
                        " CorreoElectronico=@CorreoElectronico WHERE ProveedorID=@ProveedorID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);
                    cmd.Parameters.AddWithValue("@NombreProveedor", fila.Cells["Proveedor"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", fila.Cells["Telefono"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", fila.Cells["Correo Electronico"].Value ?? DBNull.Value);


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
                int proveedorID = Convert.ToInt32(fila.Cells["ID Proveedor"].Value);

                Actualizar_Datos(proveedorID, fila);
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

                    string query = "INSERT INTO Proveedores (NombreProveedor, Telefono, CorreoElectronico) " +
                                   "VALUES (@NombreProveedor, @Telefono, @CorreoElectronico)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NombreProveedor", fila.Cells["Proveedor"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", fila.Cells["Telefono"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", fila.Cells["Correo Electronico"].Value ?? DBNull.Value);


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
                if (fila.Cells["ID Proveedor"].Value == null || string.IsNullOrEmpty(fila.Cells["ID Proveedor"].Value.ToString()))
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
            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "ID Proveedor";
            dataGridView1.Columns[0].DataPropertyName = "ProveedorID";

            dataGridView1.Columns[1].Name = "Proveedor";
            dataGridView1.Columns[1].DataPropertyName = "NombreProveedor";

            dataGridView1.Columns[2].Name = "Telefono";
            dataGridView1.Columns[2].DataPropertyName = "Telefono";

            dataGridView1.Columns[3].Name = "Correo Electronico";
            dataGridView1.Columns[3].DataPropertyName = "CorreoElectronico";
        }

        
    }
}
