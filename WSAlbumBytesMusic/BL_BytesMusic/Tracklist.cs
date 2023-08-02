using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSAlbumBytesMusic.BL_BytesMusic
{
    public class Tracklist
    {
        private string strConnectionString;
        public Tracklist(string strConnString)
        {
            strConnectionString = strConnString;
        }

        public int Save(int idAlbum, List<int> idSongs)
        {
            return new DL_BytesMusic.Tracklist(strConnectionString).Save(idAlbum, idSongs);
        }
        public int Save(int idAlbum, int idSong)
        {
            return new DL_BytesMusic.Tracklist(strConnectionString).Save(idAlbum, idSong);
        }
        public int CheckExist(int idAlbum, int idSong)
        {
            return new DL_BytesMusic.Tracklist(strConnectionString).CheckExist(idAlbum, idSong);
        }
        public DataTable Read(int idAlbum)
        {
            return new DL_BytesMusic.Tracklist(strConnectionString).Read(idAlbum);
        }
        public int Delete(int idSong)
        {
            return new DL_BytesMusic.Tracklist(strConnectionString).Delete(idSong);
        }
        public int DeleteSongOnTracklist(int idAlbum, int idSong)
        {
            return new DL_BytesMusic.Tracklist(strConnectionString).DeleteSongOnTracklist(idAlbum, idSong);
        }
    }
}
