using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserLogin
{
    public class Program
    {
        private static void ActionOnError(string errorMsg)
        {
            Console.WriteLine("!!!!!!");
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(UserData.TestUser.Username);
            //Console.WriteLine(UserData.TestUser.Password);
            //Console.WriteLine(UserData.TestUser.FakNum);
            //Console.WriteLine(UserData.TestUser.role);
            //Console.WriteLine(LoginValidation.currentUserRole);
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password");
            string password = Console.ReadLine();
            var loginValidation = new LoginValidation(username, password, ActionOnError);
            var user = new User();
            loginValidation.ValidateUserInput(ref user);
            Console.WriteLine(user.Username);
            Console.WriteLine(user.FacNum);          
            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.ADMIN:
                    {
                        DoAdmin();
                        break;
                    }
                case UserRoles.ANONYMOUS:
                    {
                        Console.WriteLine("Welcome, ANONYMOUS!");
                        break;
                    }
                case UserRoles.INSPECTOR:
                    {
                        Console.WriteLine("Hello, INSPECTOR!");
                        break;
                    }
                case UserRoles.PROFESSOR:
                    {
                        Console.WriteLine("DEAR, PROFESSOR!");
                        break;
                    }
                case UserRoles.STUDENT:
                    {
                        Console.WriteLine("HI, STUDENT!");
                        break;
                    }
            }
  
        }

        private static void DoAdmin()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change user role");
                Console.WriteLine("2: Change user active date");
                Console.WriteLine("3: List users");
                Console.WriteLine("4: Print log file");
                Console.WriteLine("5: Print current log session");
                int value = Convert.ToInt16(Console.ReadLine());
                switch (value)
                {
                    case 0:
                        return;
                    case 1:
                        ChangeRole();
                        break;
                    case 2:
                        ChangeActiveDate();
                        break;
                    case 3:
                        UserData.ListUsers();
                        break;
                    case 4:
                        List<string> fullLog = Logger.ReadFullLog().ToList();
                        foreach (string log in fullLog)
                        {
                            Console.WriteLine(log);
                        }
                        break;
                    case 5:
                        Logger.ReadCurrentLog();
                        break;
                   
                }
            }
        }

        private static void ChangeRole()
        {
            Console.WriteLine("Select username: ");
            var username = Console.ReadLine();
            var roles = new[] { UserRoles.ADMIN, UserRoles.INSPECTOR, UserRoles.PROFESSOR, UserRoles.STUDENT };
            for (var i = 0; i < roles.Length; i++)
                Console.WriteLine(i + ": " + roles[i]);
            Console.WriteLine("Select new role: ");
            var role = Convert.ToInt32(Console.ReadLine());
            UserData.AssignUserRole(username, roles[role]);
        }
        private static void ChangeActiveDate()
        {
            Console.WriteLine("Select username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Format: dd.MM.yyyy hh:mm:ss");
            Console.WriteLine("Type date: ");
            UserData.SetUserActiveTo(username, DateTime.Parse(Console.ReadLine()));
        }
    }
}

    
    
