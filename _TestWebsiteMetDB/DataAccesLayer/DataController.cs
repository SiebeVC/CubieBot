using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;
using Test.Properties;
using Test.Models;

namespace Test.Controllers
{
    public class DataController
    {

        OleDbConnection connection;
        OleDbCommand command;
        Activititeiten activiteiten;

        public DataController()
        {
            if (activiteiten == null)
                activiteiten = new Activititeiten();
            if (connection == null)
                connection = new OleDbConnection(Settings.Default.connectionString);
            if (command == null)
                command = new OleDbCommand();
        }

        public void LaadActiviteiten()
        {
            activiteiten.lstActiviteiten.Clear();
            foreach (DataRow item in GetActiviteiten()?.ToTable()?.Rows)
            {
                Activiteit activiteit = new Activiteit();
                if (activiteit.Load(item))
                {
                    activiteiten.AddActiviteit(activiteit);
                }
            }
        }


        #region DataLoad

        private DataView GetActiviteiten()
        {
            DataView activiteiten = null;
            activiteiten = new DataView(GetTableContent("tblLogboekInhoud"));
            return activiteiten;
        }

        private DataTable GetTableContent(string tabelNaam)
        {
            return ExecuteSelectionQuery(tabelNaam, CommandType.TableDirect);
        }


        private DataTable ExecuteSelectionQuery(string query, CommandType type = CommandType.Text)
        {
            DataTable resultaten = new DataTable();
            OleDbDataReader reader;
            command = new OleDbCommand(query, connection);
            command.CommandType = type;
            if (OpenConnection())
            {
                try
                {
                    reader = command.ExecuteReader();
                    resultaten.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex; //Niets doen
                }
                finally
                {
                    CloseConnection();
                }
            }
            return resultaten;
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}