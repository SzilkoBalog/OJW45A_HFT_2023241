using System;
using Microsoft.EntityFrameworkCore;
using OJW45A_HFT_2023241.Models;

namespace OJW45A_HFT_2023241.Repository
{
    public class ArmyDbContext : DbContext
    {
        public DbSet<ArmyBase> Bases { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        public ArmyDbContext()
        {
            this.Database.EnsureCreated();                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                .UseInMemoryDatabase("DATABASE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soldier>(soldier => soldier
            .HasOne(soldier => soldier.ArmyBase)
            .WithMany(armyBase => armyBase.Soldiers)
            .HasForeignKey(soldier => soldier.ArmyBaseId)
            .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Equipment>(equipment => equipment
            .HasOne(equipment => equipment.Soldier)
            .WithMany(soldier => soldier.Equipment)
            .HasForeignKey(equipment => equipment.SoldierId)
            .OnDelete(DeleteBehavior.Cascade)
            );

            // Seed data for ArmyBase
            modelBuilder.Entity<ArmyBase>().HasData(
                new ArmyBase { Id = 1, Name = "Base Alpha", NumberOfBeds = 100, DateOfBuild = 2000 },
                new ArmyBase { Id = 2, Name = "Base Bravo", NumberOfBeds = 200, DateOfBuild = 2001 },
                new ArmyBase { Id = 3, Name = "Base Charlie", NumberOfBeds = 300, DateOfBuild = 2002 },
                new ArmyBase { Id = 4, Name = "Base Delta", NumberOfBeds = 400, DateOfBuild = 2003 },
                new ArmyBase { Id = 5, Name = "Base Echo", NumberOfBeds = 500, DateOfBuild = 2004 },
                new ArmyBase { Id = 6, Name = "Base Foxtrot", NumberOfBeds = 600, DateOfBuild = 2005 },
                new ArmyBase { Id = 7, Name = "Base Golf", NumberOfBeds = 700, DateOfBuild = 2006 },
                new ArmyBase { Id = 8, Name = "Base Hotel", NumberOfBeds = 800, DateOfBuild = 2007 },
                new ArmyBase { Id = 9, Name = "Base India", NumberOfBeds = 900, DateOfBuild = 2008 },
                new ArmyBase { Id = 10, Name = "Base Juliet", NumberOfBeds = 1000, DateOfBuild = 2009 }
            );

            // Seed data for Soldiers
            modelBuilder.Entity<Soldier>().HasData(
                new Soldier { Id = 1, Name = "John Smith", Age = 25, Weight = 70, ArmyBaseId = 1 },
                new Soldier { Id = 2, Name = "Emily Johnson", Age = 30, Weight = 65, ArmyBaseId = 2 },
                new Soldier { Id = 3, Name = "Michael Williams", Age = 27, Weight = 75, ArmyBaseId = 3 },
                new Soldier { Id = 4, Name = "Jessica Jones", Age = 28, Weight = 80, ArmyBaseId = 4 },
                new Soldier { Id = 5, Name = "William Brown", Age = 26, Weight = 85, ArmyBaseId = 5 },
                new Soldier { Id = 6, Name = "Sophia Davis", Age = 29, Weight = 90, ArmyBaseId = 6 },
                new Soldier { Id = 7, Name = "Alexander Miller", Age = 24, Weight = 95, ArmyBaseId = 7 },
                new Soldier { Id = 8, Name = "Olivia Wilson", Age = 31, Weight = 72, ArmyBaseId = 8 },
                new Soldier { Id = 9, Name = "Daniel Moore", Age = 32, Weight = 82, ArmyBaseId = 9 },
                new Soldier { Id = 10, Name = "Isabella Taylor", Age = 23, Weight = 68, ArmyBaseId = 10 }
            );

            // Seed data for Equipment
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Type = "Weapon", Description = "Standard issue rifle", Weight = 6, SoldierId = 1 },
                new Equipment { Id = 2, Type = "Gear", Description = "Night vision goggles", Weight = 4, SoldierId = 2 },
                new Equipment { Id = 3, Type = "Weapon", Description = "Sniper rifle", Weight = 8, SoldierId = 3 },
                new Equipment { Id = 4, Type = "Gear", Description = "Tactical vest", Weight = 5, SoldierId = 4 },
                new Equipment { Id = 5, Type = "Weapon", Description = "Submachine gun", Weight = 7, SoldierId = 5 },
                new Equipment { Id = 6, Type = "Gear", Description = "Camouflage uniform", Weight = 3, SoldierId = 6 },
                new Equipment { Id = 7, Type = "Weapon", Description = "Assault rifle", Weight = 9, SoldierId = 7 },
                new Equipment { Id = 8, Type = "Gear", Description = "Protective helmet", Weight = 2, SoldierId = 8 },
                new Equipment { Id = 9, Type = "Weapon", Description = "Pistol", Weight = 4, SoldierId = 9 },
                new Equipment { Id = 10, Type = "Gear", Description = "First aid kit", Weight = 1, SoldierId = 10 }
            );
        }
    }
}
