using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {

        public Student()
        {

        }

        public Student(string name,string password, string surname, string last_name, string faculty, string major, string degree, string status, string facultyNumber, int year, int flow, int group)
        {
            this.UserName = name;
            this.SecondName = surname;
            this.LastName = last_name;
            this.Faculty = faculty;
            this.Speciality = major;
            this.OKS = degree;
            this.Status = status;
            this.FacultyNumber = facultyNumber;
            this.Course = year;
            this.Potok = flow;
            this.Grupa = group;
            this.Password = password;
            //this.studStatus = studStatus;
            
        }

       

        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }

        public string SecondName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Faculty
        {
            get;
            set;
        }
        public string Speciality
        {
            get;
            set;
        }

        public string OKS
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
        public string studStatus
        {
            get;
            set;
        }

        public string FacultyNumber
        {
            get;
            set;
        }

        public int Course
        {
            get;
            set;
        }

        public int Potok
        {
            get;
            set;
        }

        public int Grupa
        {
            get;
            set;
        }
        public byte[] Photo 
        { 
            get; 
            set;        
        }
        public int StudentId 
        { 
            get; 
            set; 
        }
        public override string ToString() 
        { 
            return this.UserName.ToString(); 
        }
    }
}

