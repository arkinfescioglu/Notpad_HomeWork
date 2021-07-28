using System;
using AutoMapper;
using Notepad.Domain.Notes;
using Notepad.Service.Notes.Dtos.Inputs;
using Notepad.Utilities.Helpers;
using Taikandi;

namespace Notepad.Service.Notes.Mapper
{
    public class NoteCreateMapper: Profile
    {
        #region Profile Name

        public override string ProfileName
        {
            get { return "NoteCreateMappings"; }
        }

        #endregion

        #region Construct

        public NoteCreateMapper()
        {
            ConfigureMapper();
        }

        #endregion
        
        #region Mapper

        private void ConfigureMapper()
        {
            CreateMap<NoteCreateInputDto, Note>()
                    .ForMember(
                            dest => dest.Id,
                            memb =>
                                    memb.MapFrom(x => SequentialGuid.NewGuid())
                    )
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
                            dest => dest.CreatedDate,
                            memb => 
                                    memb.MapFrom(x => DateTime.Now)
                    )
                    .ForMember(
                            dest => dest.CategoryId,
                            memb => 
                                    memb.MapFrom(x => x.CategoryId)
                    )
                    .ForMember(
                            dest => dest.UserId,
                            memb => 
                                    memb.MapFrom(x => x.UserId)
                    );
        }

        #endregion
    }
}