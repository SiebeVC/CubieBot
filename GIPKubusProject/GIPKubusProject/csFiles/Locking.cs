using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject.csFiles
{
    class Locking
    {
        public string Naam { get; set; }
        public string KeyHolder { get; set; }
        public bool IsLocked { get; set; }

        public Locking(string naam)
        {
            Naam = naam;
            KeyHolder = null;
            IsLocked = false;
        }

        /// <summary>
        /// Unlocked het slot, enkel als de keyhouder hetzelfde is
        /// </summary>
        /// <param name="keyHolder">De keyholder enkel als deze hetzelfde is gaat het slot open</param>
        /// <returns>True indien gelukt, false indien niet gelukt</returns>
        public bool UnLock(string keyHolder)
        {
            try
            {
                if (IsLocked && this.KeyHolder == keyHolder)
                {
                    this.KeyHolder = null;
                    IsLocked = false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Locked het slot enkel als het slot open is
        /// </summary>
        /// <param name="keyHouder">De nieuwe keyholder (als sleutel)</param>
        /// <returns>True indien gelukt, false indien niet gelukt</returns>
        public bool Lock(string keyHouder)
        {
            try
            {
                if (!IsLocked)
                {
                    this.KeyHolder = keyHouder;
                    IsLocked = true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
