using Actividad_practica_III;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Biblioteca_de_clases;




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
        //__________________________________Mostra Datos_________________________________//
        public void Mostrar_Datos()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var lista = db.Clientes.ToList();
                    dataGridView1.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrar_Click_1(object sender, EventArgs e)
        {
            Mostrar_Datos();
        }
        //________________________________________________________________________//


        //__________________________Eliminar Datos______________________________//
        public void Eliminar_datos(int clienteID)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var cliente = db.Clientes.FirstOrDefault(c => c.ClienteID == clienteID);

                    if (cliente != null)
                    {
                        db.Clientes.Remove(cliente);
                        db.SaveChanges();

                        MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Mostrar_Datos();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //_________________________________________________________________________//


        //____________________________Insertar Datos______________________________//
        public void Insertar_Datos(DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var nuevoCliente = new Clientes
                    {
                        Nombre_completo = fila.Cells["Nombre"].Value?.ToString(),
                        Correo_Electronico = fila.Cells["Correo Electronico"].Value?.ToString(),
                        Telefono = fila.Cells["Telefono"].Value?.ToString(),
                        Direccion = fila.Cells["Direccion"].Value?.ToString()
                    };

                    db.Clientes.Add(nuevoCliente);
                    db.SaveChanges();
                }

                MessageBox.Show("Registro insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar_Datos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //___________________________________________________________________________//



        //__________________________Actualizar Datos_______________________________//
        public void Actualizar_Datos(int clienteID, DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var cliente = db.Clientes.FirstOrDefault(c => c.ClienteID == clienteID);

                    if (cliente != null)
                    {
                        cliente.Nombre_completo = fila.Cells["Nombre"].Value?.ToString();
                        cliente.Correo_Electronico = fila.Cells["Correo Electronico"].Value?.ToString();
                        cliente.Telefono = fila.Cells["Telefono"].Value?.ToString();
                        cliente.Direccion = fila.Cells["Direccion"].Value?.ToString();

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
        //___________________________________________________________________________//

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

        
    }
}
