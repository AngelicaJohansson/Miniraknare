using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Miniräknare_inlämning
{
    // Pseudo kod
    internal class Program
    {
        static void Main(string[] args)
        {
            // Välkomnande meddelande
            Console.WriteLine("Välkommen! Nu ska vi räkna matematik ");

            // En lista för att spara historik för räkningar
            List<decimal> uträkningLista = new List<decimal>();


            Calculator calculator = new Calculator();

            while (true)
            {
                Console.WriteLine("Miniräknaren startar: ");

                calculator.MataInTal();

                Console.WriteLine(@"Vilken matematik vill du räkna "" + "", "" - "", "" * "", "" / "" och enter för att fortsätta");
                calculator.aritmetiskaOperationer = Console.ReadLine();

                decimal resultat = calculator.Beräkna(uträkningLista);

                // Visa resultat
                Console.WriteLine($"Resultat: {resultat}");

                Console.WriteLine();

                // Fråga användaren om den vill visa tidigare resultat.
                Console.WriteLine("Vill du se tidigare resultat?  Ja / Nej  ");
                string seUträkning = Console.ReadLine().ToLower();

                calculator.VisaResultat(seUträkning, uträkningLista);

                Console.WriteLine();
                if (!calculator.FortsättMiniräknare())
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
    class Calculator
    {
        public decimal tal1;
        public string aritmetiskaOperationer;
        public decimal tal2;


        // Användaren matar in tal och matematiska operation
        // OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
        public void MataInTal()
        {
            tal1 = KontrolleraInmatning("Skriv in det första talet och enter för att fortsätta");
            tal2 = KontrolleraInmatning("Skriv in det andra talet och enter för att fortsätta");
        }

        private decimal KontrolleraInmatning(string meddelande)
        {
            decimal tal;

            while (true)
            {
                Console.WriteLine(meddelande);
                string användarensTal = Console.ReadLine();

                if (decimal.TryParse(användarensTal, out tal))
                {
                    return tal;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Var god mata in ett tal.");
                }
            }
        }
        private decimal KontrolleraInmatningaritmetiskaOperationer(string meddelande)
        {
            decimal tal;

            while (true)
            {
                Console.WriteLine(meddelande);
                string användarensTal = Console.ReadLine();

                if (decimal.TryParse(användarensTal, out tal))
                {
                    return tal;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Var god mata in ett tal.");
                }
            }
        }
        public decimal Beräkna(List<decimal> uträkningLista)
        {
            decimal resultat = 0;
            switch (aritmetiskaOperationer)
            {
                case "+":
                    resultat = (tal1 + tal2);
                    break;

                case "-":
                    resultat = (tal1 - tal2);
                    break;

                case "*":
                    resultat = (tal1 * tal2);
                    break;

                // Ifall användaren skulle dela med 0 visa Ogiltig inmatning!
                case "/":
                    if (tal2 == 0)
                    {
                        Console.WriteLine("Ogiltig inmatning!");
                    }
                    else
                    {
                        resultat = (tal1 / tal2);
                    }
                    break;

                default:
                    Console.WriteLine("Något gick fel");
                    break;
            }

            // Lägga resultat till listan
            uträkningLista.Add(resultat);

            return resultat;
        }

        public List<decimal> VisaResultat(string seUträkning, List<decimal> uträkningLista)
        {
            switch (seUträkning)
            {
                // Visa tidigare resultat
                case "ja":
                    if (uträkningLista == null || uträkningLista.Count == 0)
                    {
                        Console.WriteLine("Listan är tom.");
                    }
                    else
                    {
                        Console.WriteLine("Dina tidigare resultat: ");
                        foreach (decimal resultat in uträkningLista)
                        {
                            Console.WriteLine(resultat);
                        }
                        return uträkningLista;
                    }
                    break;
                case "nej":
                    Console.WriteLine("Då fortsätter vi . . . ");
                    break;
                default:
                    Console.WriteLine("Något gick fel");
                    break;
            }
            return new List<decimal>();
        }
        public bool FortsättMiniräknare()
        {
            // Fråga användaren om den vill avsluta eller fortsätta.
            Console.WriteLine("Vill du fortsätta räkna? Ja / Nej");
            string fortsätt = Console.ReadLine().ToLower();

            if (fortsätt != "ja")
            {
                Console.WriteLine("Då avslutar vi miniräknaren . . . ");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


