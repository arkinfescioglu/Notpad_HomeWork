using System;
using Taikandi;

namespace Notepad.Domain.Base
{
    public class EntityBase
    {
        #region Properties

        public virtual Guid Id { get; set; } = SequentialGuid.NewGuid();

        
        public virtual DateTime CreatedDate { get; set; } =
            DateTime.Now;

        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        #endregion
    }
}