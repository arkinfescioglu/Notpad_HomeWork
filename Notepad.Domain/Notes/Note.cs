using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Notepad.Domain.Base;
using Notepad.Domain.NoteCategories;
using Notepad.Domain.Notes.Consts;
using Notepad.Domain.Users;

namespace Notepad.Domain.Notes
{
    public class Note: EntityBase, IEntity
    {
        #region Properties

        [MaxLength(NoteLength.MaxTitle)]
        public string NoteTitle { get; set; }
        
        public string NoteContent { get; set; }

        public Guid UserId { get; set; }
        
        public Guid CategoryId { get; set; }

        #endregion

        #region Relations

        [ForeignKey("UserId")] public User User { get; set; }
        [ForeignKey("CategoryId")] public NoteCategory Category { get; set; }

        #endregion
    }
}