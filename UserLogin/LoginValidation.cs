using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public  class LoginValidation
    {
        private string username { get; set; }
        private string password { get; set; }
        private string errorText { get; set; }
        private ActionOnError errorAction;



        public delegate void ActionOnError(string errorMsg);


        public  LoginValidation(string Username, string Password, ActionOnError ErrorAction)
        {
            username = Username;
            password = Password;
            errorAction = ErrorAction;

        }

        static public UserRoles currentUserRole
            { get;private set; }
        static public User currentUsername
        { get; set; }
        public bool ValidateUserInput(ref User TestUser)
       {
            if (username == null || username.Equals(string.Empty) || username.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorText = "Invalid username.";
                errorAction(errorText);
                return false;
            }

            if (password == null || password.Equals(string.Empty) || password.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorText = "Invalid password.";
                errorAction(errorText);
                return false;
            }
            TestUser = UserData.IsUserPassCorrect(username, password);
            if (TestUser == null)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorText = "Invalid username/password.";
                errorAction(errorText);
                return false;
            }
            currentUserRole = TestUser.role;
            Console.WriteLine("Successful login");         
            return true;
        }

        
           
       }
    }


