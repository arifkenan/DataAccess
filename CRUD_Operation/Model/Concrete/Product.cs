using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Operation.Model.Abstract;

namespace CRUD_Operation.Model.Concrete
{
    public class Product : BaseEntitity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        //Database yansıyacak olan alan
        public int CategoryId { get; set; }

        //Navigasyon Property olarak kullanılacak
        public Category Category { get; set; }

        //Navigasyon property olarak kullanılacak
        //Burası database'de herhangi bir field alanı olarak tutulmaz
       



    }
}
