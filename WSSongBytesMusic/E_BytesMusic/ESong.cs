using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSSongBytesMusic.E_BytesMusic
{
    public class ESong
    {
        public ESong()
        {
        }
        public ESong(int songId, string songName, string songPath)
        {
            ID = songId;
            SongName = songName;
            SongPath = songPath;
        }
        public int ID { get; set; }
        public string SongName { get; set; }
        public string SongPath { get; set; }
    }
}