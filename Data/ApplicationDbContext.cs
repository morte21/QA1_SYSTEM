using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Models;
using System.Reflection.Emit;

namespace QA1_SYSTEM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Consumables> Consumables { get; set; }
        public DbSet<Requestor> Requestor { get; set; }

        public DbSet<Purchasing> Purchasing { get; set; }


        public DbSet<Computers> Computers { get; set; }
        public DbSet<ComputerHistory> ComputerHistory { get; set; }
        public DbSet<FixedAssetPC> FixedAssetPC { get; set; }



        public DbSet<EquipmentMachine> EquipmentMachine { get; set; }
        public DbSet<EquipmentMachineHistory> EquipmentMachineHistory { get; set; }
        public DbSet<FixedAssetEQP> FixedAssetEQP { get; set; }


        public DbSet<ItemRequest> ItemRequest { get; set; }


    }
}
