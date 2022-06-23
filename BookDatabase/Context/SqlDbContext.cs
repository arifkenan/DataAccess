using BookDatabase.Model.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Context
{
    public class SqlDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Kitaplik;Trusted_Connection=true;");
        }


    }
}
