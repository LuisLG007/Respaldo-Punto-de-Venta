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
    public partial class AddEmpleados : Form
    {
        Conectar conexion = new Conectar();
        double N;
        string Apuesto;

        public double N1 { get => N; set => N = value; }
        public string Apuesto1 { get => Apuesto; set => Apuesto = value; }

        public AddEmpleados()
        {
            InitializeComponent();
      
        }

        private void AgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "insert into Empleado values('" + textBoxIDE.Text + "','" + textBoxNombreE.Text + "', '" + textBoxApellidosPE.Text + "', '" + textBoxApellidosME.Text + "', '" + textBoxContraseñaE.Text + "', '" + Apuesto1 + "', '" + textBoxFechaNacimientoE.Text + "')";
                DataTable Empleado = new DataTable();
                SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Empleado);

                MessageBox.Show("¡Empleado Agregado Con Exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al agregar al nuevo empleado!");
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void AddEmpleados_Load(object sender, EventArgs e)
        {
            string CMD = "select MAX (Id_Empleado) from Empleado";
            DataTable Emple = new DataTable();
            SQLiteDataAdapter adap = new SQLiteDataAdapter(CMD, conexion._conexion);
            adap.Fill(Emple);
            DGVEMPLE.DataSource = Emple;
            N1 = Convert.ToDouble(DGVEMPLE.Rows[0].Cells[0].Value);
            N1 = N1 + 1;

            textBoxIDE.Text = N1.ToString();
        }

        private void comboBoxPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Apuesto1 = comboBoxPuesto.Text;
        }
    }
}
