using Dapper;
using Npgsql;
using Schoolproject.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Schoolproject.MainProgram
{
    public class PostgresDataAccess
    {
        public static List<Student> ListaStudenter()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.\n Those student are admitted in this School.");

                var output = connectionWithServer.Query<Student>($" SELECT * FROM kha_student", new DynamicParameters());
                return output.ToList();

                List<Student> list1 = ListaStudenter();
                for (int i = 0; i < list1.Count; i++)
                {
                    Student list = list1[i];
                    Console.WriteLine("Student's Id: " + list.id);
                    Console.WriteLine("Student's FirstName: " + list.first_name);
                    Console.WriteLine("Student's LastName: " + list.last_name);
                    Console.WriteLine("Student's Email: " + list.email);
                    Console.WriteLine("Student's Age: " + list.age);
                    Console.WriteLine("Student's Password: " + list.password);
                    break;
                    //Console.WriteLine("ID : {0}  |  First Name: {1}  |  Last Name: {2}  |      Email: {3}       |     Age: {4}     |     PassWord: {5}  ", list.id, list.first_name, list.last_name, list.email, list.age, list.password);
                }
            }
        }

        public static List<Course> ListaKurser()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Course List.");

                var output = connectionWithServer.Query<Course>($"SELECT * FROM kha_course", new DynamicParameters());
                return output.ToList();

                foreach (var item in ListaKurser())
                {
                    Console.WriteLine("Student's Id: " + item.id);
                    Console.WriteLine("Student's FirstName: " + item.name);
                    Console.WriteLine("Student's Points: " + item.points);
                    Console.WriteLine("Student's Start Date: " + item.start_date);
                    Console.WriteLine("Student's End Date: " + item.end_date);
                }

            }
        }
        public static void SkapaStudent()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("Welcome to Admission Department." +
                    "\nWe need some information from you. Please follow Belows Information.");
                Console.WriteLine("Please Enter your First-Name. (Please follow Capital Lettter).");
                string firstName = Console.ReadLine().ToUpper();

                Console.WriteLine("Please Enter your Last-Name. (Please follow Capital Lettter).");
                string lastName = Console.ReadLine().ToUpper();

                Console.WriteLine("Please Enter your Email address. (Please follow small Lettter).");
                string eMail = Console.ReadLine().ToLower();

                Console.WriteLine("Please Enter your Age address.");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Please Enter your Desired PassWord. (6 Digits).");
                int passWord = int.Parse(Console.ReadLine());

                string workshop16 = "INSERT INTO kha_Student(first_name, last_name, email, age, password)" +
                    "VALUES (@firstName, @lastName, @eMail, @age, @passWord)";
                connectionWithServer.Execute(workshop16, new { firstName, lastName, eMail, age, passWord });

            }
        }

        public static void Skapakurs()
        {
            //using (IDbConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))

            {
                //connectionWithServer.Open();
                Console.WriteLine("Welcome to Registered Department.");

                Console.WriteLine("Please Enter the Course Name.");
                string name = Console.ReadLine().ToUpper();

                Console.WriteLine("How much Point for the Course");
                int points = int.Parse(Console.ReadLine());

                Console.WriteLine("When it is going to start");
                int startDate = int.Parse(Console.ReadLine());

                Console.WriteLine("When going to finish.");
                int endDate = int.Parse(Console.ReadLine());

                string workshop16 = "INSERT INTO kha_Course(name, points, start_date, end_date)" +
                    "VALUES (@name, @points, @startDate, @endDate)";
                connectionWithServer.Execute(workshop16, new { name, points, startDate, endDate });
                //connectionWithServer.Close();

            }
        }

        public static void BytLösenord()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("Do you want change your Password.");
                Console.WriteLine("Please put the serial number want to change password.");
                int id = int.Parse(Console.ReadLine());

            }
        }

        public static void RedigeraKurs()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");
                Console.WriteLine("Which course would you like to change? Please put the serial Number");
                int id = int.Parse(Console.ReadLine());



            }
        }

        public static void RaderaKurs()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");
                Console.WriteLine("Which course do you like to detele? Please put your serial Number.");
                int id = int.Parse(Console.ReadLine());


            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
