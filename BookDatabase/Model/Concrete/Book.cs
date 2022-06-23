using BookDatabase.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Model.Concrete
{
    
        public enum Tur
        {
            Roman,
            Siir,
            Ani,
            Deneme,
            Hikaye,
            Tarih
        }

        public class Book : BaseEntity
    {
        public int Id { get; set; }
        public string? bookName { get; set; }
        
        //public int? writerId { get; set; }
        public string? writerName { get; set; }
        public string? genre { get; set; }
        
    }
}
