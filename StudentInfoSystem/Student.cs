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

        public Student(string name, string surname, string last_name, string faculty, string major, string degree, string status, string facultyNumber, int year, int flow, int group)
        {
            this.name = name;
            this.surname = surname;
            this.last_name = last_name;
            this.faculty = faculty;
            this.major = major;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.year = year;
            this.flow = flow;
            this.group = group;
            this.studStatus = studStatus;
            
        }

        public DbSet<Student> Students { get; set; }

        public string name
        {
            get;
            set;
        }

        public string surname
        {
            get;
            set;
        }

        public string last_name
        {
            get;
            set;
        }

        public string faculty
        {
            get;
            set;
        }
        public string major
        {
            get;
            set;
        }

        public string degree
        {
            get;
            set;
        }

        public string status
        {
            get;
            set;
        }
        public string studStatus
        {
            get;
            set;
        }

        public string facultyNumber
        {
            get;
            set;
        }

        public int year
        {
            get;
            set;
        }

        public int flow
        {
            get;
            set;
        }

        public int group
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
            return this.name; 
        }
    }
}

