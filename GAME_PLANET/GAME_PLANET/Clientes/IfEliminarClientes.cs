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
    public partial class IfEliminarCliente : Form
    {

        Clientes clientes = new Clientes();
        Conectar conexion = new Conectar();
       
        SQLiteDataAdapter adaptar;
        DataTable Cliente;

        public IfEliminarCliente()
        {
            InitializeComponent();      
        }

        string _RFC;

        public string RFC { get => _RFC; set => _RFC = value; }

        private void btnDeleteCliente_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "DELETE FROM Cliente WHERE Nombre = '" + RFC + "'";
                Cliente = new DataTable();
                adaptar = new SQLiteDataAdapter(selectQuery, conexion._conexion);
                adaptar.Fill(Cliente);
                clientes.dgvCliente.DataSource = Cliente;

                this.Hide();
                MessageBox.Show("El Cliente se ha eliminado...");
            }
            catch (Exception E)
            {
                MessageBox.Show("No selecciono que cliente va a eliminar...");
            }
   
        }

        private void btnNoDeleteCliente_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
