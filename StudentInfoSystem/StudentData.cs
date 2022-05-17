using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public static class StudentData
    {
        static private List<Student> testStudents;
        static public List<Student> TestStudents
        {
            get
            {
                if (testStudents == null)
                {
                    testStudents = new List<Student>();

                    Student student = new Student("Petur", "Ivanov", "Petrov", "FCST", "CSE", "Bachelor", "Assured",
                        "121219099",3, 9, 30);

                    testStudents.Add(student);
                }
                
                return testStudents;
            }

            set { }
        }
        public static bool IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student result = context.Students.SingleOrDefault(s => s.facultyNumber == facNum);
            return result != null;
        }
    }
}
