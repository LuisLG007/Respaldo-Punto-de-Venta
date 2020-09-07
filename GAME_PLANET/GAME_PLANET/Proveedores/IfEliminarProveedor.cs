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
    public partial class IfEliminarProveedor : Form
    {
        Proveedores Proveedores = new Proveedores();
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Proveedore;
        public IfEliminarProveedor()
        {
            InitializeComponent();
        }

        private string rFC;

        public string RFC { get => rFC; set => rFC = value; }

        private void btnSiEliminarProvedor_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "DELETE FROM Proveedor WHERE Nombre = '" + RFC + "'";
                Proveedore = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Proveedore);
                Proveedores.dgvProveedores.DataSource = Proveedore;

                MessageBox.Show("El Proveedor se ha eliminado...");

                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Error al eliminar el proveedor...");
            }
        }

        private void btnNoEliminarProveedor_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
