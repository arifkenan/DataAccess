using BookDatabase.Model.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Context
{
    internal class PostgreDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Database=Kitaplik;Userid=postgres;Password=123");
            
        }

    }
}
