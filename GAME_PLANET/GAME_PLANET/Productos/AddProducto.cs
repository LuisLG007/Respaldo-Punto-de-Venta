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
    public partial class AddProducto : Form
    {
        Conectar conexion = new Conectar();
        double N;
        string TipoConsola;
        public double N1 { get => N; set => N = value; }

        public string TipoConsola1 { get => TipoConsola; set => TipoConsola = value; }

        public AddProducto()
        {
            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "insert into Producto values(" + textBoxIDP.Text + ", "+ textBoxIdProveedor .Text+ ",'" + TipoConsola1 + "', " + textBoxPrecioP.Text + ", '" + textBoxNombreProducto.Text + "', " + textBoxCantidadP.Text + ", '" + textBoxGeneroP.Text + "')";
                DataTable Producto = new DataTable();
                SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Producto);

                MessageBox.Show("Producto Agregado Con Exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al agregar el producto!");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddProducto_Load(object sender, EventArgs e)
        {

            string selectQuery = "select max (ID_Producto) from Producto";
            DataTable Producto = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Producto);
            dgvPro.DataSource = Producto;
            N1 = Convert.ToDouble(dgvPro.Rows[0].Cells[0].Value);
            N1 = N1 + 1;
            textBoxIDP.Text = N1.ToString();

        }

        private void comboBoxTipoConsola_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoConsola1 = comboBoxTipoConsola.Text;
        }
    }
}
