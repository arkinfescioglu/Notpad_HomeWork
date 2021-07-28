using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Notepad.Domain.Base;
using Notepad.Domain.Cities;
using Notepad.Domain.Notes;
using Notepad.Domain.Users.Consts;

namespace Notepad.Domain.Users
{
    public class User : EntityBase, IEntity
    {
        #region Properties

        public                                        string   ApiToken  { get; set; }
        public                                        string   Slug      { get; set; }
        [ MaxLength(UserLength.MaxFirstName) ] public string   FirstName { get; set; }
        [ MaxLength(UserLength.MaxLastName) ]  public string   LastName  { get; set; }
        [ MaxLength(UserLength.MaxEmail) ]     public string   Email     { get; set; }
        [ MaxLength(UserLength.MaxUsername) ]  public string   Username  { get; set; }
        public                                        string   Password  { get; set; }
        public                                        int      LoginHit  { get; set; }
        public                                        DateTime LastLogin { get; set; }
        public                                        Guid ?   CityId    { get; set; }

        #endregion

        #region Relations

        [ ForeignKey("CityId") ] public City City { get; set; }

        public List<Note> NoteRelation  { get; set; }
        
        #endregion
    }
}