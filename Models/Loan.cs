using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    internal class Loan
    {
        public Book Book { get; set; }
        public Student Student { get; set; }
        public DateTime DueDate { get; set; }
        
    }    
}
