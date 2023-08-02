using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSSongBytesMusic.E_BytesMusic;

namespace WSSongBytesMusic.DL_BytesMusic
{
    public class Song
    {
        private string strConnectionString;
        public Song(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int Save(ESong song)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO [TBL_SONG]([SONG_NAME] ,[SONG_PATH]) " +
                        " values (@SONG_NAME, @SONG_PATH)";
                    cmd.Parameters.AddWithValue("@SONG_NAME", song.SongName);
                    cmd.Parameters.AddWithValue("@SONG_PATH", song.SongPath);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int CheckExist(string songName)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_SONG] FROM [TBL_SONG] WHERE [SONG_NAME] = @SONG_NAME";
                    cmd.Parameters.AddWithValue("@SONG_NAME", songName);
                    cmd.Connection = con;
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                    return (returnValue == null ? 0 : (int)returnValue);
                }
            }
        }


        public DataTable Read()
        {
            DataTable dtSong = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [ID_SONG], [SONG_NAME] ,[SONG_PATH] from [TBL_SONG]", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtSong);
                        return dtSong;
                    }
                }
            }
        }

        public int Update(ESong song)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE [TBL_SONG] set " +
                        "[SONG_NAME] = @SONG_NAME," +
                        "[SONG_PATH] = @SONG_PATH" +
                        "[ALBUM_IMAGE_PATH] = @ALBUM_IMAGE_PATH" +
                        "where [ID_SONG] = @ID_SONG";
                    cmd.Parameters.AddWithValue("@ID_SONG", song.ID);
                    cmd.Parameters.AddWithValue("@SONG_NAME", song.SongName);
                    cmd.Parameters.AddWithValue("@SONG_PATH", song.SongPath);
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
                    cmd.CommandText = "DELETE [TBL_SONG] where [ID_SONG] = @ID_SONG";
                    cmd.Parameters.AddWithValue("@ID_SONG", id);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}