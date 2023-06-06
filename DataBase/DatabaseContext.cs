using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using OldTechApp.Models;

namespace OldTechApp.DataBase
{
    [DbConfigurationType(typeof(DatabaseConfiguration))]
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base("DbConnection") { }
          
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dweller>()
                .Property(p => p.Version)
                .HasColumnName("xmin")
                .HasColumnType("text")
                .IsConcurrencyToken()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Dweller> Dwellers { get; set; }
    }
}