using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext
    {
        // hangi veritabanına bağlanacağı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //@ işareti \ işaretini farklı algılamaması için : adresi : hangi veritabanı olacağı: kullanıcı adı ve şifre gerektirmeden giriş yababilmek için                     
            optionsBuilder.UseSqlServer(@"Server =(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //hangi class hangi tabloya karşılık geliyor onu belirliyor
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
