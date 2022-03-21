using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject
{
    public class DatabaseMethods
    {
        /// <summary>
        /// Voert een SQL uit die jij opgeeft
        /// </summary>
        /// <param name="commandstring">De SQl string</param>
        /// <returns>Het aantal aangepaste records</returns>
        public static int DatabaseActions(string commandstring)
        {
            //Connectionstring ophalen via de app settings
            OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.CubiebotConnectionString);
            OleDbCommand command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = commandstring;

            connection.Open();

            int totAangepast = command.ExecuteNonQuery();

            connection.Close();

            return totAangepast;
        }

        /// <summary>
        /// Leest een tabel
        /// </summary>
        /// <param name="commandstring">De SQL dat moet uitgevoerd worden om te lezen</param>
        /// <returns>De waardes in een string list</returns>
        public static string[] DatabaseRead(string commandstring)
        {
            //D
            List<string> read = new List<string>();
            //Connectionstring ophalen via de app settings
            OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.CubiebotConnectionString);
            OleDbCommand command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = commandstring;


            connection.Open();

            OleDbDataReader rd = command.ExecuteReader();
            //P
            while (rd.Read())
            {
                for (int i = 0; i < rd.FieldCount; i++)
                {
                    read.Add(rd[i].ToString());
                }
            }

            connection.Close();

            //O
            return read.ToArray();
        }
    }
}
