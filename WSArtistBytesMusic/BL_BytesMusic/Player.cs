using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSArtistBytesMusic.BL_BytesMusic
{
    public class Player
    {
        private string strConnectionString;
        public Player(string strConnString)
        {
            strConnectionString = strConnString;
        }

        public int Save(int idArtist, List<int> idSongs)
        {
            return new DL_BytesMusic.Player(strConnectionString).Save(idArtist, idSongs);
        }
        public int Save(int idArtist, int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).Save(idArtist, idSong);
        }
        public int CheckExist(int idArtist, int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).CheckExist(idArtist, idSong);
        }
        public DataTable Read(int idArtist)
        {
            return new DL_BytesMusic.Player(strConnectionString).Read(idArtist);
        }
        public int Delete(int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).Delete(idSong);
        }
        public int Delete(int idArtist, int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).Delete(idArtist, idSong);
        }
    }
}
