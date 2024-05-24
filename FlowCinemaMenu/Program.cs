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
            Console.Clear();
            PrintMenu();
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "0":
                    return false;
                    break;
                default:
                    Console.WriteLine("Please pick a valid choice.");
                    return true;
                    break;
            }
        }

        private static void PrintMenu()
        {   
            Console.WriteLine("Welcome to your local cinema. Choose an option:");
            Console.WriteLine("0) Quit / Exit");
        }

    }
}
