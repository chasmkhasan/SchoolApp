using Dapper;
using Npgsql;
using Schoolproject.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolproject.MainProgram
{
    public class PostgresDataAccess
    {
        public static List<Kha_student> ListaStudenter()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.\n Those student are admitted in this School.");

                var output = connectionWithServer.Query<Kha_student>($" SELECT * FROM kha_student", new DynamicParameters());
                return output.ToList();

                foreach (var Kha_student in ListaStudenter())
                {
                    //Console.WriteLine("Student's Id: " + Kha_student.id);
                    //Console.WriteLine("Student's FirstName: " + Kha_student.first_name);
                    //Console.WriteLine("Student's LastName: " + Kha_student.last_name);
                    //Console.WriteLine("Student's Email: " + Kha_student.email);
                    //Console.WriteLine("Student's Age: " + Kha_student.age);
                    //Console.WriteLine("Student's Password: " + Kha_student.password);

                    Console.WriteLine("ID : {0}  |  First Name: {1}  |  Last Name: {2}  |      Email: {3}       |     Age: {4}     |     PassWord: {5}  ", Kha_student.id, Kha_student.first_name, Kha_student.last_name, Kha_student.email, Kha_student.age, Kha_student.password);
                }


            }
        }

        public static List<Kha_course> ListaKurser()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");

                var output = connectionWithServer.Query<Kha_course>($" SELECT * FROM kha_student", new DynamicParameters());
                return output.ToList();

                foreach (var Kha_course in ListaKurser())
                {
                    Console.WriteLine("Student's Id: " + Kha_course.id);
                    Console.WriteLine("Student's FirstName: " + Kha_course.name);
                    Console.WriteLine("Student's Points: " + Kha_course.points);
                    Console.WriteLine("Student's Start Date: " + Kha_course.start_date);
                    Console.WriteLine("Student's End Date: " + Kha_course.end_date);
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


            }
        }

        public static void RedigeraKurs()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");


            }
        }

        public static void RaderaKurs()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");


            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
