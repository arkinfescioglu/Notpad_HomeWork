using System;
using System.Text.Json.Serialization;

namespace Notepad.Service.Notes.Dtos.Inputs
{
    public class NoteCreateInputDto
    {
        public string NoteTitle { get; set; }
        
        public string NoteContent { get; set; }
        
        //TODO: Validasyonda Category Id var mı kontrol et
        public Guid CategoryId { get; set; }
        
        //TODO: JsonIgnore ekledim çünkü güvenlik açığına sebep olabilir. Ne olur ne olmaz serviste de kontrol yapıyorum.
        [JsonIgnore]
        //TODO: !!Auth Olmuş User İle Aynı Id'mi kontrol et Yoksa güvenlik açığı oluşur.
        public Guid UserId { get; set; }
    }
}