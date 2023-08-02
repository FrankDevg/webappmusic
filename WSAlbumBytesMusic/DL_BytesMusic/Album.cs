using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSAlbumBytesMusic.E_BytesMusic;

namespace WSAlbumBytesMusic.DL_BytesMusic
{
    public class Album : DLBase, IMusic
    {
        public Album(string strConnectionString) : base(strConnectionString) { }
        public int Save(EAlbum album)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO TBL_ALBUM([TITLE_ALBUM], [RELEASE_YEAR], [ALBUM_IMAGE_PATH]) values (" +
                        "@TITLE_ALBUM" +
                        ",@RELEASE_YEAR" +
                        ",@ALBUM_IMAGE_PATH)";
                    cmd.Parameters.AddWithValue("@TITLE_ALBUM", album.Title);
                    cmd.Parameters.AddWithValue("@RELEASE_YEAR", album.ReleaseYear);
                    cmd.Parameters.AddWithValue("@ALBUM_IMAGE_PATH", album.ImagePath);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int CheckExist(string albumTitle)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_ALBUM] FROM TBL_ALBUM WHERE [TITLE_ALBUM] = @albumTitle";
                    cmd.Parameters.AddWithValue("@albumTitle", albumTitle);
                    cmd.Connection = con;
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                    return (returnValue == null ? 0 : (int)returnValue);
                }
            }
        }


        public DataTable Read()
        {
            DataTable dtAlbum = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [ID_ALBUM] ,[TITLE_ALBUM] ,[RELEASE_YEAR] ,[ALBUM_IMAGE_PATH] from [TBL_ALBUM]", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtAlbum);
                        return dtAlbum;
                    }
                }
            }
        }

        public int Update(EAlbum album)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE TBL_ALBUM set " +
                        "[TITLE_ALBUM] = @TITLE_ALBUM," +
                        "[RELEASE_YEAR] = @RELEASE_YEAR," +
                        "[ALBUM_IMAGE_PATH] = @ALBUM_IMAGE_PATH " +
                        "WHERE ID_ALBUM = @ID_ALBUM";
                    cmd.Parameters.AddWithValue("@ID_ALBUM", album.Id);
                    cmd.Parameters.AddWithValue("@TITLE_ALBUM", album.Title);
                    cmd.Parameters.AddWithValue("@RELEASE_YEAR", album.ReleaseYear);
                    cmd.Parameters.AddWithValue("@ALBUM_IMAGE_PATH", album.ImagePath);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE TBL_ALBUM where ID_ALBUM = @ID_ALBUM";
                    cmd.Parameters.AddWithValue("@ID_ALBUM", id);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
