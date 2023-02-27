namespace Schoolproject.MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till databasen! Vänligen välj ett av nedanstående alternativ:");
            mainMenu:
            Console.WriteLine("1. Lista studenter");
            Console.WriteLine("2. Lista kurser");
            Console.WriteLine("3. Skapa student");
            Console.WriteLine("4. Skapa kurs");
            Console.WriteLine("5. Byt lösenord");
            Console.WriteLine("6. Redigera kurs");
            Console.WriteLine("7. Radera kurs");
            Console.WriteLine("A. Avsluta");


            string menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    PostgresDataAccess.ListaStudenter();



                    goto mainMenu;
                case "2":
                    PostgresDataAccess.ListaKurser();


                    goto mainMenu;
                case "3":

                    PostgresDataAccess.SkapaStudent();


                    goto mainMenu;
                case "4":
                    PostgresDataAccess.Skapakurs();



                    goto mainMenu;
                case "5":
                    PostgresDataAccess.BytLösenord();


                    goto mainMenu;
                case "6":
                    PostgresDataAccess.RedigeraKurs();


                    goto mainMenu;
                case "7":
                    PostgresDataAccess.RaderaKurs();


                    goto mainMenu;
                case "A":
                    break;
            }
        }
    }
}