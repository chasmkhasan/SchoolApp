using Schoolproject.Model;

namespace Schoolproject.MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till databasen! Vänligen välj ett av nedanstående alternativ:");
            mainMenu:
            Console.WriteLine("1. Print Student List");
            Console.WriteLine("2. Print Course List");
            Console.WriteLine("3. Create Student File");
            Console.WriteLine("4. Create Course");
            Console.WriteLine("5. Change Password");
            Console.WriteLine("6. Edit Course");
            Console.WriteLine("7. Delete Course");
            Console.WriteLine("A. Logout");


            string menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    PostgresDataAccess.PrintStudent();



                    goto mainMenu;
                case "2":
                    PostgresDataAccess.PrintCourseList();


                    goto mainMenu;
                case "3":

                    PostgresDataAccess.CreateStudentFile();


                    goto mainMenu;
                case "4":
                    PostgresDataAccess.CreateCourse();



                    goto mainMenu;
                case "5":
                    PostgresDataAccess.ChangePassword();


                    goto mainMenu;
                case "6":
                    PostgresDataAccess.EditCourse();


                    goto mainMenu;
                case "7":
                    PostgresDataAccess.DeleteCourse();


                    goto mainMenu;
                case "A":
                    break;
            }
        }
    }
}