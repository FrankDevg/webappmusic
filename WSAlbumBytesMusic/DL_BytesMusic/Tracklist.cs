using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WSAlbumBytesMusic.DL_BytesMusic
{
    public class Tracklist
    {
        private string strConnectionString;
        public Tracklist(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int Save(int idAlbum, List<int> idSongs)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    for (int i = 0; i < idSongs.Count; i++)
                    {
                        command.CommandText += string.Format("INSERT INTO [TBL_TRACKLIST]([ID_ALBUM] ,[ID_SONG]) VALUES (@ID_ALBUM{0}, @ID_SONG{0});", i);
                        command.Parameters.AddWithValue("@ID_ALBUM" + i, idAlbum);
                        command.Parameters.AddWithValue("@ID_SONG" + i, idSongs[i]);
                    }
                    command.Connection = con;
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Save(int idAlbum, int idSong)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "INSERT INTO [TBL_TRACKLIST]([ID_ALBUM] ,[ID_SONG]) VALUES (@ID_ALBUM, @ID_SONG);";
                    command.Parameters.AddWithValue("@ID_ALBUM", idAlbum);
                    command.Parameters.AddWithValue("@ID_SONG", idSong);
                    command.Connection = con;
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int CheckExist(int idAlbum, int idSong)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_SONG] FROM [TBL_TRACKLIST] WHERE [ID_SONG] = @ID_SONG AND [ID_ALBUM] = @ID_ALBUM";
                    cmd.Parameters.AddWithValue("@ID_ALBUM", idAlbum);
                    cmd.Parameters.AddWithValue("@ID_SONG", idSong);
                    cmd.Connection = con;
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                    return (returnValue == null ? 0 : (int)returnValue);
                }
            }
        }

        public DataTable Read(int idAlbum)
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
                    FROM[BDD_BytesMusic_Song].[dbo].[TBL_SONG] AS S, [TBL_TRACKLIST], [TBL_ALBUM]
WHERE
S.[ID_SONG] = [TBL_TRACKLIST].[ID_SONG]
AND[TBL_TRACKLIST].[ID_ALBUM] = [TBL_ALBUM].[ID_ALBUM]
AND[TBL_TRACKLIST].[ID_ALBUM] = @ID_ALBUM";
#else
                    command.CommandText = @"
SELECT
S.[ID_SONG]
,[SONG_NAME]
,[SONG_PATH]
FROM [TBL_SONG] AS S, [TBL_TRACKLIST], [TBL_ALBUM]
WHERE 
S.[ID_SONG] = [TBL_TRACKLIST].[ID_SONG]
AND [TBL_TRACKLIST].[ID_ALBUM] = [TBL_ALBUM].[ID_ALBUM]
AND [TBL_TRACKLIST].[ID_ALBUM] = @ID_ALBUM";
#endif
                    command.Parameters.AddWithValue("@ID_ALBUM", idAlbum);
                    command.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(dtTracklist);
                        return dtTracklist;
                    }
                }
            }
        }

        public int Delete(int idAlbum)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE [TBL_TRACKLIST] where [ID_ALBUM] = @ID_ALBUM";
                    cmd.Parameters.AddWithValue("@ID_ALBUM", idAlbum);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int DeleteSongOnTracklist(int idAlbum, int idSong)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE [TBL_TRACKLIST] where [ID_SONG] = @ID_SONG AND [ID_ALBUM] = @ID_ALBUM";
                    cmd.Parameters.AddWithValue("@ID_ALBUM", idAlbum);
                    cmd.Parameters.AddWithValue("@ID_SONG", idSong);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
