using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject.ArduinoConnecties
{
    // Deze class wordt gebruikt voor het verbinden van het programma met de CubieBot. 
    public class CubieBotConnectie
    {
        #region Properties

        /// <summary>
        /// De naam van de verbinding (Kan gebruikt worden om op te zoeken)
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        /// De Serial poort van de Arduino, deze is nodig zodat we verbinding kunnen maken met de Arduino.
        /// </summary>
        public SerialPort SerialPort { get; set; }

        /// <summary>
        /// Snelle portname
        /// </summary>
        public string COM { get; set; }

        /// <summary>
        /// Boolean om te zien ofdat de port wordt gebruikt
        /// </summary>
        public bool WordtGebruikt { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van CubieBotConnectie
        /// </summary>
        /// <param name="com">Portnaam</param>
        /// <param name="naam">Naam van de connetie</param>
        public CubieBotConnectie(string com, string naam = "")
        {
            //Port toevoegen
            this.SerialPort = new SerialPort()
            {
                PortName = com,
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                RtsEnable = true
            };

            COM = com;
            WordtGebruikt = false;

            if (String.IsNullOrWhiteSpace(naam))
            {
                Naam = "connectie " + com[com.Length - 1];
            }
            else
                Naam = naam;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Zoekt al de beschikbare poorten voor de arduino te connecteren
        /// </summary>
        /// <returns>Een lijst met al de mogenlijke poorten. Indien er nies gevonden is, is deze lijst leeg</returns>
        public static List<CubieBotConnectie> PoortenBeschikbaar()
        {
            //D
            SerialPort testPort;
            bool werkt;
            List<CubieBotConnectie> lstPorts = new List<CubieBotConnectie>();

            for (int i = 0; i < 25; i++)
            {
                //Juiste test poort asignen
                werkt = true;
                testPort = new SerialPort()
                {
                    PortName = "COM" + i,
                    BaudRate = 9600,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    Handshake = Handshake.None,
                    RtsEnable = true
                };

                //testen uitvoeren
                /* 
                 * Als de test een fout geeft wordt deze opgevangen door de try catch
                 * Daarin wordt de variabele 'werkt' false geasigned
                 * en dus zal de serialport daarna niet in de lijst van beschikbare poorten gestoken worden
                */
                try
                {
                    testPort.Open();
                    testPort.Close();
                }
                catch (Exception)
                {
                    werkt = false;
                }

                if (werkt)
                {
                    lstPorts.Add(new CubieBotConnectie(testPort.PortName, "Connectie " + (lstPorts.Count + 1)));
                }
            }

            return lstPorts;
        }

        #endregion
    }
}
