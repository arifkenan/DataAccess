﻿using CRUD_Operation.Model.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operation.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.;Database=Sample1;Trusted_Connection=true;");



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasQueryFilter(p => p.Status != CRUD_Operation.Model.Abstract.Status.Passive);
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.Status != CRUD_Operation.Model.Abstract.Status.Passive);
            base.OnModelCreating(modelBuilder);
        }
    }
}
