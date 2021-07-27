using Microsoft.EntityFrameworkCore;
using Notepad.Domain.Cities;
using Notepad.Domain.NoteCategories;
using Notepad.Domain.Notes;
using Notepad.Domain.Users;
using Notepad.EntityFramework.EntityFrameworkCore.Configurations;
using Notepad.Utilities.Config;

namespace Notepad.EntityFramework.EntityFrameworkCore.Contexts
{
    public class EfContext : DbContext
    {
        #region DbSet Variables

        public DbSet<City>         Cities          { get; set; }
        public DbSet<User>         Users          { get; set; }
        public DbSet<Note>         Notes          { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }

        #endregion

        #region Db Connection Config

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfig.ConnectionString);
        }

        #endregion

        #region On Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfigurations());
            modelBuilder.ApplyConfiguration(new NoteCategoryConfigurations());
            modelBuilder.ApplyConfiguration(new NoteConfigurations());
        }

        #endregion
    }
}