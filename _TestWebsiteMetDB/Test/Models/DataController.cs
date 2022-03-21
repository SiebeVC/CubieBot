using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;
using Test.Properties;
using Test.Models;

namespace Test.Models
{
    public class DataController
    {
        private static DataController instance = null;
        private static object syncLock = new object();

        #region Singleton
        /// <summary>
        /// Get an instance of DataAccesController
        /// </summary>
        /// <returns>A Singleton instance of DataAccesController</returns>
        public static DataController GetInstance(string connectionstring)
        {
            // Support multithreaded applications through 'Double checked locking' pattern which
            // (once the instance exists) avoids locking each time the method is invoked.
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                        instance = new DataController(connectionstring);
                }
            }
            return instance;
        }
        #endregion

        OleDbConnection connection;
        OleDbCommand command;
        Activititeiten activiteiten;

        protected DataController(string connectionstring)
        {
            connection = new OleDbConnection(connectionstring);
            command = new OleDbCommand() { Connection = connection };
            activiteiten = new Activititeiten();
        }


        #region DataLoad

        public DataView GetActiviteiten()
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



        public int QryNieuw(string naam, DateTime datum, string wat, string hoelang)
        {
            int aangepast = -1;
            string sqlstringNonQry = $"INSERT INTO tblLogboekInhoud(Naam, Datum, Wat, Hoelang) VALUES('{naam}','{datum.Date}','{wat}','{hoelang}');";
            if (OpenConnection())
            {
                try
                {
                    aangepast = command.ExecuteNonQuery();
                    return aangepast;
                }
                catch (Exception)
                {
                    return aangepast;
                }
                finally
                {
                    CloseConnection();
                }
            }
            return aangepast;
        }
        #endregion
    }
}