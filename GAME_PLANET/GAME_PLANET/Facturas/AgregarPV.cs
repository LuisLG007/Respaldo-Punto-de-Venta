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
    public partial class AgregarPV : Form
    {
        Conectar conexion = new Conectar();
        SQLiteCommandBuilder scb;
        SQLiteDataAdapter adaptar;
        DataTable Producto;

        public AgregarPV()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public static int cont_fila = 0;

        private void AgregarPV_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductosV.DataSource = Producto;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (dgvProductosV.Rows.Count == 0)
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
                string selectQuery = "SELECT * FROM Producto WHERE Nombre ='" + textBoxBusqueda.Text + "'";
                Producto = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Producto);
                dgvProductosV.DataSource = Producto;
            }
            catch (Exception)
            {
                MessageBox.Show("Producto No Encontrado");
            }
        }

        private void btnASC_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto ORDER BY Precio DESC";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductosV.DataSource = Producto;
        }

        private void btnDESC_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto ORDER BY Precio ASC";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductosV.DataSource = Producto;
        }

        private void btnXbox_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto WHERE Tipo_consola = 'Xbox One'";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductosV.DataSource = Producto;
        }

        private void btnPlayStation4_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto WHERE Tipo_consola = 'PS4'";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductosV.DataSource = Producto;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Producto";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductosV.DataSource = Producto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvProductosV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dgvProductosV.Columns[e.ColumnIndex].Name == "Cantidad")
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

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {                                  
            try
            {                
                string selectQuery = "SELECT * FROM Producto WHERE Nombre Like ('" + textBoxBusqueda.Text + "%')";
                Producto = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Producto);
                dgvProductosV.DataSource = Producto;
            }
            catch (Exception)
            {
                MessageBox.Show("Producto No Encontrado");
            }
        }
    }
}
