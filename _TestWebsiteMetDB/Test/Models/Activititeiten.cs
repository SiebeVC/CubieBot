using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using Test.Properties;

namespace Test.Models
{
    public class Activititeiten
    {


        public List<Activiteit> lstActiviteiten { get; set; }

        OleDbConnection connection = new OleDbConnection(Settings.Default.connectionString);
        OleDbCommand command = new OleDbCommand();

        public Activititeiten()
        {
            lstActiviteiten = new List<Activiteit>();
            LaadActiviteiten();
        }

        public void LaadActiviteiten()
        {
            lstActiviteiten.Clear();
            foreach (DataRow item in GetActiviteiten()?.ToTable()?.Rows)
            {
                Activiteit activiteit = new Activiteit();
                if (activiteit.Load(item))
                {
                    AddActiviteit(activiteit);
                }
            }
        }

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

        public void AddActiviteit(Activiteit activiteit)
        {
            lstActiviteiten.Add(activiteit);
        }
    }
}