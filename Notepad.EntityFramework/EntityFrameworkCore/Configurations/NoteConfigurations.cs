using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notepad.Domain.NoteCategories;
using Notepad.Domain.Notes;
using Notepad.Domain.Notes.Consts;
using Notepad.Domain.Users;

namespace Notepad.EntityFramework.EntityFrameworkCore.Configurations
{
    public class NoteConfigurations: IEntityTypeConfiguration<Note>
    {
        #region Implementation of IEntityTypeConfiguration<Note>

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            #region Primary Keys

            builder.HasKey(c => c.Id);

            #endregion

            #region NoteTitle

            builder.Property(n => n.NoteTitle)
                   .IsRequired()
                   .HasMaxLength(NoteLength.MaxTitle);

            #endregion

            #region NoteContent

            builder.Property(n => n.NoteContent)
                   .IsRequired()
                   .HasColumnType(NoteColumnTypes.NoteContent);

            #endregion

            #region Relations

            builder.HasOne<NoteCategory>(n => n.Category)
                   .WithMany(nc => nc.NoteRelation)
                   .HasForeignKey(n => n.CategoryId);

            builder.HasOne<User>(n => n.User)
                   .WithMany(nc => nc.NoteRelation)
                   .HasForeignKey(n => n.UserId);

            #endregion

            #region TableName

            builder.ToTable("Notes");

            #endregion
        }

        #endregion
    }
}