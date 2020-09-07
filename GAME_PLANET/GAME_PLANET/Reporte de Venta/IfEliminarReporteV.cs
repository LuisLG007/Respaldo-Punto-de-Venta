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
    public partial class IfEliminarReporteV : Form
    {

        Proveedores Proveedores = new Proveedores();
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Venta;

        string N;

        public IfEliminarReporteV()
        {
            InitializeComponent();
        }

        public string N1 { get => N; set => N = value; }

        private void btnSiEliminarProdcuto_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "DELETE FROM Venta WHERE Id_Venta = " + N1 + "";
                Venta = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Venta);
                MessageBox.Show("El Reporte ha sido eliminado...");

                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al eliminar el Reporte!");
            }
        }

        private void btnNoEliminarProdcuto_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
