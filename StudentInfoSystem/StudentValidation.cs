using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student getStudentDataByUser(UserLogin.User user) 
        {
            if (user.FacNum.Equals(""))
            {
                Console.WriteLine("Faculty number required!");
            }

            List<Student> students = StudentData.TestStudents;

            Student student = (from s in students where s.FacultyNumber.Equals(user.FacNum) select s).FirstOrDefault();

            if (student == null)
            {
                Console.WriteLine("There is no student with this fac. number");
                return null;
            }

            return student;
        }
    }
}
