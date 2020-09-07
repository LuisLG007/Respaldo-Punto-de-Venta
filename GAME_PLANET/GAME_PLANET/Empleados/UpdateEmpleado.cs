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
    public partial class UpdateEmpleado : Form
    {

        Conectar conexion = new Conectar();
        DataTable Empleado;
        SQLiteDataAdapter adaptar;

        public UpdateEmpleado()
        {
            InitializeComponent();
        }

        private void tbnBuscarE_Click(object sender, EventArgs e)
        {
            try
            {

                string selectQuery = "SELECT * FROM Empleado WHERE Id_Empleado = " + BusquedaIDE.Text + "";
                Empleado = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Empleado);

                BoxNombreEmpleadoA.Text = Empleado.Rows[0][1].ToString();
                BoxApellidoPEmpleadoA.Text = Empleado.Rows[0][2].ToString();
                BoxApellidoMEmpleadoA.Text = Empleado.Rows[0][3].ToString();
                BoxContraseñaEmpleadoA.Text = Empleado.Rows[0][4].ToString();
                BoxPuestoEmpleadoA.Text = Empleado.Rows[0][5].ToString();
                BoxFechaDeNEmpleadoA.Text = Empleado.Rows[0][6].ToString();

                textBoxNombreEN.Text = Empleado.Rows[0][1].ToString();
                textBoxApellidoPEN.Text = Empleado.Rows[0][2].ToString();
                textBoxApellidoMEN.Text = Empleado.Rows[0][3].ToString();
                textBoxContraseñaEN.Text = Empleado.Rows[0][4].ToString();
                textBoxPuestoEN.Text = Empleado.Rows[0][5].ToString();
                textBoxFechaDeNEN.Text = Empleado.Rows[0][6].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("A ocurrido un error...");
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "UPDATE Empleado SET Nombre = '" + textBoxNombreEN.Text + "', Apellido_Paterno = '" + textBoxApellidoPEN.Text + "', " +
                "Apellido_Materno = '" + textBoxApellidoMEN.Text + "', Contraseña = '" + textBoxContraseñaEN.Text + "', Puesto = '" + textBoxPuestoEN.Text + "', " +
                "fecha_de_Nacimiento ='" + textBoxFechaDeNEN.Text + "' WHERE Id_Empleado = '" + BusquedaIDE.Text + "'";

                DataTable cliente = new DataTable();
                SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(cliente);

                MessageBox.Show("¡Datos Actualizados con exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al actualizar los datos del empleado!");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateEmpleado_Load(object sender, EventArgs e)
        {
            BusquedaIDE.Focus();
        }
    }
}
