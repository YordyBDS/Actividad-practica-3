namespace Actividad_practica_III
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBoxCategoria.Items.Add("Electrónicos");
            comboBoxCategoria.Items.Add("Electrodomésticos");
            comboBoxCategoria.Items.Add("Limpieza");
            comboBoxCategoria.Items.Add("Comestibles");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void textProveedores_TextChanged(object sender, EventArgs e)
        {

        }

        private void textProductos_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cliente = textCliente.Text;
            string proveedor = textProveedores.Text;
            string producto = textProductos.Text;
            string categoria = comboBoxCategoria.SelectedItem?.ToString() ?? "No seleccionada";

            dataGridView1.Rows.Add(cliente, proveedor, producto, categoria);

            textCliente.Clear();
            textProveedores.Clear();
            textProductos.Clear();


           
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
