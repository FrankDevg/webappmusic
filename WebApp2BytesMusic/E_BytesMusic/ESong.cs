using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp2BytesMusic.E_BytesMusic
{
    public class ESong
    {
        public ESong()
        {
        }
        public ESong(int songId, string songName, string songPath)
        {
            Id_Song = songId;
            Song_Name = songName;
            Song_Path = songPath;

        }
        public int Id_Song { get; set; }
        public string Song_Name { get; set; }
        public string Song_Path { get; set; }
        public int Plays { get; set; }
    }
}