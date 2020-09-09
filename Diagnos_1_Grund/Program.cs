using System;
using System.Collections.Generic;

namespace Diagnos_1_Grund
{
    class Bil
    {
        public string RegistreringsNumber;
        public string Tillverkare;
        public int Årtal;
        public bool Besiktad;

        public Bil(string registreringsNumber, string tillverkare, int årtal, bool besiktad)
        {
            RegistreringsNumber = registreringsNumber;
            Tillverkare = tillverkare;
            Årtal = årtal;
            Besiktad = besiktad;
        }

        public override string ToString()
        {
            if (Besiktad)
            {
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
                    + "\n\t\t" + RegistreringsNumber
                    + "\n\t\tBesiktad";
            }
            else
            {
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
                    + "\n\t\t" + RegistreringsNumber
                    + "\n\t\tObesiktad";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            List<Bil> bilLista = new List<Bil>();

            while (isRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\t ********************************"
                    + "\n\t * Välkommen till Bilregistret *"
                    + "\n\t *******************************"
                    + "\n\n\t [1] Registera ny bil"
                    + "\n\t [2] Se alla registrerade bilar"
                    + "\n\t [3] Importera bil"
                    + "\n\t [4] Avsluta");
                Console.ResetColor();
            }
        }
    }
}
