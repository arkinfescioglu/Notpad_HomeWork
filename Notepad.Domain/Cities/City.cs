using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Notepad.Domain.Base;
using Notepad.Domain.Users;

namespace Notepad.Domain.Cities
{
    [Table("Cities", Schema = "dbo")]
    public class City: EntityBase, IEntity
    {
        #region Properties

        public string CityName { get; set; }
        
        #endregion

        #region Relation Ships

        public List<User> UserRelation { get; set; }

        #endregion
    }
}