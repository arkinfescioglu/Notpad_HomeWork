using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Notepad.Domain.Base;
using Notepad.Domain.NoteCategories.Consts;
using Notepad.Domain.Notes;

namespace Notepad.Domain.NoteCategories
{
    [Table("NoteCategories", Schema = "dbo")]
    public class NoteCategory: EntityBase, IEntity
    {
        #region Properties

        [MaxLength(NoteCategoryLength.MaxTitle)]
        public string NoteCategoryTitle       { get; set; }
        
        [MaxLength(NoteCategoryLength.MaxDescription)]
        public string NoteCategoryDescription { get; set; }
        
        #endregion

        #region Relations

        //Relation ismi verdim çünkü EfContext sorun çıkartıyor
        public List<Note> NoteRelation { get; set; }

        #endregion
    }
}