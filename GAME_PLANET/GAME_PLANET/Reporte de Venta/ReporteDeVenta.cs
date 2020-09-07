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
    public partial class ReporteDeVenta : Form
    {
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Venta;
        string N;

        public string N1 { get => N; set => N = value; }

        public ReporteDeVenta()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Venta";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;
            NombreEmpleado.Text = "";
            textBoxBCliente.Text = "";
            textBoxProducto.Text = "";
            textBoxIDV.Text = "";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Venta WHERE Id_Venta ='" + textBoxIDV.Text + "'";
                Venta = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Venta);
                dgvReporteV.DataSource = Venta;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al realizar la busqueda");
            }
        }

        private void btnMayorImpote_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Venta ORDER BY Importe DESC";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;
        }

        private void btnDESC_Click(object sender, EventArgs e)
        {

            string selectQuery = "SELECT * FROM Venta ORDER BY Importe ASC";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;
        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Venta WHERE Fecha ='" + comboBoxMes.Text + "'";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;
        }

        private void textBoxBCliente_TextChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Venta WHERE Cliente LIKE ('" + textBoxBCliente.Text + "%')";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;
        }

        private void textBoxProducto_TextChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Venta WHERE Articulo LIKE ('" + textBoxProducto.Text + "%')";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;

        }

        private void NombreEmpleado_TextChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Venta WHERE Empleado LIKE ('" + NombreEmpleado.Text + "%')";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;
        }

        private void ReporteDeVenta_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Venta";
            Venta = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Venta);
            dgvReporteV.DataSource = Venta;
        }

        private void NombreEmpleado_Leave(object sender, EventArgs e)
        {

                NombreEmpleado.Text = "";
               
        }

        private void textBoxBCliente_Leave(object sender, EventArgs e)
        {
            textBoxBCliente.Text = "";
        }

        private void textBoxProducto_Leave(object sender, EventArgs e)
        {
            textBoxProducto.Text = "";
        }

        private void dgvReporteV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvReporteV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvReporteV.CurrentRow.Selected = true;

                    N1 = dgvReporteV.Rows[e.RowIndex].Cells["Id_Venta"].FormattedValue.ToString();
                }
            }
            catch (Exception A)
            {

                MessageBox.Show("Casilla Invalida");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IfEliminarReporteV reporteV = new IfEliminarReporteV();
            reporteV.N1 = N1;
            reporteV.Show();
           
        }

        private void BtnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
