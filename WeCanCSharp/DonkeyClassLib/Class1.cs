using Microsoft.EntityFrameworkCore;
using System;

namespace DonkeyClassLib
{
    public class DonkeyContext : DbContext
    {
        public DbSet<ModelDonkeyData> Donkeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlite("Data Source = donkey.db");
        }
    }
    public class ModelDonkeyData
    {
        public int ID { get; set; }
        public double Angle { get; set; }
        public double Throttle { get; set; }
        public UInt64 TimeStamp { get; set; }
    }
}
