using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp2BytesMusic.E_BytesMusic
{
    public class EPlaylist
    {
        public EPlaylist()
        {
        }
        public EPlaylist(int idPlaylist, int idUser, string title, string creationDate, int type, string photo)
        {
            Id_Playlist = idPlaylist;
            Id_User = idUser;
            Title = title;
            Creation_Date = creationDate;
            Type = type;
            Photo = photo;
        }
        public int Id_Playlist { get; set; }
        public int Id_User { get; set; }
        public string Title { get; set; }
        public string Creation_Date { get; set; }
        public int Type { get; set; }
        public string Photo { get; set; }
    }
}