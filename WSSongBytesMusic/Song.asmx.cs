using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSSongBytesMusic.E_BytesMusic;

namespace WSSongBytesMusic
{
    /// <summary>
    /// Summary description for Song
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Song : System.Web.Services.WebService
    {

        private string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_SongBytesMusicConnectionString"].ConnectionString;

        [WebMethod]
        public int Save(ESong song)
        {
            return new BL_BytesMusic.Song(strConnectionString).Save(song);
        }
        [WebMethod]
        public DataTable Read()
        {
            DataTable dt = new BL_BytesMusic.Song(strConnectionString).Read();
            dt.TableName = "dtSong";
            return dt;
        }
        [WebMethod]
        public int Update(ESong song)
        {
            return new BL_BytesMusic.Song(strConnectionString).Update(song);
        }
        [WebMethod]
        public int Delete(int songId)
        {
            return new BL_BytesMusic.Song(strConnectionString).Delete(songId);
        }
        [WebMethod]
        public int CheckExist(string songName)
        {
            return new BL_BytesMusic.Song(strConnectionString).CheckExist(songName);
        }
    }
}
