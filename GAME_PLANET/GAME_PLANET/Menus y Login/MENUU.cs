using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace GAME_PLANET
{
    public partial class MENUU : Form
    {
        private string eM;
        private string nE;
        private int IdEm;

        public string EM { get => eM; set => eM = value; }
        public string NE { get => nE; set => nE = value; }
        public int IdEm1 { get => IdEm; set => IdEm = value; }
        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
            CerrarFormulario();
        }

        private void MostrarFormLogo()
        {
            AbrirFormHija(new Reposo());
        }
        public MENUU()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("¿Esta seguro de cerrar la aplicación?", "Cerrar", MessageBoxButtons.YesNo);

            if (DR == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void MENUU_Load(object sender, EventArgs e)
        {
            AbrirFormHija(new Reposo());
            PresentacionE.Text = NE;
        }

        public void AbrirFormHija(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }


        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.MainPanel.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }


        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (EM == "Administrador")
            {
                //AbrirFormHija(new ReporteDeVenta());
                ReporteDeVenta repor = new ReporteDeVenta();
                repor.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                btnReportes.BackColor = Color.FromArgb(12, 61, 92);
                AbrirFormHija(repor);
            }
            else
            {
                MessageBox.Show("Acceso solo con nivel ADMINISTRADOR");
            }
        }


        private void btnproductos_Click(object sender, EventArgs e)
        {
            Productos pro = new Productos();
            if (EM == "Administrador")
            {
                pro.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                btnproductos.BackColor = Color.FromArgb(12, 61, 92);
                AbrirFormHija(pro);
            }
            else
            {
                MessageBox.Show("Acceso solo con nivel ADMINISTRADOR");
            }
            

        }

        //METODO/EVENTO AL CERRAR FORMS
        private void CerrarFormulario()
        {  
                btnproductos.BackColor = Color.FromArgb(26, 32, 40);
                BTNventas.BackColor = Color.FromArgb(26, 32, 40);
                button3.BackColor = Color.FromArgb(26, 32, 40);
                button4.BackColor = Color.FromArgb(26, 32, 40);
                button5.BackColor = Color.FromArgb(26, 32, 40);
                button6.BackColor = Color.FromArgb(26, 32, 40);
                btnReportes.BackColor = Color.FromArgb(26, 32, 40);

        }


       
    private void button5_Click(object sender, EventArgs e)
        {
            if (EM == "Administrador")
            {
                //AbrirFormHija(new Empleados());
                Empleados emp = new Empleados();
                emp.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                button5.BackColor = Color.FromArgb(12, 61, 92);
                AbrirFormHija(emp);
            }
            else
            {

                MessageBox.Show("Acceso solo con nivel ADMINISTRADOR");
            }
        }

        private void BTNventas_Click(object sender, EventArgs e)
        {
            //AbrirFormHija(new Ventas(NE, EM, IdEm1));
            Ventas ve = new Ventas(NE, EM, IdEm1);
            ve.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            BTNventas.BackColor = Color.FromArgb(12, 61, 92);
            AbrirFormHija(ve);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EM == "Administrador")
            {
                //AbrirFormHija(new Clientes());
                Clientes CLI = new Clientes();
                CLI.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                button3.BackColor = Color.FromArgb(12, 61, 92);
                AbrirFormHija(CLI);
            }
            else
            {
                MessageBox.Show("Acceso solo con nivel ADMINISTRADOR");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (EM == "Administrador")
            {
                //AbrirFormHija(new Proveedores());
                Proveedores prove = new Proveedores();
                prove.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                button4.BackColor = Color.FromArgb(12, 61, 92);
                AbrirFormHija(prove);
            }
            else
            {
                MessageBox.Show("Acceso solo con nivel ADMINISTRADOR");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (EM == "Administrador")
            {
                //AbrirFormHija(new Pedidos());
                Pedidos ped = new Pedidos();
                ped.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                button6.BackColor = Color.FromArgb(12, 61, 92);
                AbrirFormHija(ped);
            }
            else
            {
                MessageBox.Show("Acceso solo con nivel ADMINISTRADOR");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginAdministrador login = new LoginAdministrador();
            login.Show();
            this.Hide();
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Reposo());
        }
        int lx, ly;
        private void BtnMax_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMax.Visible = false;
            btnMinMax.Visible = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.Dll", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWid, int wMsg, int wParam, int lParam);
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void FECHAHORA_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnMinMax_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1360, 649);
            this.Location = new Point(lx, ly);
            btnMax.Visible = true;
            btnMinMax.Visible = false;
        }
    }
}
