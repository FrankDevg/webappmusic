using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAlbumBytesMusic.DL_BytesMusic
{
    public abstract class DLBase
    {
        protected string strConnectionString;
        protected DLBase(string strConnString)
        {
            strConnectionString = strConnString;
        }
    }
}
