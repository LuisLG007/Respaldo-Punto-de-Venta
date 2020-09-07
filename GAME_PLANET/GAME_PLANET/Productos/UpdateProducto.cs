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
    public partial class UpdateProducto : Form
    {
        Conectar conexion = new Conectar();
        DataTable Producto;
        SQLiteDataAdapter adaptar;

        public UpdateProducto()
        {
            InitializeComponent();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void tbnBuscarP_Click(object sender, EventArgs e)
        {
            try
            {

                string selectQuery = "SELECT * FROM Producto WHERE Id_Producto = '" + BusquedaID.Text + "' ";
                Producto = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Producto);
                dgvTemp.DataSource = Producto;

                textBoxIDP.Text = Producto.Rows[0][0].ToString();
                textBoxIdProve.Text = Producto.Rows[0][1].ToString();
                textBoxTipoCP.Text = Producto.Rows[0][2].ToString();
                textBoxPrecioP.Text = Producto.Rows[0][3].ToString();
                textBoxNombreP.Text = Producto.Rows[0][4].ToString();
                textBoxCantidadP.Text = Producto.Rows[0][5].ToString();
                textBoxGeneroP.Text = Producto.Rows[0][6].ToString();


                textBoxIDN.Text = Producto.Rows[0][0].ToString();
                textBoxIdProveN.Text = Producto.Rows[0][1].ToString();
                textBoxNuevoTipoDeConsolaP.Text = Producto.Rows[0][2].ToString();
                textBoxNuevoPrecioP.Text = Producto.Rows[0][3].ToString();
                textBoxNuevoNombreP.Text = Producto.Rows[0][4].ToString();
                textBoxNuevoCantidadP.Text = Producto.Rows[0][5].ToString();
                textBoxNuevoGeneroP.Text = Producto.Rows[0][6].ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("A ocurrido un error...");
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "UPDATE Producto SET Id_Producto = " + textBoxIDP.Text + ", Id_Proveedor = "+ textBoxIdProveN.Text+ " , Tipo_Consola = '" + textBoxNuevoTipoDeConsolaP.Text + "', " +
              "Precio = " + textBoxNuevoPrecioP.Text + ", Nombre = '" + textBoxNuevoNombreP.Text + "', Cantidad = " + textBoxNuevoCantidadP.Text + ", " +
              "Genero = '" + textBoxNuevoGeneroP.Text + "' WHERE Id_Producto = " + BusquedaID.Text + "";

                Producto = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Producto);
                MessageBox.Show("¡Datos Actualizados con exito!");

            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al actualiar el producto!");
            }

        }

        private void UpdateProducto_Load(object sender, EventArgs e)
        {
            BusquedaID.Focus();
        }
    }
}
