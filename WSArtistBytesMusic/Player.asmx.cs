using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSArtistBytesMusic
{
    /// <summary>
    /// Summary description for Player
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Player : System.Web.Services.WebService
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_ArtistBytesMusicConnectionString"].ConnectionString;
        /*[WebMethod]
        public int Save(int idArtist, List<int> idSongs)
        {
            return new DL_BytesMusic.Player(strConnectionString).Save(idArtist, idSongs);
        }*/
        [WebMethod]
        public int Save(int idArtist, int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).Save(idArtist, idSong);
        }
        [WebMethod]
        public int CheckExist(int idArtist, int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).CheckExist(idArtist, idSong);
        }
        [WebMethod]
        public DataTable Read(int idArtist)
        {
            DataTable dt = new DL_BytesMusic.Player(strConnectionString).Read(idArtist);
            dt.TableName = "dtPlayer";
            return dt;
        }
        [WebMethod]
        public int DeleteByIdSong(int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).Delete(idSong);
        }
        [WebMethod]
        public int Delete(int idArtist, int idSong)
        {
            return new DL_BytesMusic.Player(strConnectionString).Delete(idArtist, idSong);
        }
    }
}
