using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSSongBytesMusic.E_BytesMusic;

namespace WSSongBytesMusic.BL_BytesMusic
{
    public class Song
    {
        private string strConnectionString;
        public Song(string strConnString)
        {
            strConnectionString = strConnString;
        }

        public int Save(ESong song)
        {
            return new DL_BytesMusic.Song(strConnectionString).Save(song);
        }
        public int CheckExist(string songName)
        {
            return new DL_BytesMusic.Song(strConnectionString).CheckExist(songName);
        }
        public DataTable Read()
        {
            return new DL_BytesMusic.Song(strConnectionString).Read();
        }
        public int Update(ESong song)
        {
            return new DL_BytesMusic.Song(strConnectionString).Update(song);
        }
        public int Delete(int songId)
        {
            return new DL_BytesMusic.Song(strConnectionString).Delete(songId);
        }
    }
}
