using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    internal class FineManager
    {
        private List<Fine> fines = new List<Fine>();

        public void AddFine(Fine fine)
        {
            fines.Add(fine);
        }

        public List<Fine> GetAllFines()
        {
            return fines;
        }

        public List<Fine> GetFinesByStudent(Student student)
        {
            return fines.FindAll(fine => fine.Student == student);
        }

        public void RemoveFine(Fine fine)
        {
            fines.Remove(fine);
        }
    }
}
