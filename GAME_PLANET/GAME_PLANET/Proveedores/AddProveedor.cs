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
    public partial class AddProveedor : Form
    {
        Conectar conexion = new Conectar();
        double N;

        public double N1 { get => N; set => N = value; }

        public AddProveedor()
        {
            InitializeComponent();
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "insert into Proveedor values(" + textBoxIDProveedor.Text + ",'" + textBoxNombreP.Text + "', '"+textBoxEmpresa.Text+"'," + textBoxTelefono.Text + ", '" + textBoxRFC.Text + "', " + textBoxCPP.Text + ", '" + textBoxCalleProve.Text + "', " + textBoxNumExteriorProve.Text + ")";
                DataTable Proveedor = new DataTable();
                SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Proveedor);

                MessageBox.Show("¡Proveedor Agregado Con Exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al agregar el proveedor!");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddProveedor_Load(object sender, EventArgs e)
        {
            string selectQuery = "Select Max (Id_Proveedor) From Proveedor";
            DataTable Proveedor = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Proveedor);
            dgvProve.DataSource = Proveedor;
            N1 = Convert.ToDouble(dgvProve.Rows[0].Cells[0].Value);
            N1 = N1 + 1;
            textBoxIDProveedor.Text = N1.ToString();
        }
    }
}
