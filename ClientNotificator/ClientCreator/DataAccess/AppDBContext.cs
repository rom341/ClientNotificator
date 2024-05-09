﻿using Microsoft.EntityFrameworkCore;
using ClientCreator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.DataAccess
{
    public class AppDBContext : DbContext
    {
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.ClientContacts> ClientContacts { get; set; }
        public DbSet<Models.ClientPersonalInfo> ClientPersonalInfo { get; set; }
        public DbSet<Models.Service> Trainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Filename={PathDB.GetPath("Clients_temp2.db")}";
            optionsBuilder.UseSqlite(connectionString);
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
                .HasMany(c => c.SubscribedServices)
                .WithMany(t => t.Clients);

            modelBuilder.Entity<Models.ClientContacts>()
                .HasIndex(cc => cc.EmailAddress)
                .IsUnique();

            modelBuilder.Entity<Models.ClientContacts>()
                .HasIndex(cc => cc.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Models.Service>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
