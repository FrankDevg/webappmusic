using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSPlaylistBytesMusic
{
    /// <summary>
    /// Summary description for PlaylistSong
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PlaylistSong : System.Web.Services.WebService
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_PlaylistBytesMusicConnectionString"].ConnectionString;
        [WebMethod]
        public int CheckExist(int playlistId, int songId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).CheckExist(playlistId, songId);
        }
        [WebMethod]
        public int Save(int playlistId, int songId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).Save(playlistId, songId);
        }
        [WebMethod]
        public DataTable Read(int playlistId)
        {
            DataTable dt = new DL_BytesMusic.PlaylistSong(strConnectionString).Read(playlistId);
            dt.TableName = "dtPlaylistSong";
            return dt;
        }
        [WebMethod]
        public int Delete(int playlistId, int songId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).Delete(playlistId, songId);
        }
        [WebMethod]
        public int DeleteById(int playlistId)
        {
            return new DL_BytesMusic.PlaylistSong(strConnectionString).Delete(playlistId);
        }
    }
}
