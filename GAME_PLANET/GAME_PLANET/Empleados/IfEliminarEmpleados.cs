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
    public partial class IfEliminarEmpleado : Form
    {
        Empleados empleados = new Empleados();
        Conectar conexion = new Conectar();
      
        SQLiteDataAdapter adaptar;
        DataTable Empleado;

        public IfEliminarEmpleado()
        {
            InitializeComponent();
        }

        string nombre;

        public string Nombre { get => nombre; set => nombre = value; }

        private void btnNoDeleteCliente_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDeleteCliente_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "DELETE FROM Empleado WHERE Nombre = '" + Nombre + "'";
                Empleado = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Empleado);
                empleados.dgvEmpleados.DataSource = Empleado;

                this.Hide();
                MessageBox.Show("El Empleado se ha eliminado...");
            }
            catch (Exception )
            {

                MessageBox.Show("No selecciono que empleado va a eliminar...");
            }

        }
    }
}
