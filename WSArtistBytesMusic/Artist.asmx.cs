using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSArtistBytesMusic.E_BytesMusic;

namespace WSArtistBytesMusic
{
    /// <summary>
    /// Summary description for Artist
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Artist : System.Web.Services.WebService
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_ArtistBytesMusicConnectionString"].ConnectionString;
        [WebMethod]
        public int SaveArtist(EArtist artist)
        {
            return new DL_BytesMusic.Artist(strConnectionString).SaveArtist(artist);
        }
        [WebMethod]
        public int CheckExistArtist(EArtist artist)
        {
            return new DL_BytesMusic.Artist(strConnectionString).CheckExistArtist(artist);
        }
        [WebMethod]
        public DataTable ReadArtist()
        {
            DataTable dt = new DL_BytesMusic.Artist(strConnectionString).ReadArtist();
            dt.TableName = "dtArtist";
            return dt;
        }
        [WebMethod]
        public int UpdateArtist(EArtist artist)
        {
            return new DL_BytesMusic.Artist(strConnectionString).UpdateArtist(artist);
        }
        [WebMethod]
        public int DeleteArtist(int artistId)
        {
            return new DL_BytesMusic.Artist(strConnectionString).DeleteArtist(artistId);
        }

        [WebMethod]
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
