using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSArtistBytesMusic.E_BytesMusic;

namespace WSArtistBytesMusic.DL_BytesMusic
{
    public class Artist
    {
        private string strConnectionString;
        public Artist(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int SaveArtist(EArtist artist)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "insert into [TBL_ARTIST]([ARTIST_NAME], [ARTIST_LASTNAME], [ARTIST_IMAGE]) values (@firstName, @lastName, @imageName)";
                    cmd.Parameters.AddWithValue("@firstName", artist.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", artist.LastName);
                    cmd.Parameters.AddWithValue("@imageName", artist.ImagePath);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int CheckExistArtist(EArtist artist)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_ARTIST] FROM TBL_ARTIST WHERE ARTIST_NAME = @firstName AND ARTIST_LASTNAME = @lastName";
                    cmd.Parameters.AddWithValue("@firstName", artist.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", artist.LastName);
                    cmd.Connection = con;
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                    return (returnValue == null ? 0 : (int)returnValue);
                }
            }
        }


        public DataTable ReadArtist()
        {
            DataTable dtArtist = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [ID_ARTIST] , [ARTIST_NAME], [ARTIST_LASTNAME], [ARTIST_IMAGE] from [TBL_ARTIST]", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtArtist);
                        return dtArtist;
                    }
                }
            }
        }

        public int UpdateArtist(EArtist artist)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE [TBL_ARTIST] " +
                    "SET [ARTIST_NAME] = @firstName, [ARTIST_LASTNAME] = @lastName, [ARTIST_IMAGE] = @imageName " +
                    "WHERE [ID_ARTIST] = @artistId"))
                {
                    cmd.Parameters.AddWithValue("@artistId", artist.ID);
                    cmd.Parameters.AddWithValue("@firstName", artist.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", artist.LastName);
                    cmd.Parameters.AddWithValue("@imageName", artist.ImagePath);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteArtist(int artistId)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [TBL_ARTIST] WHERE [ID_ARTIST] = @artistId"))
                {
                    cmd.Parameters.AddWithValue("@artistId", artistId);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
