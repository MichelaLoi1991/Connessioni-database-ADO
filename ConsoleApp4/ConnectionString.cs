using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class ConnectionString
    {
        //sql adapter : non c'è apertura della connessione, Gestisce in automatico la connessione (apertura e chiusura)

        private void ConectionDataAdapter()
        {
            var connString = "data source = xxx; Initial Catalog (o database) = xxxx; Integrated Security = true";// viene inserita la stringa connessione
            var conn = new SqlConnection(connString);
            var sda = new SqlDataAdapter("select * from - nome tabella- ", conn);
            var dt = new DataTable();
            sda.Fill(dt);
        }


        //sql connection - sql command (si utilazzano le query) Qui la connessione bisogna aprirla
        private void ConnectionWhitCommand()
        {
            using (SqlConnection connection =
                new SqlConnection("data source = xxx; Initial Catalog (o database) = xxxx; Integrated Security = true"))
            {
                var command = new SqlCommand("select * from - nome tabella- ", connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //serve per legger riga 
                        while (reader.Read())
                        {
                            //Lettura delle colonne
                            Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");


                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
