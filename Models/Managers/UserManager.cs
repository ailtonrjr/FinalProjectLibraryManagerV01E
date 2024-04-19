using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    public static class UserManager
    {
        public static List<Student> students = new List<Student>()
        {
            new Student {Name="Lucas Munhoz", ID=1},
            new Student {Name="Angelo Pires", ID=2},
            new Student {Name="Arya Perbhaker", ID=3},
            new Student {Name="Ailton Junior", ID=4},
            new Student {Name="Mazanza Alberto", ID=5},
            new Student{Name="John Doe", ID=123456789}

        };

        public static Student IstheUserRegistered(string name)
        {
            return students.FirstOrDefault(student => student.Name == name);
        }

    }
}
