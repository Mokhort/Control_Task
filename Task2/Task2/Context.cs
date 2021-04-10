using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Task2
{
    class Context : DbContext
    {
        public DbSet<Info> Info { get; set; }
        public DbSet<Type_animal> Type_animal { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-BV1FJHR6;Database=Farm;Trusted_Connection=True;");
        }
    }
}
