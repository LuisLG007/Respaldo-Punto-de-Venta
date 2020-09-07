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
    public partial class LoginAdministrador : Form
    {
        public LoginAdministrador()
        {
            InitializeComponent();
            textBoxUsu.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logear(this.textBoxUsu.Text, this.textBoxContra.Text);
        }


        public void logear(string nombre, string contraseña)
        {
            try
            {
                Conectar conexion = new Conectar();
                SQLiteDataAdapter adaptar;
                DataTable Personas;
             
                string cmd = "SELECT Nombre, Puesto, Apellido_Paterno, Apellido_Materno, Id_Empleado FROM Empleado WHERE Nombre = '" + nombre + "' AND Contraseña = '" + contraseña + "'";
                adaptar = new SQLiteDataAdapter(cmd, conexion._conexion);
                Personas = new DataTable();
                adaptar.Fill(Personas);

                if (Personas.Rows.Count == 1)
                {
                    this.Hide();
                    if (Personas.Rows[0][1].ToString() == "Administrador")
                    {
                        MENUU mENUU = new MENUU();
           
                        mENUU.NE = Personas.Rows[0][0].ToString() + " " + Personas.Rows[0][2].ToString() + " " + Personas.Rows[0][3].ToString(); 
                        mENUU.EM = Personas.Rows[0][1].ToString();
                        mENUU.IdEm1 = int.Parse(Personas.Rows[0][4].ToString());

                        mENUU.Show();
                        
                    }
                    else if (Personas.Rows[0][1].ToString() == "Empleado")
                    {
                        MENUU mENUU = new MENUU();
           
                        mENUU.NE = Personas.Rows[0][0].ToString() + " " + Personas.Rows[0][2].ToString() + " " + Personas.Rows[0][3].ToString(); 
                        mENUU.EM = Personas.Rows[0][1].ToString();
                        mENUU.IdEm1 = int.Parse(Personas.Rows[0][4].ToString());
                        mENUU.Show();
                    }
                 
                }
                else
                    {
                        MessageBox.Show("Usuario y/0 contraseña incorrecta");
                    }


            }
            catch (Exception error)
            {
                MessageBox.Show("Error al conectarse a la base de datos");
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUsu_Enter(object sender, EventArgs e)
        {
            if (textBoxUsu.Text == "USUARIO")
            {
                textBoxUsu.Text = "";
                textBoxUsu.ForeColor = Color.LightGray;
            }
        }

        private void textBoxUsu_Leave(object sender, EventArgs e)
        {
            if (textBoxUsu.Text == "")
            {
                textBoxUsu.Text = "USUARIO";
                textBoxUsu.ForeColor = Color.DimGray;
            }
        }

        private void textBoxContra_Enter(object sender, EventArgs e)
        {
           
            if (textBoxContra.Text == "CONTRASEÑA")
            {
                
                textBoxContra.Text = "";             
                textBoxContra.ForeColor = Color.LightGray;              
                textBoxContra.UseSystemPasswordChar = true;
            }
        }

        private void textBoxContra_Leave(object sender, EventArgs e)
        {
            if (textBoxContra.Text == "")
            {
                textBoxContra.UseSystemPasswordChar = false;
                textBoxContra.Text = "CONTRASEÑA";
                textBoxContra.ForeColor = Color.DimGray;              
            }
        }

        private void LoginAdministrador_Load(object sender, EventArgs e)
        {        
            textBoxUsu.Focus();
        }

        private void textBoxContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                logear(this.textBoxUsu.Text, this.textBoxContra.Text);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MV M = new MV();
            M.Show();
        }
    }
}
 