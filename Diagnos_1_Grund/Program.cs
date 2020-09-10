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

                if (Int32.TryParse(Console.ReadLine(), out int resultat))
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

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\n\t * Vilken tillverkare har bilen? *");
                            Console.ResetColor();
                            Console.Write("\t * ");
                            tillverkare = Console.ReadLine().ToUpper();
                            if (tillverkare == "")
                                tillverkare = "ÖKÄND";

                            while (årtal < 1900)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n\n\t * Var god skriv in året då bilen tillverkades *");
                                Console.ResetColor();
                                Console.Write("\t * ");
                                if (Int32.TryParse(Console.ReadLine(), out årtal))
                                {
                                    if (årtal < 1900 || årtal > DateTime.Now.Year)
                                        Felmeddelande("Måste välja mellan 1990 till i år");
                                    else
                                    {

                                    }
                                }
                            }

                            string input = "";
                            while (input == "")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n\n\t * Är bilen besiktad? (Ja / Nej) *");
                                Console.ResetColor();
                                Console.Write("\t * ");
                                input = Console.ReadLine();
                                if (input.Length > 0)
                                {
                                    if (input[0] == 'j' || input[0] == 'J')
                                    {
                                        besiktad = true;
                                        Console.WriteLine("\n\n\t * Noterat - Bilen är besiktad. *");
                                    }
                                    else if(input[0] == 'n' || input[0] == 'N')
                                    {
                                        besiktad = false;
                                        Console.WriteLine("\n\n\t * Noterat - Bilen är inte besiktad. *");
                                    }
                                    else
                                    {
                                        input = "";
                                        Felmeddelande("Du behöver skriva in Ja eller Nej");
                                    }
                                }
                                else
                                {
                                    Felmeddelande("Du måste göra ett val");
                                }
                            }

                            Bil nyBil = new Bil(registreringsNumber, tillverkare, årtal, besiktad);

                            bilLista.Add(nyBil);

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Felmeddelande("Ogiltigt menyval");
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
