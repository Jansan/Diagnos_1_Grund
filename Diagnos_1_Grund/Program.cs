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

                        case 2:
                            if(bilLista.Count > 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                foreach (Bil item in bilLista)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine("\n\n\t * " + bilLista.Count + " bilar är total registerade. * ");
                                Console.ResetColor();
                                Console.ReadLine();
                            }
                            else
                            {
                                Felmeddelande("Det finns inga registrerade bilar i dagsläget");
                            }
                            break;

                        case 3:
                            Random newRandom = new Random();
                            string[] slumpABC = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Å", "Ä", "Ö" };
                            string[] slumpTillverkare = new string[] { "Toyota", "Volkswagen", "General Motors", "Hyundai", "Ford", "Nissan", "Honda", "Fiat Chrysler", "Renault", "Volvo" };

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\n\t * Hur många bilar vill du importera? *");
                            Console.Write("\t * ");
                            if (Int32.TryParse(Console.ReadLine(), out int antalBilar))
                            {
                                if (antalBilar > 0)
                                {
                                    for (int i = 0; i < antalBilar; i++)
                                    {
                                        string register_slum = "";
                                        for (int a = 0; a < 3; a++)
                                        {
                                            register_slum += slumpABC[newRandom.Next(0, slumpABC.Length)];
                                        }
                                        for (int b = 0; b < 3; b++)
                                        {
                                            register_slum += newRandom.Next(0, 10);
                                        }

                                        string tillverkare_slum = slumpTillverkare[newRandom.Next(0, slumpTillverkare.Length)];

                                        int årtal_slump = newRandom.Next(1920, (DateTime.Now.Year + 1));

                                        bool besiktad_slump = false;

                                        if (newRandom.Next(0,2) == 0)
                                        {
                                            besiktad_slump = true;
                                        }
                                        bilLista.Add(new Bil(register_slum, tillverkare_slum, årtal_slump, besiktad_slump));
                                    }
                                    Console.WriteLine("\t * " + antalBilar + " bilar registrerade *");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t * Återvänder till huvudmeny *");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Felmeddelande("Du har inte valt ett giltigt antal!");
                            }
                            break;

                        case 4:
                            isRunning = false;
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
