using AutoMapper;
using Notepad.Domain.Notes;
using Notepad.Service.Notes.Dtos.Outputs;

namespace Notepad.Service.Notes.Mapper
{
    public class NoteOutMapper: Profile
    {
        #region Profile Name

        public override string ProfileName
        {
            get { return "NoteOutMappings"; }
        }

        #endregion

        #region Construct

        public NoteOutMapper()
        {
            ConfigureMapper();
        }

        #endregion
        
        #region Mapper

        private void ConfigureMapper()
        {
            CreateMap<NoteInfoOutDto, Note>();
            CreateMap<Note, NoteInfoOutDto>().ReverseMap();
        }

        #endregion
    }
}