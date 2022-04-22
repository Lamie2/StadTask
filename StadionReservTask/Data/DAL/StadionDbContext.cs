using Microsoft.EntityFrameworkCore;
using StadionReservTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StadionReservTask.Data.DAL
{
    class StadionDbContext:DbContext
    {
        public DbSet<Stadion> Stadions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2VCD5FN;Database=StadionReserv;Trusted_Connection=TRUE;")
        }
    }
}
