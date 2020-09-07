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
    public partial class NuevoPedido : Form
    {
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable Pedido;

        int IDP_PEDI;
        string Entrega;
        string ID_Prove;
        string TDC;

        public int IDP_PEDI1 { get => IDP_PEDI; set => IDP_PEDI = value; }
      
        public string ID_Prove1 { get => ID_Prove; set => ID_Prove = value; }
        public string TDC1 { get => TDC; set => TDC = value; }
        public string Entrega1 { get => Entrega; set => Entrega = value; }

        public NuevoPedido()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                int Cancti = int.Parse(textBoxNumProSoli.Text);
                int resul, Cos;
                Cos = int.Parse(textBoxCostoIn.Text);
                resul = Cancti * Cos;
                textBoxCosrTO.Text = resul.ToString();

                string selectQuery = "insert into Pedido values(" + textBoxIDPedido.Text + ", " + ID_Prove1 + ", '" + textBoxFechaGenerada.Text + "', '" + Entrega1 + "', '" + textBoxStatus.Text + "', '" + textBoxProductos.Text + "', '" + TDC1 + "', " + textBoxNumProSoli.Text + ", " + textBoxCostoIn.Text + ", " + textBoxCosrTO.Text + ")";
                Pedido = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Pedido);

                MessageBox.Show("¡Pedido Realizado Con Exito!");
            }
            catch (Exception)
            {

                MessageBox.Show("¡Error al completar el pedido!");
            }

        }

        private void NuevoPedido_Load(object sender, EventArgs e)
        {
            string selectQuery = "select MAX (Id_Pedido) From Pedido";
            DataTable Pedi = new DataTable();
            SQLiteDataAdapter adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(Pedi);
            DGVPEDIDO.DataSource = Pedi;
            IDP_PEDI1 = Convert.ToInt32(DGVPEDIDO.Rows[0].Cells[0].Value);
            IDP_PEDI1 = IDP_PEDI1 + 1;
            textBoxIDPedido.Text = IDP_PEDI1.ToString();

            Random Precio = new Random();

            textBoxCostoIn.Text = Precio.Next(399,1300).ToString();

            textBoxFechaGenerada.Text = DateTime.Now.ToShortDateString();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha = FechaEntrega.Value;

           Entrega1 = Fecha.ToShortDateString();
        }

        private void btnAgrePro_Click(object sender, EventArgs e)
        {
            AgreProPedido pedido = new AgreProPedido();
            pedido.ShowDialog();
            if (pedido.DialogResult == DialogResult.OK)
            {
                textBoxProductos.Text = pedido.dgvProductosPedido.Rows[pedido.dgvProductosPedido.CurrentRow.Index].Cells[0].Value.ToString();
            }
        }

        private void comboBoxConsola_SelectedIndexChanged(object sender, EventArgs e)
        {
            TDC1 = comboBoxConsola.Text;
        }

        private void btnAddPorve_Click(object sender, EventArgs e)
        {
            AddProvePedido addProve = new AddProvePedido();
            addProve.ShowDialog();
            if (addProve.DialogResult == DialogResult.OK)
            {
                textBoxAddProve.Text = addProve.dgvProveeP.Rows[addProve.dgvProveeP.CurrentRow.Index].Cells[1].Value.ToString();
                ID_Prove1 = addProve.dgvProveeP.Rows[addProve.dgvProveeP.CurrentRow.Index].Cells[0].Value.ToString();
            }
        }
    }
}
