using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notepad.Domain.Cities;
using Notepad.EntityFramework.EntityFrameworkCore.Seeder;

namespace Notepad.EntityFramework.EntityFrameworkCore.Configurations
{
    public class CityConfigurations: IEntityTypeConfiguration<City>
    {
        #region Implementation of IEntityTypeConfiguration<City>

        public void Configure(EntityTypeBuilder<City> builder)
        {
            #region Primary Keys

            builder.HasKey(c => c.Id);

            #endregion

            #region City Name

            builder.Property(c => c.CityName).IsRequired();

            #endregion

            #region Created & Modifies Date

            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();

            #endregion

            #region Table Name

            builder.ToTable("Cities");

            #endregion

            #region Seeder

            builder.HasData(CitySeeder.Run());

            #endregion
        }

        #endregion
    }
}