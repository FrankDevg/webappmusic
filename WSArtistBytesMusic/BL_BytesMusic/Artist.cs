using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSArtistBytesMusic.E_BytesMusic;

namespace WSArtistBytesMusic.BL_BytesMusic
{
    public class Artist
    {
        private string strConnectionString;
        public Artist(string strConnString)
        {
            strConnectionString = strConnString;
        }

        public int SaveArtist(EArtist artist)
        {
            return new DL_BytesMusic.Artist(strConnectionString).SaveArtist(artist);
        }
        public int CheckExistArtist(EArtist artist)
        {
            return new DL_BytesMusic.Artist(strConnectionString).CheckExistArtist(artist);
        }
        public DataTable ReadArtist()
        {
            return new DL_BytesMusic.Artist(strConnectionString).ReadArtist();
        }
        public int UpdateArtist(EArtist artist)
        {
            return new DL_BytesMusic.Artist(strConnectionString).UpdateArtist(artist);
        }
        public int DeleteArtist(int artistId)
        {
            return new DL_BytesMusic.Artist(strConnectionString).DeleteArtist(artistId);
        }

        public string ArtistValidations(EArtist artist)
        {
            if (artist.FirstName == string.Empty || artist.LastName == string.Empty)
            {
                return "First and LastName are required!";
            }
            int returnValue = CheckExistArtist(artist);
            if (returnValue != 0)
            {
                return "Album already exist!"; ;
            }
            return string.Empty;
        }
    }
}
