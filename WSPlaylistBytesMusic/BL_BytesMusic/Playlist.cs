using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSPlaylistBytesMusic.E_BytesMusic;

namespace WSPlaylistBytesMusic.BL_BytesMusic
{
    public class Playlist
    {
        private string strConnectionString;
        public Playlist(string strConnString)
        {
            strConnectionString = strConnString;
        }

        public int Save(EPlaylist playList)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Save(playList);
        }
        public int CheckExist(EPlaylist playList)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).CheckExist(playList);
        }
        public DataTable Read(int idUser)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Read(idUser);
        }
        public DataTable Read(int idUser, int idPlaylist)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Read(idUser, idPlaylist);
        }
        public int Update(EPlaylist playList)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Update(playList);
        }
        public int Delete(int idPlaylist)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Delete(idPlaylist);
        }
        public string FieldsRequiredValidations(EPlaylist playlist)
        {
            if (playlist.Title == string.Empty)
            {
                return "Title is required!";
            }
            return string.Empty;
        }
    }
}
