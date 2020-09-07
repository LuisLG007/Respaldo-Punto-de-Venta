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
    public partial class FacPrueba : Form
    {
        double total;
        double RESUL;
        double recibido;
        double cambio;
        Conectar conexion = new Conectar();

        public double Recibido { get => recibido; set => recibido = value; }
        public double Cambio { get => cambio; set => cambio = value; }

        public FacPrueba(int IDC, string NC, string NE)
        {
            InitializeComponent();

            lblIDC.Text = IDC.ToString();
            lblC.Text = NC;
            lblE.Text = NE;         
        }

        private void timerFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        public void FacPrueba_Load(object sender, EventArgs e)
        {
            total = 0;
            foreach (DataGridViewRow fila in dgvFactura.Rows)
            {
                total += Convert.ToDouble(fila.Cells[7].Value);
            }
            textBoxSubT.Text = "  $ " + total.ToString();
      
            double IVA = total * 0.16;
            RESUL = total + IVA;
            textBoxTotal.Text = "  $ "+RESUL.ToString();
            textBoxReci.Text = "  $ " + Recibido.ToString();
            textBoxCambi.Text = "  $ " + Cambio.ToString();


            timerPrint.Start();
        }

        private void timerPrint_Tick(object sender, EventArgs e)
        {
            timerPrint.Stop();
            printFactura.Print();
            
        }
    }
}
