﻿// <auto-generated />
using DonkeyClassLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DonkeyClassLib.Migrations
{
    [DbContext(typeof(DonkeyContext))]
    [Migration("20201201224310_Db-Create")]
    partial class DbCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("DonkeyClassLib.ModelDonkeyData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Angle");

                    b.Property<double>("Throttle");

                    b.Property<ulong>("TimeStamp");

                    b.HasKey("ID");

                    b.ToTable("Donkeys");
                });
#pragma warning restore 612, 618
        }
    }
}
