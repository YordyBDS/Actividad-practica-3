using Microsoft.Data.SqlClient;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Actividad_practica_III
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextProveedores_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextProductos_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Mostrar_Datos()
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";


                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    string query = "SELECT ClienteID, Nombre_completo, Correo_Electronico, Telefono, Direccion FROM Clientes";

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


        public void Eliminar_datos(int clienteID)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    string query = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue(@"ClienteID", clienteID);

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


        public void Insertar_Datos(DataGridViewRow fila)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string query = "INSERT INTO Clientes (Nombre_completo, Correo_Electronico, Telefono, Direccion) " +
                                   "VALUES (@Nombre, @Correo, @Telefono, @Direccion)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ClienteID", fila.Cells["ID Cliente"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nombre", fila.Cells["Nombre"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Correo", fila.Cells["Correo Electronico"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", fila.Cells["Telefono"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", fila.Cells["Direccion"].Value ?? DBNull.Value);

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


        public void Actualizar_Datos(int clienteID, DataGridViewRow fila)
        {
            try
            {
                string conexion = @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;";
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string query = "UPDATE Clientes SET Nombre_completo=@Nombre, Correo_Electronico=@Correo, " +
                                   "Telefono=@Telefono, Direccion=@Direccion WHERE ClienteID=@ClienteID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                    cmd.Parameters.AddWithValue("@Nombre", fila.Cells["Nombre"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Correo", fila.Cells["Correo Electronico"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", fila.Cells["Telefono"].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", fila.Cells["Direccion"].Value ?? DBNull.Value);

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




        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[0].Name = "ID Cliente";
            dataGridView1.Columns[0].DataPropertyName = "ClienteID";

            dataGridView1.Columns[1].Name = "Nombre";
            dataGridView1.Columns[1].DataPropertyName = "Nombre_completo";

            dataGridView1.Columns[2].Name = "Correo Electronico";
            dataGridView1.Columns[2].DataPropertyName = "Correo_Electronico";

            dataGridView1.Columns[3].Name = "Telefono";
            dataGridView1.Columns[3].DataPropertyName = "Telefono";

            dataGridView1.Columns[4].Name = "Direccion";
            dataGridView1.Columns[4].DataPropertyName = "Direccion";



            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click_1(object sender, EventArgs e)
        {
            Mostrar_Datos();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                int clienteID = Convert.ToInt32(fila.Cells["ID Cliente"].Value);

                Actualizar_Datos(clienteID, fila);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int clienteID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Cliente"].Value);
                Eliminar_datos(clienteID);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue; 
                if (fila.Cells["ID Cliente"].Value == null || string.IsNullOrEmpty(fila.Cells["ID Cliente"].Value.ToString()))
                {
                    Insertar_Datos(fila);
                }
            }
        }
    }
}
