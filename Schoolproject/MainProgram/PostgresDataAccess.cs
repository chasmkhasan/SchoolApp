using Dapper;
using Microsoft.VisualBasic;
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
        public static List<Student> ReadStudentFromDataBase()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.\n Those student are admitted in this School.");

                var listOfStudents = connectionWithServer.Query<Student>($" SELECT * FROM kha_student", new DynamicParameters());
                
                return listOfStudents.ToList();
            }
        }

        public static void PrintStudent()
        {
            
            foreach (var list in ReadStudentFromDataBase())
            {
                //Console.WriteLine("Student's Id: " + list.id);
                //Console.WriteLine("Student's FirstName: " + list.first_name);
                //Console.WriteLine("Student's LastName: " + list.last_name);
                //Console.WriteLine("Student's Email: " + list.email);
                //Console.WriteLine("Student's Age: " + list.age);
                //Console.WriteLine("Student's Password: " + list.password);

                Console.WriteLine("ID : {0}  |  First Name: {1}|  Last Name: {2}|      Email: {3}|     Age: {4}|     PassWord: {5}", list.id, list.first_name, list.last_name, list.email, list.age, list.password);
            }
        }

        public static void PrintCourseList() // problem with datetime and int32
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Course List.");

                var listOfCourses = connectionWithServer.Query<Course>($"SELECT * FROM kha_course", new DynamicParameters());
                

                foreach (var item in listOfCourses)
                {
                    //Console.WriteLine("Student's Id: " + item.id);
                    //Console.WriteLine("Student's FirstName: " + item.name);
                    //Console.WriteLine("Student's Points: " + item.points);
                    //Console.WriteLine("Student's Start Date: " + item.start_date);
                    //Console.WriteLine("Student's End Date: " + item.end_date);

                    Console.WriteLine("ID : {0}  |  Name: {1}|  Points: {2}|   Start Date: {3}|    End Date: {4}", item.id, item.name, item.points, item.start_date, item.end_date);
                }
            }
        }

        public static void CreateStudentFile()
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

                string createStudentListQuery = "INSERT INTO kha_Student(first_name, last_name, email, age, password)" +
                    "VALUES (@firstName, @lastName, @eMail, @age, @passWord)";
                connectionWithServer.Execute(createStudentListQuery, new { firstName, lastName, eMail, age, passWord });

            }
        }

        public static void CreateCourse() //Problem with query
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
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("When going to finish.");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                string createCourseListQuery = "INSERT INTO kha_course(name, points, start_date, end_date)" +
                    "VALUES (@name, @points, @startDate, @endDate)";
                connectionWithServer.Execute(createCourseListQuery, new { name, points, startDate, endDate });
                //connectionWithServer.Close();

            }
        }

        public static void ChangePassword()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("Do you want change your Password.");
                Console.WriteLine("Please select the name.");

                var listOfStudents = connectionWithServer.Query<Student>($" SELECT * FROM kha_student", new DynamicParameters());

                foreach (var list in ReadStudentFromDataBase())
                {
                    Console.WriteLine("First Name: {0}|  Last Name: {1}|   Email: {2}|", list.first_name, list.last_name, list.email);
                }

                //Console.WriteLine("Write your Email Address.");
                //string eMail = Console.ReadLine().ToLower();

                Console.WriteLine("Write Your PassWord");
                int passWord = int.Parse(Console.ReadLine());

                int count = 0;
                foreach (var student in listOfStudents)
                {
                    if (student.password == passWord)
                    {
                        Console.WriteLine("PassWord is Right.");
                        count++;
                    }
                    
                }
                
                Console.WriteLine("Please put New Password");
                int newPassWord = int.Parse(Console.ReadLine());


                string changePasswordQuery = "UPDATE kha_student SET password = newPassWord WHERE newPassWord = password";
                   
                connectionWithServer.Execute(changePasswordQuery, new { newPassWord });


                Console.ReadKey();

            }
        }

        public static void EditCourse()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");
                Console.WriteLine("Which course would you like to change? Please put the serial Number");

                var listOfCourses = connectionWithServer.Query<Course>($"SELECT * FROM kha_course", new DynamicParameters());

                foreach (var item in listOfCourses)
                {
                    Console.WriteLine("ID : {0}  |  Name: {1}| ", item.id, item.name);
                }



            }
        }

        public static void DeleteCourse()
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
