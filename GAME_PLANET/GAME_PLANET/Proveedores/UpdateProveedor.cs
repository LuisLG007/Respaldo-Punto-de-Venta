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
    public partial class UpdateProveedor : Form
    {
        Conectar conexion = new Conectar();
        DataTable Proveedor;
        SQLiteDataAdapter adaptar;

        
        public UpdateProveedor()
        {
            InitializeComponent();
        }

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "UPDATE Proveedor SET Nombre = '" + textBoxUpdateNProve.Text + "',  Empresa = '" + textBoxEmpresaNueva.Text + "', Telefono = " + textBoxUpdateTelefonoProve.Text + ", " +
                "RFC ='" + textBoxUpdateRFCProve.Text + "', CP= " + textBoxUpdateCPProve.Text + ", Calle = '" + textBoxUpdateCalleProve.Text + "', " +
                "Numero_De_Casa = " + textBoxUpdateNEProve.Text + " WHERE RFC = '" + BusquedaDeProveedorEdit.Text + "'";

                DataTable Proveedor = new DataTable();
                SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Proveedor);

                MessageBox.Show("¡Datos Actualizados con exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al actualizar los datos!");
            }

        }

        private void tbnBuscarProve_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Proveedor WHERE RFC = '" + BusquedaDeProveedorEdit.Text + "' ";
                Proveedor = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Proveedor);

                textBoxMostrarNProve.Text = Proveedor.Rows[0][1].ToString();
                textBoxEmpresa.Text = Proveedor.Rows[0][2].ToString();
                textBoxTelefonoProve.Text = Proveedor.Rows[0][3].ToString();
                textBoxRFCProve.Text = Proveedor.Rows[0][4].ToString();
                textBoxCPProve.Text = Proveedor.Rows[0][5].ToString();
                textBoxCalleProve.Text = Proveedor.Rows[0][6].ToString();
                textBoxNumExteriorProve.Text = Proveedor.Rows[0][7].ToString();

                textBoxUpdateNProve.Text = Proveedor.Rows[0][1].ToString();
                textBoxEmpresaNueva.Text = Proveedor.Rows[0][2].ToString();
                textBoxUpdateTelefonoProve.Text = Proveedor.Rows[0][3].ToString();
                textBoxUpdateRFCProve.Text = Proveedor.Rows[0][4].ToString();
                textBoxUpdateCPProve.Text = Proveedor.Rows[0][5].ToString();
                textBoxUpdateCalleProve.Text = Proveedor.Rows[0][6].ToString();
                textBoxUpdateNEProve.Text = Proveedor.Rows[0][7].ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("A ocurrido un error...");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateProveedor_Load(object sender, EventArgs e)
        {
            BusquedaDeProveedorEdit.Focus();
        }
    }
}
