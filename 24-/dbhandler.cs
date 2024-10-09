using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _24_
{
    class dbhandler
    {
        MySqlConnection connection;
        string table = "kiflik";
        public dbhandler()
        {
            string username = "root";
            string password = "";
            string host = "localhost";
            string dbname = "pekseg";

            string connectionstring = $"username={username};password={password};host={host};database={dbname}";

            connection = new MySqlConnection(connectionstring);
        }

        public void readAll()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * from {table}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                kifli.kiflik.Clear();
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    string name = "name";
                    int quantity = reader.GetOrdinal("quantity");

                    kifli oneKifli = new kifli();

                    
                    oneKifli.nameKifli = name;
                    oneKifli.quantity = quantity;
                    oneKifli.id = id;

                    kifli.kiflik.Add(oneKifli);
                }
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("beolvbasas hiba " + e.Message);
            }
        }
        public void deleteAll()
        {
            try
            {
                connection.Open();
                string query = $"delete from {table}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Minden törölve");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void addOne(kifli oneKifli)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {table} (name,quantity) values ('{oneKifli.nameKifli}',{oneKifli.quantity})";
                MySqlCommand comand = new MySqlCommand(query, connection);
                comand.ExecuteNonQuery();
                comand.Dispose();
                connection.Close();
                
            }
            catch (Exception)
            {
                
            }
            
        }

        public void deleteOnekifli(kifli onekifli)
        {
            try
            {
                connection.Open();
                string query = $"Delete from {table} where id= {onekifli.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message ,"error ");
            }
        }
        /*public void insertOne(kifli oneKifli)
        {
            try
            {
                connection.Open();
                string query = $"insert into {table} (name,price,weight) " +
                    $"values ('{oneKifli.nameKifli}',{oneKifli.quantity})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Sikeres beillesztés");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }*/
    }
}
