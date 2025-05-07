using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Lop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public virtual List<Student> Students { get; set; } = null!;
        public Lop(int id, string name, string major)
        {
            Id = id;
            Name = name;
            Major = major;
            Students = new List<Student>();
        }
    }
}
