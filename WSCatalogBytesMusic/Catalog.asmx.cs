using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSCatalogBytesMusic.E_BytesMusic;

namespace WSCatalogBytesMusic
{
    /// <summary>
    /// Summary description for Catalog
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Catalog : System.Web.Services.WebService
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["BDD_CatalogBytesMusicConnectionString"].ConnectionString;
        [WebMethod]
        public int Save(ECatalog catalog)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).Save(catalog);
        }
        [WebMethod]
        public DataTable Read()
        {
            DataTable dt = new DL_BytesMusic.Catalog(strConnectionString).Read();
            dt.TableName = "dtCatalog";
            return dt;
        }
        [WebMethod]
        public int Update(ECatalog catalog)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).Update(catalog);
        }
        [WebMethod]
        public int Delete(int id)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).Delete(id);
        }
        [WebMethod]
        public int CheckExist(ECatalog catalog)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).CheckExist(catalog);
        }
        [WebMethod]
        public string Validations(ECatalog catalog)
        {
            if (catalog.CodeCatalog == string.Empty || catalog.CodeCatalogParent == string.Empty)
            {
                return "Code or Code Parent catalog is required!";
            }
            if (catalog.Value == string.Empty)
            {
                return "A value for the Catalog is required!";
            }
            return string.Empty;
        }
        [WebMethod]
        public DataTable GetUserType()
        {
            DataTable dt = new DL_BytesMusic.Catalog(strConnectionString).GetUserType(); ;
            dt.TableName = "dtCatalog";
            return dt;
        }
        [WebMethod]
        public DataTable GetPlaylistType()
        {
            DataTable dt = new DL_BytesMusic.Catalog(strConnectionString).GetPlaylistType();
            dt.TableName = "dtCatalog";
            return dt;
        }
    }
}
