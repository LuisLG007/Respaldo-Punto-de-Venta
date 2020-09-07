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
    public partial class Empleados : Form
    {

        public Empleados()
        {
            InitializeComponent();
        }

        Conectar conexion = new Conectar();    
        SQLiteDataAdapter adaptar;
        DataTable Empleado;
        string N;

        private void btnAddEmpleado_Click(object sender, EventArgs e)
        {
            AddEmpleados addEmpleados = new AddEmpleados();
            addEmpleados.Show();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            IfEliminarEmpleado ifEliminarEmpleado = new IfEliminarEmpleado();
            ifEliminarEmpleado.Nombre = N;
            ifEliminarEmpleado.Show();
        }
   
        private void btnActualizarEmpleado_Click(object sender, EventArgs e)
        {
            UpdateEmpleado updateEmpleado = new UpdateEmpleado();
            updateEmpleado.Show();
        }

        public void btnMostrarEmpleados_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Empleado";
            DataTable Empleado = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Empleado);
            dgvEmpleados.DataSource = Empleado;
            BusquedaDeEmpleado.Text = "";
        }

        public void Empleados_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Empleado";
            DataTable Empleado = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Empleado);
            dgvEmpleados.DataSource = Empleado;
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvEmpleados.CurrentRow.Selected = true;
               
                    N = dgvEmpleados.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                    pictureBoxE.ImageLocation = "" + Conectar.USB + ":/Users/LuisL/OneDrive/PROYECTO/GAME_PLANET/GAME_PLANET/Pic Clientes/" + N + ".JPG";
                  
                }
            }
            catch (Exception A)
            {

                MessageBox.Show("Casilla Invalida");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Empleado WHERE Id_Empleado = " + BusquedaDeEmpleado.Text + "";
                Empleado = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Empleado);
                dgvEmpleados.DataSource = Empleado;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al realizar la busqueda");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM Empleado WHERE Nombre LIKE ('"+textBoxNombre.Text+"%')";
            Empleado = new DataTable();
            adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Empleado);
            dgvEmpleados.DataSource = Empleado;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al realizar la busqueda");
            }
        }

        private void BtnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
