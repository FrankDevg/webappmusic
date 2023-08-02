using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSAlbumBytesMusic.E_BytesMusic;

namespace WSAlbumBytesMusic.BL_BytesMusic
{
    public class Album
    {
        private string strConnectionString;
        public Album(string strConnString)
        {
            strConnectionString = strConnString;
        }

        public int Save(EAlbum album)
        {
            return new DL_BytesMusic.Album(strConnectionString).Save(album);
        }
        public int CheckExist(string albumTitle)
        {
            return new DL_BytesMusic.Album(strConnectionString).CheckExist(albumTitle);
        }
        public DataTable Read()
        {
            DL_BytesMusic.IMusic music = new DL_BytesMusic.Album(strConnectionString);
            return music.Read();
        }
        public int Update(EAlbum album)
        {
            return new DL_BytesMusic.Album(strConnectionString).Update(album);
        }
        public int Delete(int albumId)
        {
            return new DL_BytesMusic.Album(strConnectionString).Delete(albumId);
        }
    }
}
