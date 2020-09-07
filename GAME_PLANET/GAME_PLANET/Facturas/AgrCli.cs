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
    public partial class AgrCli : Form
    {
        Conectar conexion = new Conectar();
        SQLiteCommandBuilder scb;
        SQLiteDataAdapter adaptar;
        DataTable Cliente;
        public AgrCli()
        {
            InitializeComponent();
        }

        private void AgrCli_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Cliente";
            Cliente = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvClientesV.DataSource = Cliente;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientesV.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnNombre_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Cliente WHERE Nombre = '" + textBoxBusqueda.Text + "'";
                Cliente = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Cliente);
                dgvClientesV.DataSource = Cliente;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Cliente no encontrado!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Cliente";
            Cliente = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvClientesV.DataSource = Cliente;
        }

        private void btnASC_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Cliente ORDER BY Nombre";
            Cliente = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvClientesV.DataSource = Cliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Cliente ORDER BY Nombre DESC";
            Cliente = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvClientesV.DataSource = Cliente;
        }

        public void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {                    
            string selectQuery = "SELECT * FROM Cliente WHERE Nombre LIKE ('"+textBoxBusqueda.Text+"%')";
            Cliente = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvClientesV.DataSource = Cliente;
        }
    }
}
