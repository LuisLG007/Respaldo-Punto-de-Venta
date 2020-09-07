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
    public partial class IfEliminarPedido : Form
    {

        Proveedores Proveedores = new Proveedores();
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Pedido;

        public IfEliminarPedido()
        {
            InitializeComponent();
        }

        string N;

        public string N1 { get => N; set => N = value; }

        private void btnSiEliminarProdcuto_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "DELETE FROM Pedido WHERE Id_Pedido = '" + N1 + "'";
                Pedido = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Pedido);
                MessageBox.Show("El Pedido ha sido cancelado...");

                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al eliminar el producto!");
            }
        }

        private void btnNoEliminarProdcuto_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
