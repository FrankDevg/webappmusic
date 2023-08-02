using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSUserBytesMusic.E_BytesMusic;

namespace WSUserBytesMusic
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_UserBytesMusicConnectionString"].ConnectionString;
        [WebMethod]
        public int Save(EUser user)
        {
            return new BL_BytesMusic.User(strConnectionString).Save(user);
        }
        [WebMethod]
        public DataTable Read()
        {
            DataTable dt = new BL_BytesMusic.User(strConnectionString).Read();
            dt.TableName = "dtUser";
            return dt;
        }
        [WebMethod]
        public int Update(EUser user)
        {
            return new BL_BytesMusic.User(strConnectionString).Update(user);
        }
        [WebMethod]
        public int Delete(int id)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["BDD_UserBytesMusicConnectionString"].ConnectionString;
            return new BL_BytesMusic.User(strConnectionString).Delete(id);
        }
        [WebMethod]
        public string ValidationsDuplicated(EUser user)
        {
            return new BL_BytesMusic.User(strConnectionString).ValidationsDuplicated(user);
        }
        [WebMethod]
        public DataTable AuthenticateUser(string login, string password)
        {
            DataTable dt = new BL_BytesMusic.User(strConnectionString).AuthenticateUser(login, password);
            dt.TableName = "dtUser";
            return dt;
        }
        [WebMethod]
        public int CheckExistUser(string userName)
        {
            return new BL_BytesMusic.User(strConnectionString).CheckExistUser(userName);
        }
        [WebMethod]
        public int CheckExistEmail(string email)
        {
            return new BL_BytesMusic.User(strConnectionString).CheckExistEmail(email);
        }
    }
}
