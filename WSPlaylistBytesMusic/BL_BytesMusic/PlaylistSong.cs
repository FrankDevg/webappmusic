using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSPlaylistBytesMusic.BL_BytesMusic
{
    public class PlaylistSong
    {
        private string strConnectionString;
        public PlaylistSong(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int CheckExist(int playlistId, int songId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).CheckExist(playlistId, songId);
        }
        public int Save(int playlistId, int songId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).Save(playlistId, songId);
        }
        public DataTable Read(int playlistId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).Read(playlistId);
        }
        public int Delete(int playlistId, int songId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).Delete(playlistId, songId);
        }
        public int Delete(int playlistId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).Delete(playlistId);
        }
    }
}
