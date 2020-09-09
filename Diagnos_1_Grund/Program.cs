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

                if (Int32.TryParse(Console.ReadLine(), out int resultat)
                {
                    switch (resultat)
                    {
                        case 1:
                            string registreringsNumber = "";
                            string tillverkare = "";
                            int årtal = 0;
                            bool besiktad = false;

                            while (registreringsNumber.Length != 6)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n\n\t * Då börjar vi med att välja bilens registeringsnummber. Var god skriv in 6 symboler *");
                                Console.ResetColor();
                                Console.Write("\t * ");
                                registreringsNumber = Console.ReadLine().ToUpper();
                                if (registreringsNumber.Length != 6)
                                {
                                    Felmeddelande("Registrering sker med 6 symboler, utan mellanslag");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void Felmeddelande(string kontext)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\t * " + kontext + " *");
            Console.ResetColor();
            Console.WriteLine("\t * (Tryck ENTER för att fortsätta)");
            Console.ReadLine();
        }
    }
}
