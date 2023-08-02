using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSAlbumBytesMusic.DL_BytesMusic
{
    public interface IMusic
    {
        DataTable Read();
    }
}