using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=blogging.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GarageDoorModel>().ToTable("GarageDoorModels");
            modelBuilder.Entity<Section>().ToTable("Sections");
        }
    
        public DbSet<GarageDoorModel> GarageDoorModels { get; set; }
        public DbSet<Section> Sections { get; set; }
    }

    public class GarageDoorModel
    {
        public int GarageDoorModelId { get; set; }
        public string ModelName { get; set; }
        public string WindCode { get; set; }
        public string Layout { get; set; }
        
        public ICollection<Section> Sections { get; set; }
    }

    public class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string Key { get; set; }
        
        public ICollection<GarageDoorModel> GarageDoorModels { get; set; }
    }
    
}
