using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notepad.Domain.NoteCategories;
using Notepad.EntityFramework.EntityFrameworkCore.Seeder;

namespace Notepad.EntityFramework.EntityFrameworkCore.Configurations
{
    public class NoteCategoryConfigurations: IEntityTypeConfiguration<NoteCategory>
    {
        #region Implementation of IEntityTypeConfiguration<NoteCategory>

        public void Configure(EntityTypeBuilder<NoteCategory> builder)
        {
            #region Primary Keys

            builder.HasKey(c => c.Id);

            #endregion

            #region NoteCategoryTitle

            builder.Property(nc => nc.NoteCategoryTitle).IsRequired();

            #endregion

            #region NoteCategoryDescription

            builder.Property(nc => nc.NoteCategoryDescription);

            #endregion

            #region Table Name

            builder.ToTable("NoteCategories");

            #endregion

            #region Seeder

            builder.HasData(NoteCategorySeeder.Run());

            #endregion
        }

        #endregion
    }
}