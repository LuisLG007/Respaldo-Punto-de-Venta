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
    public partial class Ventas : Form
    {
        Conectar conexion = new Conectar();
        SQLiteDataAdapter adaptar;
        DataTable ProductosVenta;
        FacPrueba fac;
        AgrCli AgrCli = new AgrCli();

        double N;
        public double N1 { get => N; set => N = value; }
        public double I1 { get => I; set => I = value; }

        public Ventas(string Nom, string pues, int IdE)
        {
            InitializeComponent();
            this.NE = Nom;
            this.puesto = pues;
            this.Ide = IdE;
        }

        string NE;
        string puesto;
        int IDCLIENTE;
        string Client;
        int Ide;
        double RESUL;
        double importe = 0;
        double Recibido;
        double Cambio;
        double I;


        private void Ventas_Load(object sender, EventArgs e)
        {
            textBox1.Text = NE;
            textBox2.Text = puesto;
        }

        private void timerFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        public void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            AgrCli.ShowDialog();
            if (AgrCli.DialogResult == DialogResult.OK)
            {
                IDCLIENTE = Convert.ToInt32(AgrCli.dgvClientesV.Rows[AgrCli.dgvClientesV.CurrentRow.Index].Cells[0].Value);
                textBoxNombrec.Text = AgrCli.dgvClientesV.Rows[AgrCli.dgvClientesV.CurrentRow.Index].Cells[1].Value.ToString();
                Client = AgrCli.dgvClientesV.Rows[AgrCli.dgvClientesV.CurrentRow.Index].Cells[1].Value.ToString();
                textBoxRFCc.Text = AgrCli.dgvClientesV.Rows[AgrCli.dgvClientesV.CurrentRow.Index].Cells[6].Value.ToString();
                textBoxEmailc.Text = AgrCli.dgvClientesV.Rows[AgrCli.dgvClientesV.CurrentRow.Index].Cells[4].Value.ToString();
                textBoxCiudadc.Text = AgrCli.dgvClientesV.Rows[AgrCli.dgvClientesV.CurrentRow.Index].Cells[7].Value.ToString();
            }

            fac = new FacPrueba(IDCLIENTE, Client, NE);
        }

        private void btnNewCliente_Click(object sender, EventArgs e)
        {
            AddCliente addCliente = new AddCliente();
            addCliente.Show();
        }

        private void btnUpdateCliente_Click(object sender, EventArgs e)
        {
            UpdateCliente updateCliente = new UpdateCliente();
            updateCliente.Show();
        }

        private void btnBuscarPro_Click(object sender, EventArgs e)
        {
            AgregarPV agregarPV = new AgregarPV();
            agregarPV.ShowDialog();
            if (agregarPV.DialogResult == DialogResult.OK)
            {
                textBoxIDPRO.Text = agregarPV.dgvProductosV.Rows[agregarPV.dgvProductosV.CurrentRow.Index].Cells[0].Value.ToString();
                textBoxCantidad.Focus();
            }
        }
        public static int cont_fila = 0;
        public static double total;

        public void Id()
        {
            string selectQuery = "select MAX (Id_Venta) From Venta";
            DataTable Vent = new DataTable();
            SQLiteDataAdapter adaptr = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptr.Fill(Vent);
            dgvVent.DataSource = Vent;
            I1 = Convert.ToDouble(dgvVent.Rows[0].Cells[0].Value);
            I1 = I1 + 1;

        }
        public void IDVENTA()
        {
            string selectQuery = "select MAX (Id_Venta) From Venta";
            DataTable Vent = new DataTable();
            SQLiteDataAdapter adaptr = new SQLiteDataAdapter(selectQuery, conexion._conexion);
            adaptr.Fill(Vent);
            dgvVent.DataSource = Vent;
            N1 = Convert.ToDouble(dgvVent.Rows[0].Cells[0].Value);
            N1 = N1 + 1;
            textBoxIdVenta.Text = N1.ToString();

            string select = "INSERT INTO Venta VALUES(" + textBoxIdVenta.Text + ",'" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() + "', '" + textBoxIDPRO.Text + "', '" + ProductosVenta.Rows[0][0].ToString() + "', '" + ProductosVenta.Rows[0][1].ToString() + "', " + textBoxCantidad.Text + ", " + importe + ", " + IDCLIENTE + ", '" + Client + "', " + Ide + ", '" + NE + "')";
            DataTable Vents = new DataTable();
            SQLiteDataAdapter A = new SQLiteDataAdapter(select, conexion._conexion);
            A.Fill(Vents);
        }

        private void btnCanti_Click(object sender, EventArgs e)
        {
            string select = "SELECT * FROM Producto";
            DataTable VentSS = new DataTable();
            SQLiteDataAdapter A = new SQLiteDataAdapter(select, conexion._conexion);
            A.Fill(VentSS);
            dgvStock.DataSource = VentSS;

            string cmd = "SELECT Nombre, Precio FROM Producto WHERE Id_Producto = '" + textBoxIDPRO.Text + "'";
            adaptar = new SQLiteDataAdapter(cmd, conexion._conexion);
            ProductosVenta = new DataTable();
            adaptar.Fill(ProductosVenta);


                Id();
                dgvProductosVentas.Rows.Add(I1, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), textBoxIDPRO.Text, ProductosVenta.Rows[0][0].ToString(), ProductosVenta.Rows[0][1].ToString(), textBoxCantidad.Text, "", IDCLIENTE, Client, Ide, NE);
                importe = Convert.ToDouble(dgvProductosVentas.Rows[cont_fila].Cells[5].Value) * Convert.ToDouble(dgvProductosVentas.Rows[cont_fila].Cells[6].Value);
                dgvProductosVentas.Rows[cont_fila].Cells[7].Value = importe;
                IDVENTA();

                int H = int.Parse(textBoxIDPRO.Text) - 1;
                double K = Convert.ToDouble(dgvStock.Rows[H].Cells[5].Value);
                double L = Convert.ToDouble(textBoxCantidad.Text);
                double Ñ = K - L;
                MessageBox.Show("¡Quedan " + Ñ.ToString() + " piezas de este producto en stok!");

                dgvStock.Rows[H].Cells[5].Value = Ñ;

                string cm = "UPDATE Producto SET Id_Producto = " + textBoxIDPRO.Text + ", Id_Proveedor = '" + dgvStock.Rows[H].Cells[1].Value + "', Tipo_Consola = '" + dgvStock.Rows[H].Cells[2].Value + "', Precio = " + dgvStock.Rows[H].Cells[3].Value + ", Nombre = '" + dgvStock.Rows[H].Cells[4].Value + "', Cantidad = " + Ñ + ", Genero = '" + dgvStock.Rows[H].Cells[6].Value + "' WHERE Id_Producto = " + textBoxIDPRO.Text + " ";
                SQLiteDataAdapter XD = new SQLiteDataAdapter(cm, conexion._conexion);
                DataTable LL = new DataTable();
                XD.Fill(LL);

                fac.dgvFactura.Rows.Add(textBoxIdVenta.Text, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), textBoxIDPRO.Text, ProductosVenta.Rows[0][0].ToString(), ProductosVenta.Rows[0][1].ToString(), textBoxCantidad.Text, importe, IDCLIENTE, Client, Ide, NE);

                cont_fila++;

            total = 0;
            foreach (DataGridViewRow fila in dgvProductosVentas.Rows)
            {
                total += Convert.ToDouble(fila.Cells[7].Value);
            }
            textBoxSubtotal.Text = "$ " + total.ToString();
            textBoxIva.Text = "16%";
            double IVA = total * 0.16;
            RESUL = total + IVA;

            textBoxTOTAL.Text = "$ " + RESUL.ToString();

            textBoxCantidad.Text = "";
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            dgvProductosVentas.Rows.Clear();
            cont_fila = 0;
            RESUL = 0;
            Cambio = 0;
            textBoxRecibido.Text = "";
            textBoxCambio.Text = "";
            textBoxNombrec.Text = "";
            textBoxCiudadc.Text = "";
            textBoxEmailc.Text = "";
            textBoxCantidad.Text = "";
            textBoxRFCc.Text = "";
            textBoxSubtotal.Text = "";
            textBoxTOTAL.Text = "";
        }

        private void btnConfi_Click(object sender, EventArgs e)
        {
            fac.Show();

        }

        private void textBoxRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Recibido = Convert.ToDouble(textBoxRecibido.Text);
                Cambio = Recibido - RESUL;
                textBoxCambio.Text = Cambio.ToString();

                fac.Recibido = Convert.ToDouble(textBoxRecibido.Text);
                fac.Cambio = Convert.ToDouble(textBoxCambio.Text);
            }
        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cont_fila > 0)
            {
                double D;
                D = (Convert.ToDouble(dgvProductosVentas.Rows[dgvProductosVentas.CurrentRow.Index].Cells[0].Value));

                string select = "DELETE FROM Venta WHERE Id_Venta = " + D + "";
                DataTable VentSS = new DataTable();
                SQLiteDataAdapter A = new SQLiteDataAdapter(select, conexion._conexion);
                A.Fill(VentSS);

                dgvProductosVentas.Rows.RemoveAt(dgvProductosVentas.CurrentRow.Index);
                fac.dgvFactura.Rows.RemoveAt((dgvProductosVentas.CurrentRow.Index)+1);

                cont_fila--;
                total = 0;
                foreach (DataGridViewRow fila in dgvProductosVentas.Rows)
                {
                    total += Convert.ToDouble(fila.Cells[7].Value);
                }
                textBoxSubtotal.Text = "$ " + total.ToString();
                textBoxIva.Text = "16%";
                double IVA = total * 0.16;
                RESUL = total + IVA;

                textBoxTOTAL.Text = "$ " + RESUL.ToString();

                textBoxCantidad.Text = "";
            }
        }

        private void BtnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
