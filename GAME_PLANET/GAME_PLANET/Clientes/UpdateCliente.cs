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
    public partial class UpdateCliente : Form
    {

        Conectar conexion = new Conectar();

        DataTable Cliente;
        SQLiteDataAdapter adaptar;

        public UpdateCliente()
        {    
            InitializeComponent();
        }

 
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBuscarClienteModificar_Click_1(object sender, EventArgs e)
        {
            try
            {

                string selectQuery = "SELECT * FROM Cliente WHERE Telefono = " + BusquedaDeCliente.Text + " ";
                Cliente = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Cliente);

                NombreActualCliente.Text = Cliente.Rows[0][1].ToString();
                ApellidoPActualCliente.Text = Cliente.Rows[0][2].ToString();
                ApellidoMActualCliente.Text = Cliente.Rows[0][3].ToString();
                RFCActualCliente.Text = Cliente.Rows[0][4].ToString();
                TelefonoActualCliente.Text = Cliente.Rows[0][5].ToString();
                EmailActualCliente.Text = Cliente.Rows[0][6].ToString();
                CiudadActualCliente.Text = Cliente.Rows[0][7].ToString();
                CalleActualCliente.Text = Cliente.Rows[0][8].ToString();
                CPActualCliente.Text = Cliente.Rows[0][9].ToString();
                ExteriorActualCliente.Text = Cliente.Rows[0][10].ToString();

                textBox1.Text = Cliente.Rows[0][1].ToString();
                textBox2.Text = Cliente.Rows[0][2].ToString();
                textBox3.Text = Cliente.Rows[0][3].ToString();
                textBox4.Text = Cliente.Rows[0][4].ToString();
                textBox5.Text = Cliente.Rows[0][5].ToString();
                textBox6.Text = Cliente.Rows[0][6].ToString();
                textBox7.Text = Cliente.Rows[0][7].ToString();
                textBox8.Text = Cliente.Rows[0][8].ToString();
                textBox9.Text = Cliente.Rows[0][9].ToString();
                textBox10.Text = Cliente.Rows[0][10].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("A ocurrido un error...");
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "UPDATE Cliente SET Nombre = '" + textBox1.Text + "', Apellido_Paterno = '" + textBox2.Text + "', " +
             "Apellido_Materno = '" + textBox3.Text + "', Email = '" + textBox4.Text + "', Telefono = " + textBox5.Text + ", " +
             "RFC ='" + textBox6.Text + "', Ciudad = '" + textBox7.Text + "', Calle = '" + textBox8.Text + "', Codigo_Postal =" + textBox9.Text + ", " +
             "Numero_De_Casa =" + textBox10.Text + " WHERE Telefono = '" + BusquedaDeCliente.Text + "'";

                DataTable cliente = new DataTable();
                SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(cliente);

                MessageBox.Show("¡Datos Actualizados con exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al actualizar el cliente!");
            }
        }

        private void UpdateCliente_Load(object sender, EventArgs e)
        {
            BusquedaDeCliente.Focus();
        }
    }
}
