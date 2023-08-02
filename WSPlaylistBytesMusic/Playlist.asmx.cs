using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSPlaylistBytesMusic.E_BytesMusic;

namespace WSPlaylistBytesMusic
{
    /// <summary>
    /// Summary description for Playlist
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Playlist : System.Web.Services.WebService
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_PlaylistBytesMusicConnectionString"].ConnectionString;
        [WebMethod]
        public int Save(EPlaylist playList)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Save(playList);
        }
        [WebMethod]
        public int CheckExist(EPlaylist playList)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).CheckExist(playList);
        }
        [WebMethod]
        public DataTable ReadById(int idUser)
        {
            DataTable dt = new DL_BytesMusic.Playlist(strConnectionString).Read(idUser);
            dt.TableName = "dtPlaylist";
            return dt;
        }
        [WebMethod]
        public DataTable Read(int idUser, int idPlaylist)
        {
            DataTable dt = new DL_BytesMusic.Playlist(strConnectionString).Read(idUser, idPlaylist);
            dt.TableName = "dtPlaylist";
            return dt;
        }
        [WebMethod]
        public int Update(EPlaylist playList)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Update(playList);
        }
        [WebMethod]
        public int Delete(int idPlaylist)
        {
            return new DL_BytesMusic.Playlist(strConnectionString).Delete(idPlaylist);
        }
        [WebMethod]
        public string FieldsRequiredValidations(EPlaylist playlist)
        {
            if (playlist.Title == string.Empty)
            {
                return "Title is required!";
            }
            return string.Empty;
        }
    }
}
