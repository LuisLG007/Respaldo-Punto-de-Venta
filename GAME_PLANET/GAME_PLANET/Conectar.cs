using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace GAME_PLANET
{
    class Conectar
    {
        public SQLiteConnection _conexion;
        public SQLiteCommand _comando;

        public static string USB = "C";

        public Conectar()
        {                                                          
            _conexion = new SQLiteConnection("Data Source = "+USB+ ":/Users/LuisL/OneDrive/PROYECTO/GAME_PLANET/GAME_PLANET/Basee.db");
        }                                                         
                                           
    }
}
