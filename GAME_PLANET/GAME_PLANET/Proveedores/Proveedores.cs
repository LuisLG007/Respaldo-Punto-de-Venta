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
    public partial class Proveedores : Form
    {
        Conectar conexion = new Conectar();
        DataTable Proveedor;
        SQLiteDataAdapter adaptar;
        string N;

        public Proveedores()
        {
            InitializeComponent();
        }

        private void btnAddProveedor_Click(object sender, EventArgs e)
        {
            AddProveedor addProveedor = new AddProveedor();
            addProveedor.Show();
        }

        private void btnActualizarProveedor_Click(object sender, EventArgs e)
        {
            UpdateProveedor updateProveedor = new UpdateProveedor();
            updateProveedor.Show();
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {

            IfEliminarProveedor ifEliminarProveedor = new IfEliminarProveedor();
            ifEliminarProveedor.RFC = N;
            ifEliminarProveedor.Show();
        }
      
        private void btnMostrarProveedor_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Proveedor";
            Proveedor = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Proveedor);
            dgvProveedores.DataSource = Proveedor;
            BusquedaDeProveedor.Text = "";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Proveedor WHERE RFC = '" + BusquedaDeProveedor.Text + "'";
                Proveedor = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Proveedor);
                dgvProveedores.DataSource = Proveedor;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al realizar la busqueda"); ;
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvProveedores.CurrentRow.Selected = true;

                    N = dgvProveedores.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                    pictureBoxP.ImageLocation = "" + Conectar.USB + ":/Users/LuisL/OneDrive/PROYECTO/GAME_PLANET/GAME_PLANET/Pic Clientes/" + N + ".JPG";

                }
            }
            catch (Exception A)
            {

                MessageBox.Show("Casilla Invalida");
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Proveedor WHERE Nombre LIKE ('" + textBoxNombre.Text + "%')";
            Proveedor = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Proveedor);
            dgvProveedores.DataSource = Proveedor;
        }

        private void Proveedores_Load_1(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Proveedor";
            Proveedor = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Proveedor);
            dgvProveedores.DataSource = Proveedor;
        }

        private void BtnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
