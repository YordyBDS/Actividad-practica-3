using Biblioteca_de_clases;
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

        //______________________Mostrar Datos______________________\\
        public void Mostrar_Datos()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var lista = db.Proveedores.ToList();
                    dataGridView1.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar_Datos();
        }
        //__________________________________________________________\\


        //______________________Insertar Datos______________________\\
        public void Insertar_Datos(DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var nuevoProveedor = new Proveedores
                    {
                        NombreProveedor = fila.Cells["Proveedor"].Value?.ToString(),
                        CorreoElectronico = fila.Cells["Correo Electronico"].Value?.ToString(),
                        Telefono = fila.Cells["Telefono"].Value?.ToString(),
                        
                    };

                    db.Proveedores.Add(nuevoProveedor);
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
        //__________________________________________________________\\


        //______________________Actualizar Datos______________________\\
        public void Actualizar_Datos(int proveedorID, DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var proveedor = db.Proveedores.FirstOrDefault(c => c.ProveedorID == proveedorID);

                    if (proveedor != null)
                    {
                        proveedor.NombreProveedor = fila.Cells["Proveedor"].Value?.ToString();
                        proveedor.CorreoElectronico = fila.Cells["Correo Electronico"].Value?.ToString();
                        proveedor.Telefono = fila.Cells["Telefono"].Value?.ToString();
                        

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
                int proveedorID = Convert.ToInt32(fila.Cells["ID Proveedor"].Value);
                Actualizar_Datos(proveedorID, fila);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //_____________________________________________________________\\
        


        //______________________Eliminar Datos_________________________\\
        public void Eliminar_Datos(int proveedorID)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var proveedor = db.Proveedores.FirstOrDefault(c => c.ProveedorID == proveedorID);

                    if (proveedor != null)
                    {
                        db.Proveedores.Remove(proveedor);
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
        //______________________________________________________________\\

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
