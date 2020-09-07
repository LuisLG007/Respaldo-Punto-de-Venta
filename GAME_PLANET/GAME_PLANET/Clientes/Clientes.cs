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
    public partial class Clientes : Form
    { 
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Cliente;
        string N;
        public Clientes()
        {
            InitializeComponent();        
        }
  
        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            AddCliente add = new AddCliente();
            
            add.TopLevel = false;
            add.Dock = DockStyle.Fill;
            this.Controls.Add(add);
            this.Tag = add;
            add.BringToFront();
            add.Show();
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            UpdateCliente updateCliente = new UpdateCliente();
            updateCliente.Show();
        }


        public void btnEliminarCliente_Click(object sender, EventArgs e)
        {         
            IfEliminarCliente ifEliminarCliente = new IfEliminarCliente();
            ifEliminarCliente.RFC = N;
            ifEliminarCliente.Show();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Cliente";
            Cliente = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvCliente.DataSource = Cliente;
        }

        public void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Cliente";
            Cliente = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvCliente.DataSource = Cliente;
            textBoxRFC.Text = "";
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCliente.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvCliente.CurrentRow.Selected = true;
                 
                    N = dgvCliente.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                    pictureBoxC.ImageLocation = ""+Conectar.USB+ ":/Users/LuisL/OneDrive/PROYECTO/GAME_PLANET/GAME_PLANET/Pic Clientes/" + N + ".JPG";
                }
            }
            catch (Exception A)
            {

                MessageBox.Show("Casilla Invalida");
            }         
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Cliente WHERE RFC = '" + textBoxRFC.Text + "'";
                Cliente = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Cliente);
                dgvCliente.DataSource = Cliente;
                textBoxRFC.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Error al realizar la busqueda");
            }
        }

        private void BusquedaDeCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Cliente WHERE Nombre LIKE ('" + BusquedaDeCliente.Text + "%')";
                Cliente = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Cliente);
                dgvCliente.DataSource = Cliente;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al realizar la busqueda");
            }
        }

        private void BtnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
