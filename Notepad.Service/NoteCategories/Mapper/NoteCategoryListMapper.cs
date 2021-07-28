using AutoMapper;
using Notepad.Domain.NoteCategories;
using Notepad.Service.NoteCategories.Dtos.Outputs;

namespace Notepad.Service.NoteCategories.Mapper
{
    public class NoteCategoryListMapper: Profile
    {
        #region Profile Name

        public override string ProfileName
        {
            get { return "NoteCategoryListMappings"; }
        }

        #endregion

        #region Construct

        public NoteCategoryListMapper()
        {
            ConfigureMapper();
        }

        #endregion
        
        #region Mapper

        private void ConfigureMapper()
        {
            CreateMap<NoteCategoryListOutDto, NoteCategory>();
            CreateMap<NoteCategory, NoteCategoryListOutDto>().ReverseMap();
        }

        #endregion
    }
}