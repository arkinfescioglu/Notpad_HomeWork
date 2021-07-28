using Notepad.Domain.Base.Dto;

namespace Notepad.Service.NoteCategories.Dtos.Outputs
{
    public class NoteCategoryListOutDto: DtoOutBase
    {
        public string NoteCategoryTitle       { get; set; }
        public string NoteCategoryDescription { get; set; }
    }
}