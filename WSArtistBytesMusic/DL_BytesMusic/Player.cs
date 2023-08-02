using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WSArtistBytesMusic.DL_BytesMusic
{
    public class Player
    {
        private string strConnectionString;
        public Player(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int Save(int idArtist, List<int> idSongs)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    for (int i = 0; i < idSongs.Count; i++)
                    {
                        command.CommandText += string.Format("INSERT INTO [TBL_PLAYER]([ID_SONG] ,[ID_ARTIST]) VALUES (@ID_SONG{0}, @ID_ARTIST{0});", i);
                        command.Parameters.AddWithValue("@ID_SONG" + i, idSongs[i]);
                        command.Parameters.AddWithValue("@ID_ARTIST" + i, idArtist);
                    }
                    command.Connection = con;
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Save(int idArtist, int idSong)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "INSERT INTO [TBL_PLAYER]([ID_SONG] ,[ID_ARTIST]) VALUES (@ID_SONG, @ID_ARTIST);";
                    command.Parameters.AddWithValue("@ID_SONG", idSong);
                    command.Parameters.AddWithValue("@ID_ARTIST", idArtist);
                    command.Connection = con;
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int CheckExist(int idArtist, int idSong)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_SONG] FROM [TBL_PLAYER] WHERE [ID_SONG] = @ID_SONG AND [ID_ARTIST] = @ID_ARTIST";
                    cmd.Parameters.AddWithValue("@ID_ARTIST", idArtist);
                    cmd.Parameters.AddWithValue("@ID_SONG", idSong);
                    cmd.Connection = con;
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                    return (returnValue == null ? 0 : (int)returnValue);
                }
            }
        }

        public DataTable Read(int idArtist)
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
FROM [BDD_BytesMusic_Song].[dbo].[TBL_SONG] AS S, [TBL_PLAYER], [TBL_ARTIST]
WHERE 
S.[ID_SONG] = [TBL_PLAYER].[ID_SONG]
AND [TBL_PLAYER].[ID_ARTIST] = [TBL_ARTIST].[ID_ARTIST]
AND [TBL_PLAYER].[ID_ARTIST] = @ID_ARTIST";
#else
                    command.CommandText = @"
SELECT 
S.[ID_SONG]
,[SONG_NAME]
,[SONG_PATH]
FROM [TBL_SONG] AS S, [TBL_PLAYER], [TBL_ARTIST]
WHERE 
S.[ID_SONG] = [TBL_PLAYER].[ID_SONG]
AND [TBL_PLAYER].[ID_ARTIST] = [TBL_ARTIST].[ID_ARTIST]
AND [TBL_PLAYER].[ID_ARTIST] = @ID_ARTIST";
#endif
                    command.Parameters.AddWithValue("@ID_ARTIST", idArtist);
                    command.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(dtTracklist);
                        return dtTracklist;
                    }
                }
            }
        }

        public int Delete(int idArtist)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE [TBL_PLAYER] where [ID_ARTIST] = @ID_ARTIST";
                    cmd.Parameters.AddWithValue("@ID_ARTIST", idArtist);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int Delete(int idArtist, int idSong)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE [TBL_PLAYER] where [ID_SONG] = @ID_SONG AND [ID_ARTIST] = @ID_ARTIST";
                    cmd.Parameters.AddWithValue("@ID_ARTIST", idArtist);
                    cmd.Parameters.AddWithValue("@ID_SONG", idSong);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
