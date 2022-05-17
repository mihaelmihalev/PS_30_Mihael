using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class UserData
    {
       static private List<User> _testUsers;
       static public List<User> TestUsers
        {
            get 
            {
                ResetTestUserData();
                return _testUsers;
            }   
            set {}
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            ResetTestUserData();

            User testUser = (from user in _testUsers where user.Username.Equals(username) && user.Password.Equals(password) select user).FirstOrDefault();

            if (testUser == null)
            {
                return null;
            }

            return testUser;
        }

        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>
                {
                new User("Mihael", "12345", "121219046", UserRoles.ADMIN), 
                new User("Petur", "123456", "121219037", UserRoles.STUDENT), 
                new User("Nikolai", "12345678", "121219048", UserRoles.STUDENT)
                };
            }

        }

        public static void SetUserActiveTo(string username, DateTime date)
        {
            foreach (var testUser in _testUsers)
                if (testUser.Username == username)
                {
                    testUser.ValidDate = date;
                    Logger.LogActivity("Changed active date for " + username + " to " + date);
                    return;
                }

        }


        public static void AssignUserRole(string username, UserRoles role)
        {
            foreach (var user in _testUsers)
                if (user.Username == username)
                {
                    user.role = role;
                    Logger.LogActivity("Changed role for " + username + " to " + role);
                    return;
                }
           
        }
        public static void ListUsers()
        {
            foreach (var user in _testUsers)
                Console.WriteLine("{0} {1};",user.Username,user.FacNum);
                
                
        }
    }
}



    

