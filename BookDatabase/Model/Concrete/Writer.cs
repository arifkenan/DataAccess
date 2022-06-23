using BookDatabase.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Model.Concrete
{
    public class Writer:BaseEntity
    {
        public int Id { get; set; }
        //[MaxLength(50)]
        //public string? Name { get; set; }
        //[MaxLength(50)]
        //public string? LastName { get; set; }
        //public bool? Gender { get; set; }
        //public DateTime? Birthday { get; set; }
        //public List<Book>? Books { get; set; }
        //public DateTime? CreateDate { get; set; }

    }
}
