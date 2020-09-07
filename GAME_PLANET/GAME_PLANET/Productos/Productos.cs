using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GAME_PLANET
{
    public partial class Productos : Form
    {
        Conectar conexion = new Conectar();
        SQLiteCommandBuilder scb;
        SQLiteDataAdapter adaptar;
        DataTable Producto;
        string N;


        public Productos()
        {
            InitializeComponent();
        }

        public void btnAddProducto_Click(object sender, EventArgs e)
        {
            AddProducto addProducto = new AddProducto();
            addProducto.Show();
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            UpdateProducto updateProducto = new UpdateProducto();
            updateProducto.Show();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            IfEliminarProducto ifEliminarProducto = new IfEliminarProducto();
            ifEliminarProducto.Nombre1 = N;
            ifEliminarProducto.Show();

        }
     
        private void Productos_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto";
            DataTable Producto = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductos.DataSource = Producto;
        }

        public void btnMostrarProducto_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto";
            DataTable Producto= new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductos.DataSource = Producto;
        }

  
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvProductos.CurrentRow.Selected = true;
                   
                    N = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                    pictureBoxP.ImageLocation = "" + Conectar.USB + ":/Users/LuisL/OneDrive/PROYECTO/GAME_PLANET/GAME_PLANET/Pic/" + N + ".jpg";
                }
            }
            catch (Exception A)
            {

                MessageBox.Show("Casilla Invalida");
            }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dgvProductos.Columns[e.ColumnIndex].Name == "Cantidad")
                {

                    if (Convert.ToInt32(e.Value) <= 50)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.BackColor = Color.MistyRose;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Casilla Invalida");
            }
           
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void BoxBucarProducto_TextChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto WHERE Nombre LIKE ('"+ BoxBucarProducto.Text +"%')";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductos.DataSource = Producto;
        }

        private void comboBoxConsola_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto WHERE Tipo_Consola ='" + comboBoxConsola.Text+ "'";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductos.DataSource = Producto;
        }

        private void BtnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
