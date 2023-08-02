using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;

namespace WebApp2BytesMusic.Tracklist
{
    public partial class TracklistManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataAlbum();
                BindDataSong();
            }
            lblMessage.Text = string.Empty;
        }
        private void BindDataAlbum()
        {
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readAlbum";
            //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            //DataTable dtAlbum = new BL_BytesMusic.Album(strConnString).Read();

            DataTable dtAlbum = new DataTable();

            using (var client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);

                    dtAlbum = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewAlbumDataTable();

                    //DataTable dtAlbum = new BL_BytesMusic.Album(strConnString).Read();

                    if (dtAlbum != null && dtAlbum.Rows.Count > 0)
                    {
                        gridViewAlbum.DataSource = dtAlbum;
                        gridViewAlbum.DataBind();
                    }
                    else
                    {
                        dtAlbum.Rows.Add(dtAlbum.NewRow());
                        gridViewAlbum.DataSource = dtAlbum;
                        gridViewAlbum.DataBind();
                        int columncount = gridViewAlbum.Rows[0].Cells.Count;
                        gridViewAlbum.Rows[0].Cells.Clear();
                        gridViewAlbum.Rows[0].Cells.Add(new TableCell());
                        gridViewAlbum.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewAlbum.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                    return;
                }
            }
        }
        protected DataTable setColumnsInNewAlbumDataTable()
        {
            DataTable dt = new DataTable();

            //[ID_USER] ,[USERNAME] ,[PASSWORD] ,[EMAIL], [BIRTHDAY], [USER_PHOTO],[USER_TYPE]
            //TODO: 
            dt.Columns.Add("ID_ALBUM", typeof(int));
            dt.Columns.Add("TITLE_ALBUM", typeof(String));
            dt.Columns.Add("RELEASE_YEAR", typeof(int));
            dt.Columns.Add("ALBUM_IMAGE_PATH", typeof(String));


            return dt;

        }
        protected DataTable setColumnsInNewDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id_Song", typeof(int));
            dt.Columns.Add("Song_Name", typeof(String));
            dt.Columns.Add("Song_Path", typeof(String));
            return dt;
        }

        private void BindDataSong()
        {
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readSong";
            DataTable dtSong = new DataTable();
            //DataColumn workCol= dtSong.Columns.Add("ID", typeof(Int32));
            //dtSong.Columns.Add("Song_Name", typeof(String));
            //dtSong.Columns.Add("Song_Path", typeof(String));
            // workCol.Unique = true;


            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";
                string response = client.DownloadString(url);
                try
                {
                    dtSong = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();
                    if (dtSong != null && dtSong.Rows.Count > 0)
                    {
                        gridViewSong.DataSource = dtSong;
                        gridViewSong.DataBind();
                    }
                    else
                    {
                        dtSong.Rows.Add(dtSong.NewRow());
                        gridViewSong.DataSource = dtSong;
                        gridViewSong.DataBind();
                        int columncount = gridViewSong.Rows[0].Cells.Count;
                        gridViewSong.Rows[0].Cells.Clear();
                        gridViewSong.Rows[0].Cells.Add(new TableCell());
                        gridViewSong.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewSong.Rows[0].Cells[0].Text = "No Records Found";
                    }

                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                    return;
                }

            }
        }
        protected void gridViewAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewAlbum.Rows)
            {
                if (row.RowIndex == gridViewAlbum.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
            Label lblId = gridViewAlbum.SelectedRow.FindControl("lblId") as Label;
            int albumId = Convert.ToInt32(lblId.Text);
            BindDataTracklist(albumId);
        }
        protected void gridViewTracklist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idSong = Convert.ToInt32(gridViewTracklist.DataKeys[e.RowIndex].Values[0]);
                Label lblIdAlbum = gridViewAlbum.SelectedRow.FindControl("lblId") as Label;
                int albumId = Convert.ToInt32(lblIdAlbum.Text);
                //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;

                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deleteSongOnTracklist";
                url += "/" + albumId + "/" + idSong;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //new BL_BytesMusic.Tracklist(strConnString).DeleteSongOnTracklist(albumId, idSong);
                lblMessage.Text = "Se elimino correctamente la canción";

                BindDataTracklist(albumId);
            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                return;
            }
        }
        private void BindDataTracklist(int idAlbum)
        {
            //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            //DataTable dtTracklist = new BL_BytesMusic.Tracklist(strConnString).Read(idAlbum);
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readTracklist";

            DataTable dtTracklist = new DataTable();
            using (var client = new WebClient())
            {
                try
                {
                    //  client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    url += "/" + idAlbum;
                    byte[] responseHttp = client.UploadValues(url, new NameValueCollection()
                           {
                               { "data", "0" }
                           });
                    string response = System.Text.Encoding.UTF8.GetString(responseHttp);

                    dtTracklist = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();

                    if (dtTracklist != null && dtTracklist.Rows.Count > 0)
                    {
                        gridViewTracklist.DataSource = dtTracklist;
                        gridViewTracklist.DataBind();
                    }
                    else
                    {
                        dtTracklist.Rows.Add(dtTracklist.NewRow());
                        gridViewTracklist.DataSource = dtTracklist;
                        gridViewTracklist.DataBind();
                        int columncount = gridViewTracklist.Rows[0].Cells.Count;
                        gridViewTracklist.Rows[0].Cells.Clear();
                        gridViewTracklist.Rows[0].Cells.Add(new TableCell());
                        gridViewTracklist.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewTracklist.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                    return;
                }

            }
        }
        protected void gridViewSong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                if (gridViewAlbum.SelectedRow == null)
                {
                    lblMessage.Text = "Select an Album, first!";
                    return;
                }

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                Label lblId = row.FindControl("lblId") as Label;
                int songId = Convert.ToInt32(lblId.Text);

                Label lblIdAlbum = gridViewAlbum.SelectedRow.FindControl("lblId") as Label;
                int albumId = Convert.ToInt32(lblIdAlbum.Text);

                //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;

                string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistTracklist";
                using (var client = new WebClient())
                {
                    try
                    {
                        //  client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        url += "/" + albumId + "/" + songId;

                        byte[] responseHttp = client.UploadValues(url, new NameValueCollection()
                           {
                               { "data", "0" }
                           });
                        string response = System.Text.Encoding.UTF8.GetString(responseHttp);
                        int result = Int32.Parse(response);
                        // int result = new BL_BytesMusic.Tracklist(strConnString).CheckExist(albumId, songId);
                        if (result != 0)
                        {
                            lblMessage.Text = "Song already add!";
                            return;
                        }

                        string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/saveTracklist";
                        urlSave += "/" + albumId + "/" + songId;

                        var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                        request.Accept = "application/json";
                        request.ContentType = "application/json";
                        request.Method = "POST";


                        var responseSave = request.GetResponse();
                        var stream = responseSave.GetResponseStream();
                        var sr = new StreamReader(stream);

                        //  new BL_BytesMusic.Tracklist(strConnString).Save(albumId, songId);
                        lblMessage.Text = "Se ingreso correctamente la canción";

                    }
                    catch (Exception exp)
                    {
                        lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                        return;
                    }

                }

                BindDataTracklist(albumId);
            }
        }
    }
}