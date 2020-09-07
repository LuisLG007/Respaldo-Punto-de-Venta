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
    public partial class IfEliminarProducto : Form
    {
        Proveedores Proveedores = new Proveedores();
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Producto;

        public IfEliminarProducto()
        {
            InitializeComponent();
        }

        private string Nombre;

        public string Nombre1 { get => Nombre; set => Nombre = value; }

        private void btnNoEliminarProdcuto_Click_1(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void btnSiEliminarProdcuto_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "DELETE FROM Producto WHERE Nombre = '" + Nombre1 + "'";
                Producto = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Producto);
                Proveedores.dgvProveedores.DataSource = Producto;


                MessageBox.Show("El Producto se ha eliminado...");

                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al eliminar el producto!");
            }
        }
    }
}
