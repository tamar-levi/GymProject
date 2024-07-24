using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public virtual DbSet<FitnessMachines> FitnessMachines { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Guide> Guides { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-L1QQEC3\\SQLEXPRESS;Database=Gyme;trusted_Connection=True;MultipleActiveResultSets=true",
                    b => b.MigrationsAssembly("MODELS"));
            }
        }
        //to define uniq mail every user
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.mail)
                .IsUnique();
        }

    }

   

}

