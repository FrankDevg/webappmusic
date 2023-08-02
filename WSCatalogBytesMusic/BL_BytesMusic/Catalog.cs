using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSCatalogBytesMusic.E_BytesMusic;

namespace WSCatalogBytesMusic.BL_BytesMusic
{
    public class Catalog
    {
        private string strConnectionString;
        public Catalog(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int Save(ECatalog catalog)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).Save(catalog);
        }
        public DataTable Read()
        {
            return new DL_BytesMusic.Catalog(strConnectionString).Read();
        }
        public int Update(ECatalog catalog)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).Update(catalog);
        }
        public int Delete(int id)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).Delete(id);
        }
        public int CheckExist(ECatalog catalog)
        {
            return new DL_BytesMusic.Catalog(strConnectionString).CheckExist(catalog);
        }
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
        public DataTable GetUserType()
        {
            return new DL_BytesMusic.Catalog(strConnectionString).GetUserType();
        }
        public DataTable GetPlaylistType()
        {
            return new DL_BytesMusic.Catalog(strConnectionString).GetPlaylistType();
        }
    }
}
