
namespace FlowCinemaMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
        }

        private static bool Menu()
        {
            PrintMenu();
            string menuChoice = AskForString("Val");
            switch (menuChoice)
            {
                case "0":
                    return false;
                case "1":
                    TicketPriceForOne();
                    return true;
                case "2":
                    TicketPriceForX();
                    return true;
                default:
                    Console.WriteLine("Vänligen gör ett korrekt val i menyn.");
                    return true;
            }
        }

        private static void PrintMenu()
        {   
            Console.WriteLine("Välkommen till din lokala biograf. Gör ett val:");
            Console.WriteLine("1) Biljettpris för en besökare");
            Console.WriteLine("2) Biljettpris för flera besökare");
            Console.WriteLine("0) Quit / Exit");
        }

        private static int AgeVerification()
        {
            int age = AskForInt("Ålder");
            int cost = 0;
            if (age > 0 && age <= 5 || age > 100)
                cost = 0;
            else if (age > 5 && age < 20)
                cost = 80;
            else if (age >= 20 && age < 65)
                cost = 120;
            else if (age >= 65 && age <= 100)
                cost = 90;
            else
                cost = AgeVerification();   //To fix: Could become recursive.

            return cost;
        }

        private static void TicketPriceForOne()
        {
            int cost = AgeVerification();
            switch (cost)
            {
                case 0:
                    Console.WriteLine("Du går gratis!");
                    break;
                case 80:
                    Console.WriteLine("Ungdomspris: 80kr");
                    break;
                case 90:
                    Console.WriteLine("Pensionärspris: 90kr");
                    break;
                case 120:
                    Console.WriteLine("Standardpris: 120kr");
                    break;
            }
        }

        private static void TicketPriceForX()
        {
            Console.WriteLine("Hur många besökare är ni?");
            int visitors = AskForInt("Besökare");
            int totalCost = 0;

            for (int i = 0; i < visitors; i++)
            {
                totalCost += AgeVerification();
            }
            Console.WriteLine($"Ni är {visitors} besökare och eran totala kostnad för biljetterna är {totalCost}kr.");
        }

        private static string AskForString(string prompt)
        {
            bool success = false;
            string given;
            do
            {
                Console.WriteLine($"{prompt}: ");
                given = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(given))
                {
                    Console.WriteLine($"Du måste ange en/ett korrekt {prompt}");
                }
                else
                {
                    success = true;
                }
            } while (!success);
            return given;
        }

        private static int AskForInt(string prompt)
        {
            do
            {
                string given = AskForString(prompt);
                if (int.TryParse(given, out int result))
                {
                    return result;
                }
            } while (true);
        }

    }
}
