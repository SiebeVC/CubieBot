using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Test
{
    class Program
    {
        static bool magTerug = false;
        static async Task Main(string[] args)
        {
            #region Port aanmaken

            SerialPort portFBL = new SerialPort
            {
                PortName = "COM9",
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                RtsEnable = true
            };   //9
            SerialPort portUDR = new SerialPort()
            {
                PortName = "COM7",
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                RtsEnable = true
            }; //7


            portFBL.DataReceived += new SerialDataReceivedEventHandler(DataReceiver);
            portUDR.DataReceived += new SerialDataReceivedEventHandler(DataReceiver);

            #endregion

            //portFBL.Open();
            //portFBL.Close();

            //Var voor naar arduino
            string[] arr = { "f", "f", "n", "l", "b", "g", "d", "u", "r", "t" ,"f","u","b","l"};

            portFBL.Open(); //Openen van portFBL
            portUDR.Open();
            //portFBL.Close();
            //portUDR.Close();
            Console.ReadKey();
            foreach (string turn in arr)
            {
                if (turn == "f" || turn == "g" || turn == "b" || turn == "n" || turn == "l" || turn == "m")
                {
                    portFBL.Write(turn);
                    Console.WriteLine(turn);
                    while (!magTerug)
                    {
                        Console.WriteLine("Aan het draaien...");
                        await Wachten();
                    }
                    magTerug = false;
                }
                else
                {
                    portUDR.Write(turn);
                    Console.WriteLine(turn);
                    while (!magTerug)
                    {
                        Console.WriteLine("Aan het draaien...");
                        await Wachten();
                    }
                }
            }
            magTerug = true;

            Console.ReadKey();

            portFBL.Close(); //Sluiten van portFBL
            portUDR.Close();
            Console.Clear();
        }

        private static void DataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort myport = (SerialPort)sender;

            string data = myport.ReadExisting();
            if (data.Substring(data.Length - 3, 3) == "X\r\n")
                magTerug = true;
            Console.Write(data);
        }

        private static async Task Wachten()
        {
            // Use await here!
            await Task.Delay(50);

            // Other async goodness...
        }
    }
}
