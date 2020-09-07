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
    public partial class AddCliente : Form
    {
        Conectar conexion = new Conectar();
        double N;

        public double N1 { get => N; set => N = value; }

        public AddCliente()
        {
            InitializeComponent();
        }

        public void AgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "insert into Cliente values(" + textBoxIDc.Text + ", '" + textBoxNombrec.Text + "', '" + textBoxApellidoPc.Text + "', '" + textBoxApellidoMc.Text + "', '" + textBoxEmailc.Text + "', " + textBoxTelefonoc.Text + ", '" + textBoxRFCc.Text + "', '" + textBoxCiudadc.Text + "', ' " + textBoxCallec.Text + "', " + textBoxCP.Text + ", " + textBoxNumEx.Text + ")";
                DataTable Cliente = new DataTable();
                SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Cliente);

                MessageBox.Show("¡Cliente Agregado Con Exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al agregar al nuevo cliente!");
            }
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddCliente_Load(object sender, EventArgs e)
        {
            string selectQuery = "select MAX (Id_Cliente) From Cliente";
            DataTable Cliente = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Cliente);
            dgvCli.DataSource = Cliente;
            N1=Convert.ToDouble(dgvCli.Rows[0].Cells[0].Value);
            N1 = N1 + 1;
            textBoxIDc.Text = N1.ToString();
        }
    }
}
