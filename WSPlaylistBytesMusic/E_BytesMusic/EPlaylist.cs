using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSPlaylistBytesMusic.E_BytesMusic
{
    public class EPlaylist
    {
        public EPlaylist()
        {
        }
        public EPlaylist(int idPlaylist, int idUser, string title, string creationDate, int type, string photo)
        {
            ID = idPlaylist;
            IdUser = idUser;
            Title = title;
            CreationDate = creationDate;
            Type = type;
            Photo = photo;
        }
        public int ID { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public int Type { get; set; }
        public string Photo { get; set; }
    }
}