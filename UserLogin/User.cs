using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string password, string facultyNumber, UserRoles rolee)
        {
            Username = username;
            Password = password;
            FacNum = facultyNumber;
            role = rolee;
            Created = DateTime.Now;
            ValidDate = DateTime.MaxValue;
           
        }

        public User(string username, string password, string facultyNumber, UserRoles rolee, DateTime creationDate, DateTime validDate)
        {
            Username = username;
            Password = password;
            FacNum = facultyNumber;
            role = rolee;
            Created = creationDate;
            ValidDate = validDate;
        }
        public DbSet<User> Users { get; set; }
        public DateTime Created { get; set; }
        public DateTime ValidDate { get; set; }
        public string Username 
            { get; set; }
        public string Password 
            { get; set; }
        public string FacNum 
            { get; set; }
        public UserRoles role 
            { get; set; }
        public System.DateTime? ActiveTo 
        { get; set; }
        public Int32 UserId 
        { get; set; }

    }

}

