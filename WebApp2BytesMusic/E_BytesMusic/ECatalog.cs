using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp2BytesMusic.E_BytesMusic
{
    public class ECatalog
    {
        public ECatalog()
        {
        }
        public ECatalog(int id, string codeCatalogParent, string codeCatalog, string value)
        {
            Id_Catalog = id;
            Cod_Catalog_Parent = codeCatalogParent;
            Cod_Catalog = codeCatalog;
            Value = value;
        }
        public int Id_Catalog { get; set; }
        public string Cod_Catalog_Parent { get; set; }
        public string Cod_Catalog { get; set; }
        public string Value { get; set; }
    }
}