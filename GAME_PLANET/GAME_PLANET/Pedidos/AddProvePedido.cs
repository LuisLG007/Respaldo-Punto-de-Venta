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
    public partial class AddProvePedido : Form
    {
        Conectar conexion = new Conectar();
        SQLiteCommandBuilder scb;
        SQLiteDataAdapter adaptar;
        DataTable Producto;

        public AddProvePedido()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (dgvProveeP.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void AddProvePedido_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT Id_Proveedor, Empresa, Nombre From Proveedor";
            DataTable Pedi = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedi);
            dgvProveeP.DataSource = Pedi;
        }
    }
}
