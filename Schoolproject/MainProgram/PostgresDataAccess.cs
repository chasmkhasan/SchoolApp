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

        public static List<Course> ReadCourseList() 
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Course List.");

                var listOfCourses = connectionWithServer.Query<Course>($" SELECT * FROM kha_course", new DynamicParameters());
                return listOfCourses.ToList();
            }
        }

        public static void PrintCourseList() 
        {

            foreach (var item in ReadCourseList())
            {
                Console.WriteLine("ID : {0}  |  Name: {1}|  Points: {2}|   Start Date: {3}|    End Date: {4}", item.id, item.name, item.points, item.start_date, item.end_date);
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

        public static void CreateCourse()
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

                Console.WriteLine("When it is going to start(Please use this formate YYYY-Month-Date)");
                //DateTime startDate = DateTime.Parse(Console.ReadLine());
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("When going to finish(Please use this formate YYYY-Month-Date).");
                //DateTime endDate = DateTime.Parse(Console.ReadLine());
                DateTime endDate = Convert.ToDateTime(Console.ReadLine());

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

                Console.WriteLine("Write your Email Address.");
                string eMail = Console.ReadLine().ToLower();

                Console.WriteLine("Write Your old PassWord");
                int passWord = int.Parse(Console.ReadLine());

                int count = 0;
                foreach (var student in listOfStudents)
                {
                    if (student.password == passWord && student.email == eMail)
                    {
                        Console.WriteLine("You have permission to go foreward.");
                        count++;
                    }
                }
                
                Console.WriteLine("Please put New Password");
                int newPassWord = int.Parse(Console.ReadLine());

                string changePasswordQuery = "UPDATE kha_student SET password = @newPassWord where email = @eMail";
                   
                connectionWithServer.Execute(changePasswordQuery, new { newPassWord, eMail });

                Console.ReadKey();
            }
        }

        public static void EditCourse()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");

                var editListOfCourses = connectionWithServer.Query<Course>($" SELECT * FROM kha_course", new DynamicParameters());

                foreach (var item in editListOfCourses)
                {
                    Console.WriteLine("ID : {0}  |  Name: {1}| ", item.id, item.name);
                }

                Console.WriteLine("Write the ID number");
                int inputId = int.Parse(Console.ReadLine());

                Console.WriteLine("Which course would you like to chnage?");
                string courseName = Console.ReadLine().ToUpper();

                //int count = 0;
                foreach (var list in editListOfCourses)
                {
                    if (list.name == courseName && list.id == inputId)
                    {
                        Console.WriteLine("Perfect!");
                        //count++;
                    }
                }

                Console.WriteLine("Write the new name of the course.");
                string newCourseName = Console.ReadLine().ToUpper();

                string changePasswordQuery = "UPDATE kha_course SET name = @newCourseName where id = @inputId";

                connectionWithServer.Execute(changePasswordQuery, new { newCourseName, inputId });

                Console.ReadKey();
            }
        }

        public static void DeleteCourse()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                Console.WriteLine("WelCome to Khan School's Student List.");
                
                var listOfCourses = connectionWithServer.Query<Course>($"SELECT * FROM kha_course", new DynamicParameters());

                foreach (var item in listOfCourses)
                {
                    Console.WriteLine("ID : {0}  |  Name: {1}| ", item.id, item.name);
                }

                Console.WriteLine("Write the ID number");
                int inputId = int.Parse(Console.ReadLine());

                Console.WriteLine("Which course would you like to Delete?");
                string deletedCourseName = Console.ReadLine().ToUpper();

                //int count = 0;
                foreach (var list in listOfCourses)
                {
                    if (list.name == deletedCourseName && list.id == inputId)
                    {
                        Console.WriteLine("Perfect!");
                        //count++;
                    }
                }

                string changePasswordQuery = "DELETE FROM kha_course WHERE name = @deletedCourseName";

                connectionWithServer.Execute(changePasswordQuery, new { deletedCourseName });

                Console.ReadKey();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
