using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonkeyDBMigrations;

namespace DonkeyDBMigrations
{
    class DonkeyContext:DbContext
    {
        public DbSet<ModelDonkeyData> Donkeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlite("Data Source = donkey.db");
        }
    }

}
