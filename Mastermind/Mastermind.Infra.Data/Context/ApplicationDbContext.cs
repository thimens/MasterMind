﻿using System.Data.Entity;
using Mastermind.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Mastermind.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Player> User { get; set; }
        public virtual DbSet<Guess> Guess { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }        
    }
}
