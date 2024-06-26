﻿using Microsoft.EntityFrameworkCore;
using ClientCreator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.DataAccess
{
    internal class AppDBContext : DbContext
    {
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.ClientContacts> ClientContacts { get; set; }
        public DbSet<Models.ClientPersonalInfo> ClientPersonalInfo { get; set; }
        public DbSet<Models.Training> Trainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Filename={PathDB.GetPath("ClientCreatorDB.db")}";
            optionsBuilder.UseSqlite("Server=.;Database=ClientCreatorDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Client>()
                .HasOne(c => c.Contacts)
                .WithOne(cc => cc.Client)
                .HasForeignKey<Models.ClientContacts>(cc => cc.ID);

            modelBuilder.Entity<Models.Client>()
                .HasOne(c => c.PersonalInfo)
                .WithOne(pi => pi.Client)
                .HasForeignKey<Models.ClientPersonalInfo>(pi => pi.ID);

            modelBuilder.Entity<Models.Client>()
                .HasMany(c => c.Trainings)
                .WithMany(t => t.Clients);

            modelBuilder.Entity<Models.ClientContacts>()
                .HasIndex(cc => cc.Email)
                .IsUnique();

            modelBuilder.Entity<Models.ClientContacts>()
                .HasIndex(cc => cc.Phone)
                .IsUnique();

            modelBuilder.Entity<Models.Training>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
