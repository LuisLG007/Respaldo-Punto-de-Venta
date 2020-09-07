using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME_PLANET
{
    public partial class Reposo : Form
    {
        public Reposo()
        {
            InitializeComponent();
        }

        private void FECHAHORA_Tick(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToLongTimeString();
            Fecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
