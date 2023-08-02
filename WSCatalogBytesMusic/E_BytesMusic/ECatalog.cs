using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSCatalogBytesMusic.E_BytesMusic
{
    public class ECatalog
    {
        public ECatalog()
        {
        }
        public ECatalog(int id, string codeCatalogParent, string codeCatalog, string value)
        {
            ID = id;
            CodeCatalogParent = codeCatalogParent;
            CodeCatalog = codeCatalog;
            Value = value;
        }
        public int ID { get; set; }
        public string CodeCatalogParent { get; set; }
        public string CodeCatalog { get; set; }
        public string Value { get; set; }
    }
}
