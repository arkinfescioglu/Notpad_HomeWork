using System;
using AutoMapper;
using Notepad.Domain.Users;
using Notepad.Service.Users.Dtos.Inputs;
using Notepad.Utilities.Helpers;
using Taikandi;

namespace Notepad.Service.Users.Mapper
{
    public class UserCreateMapper : Profile
    {
        #region Profile Name

        public override string ProfileName
        {
            get { return "UserCreateMappings"; }
        }

        #endregion

        #region Construct

        public UserCreateMapper()
        {
            ConfigureMapper();
        }

        #endregion

        #region Mapper

        private void ConfigureMapper()
        {
            CreateMap<UserCreateInputDto, User>()
                    .ForMember(
                            dest => dest.Id,
                            memb =>
                                    memb.MapFrom(x => SequentialGuid.NewGuid())
                    )
                    .ForMember(
                                    dest => dest.Slug,
                                    memb => 
                                                    memb.MapFrom(x => Helpers.CreateSlug(x.Username))
                    )
                    .ForMember(
                            dest => dest.CreatedDate,
                            memb =>
                                    memb.MapFrom(x => DateTime.Now))
                    .ForMember(
                            dest => dest.Email,
                            memb =>
                                    memb.MapFrom(x => Helpers.CleanHtml(x.Email))
                    )
                    .ForMember(
                            dest => dest.Username,
                            memb =>
                                    memb.MapFrom(x => Helpers.CleanHtml(x.Username))
                    )
                    .ForMember(
                            dest => dest.Password,
                            memb =>
                                    memb.MapFrom(x => Helpers.MakeHash(x.Password))
                    )
                    .ForMember(
                            dest => dest.FirstName,
                            memb =>
                                    memb.MapFrom(x => Helpers.CleanHtml(x.FirstName))
                    )
                    .ForMember(
                            dest => dest.LastName,
                            memb =>
                                    memb.MapFrom(x => Helpers.CleanHtml(x.LastName))
                    )
                    .ForMember(
                            dest => dest.CityId,
                            memb =>
                                    memb.MapFrom(x => x.CityId)
                    )
                    .ForMember(
                            dest => dest.ApiToken,
                            memb =>
                                    memb.MapFrom(x => Helpers.MakeToken())
                    )
                    .ForMember(
                            dest => dest.LoginHit,
                            memb =>
                                    memb.MapFrom(x => 0)
                    );
        }

        #endregion
    }
}