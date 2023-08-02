using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSAlbumBytesMusic.E_BytesMusic;

namespace WSAlbumBytesMusic
{
    /// <summary>
    /// Summary description for Album
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Album : System.Web.Services.WebService
    {

        string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_AlbumBytesMusicConnectionString"].ConnectionString;
        [WebMethod]
        public int Save(EAlbum album)
        {
            return new BL_BytesMusic.Album(strConnectionString).Save(album);
        }
        [WebMethod]
        public int CheckExist(string albumTitle)
        {
            return new BL_BytesMusic.Album(strConnectionString).CheckExist(albumTitle);
        }
        [WebMethod]
        public DataTable Read()
        {
            DataTable dt = new BL_BytesMusic.Album(strConnectionString).Read();
            dt.TableName = "dtAlbum";
            return dt;
        }
        [WebMethod]
        public int Update(EAlbum album)
        {
            return new BL_BytesMusic.Album(strConnectionString).Update(album);
        }
        [WebMethod]
        public int Delete(int albumId)
        {
            return new BL_BytesMusic.Album(strConnectionString).Delete(albumId);
        }
    }
}
