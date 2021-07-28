using System;
using AutoMapper;
using Notepad.Domain.Notes;
using Notepad.Service.Notes.Dtos.Inputs;
using Notepad.Utilities.Helpers;
using Taikandi;

namespace Notepad.Service.Notes.Mapper
{
    public class NoteUpdateMapper: Profile
    {
        #region Profile Name

        public override string ProfileName
        {
            get { return "NoteUpdateMappings"; }
        }

        #endregion

        #region Construct

        public NoteUpdateMapper()
        {
            ConfigureMapper();
        }

        #endregion
        
        #region Mapper

        private void ConfigureMapper()
        {
            CreateMap<NoteUpdateInputDto, Note>()
                    .ForMember(
                            dest => dest.NoteTitle,
                            memb => 
                                    memb.MapFrom(x => Helpers.CleanHtml(x.NoteTitle))
                    )
                    .ForMember(
                            dest => dest.NoteContent,
                            memb => 
                                    memb.MapFrom(x => x.NoteContent)
                    )
                    .ForMember(
                            dest => dest.ModifiedDate,
                            memb => 
                                    memb.MapFrom(x => DateTime.Now)
                    )
                    .ForMember(
                            dest => dest.CategoryId,
                            memb => 
                                    memb.MapFrom(x => x.CategoryId)
                    );
        }

        #endregion
    }
}