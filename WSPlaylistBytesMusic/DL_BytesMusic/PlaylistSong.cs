using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WSPlaylistBytesMusic.DL_BytesMusic
{
    public class PlaylistSong
    {
        private string strConnectionString;
        public PlaylistSong(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int CheckExist(int playlistId, int songId)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_PLAYLIST] FROM [TBL_PLAYLIST_SONG] WHERE [ID_PLAYLIST]=@ID_PLAYLIST AND [ID_SONG]=@ID_SONG";
                    cmd.Parameters.AddWithValue("@ID_PLAYLIST", playlistId);
                    cmd.Parameters.AddWithValue("@ID_SONG", songId);
                    cmd.Connection = con;
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                    return (returnValue == null ? 0 : (int)returnValue);
                }
            }
        }

        public int Save(int playlistId, int songId)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "insert into [TBL_PLAYLIST_SONG]([ID_PLAYLIST], [ID_SONG]) values (" +
                        "@ID_PLAYLIST" +
                        ",@ID_SONG)";
                    cmd.Parameters.AddWithValue("@ID_PLAYLIST", playlistId);
                    cmd.Parameters.AddWithValue("@ID_SONG", songId);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable Read(int playlistId)
        {
            DataTable dtTracklist = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
#if DEBUG
                    command.CommandText = @"
SELECT 
S.[ID_SONG]
,[SONG_NAME]
,[SONG_PATH]
FROM [BDD_BytesMusic_Song].[dbo].[TBL_SONG] AS S, [TBL_PLAYLIST_SONG], [TBL_PLAYLIST]
WHERE 
S.[ID_SONG] = [TBL_PLAYLIST_SONG].[ID_SONG]
AND [TBL_PLAYLIST_SONG].[ID_PLAYLIST] = [TBL_PLAYLIST].[ID_PLAYLIST]
AND [TBL_PLAYLIST].[ID_PLAYLIST] = @ID_PLAYLIST";
#else
                    command.CommandText = @"
SELECT
S.[ID_SONG]
,[SONG_NAME]
,[SONG_PATH]
FROM [TBL_SONG] AS S, [TBL_PLAYLIST_SONG], [TBL_PLAYLIST]
WHERE
S.[ID_SONG] = [TBL_PLAYLIST_SONG].[ID_SONG]
AND [TBL_PLAYLIST_SONG].[ID_PLAYLIST] = [TBL_PLAYLIST].[ID_PLAYLIST]
AND [TBL_PLAYLIST].[ID_PLAYLIST] = @ID_PLAYLIST";
#endif
                    command.Parameters.AddWithValue("@ID_PLAYLIST", playlistId);
                    command.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(dtTracklist);
                        return dtTracklist;
                    }
                }
            }
        }

        public int Delete(int playlistId, int songId) // debe retornar 1 si es satisfactorio 
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "delete [TBL_PLAYLIST_SONG] " +
                        "where [ID_PLAYLIST] = @ID_PLAYLIST and [ID_SONG] = @ID_SONG";
                    cmd.Parameters.AddWithValue("@ID_PLAYLIST", playlistId);
                    cmd.Parameters.AddWithValue("@ID_SONG", songId);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int Delete(int playlistId)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "delete [TBL_PLAYLIST_SONG] " +
                        "where [ID_PLAYLIST] = @ID_PLAYLIST";
                    cmd.Parameters.AddWithValue("@ID_PLAYLIST", playlistId);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
