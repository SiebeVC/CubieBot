using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Test.Models;
using System.Data;

namespace Test.Models
{
    public class DomainController
    {
        Activititeiten activiteiten;
        private DataController dal;

        private static DomainController instance = null;
        private static object syncLock = new object();
        #region Singleton

        //Singleton patern
        /// <summary>
        /// Get an instance of DomainController
        /// </summary>
        /// <returns>A Singleton instance of DomainController</returns>
        public static DomainController GetInstance(string connectionstring)
        {
            // Support multithreaded applications through 'Double checked locking' pattern which
            // (once the instance exists) avoids locking each time the method is invoked.
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                        instance = new DomainController(connectionstring);
                }
            }
            return instance;
        }

        #endregion

        protected DomainController(string connectionstring)
        {
            dal = DataController.GetInstance(connectionstring);
            activiteiten = new Activititeiten();
        }

        public void LaadActiviteiten()
        {
            activiteiten.lstActiviteiten.Clear();
            foreach (DataRow item in dal.GetActiviteiten()?.ToTable()?.Rows)
            {
                Activiteit activiteit = new Activiteit();
                if (activiteit.Load(item))
                {
                    activiteiten.AddActiviteit(activiteit);
                }
            }
        }

        public Activititeiten GetActivititeiten()
        {
            return activiteiten;
        }

        public void MaakNieuweActiviteit(Activiteit activiteit)
        {
            dal.QryNieuw(activiteit.Naam, activiteit.Datum, activiteit.Wat, activiteit.Hoelang);
        }
    }
}