using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicTacGame
{
    internal class BDConnection
    {
        static string infoConnect = "server = 149.202.88.119; user = gs258729; password = mkCzAqMupQPK; database = gs258729";
        static public MySqlDataAdapter msDataAdapter;
        static MySqlConnection myconnect;
        static public MySqlCommand msCommand;
        
        public static bool ConnectoinBD()
        {
            try
            {
                myconnect = new MySqlConnection(infoConnect);
                myconnect.Open();
                msCommand = new MySqlCommand();
                msCommand.Connection = myconnect;
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошмбка подключения к базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public void CloseBD()
        {
            myconnect.Close();
        }

        public MySqlConnection GetConnection()
        {
            return myconnect;
        }
    }
}
