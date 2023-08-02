using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSCatalogBytesMusic.E_BytesMusic;

namespace WSCatalogBytesMusic.DL_BytesMusic
{
    public class Catalog
    {
        private string strConnectionString;
        public Catalog(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int Save(ECatalog catalog)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    /*
                    string sentence = "INSERT INTO TBL_CATALOG(";
                    if (catalog.CodeCatalogParent != int.MinValue && catalog.CodeCatalog != int.MinValue)
                    {
                        sentence += "[COD_CATALOG_PARENT], [COD_CATALOG]";
                    }
                    else if (catalog.CodeCatalogParent != int.MinValue && catalog.CodeCatalog == int.MinValue)
                    {
                        sentence += "[COD_CATALOG_PARENT]";
                    }
                    else if (catalog.CodeCatalogParent == int.MinValue && catalog.CodeCatalog != int.MinValue)
                    {
                        sentence += "[COD_CATALOG]";
                    }
                    sentence += ", [VALUE]) VALUES(";

                    if (catalog.CodeCatalogParent != int.MinValue && catalog.CodeCatalogParent != int.MinValue)
                    {
                        sentence += "@COD_CATALOG_PARENT, ,@COD_CATALOG";
                    }
                    else if (catalog.CodeCatalogParent != int.MinValue && catalog.CodeCatalog == int.MinValue)
                    {
                        sentence += "@COD_CATALOG_PARENT";
                    }
                    else if (catalog.CodeCatalogParent == int.MinValue && catalog.CodeCatalog != int.MinValue)
                    {
                        sentence += "@COD_CATALOG";
                    }
                    sentence += ",@VALUE)";
                    cmd.CommandText = sentence;
                    */

                    cmd.CommandText = "INSERT INTO TBL_CATALOG([COD_CATALOG_PARENT], [COD_CATALOG], [VALUE]) VALUES (" +
                        "@COD_CATALOG_PARENT" +
                        ",@COD_CATALOG" +
                        ",@VALUE)";

                    if (catalog.CodeCatalogParent == null || catalog.CodeCatalogParent == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG_PARENT", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG_PARENT", catalog.CodeCatalogParent);
                    }
                    if (catalog.CodeCatalog == null || catalog.CodeCatalog == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG", catalog.CodeCatalog);
                    }
                    cmd.Parameters.AddWithValue("@VALUE", catalog.Value);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int CheckExist(ECatalog catalog)
        {
            object returnValue;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [ID_CATALOG] FROM [TBL_CATALOG] WHERE [COD_CATALOG_PARENT] = @COD_CATALOG_PARENT AND [COD_CATALOG] = @COD_CATALOG AND [VALUE] = @VALUE";
                    cmd.Parameters.AddWithValue("@COD_CATALOG_PARENT", catalog.CodeCatalogParent);
                    cmd.Parameters.AddWithValue("@COD_CATALOG", catalog.CodeCatalog);
                    cmd.Parameters.AddWithValue("@VALUE", catalog.Value);
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
                using (SqlCommand cmd = new SqlCommand("SELECT [ID_CATALOG] , [COD_CATALOG_PARENT], [COD_CATALOG], [VALUE] FROM [TBL_CATALOG]", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtAlbum);
                        return dtAlbum;
                    }
                }
            }
        }
        public int Update(ECatalog catalog)
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE [TBL_CATALOG] SET [COD_CATALOG]=@COD_CATALOG, [COD_CATALOG_PARENT]=@COD_CATALOG_PARENT, [VALUE]=@VALUE " +
                        " WHERE [ID_CATALOG] = @ID_CATALOG";
                    cmd.Parameters.AddWithValue("@ID_CATALOG", catalog.ID);
                    if (catalog.CodeCatalogParent == null || catalog.CodeCatalogParent == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG_PARENT", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG_PARENT", catalog.CodeCatalogParent);
                    }
                    if (catalog.CodeCatalog == null || catalog.CodeCatalog == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@COD_CATALOG", catalog.CodeCatalog);
                    }
                    cmd.Parameters.AddWithValue("@VALUE", catalog.Value);
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
                    cmd.CommandText = "DELETE TBL_CATALOG WHERE [ID_CATALOG] = @ID_CATALOG";
                    cmd.Parameters.AddWithValue("@ID_CATALOG", id);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetUserType()
        {
            DataTable dtCatalog = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [COD_CATALOG],[VALUE] FROM [TBL_CATALOG] WHERE [COD_CATALOG_PARENT] = @COD_CATALOG_PARENT";
                    cmd.Parameters.AddWithValue("@COD_CATALOG_PARENT", Constants.ID_USER_TYPE_CATALOG);
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtCatalog);
                        return dtCatalog;
                    }
                }
            }
        }
        public DataTable GetPlaylistType()
        {
            DataTable dtCatalog = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT [COD_CATALOG],[VALUE] FROM [TBL_CATALOG] WHERE [COD_CATALOG_PARENT] = @COD_CATALOG_PARENT";
                    cmd.Parameters.AddWithValue("@COD_CATALOG_PARENT", Constants.ID_PLAYLIST_TYPE_CATALOG);
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtCatalog);
                        return dtCatalog;
                    }
                }
            }
        }
    }
}
