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
    public partial class Pedidos : Form
    {
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Pedido;
        string N;

        public string N1 { get => N; set => N = value; }

        public Pedidos()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido WHERE Mes = '"+comboBoxMes.Text+"'";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void comboBoxAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido WHERE Año = '" + comboBoxAño.Text + "'";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;

        }

        private void btnMayorIndividual_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido ORDER BY Costo_Individual DESC";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void btnMayorCostoI_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido ORDER BY Costo_Individual ASC";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void btnCostoMTotal_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido ORDER BY Costo_Total DESC";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void btnMenorCostoT_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido ORDER BY Costo_Total ASC";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoPedido nuevo = new NuevoPedido();
            nuevo.Show();
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Pedido WHERE Producto LIKE ('"+ textBoxNombre .Text+ "%')";
            Pedido = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedido);
            dgvPedido.DataSource = Pedido;
        }

        private void textBoxNombre_Leave(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IfEliminarPedido pedido = new IfEliminarPedido();
            pedido.N1 = N1;
            pedido.Show();
        }

        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPedido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvPedido.CurrentRow.Selected = true;

                    N1 = dgvPedido.Rows[e.RowIndex].Cells["Id_Pedido"].FormattedValue.ToString();
                }
            }
            catch (Exception A)
            {

                MessageBox.Show("Casilla Invalida");
            }
        }

        private void dgvPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
         
            if (this.dgvPedido.Columns[e.ColumnIndex].Name == "Curso")
            {               
                if (dgvPedido.Rows[e.RowIndex].Cells["Pedido_Generado"].Value.ToString() == dgvPedido.Rows[e.RowIndex].Cells["Fecha_Entrega"].Value.ToString())
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.Green;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.MistyRose;
                }
            }

        }

        private void BtnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
