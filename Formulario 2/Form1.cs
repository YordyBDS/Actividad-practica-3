using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms;
using Biblioteca_de_clases;




namespace Formulario_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        //___________________________Mostrar Datos________________________//
        public void Mostrar_Datos()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var lista = db.Categoria.ToList();
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
        //_________________________________________________________________//





        //___________________________Inseertar Datos________________________//
        public void Insertar_Datos(DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var nuevaCategoria = new Categoria
                    {
                        Nombre = fila.Cells["Nombre"].Value?.ToString()
                    };

                    db.Categoria.Add(nuevaCategoria);
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
                if (fila.Cells["ID Categoria"].Value == null || string.IsNullOrEmpty(fila.Cells["ID Categoria"].Value.ToString()))
                {
                    Insertar_Datos(fila);
                }
            }
        }
        //_________________________________________________________________//




        //___________________________Actualizar Datos________________________\\
        public void Actualizar_Datos(int categoriaID, DataGridViewRow fila)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var categoria = db.Categoria.FirstOrDefault(c => c.CategoriaID == categoriaID);

                    if (categoria != null)
                    {
                        categoria.Nombre = fila.Cells["Nombre"].Value?.ToString();

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
                int categoriaID = Convert.ToInt32(fila.Cells["ID Categoria"].Value);
                Actualizar_Datos(categoriaID, fila);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //________________________________________________________________\\





        //___________________________Eliminar Datos________________________\\
        public void Eliminar_Datos(int categoriaID)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var categoria = db.Categoria.FirstOrDefault(c => c.CategoriaID == categoriaID);

                    if (categoria != null)
                    {
                        db.Categoria.Remove(categoria);
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
                int categoriaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Categoria"].Value);
                Eliminar_Datos(categoriaID);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //________________________________________________________________\\


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

