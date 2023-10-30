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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TemporaryDb.mdf;Integrated Security=True;MultipleActiveResultSets = True";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);
                //.UseInMemoryDatabase("DATABASE");
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
        }
    }
}
