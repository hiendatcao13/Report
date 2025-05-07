using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public string Major { get; set; }
        public int? LopId { get; set; }
        public Lop? Lop { get; set; }
        public Student() { }
        public Student(int id, string name, double gPA, string major, int? LopId)
        {
            Id = id;
            Name = name;
            GPA = gPA;
            Major = major;
            this.LopId = LopId;
        }
        public Student(int id, string name, double gPA, string major, int? LopId, Lop? lop)
        {
            Id = id;
            Name = name;
            GPA = gPA;
            Major = major;
            this.LopId = LopId;
            Lop = lop;
        }
    }
}
