using Assignment2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Context
{
    public class HotelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=HotelManagementDB;Integrated Security=true;Encrypt=false;");

        public virtual DbSet<Entities.KitchenEntity> KitchenUsers { get; set; }
        public virtual DbSet<FrontEndEntity> FrontendUsers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .Property(r => r.Id)
                .UseIdentityColumn(1011, 1);
        }
    }
}
