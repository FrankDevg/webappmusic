using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSPlaylistBytesMusic.E_BytesMusic;

namespace WSPlaylistBytesMusic.DL_BytesMusic
{
    public class Playlist
    {
        private string strConnectionString;
        public Playlist(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int Save(EPlaylist playList)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO [TBL_PLAYLIST]([ID_USER], [TITLE], [CREATION_DATE], [TYPE], [PHOTO]) VALUES (" +
                        "@ID_USER" +
                        ",@TITLE" +
                        ",@CREATION_DATE" +
                        ",@TYPE" +
                        ",@PHOTO)";
                    cmd.Parameters.AddWithValue("@ID_USER", playList.IdUser);
                    cmd.Parameters.AddWithValue("@TITLE", playList.Title);
                    cmd.Parameters.AddWithValue("@CREATION_DATE", playList.CreationDate);
                    cmd.Parameters.AddWithValue("@TYPE", playList.Type);
                    cmd.Parameters.AddWithValue("@PHOTO", playList.Photo);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int CheckExist(EPlaylist playList)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_PLAYLIST] FROM [TBL_PLAYLIST] WHERE [TITLE] = @TITLE AND [ID_USER]=@ID_USER";
                    cmd.Parameters.AddWithValue("@TITLE", playList.Title);
                    cmd.Parameters.AddWithValue("@ID_USER", playList.IdUser);
                    cmd.Connection = con;
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                    return (returnValue == null ? 0 : (int)returnValue);
                }
            }
        }
        public DataTable Read(int idUser)
        {
            DataTable dtTracklist = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
#if DEBUG
                    command.CommandText = @"
SELECT 
[TBL_PLAYLIST].[ID_PLAYLIST]
,[TBL_PLAYLIST].[ID_USER]
,[TITLE]
,[CREATION_DATE]
,[TYPE]
,[PHOTO]
FROM [TBL_PLAYLIST], [BDD_BytesMusic_User].[dbo].[TBL_USER] AS U
WHERE 
[TBL_PLAYLIST].[ID_USER] = U.[ID_USER]
AND [TBL_PLAYLIST].[ID_USER] = @ID_USER";
#else
                    command.CommandText = @"
SELECT 
[TBL_PLAYLIST].[ID_PLAYLIST]
,[TBL_PLAYLIST].[ID_USER]
,[TITLE]
,[CREATION_DATE]
,[TYPE]
,[PHOTO]
FROM [TBL_PLAYLIST], [TBL_USER]
WHERE 
[TBL_PLAYLIST].[ID_USER] = [TBL_USER].[ID_USER]
AND [TBL_PLAYLIST].[ID_USER] = @ID_USER";
#endif
                    command.Parameters.AddWithValue("@ID_USER", idUser);
                    command.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(dtTracklist);
                        return dtTracklist;
                    }
                }
            }
        }
        public DataTable Read(int idUser, int idPlayList)
        {
            DataTable dtTracklist = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
#if DEBUG
                    command.CommandText = @"
SELECT 
[TBL_PLAYLIST].[ID_PLAYLIST]
,[TBL_PLAYLIST].[ID_USER]
,[TITLE]
,[CREATION_DATE]
,[TYPE]
,[PHOTO]
FROM [TBL_PLAYLIST], [BDD_BytesMusic_User].[dbo].[TBL_USER] AS U
WHERE 
[TBL_PLAYLIST].[ID_USER] = U.[ID_USER]
AND [TBL_PLAYLIST].[ID_USER] = @ID_USER AND [TBL_PLAYLIST].[ID_PLAYLIST] = @ID_PLAYLIST";
#else
                    command.CommandText = @"
SELECT 
[TBL_PLAYLIST].[ID_PLAYLIST]
,[TBL_PLAYLIST].[ID_USER]
,[TITLE]
,[CREATION_DATE]
,[TYPE]
,[PHOTO]
FROM [TBL_PLAYLIST], [TBL_USER] AS U
WHERE 
[TBL_PLAYLIST].[ID_USER] = U.[ID_USER]
AND [TBL_PLAYLIST].[ID_USER] = @ID_USER AND [TBL_PLAYLIST].[ID_PLAYLIST] = @ID_PLAYLIST";
#endif
                    command.Parameters.AddWithValue("@ID_USER", idUser);
                    command.Parameters.AddWithValue("@ID_PLAYLIST", idPlayList);
                    command.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(dtTracklist);
                        return dtTracklist;
                    }
                }
            }
        }
        public int Update(EPlaylist playList)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE [TBL_PLAYLIST] SET " +
                        "[TITLE] = @TITLE" +
                        ",[TYPE] = @TYPE" +
                        ",[PHOTO] = @PHOTO" +
                        " WHERE [ID_PLAYLIST] = @ID_PLAYLIST AND [ID_USER] = @ID_USER";
                    cmd.Parameters.AddWithValue("@ID_PLAYLIST", playList.ID);
                    cmd.Parameters.AddWithValue("@ID_USER", playList.IdUser);
                    cmd.Parameters.AddWithValue("@TITLE", playList.Title);
                    cmd.Parameters.AddWithValue("@TYPE", playList.Type);
                    cmd.Parameters.AddWithValue("@PHOTO", playList.Photo);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Delete(int idPlaylist)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE [TBL_PLAYLIST] WHERE [ID_PLAYLIST] = @ID_PLAYLIST";
                    cmd.Parameters.AddWithValue("@ID_PLAYLIST", idPlaylist);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
