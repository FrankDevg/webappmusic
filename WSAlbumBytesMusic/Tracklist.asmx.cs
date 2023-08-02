using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSAlbumBytesMusic
{
    /// <summary>
    /// Summary description for Tracklist
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Tracklist : System.Web.Services.WebService
    {

        string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_AlbumBytesMusicConnectionString"].ConnectionString;
        /*[WebMethod]
        public int Save(int idAlbum, List<int> idSongs)
        {
            return new BL_BytesMusic.Tracklist(strConnectionString).Save(idAlbum, idSongs);
        }*/
        [WebMethod]
        public int Save(int idAlbum, int idSong)
        {
            return new BL_BytesMusic.Tracklist(strConnectionString).Save(idAlbum, idSong);
        }
        [WebMethod]
        public int CheckExist(int idAlbum, int idSong)
        {
            return new BL_BytesMusic.Tracklist(strConnectionString).CheckExist(idAlbum, idSong);
        }
        [WebMethod]
        public DataTable Read(int idAlbum)
        {
            DataTable dt = new BL_BytesMusic.Tracklist(strConnectionString).Read(idAlbum);
            dt.TableName = "dtTracklist";
            return dt;
        }
        [WebMethod]
        public int Delete(int idSong)
        {
            return new BL_BytesMusic.Tracklist(strConnectionString).Delete(idSong);
        }
        [WebMethod]
        public int DeleteSongOnTracklist(int idAlbum, int idSong)
        {
            return new BL_BytesMusic.Tracklist(strConnectionString).DeleteSongOnTracklist(idAlbum, idSong);
        }
    }
}
