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
    public partial class AgreProPedido : Form
    {
        Conectar conexion = new Conectar();
        SQLiteCommandBuilder scb;
        SQLiteDataAdapter adaptar;
        DataTable Producto;


        public AgreProPedido()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (dgvProductosPedido.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void AgreProPedido_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT Nombre, Cantidad FROM Producto";
            Producto = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvProductosPedido.DataSource = Producto;

        }

        private void dgvProductosV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dgvProductosPedido.Columns[e.ColumnIndex].Name == "Cantidad")
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
    }
}
