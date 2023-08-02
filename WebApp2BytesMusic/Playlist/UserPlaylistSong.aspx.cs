using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp2BytesMusic.Playlist
{
    public partial class UserPlaylistSong : System.Web.UI.Page
    {
        protected int playlistId = 0;
        protected int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                userId = Convert.ToInt32(Request.QueryString["uid"]);
            else
                userId = Convert.ToInt32(Session[Util.Constants.USER]);
            playlistId = Convert.ToInt32(Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                FillPlaylistName();
                BindDataPlaylistSong(playlistId);
                BindDataSong();
            }
        }
        protected void FillPlaylistName()
        {
            //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            //DataTable dtPlayerlist = new BL_BytesMusic.Playlist(strConnString).Read(userId, playlistId);
            try
            {
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/readPlaylistsIdUser";
                url += "/" + playlistId + "?idUser=" + userId;
                DataTable dtPlayerlist = new DataTable();
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);
                    dtPlayerlist = response != "" ? Util.DataConvert.JSONToDataTable(response) : null;
                    if (dtPlayerlist != null && dtPlayerlist.Rows.Count > 0)
                    {
                        lblPlaylistTitle.Text = dtPlayerlist.Rows[0]["TITLE"].ToString();
                    }
                }
            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;
            }
        }
        protected void gridViewPlaylistSong_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int songId = Convert.ToInt32(gridViewPlaylistSong.DataKeys[e.RowIndex].Values[0]);
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deletePlaylistSong";
                url += "/" + playlistId + "/" + songId;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                BindDataPlaylistSong(playlistId);
                lblMessage.Text = "Se elimino correctamente la canción.";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                return;
            }
        }
        private void BindDataPlaylistSong(int playlistId)
        {
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readPlaylistSong";
            url += "/" + playlistId;

            DataTable dtPlayerlistSong = new DataTable();

            using (var client = new WebClient())
            {
                try
                {

                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    byte[] responseHttp = client.UploadValues(url, new NameValueCollection()
                           {
                               { "data", "0" }
                           });
                    string response = System.Text.Encoding.UTF8.GetString(responseHttp);
                    dtPlayerlistSong = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();
                    if (dtPlayerlistSong != null && dtPlayerlistSong.Rows.Count > 0)
                    {
                        gridViewPlaylistSong.DataSource = dtPlayerlistSong;
                        gridViewPlaylistSong.DataBind();
                    }
                    else
                    {
                        dtPlayerlistSong.Rows.Add(dtPlayerlistSong.NewRow());
                        gridViewPlaylistSong.DataSource = dtPlayerlistSong;
                        gridViewPlaylistSong.DataBind();
                        int columncount = gridViewPlaylistSong.Rows[0].Cells.Count;
                        gridViewPlaylistSong.Rows[0].Cells.Clear();
                        gridViewPlaylistSong.Rows[0].Cells.Add(new TableCell());
                        gridViewPlaylistSong.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewPlaylistSong.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                    return;
                }


            }
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
        protected void gridViewSong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                Label lblId = row.FindControl("lblId") as Label;
                int songId = Convert.ToInt32(lblId.Text);

                //Label lblPlaylistId = gridViewPlaylist.SelectedRow.FindControl("lblId") as Label;
                //int playlistId = Convert.ToInt32(lblPlaylistId.Text);
                using (var client = new System.Net.WebClient())
                {
                    try
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        //checkExistPlaylistSong?playlistId=6&songId=6
                        string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistPlaylistSong";
                        url += "?playlistId=" + playlistId + "&songId=" + songId;
                        string response = client.UploadString(url, "POST", "");
                        // int result = new BL_BytesMusic.PlaylistSong(strConnString).CheckExist(playlistId, songId);
                        int result = Int32.Parse(response);

                        if (result != 0)
                        {
                            lblMessage.Text = "Song already added!";
                            return;
                        }

                        //new BL_BytesMusic.PlaylistSong(strConnString).Save(playlistId, songId);
                        string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/savePlaylistSong";
                        urlSave += "/" + playlistId + "/" + songId;
                        var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                        request.Accept = "application/json";
                        request.ContentType = "application/json";
                        request.Method = "POST";
                        var responseSave = request.GetResponse();
                        var stream = responseSave.GetResponseStream();
                        var sr = new StreamReader(stream);
                        BindDataPlaylistSong(playlistId);
                        lblMessage.Text = "Se agrego correctamente la canción.";

                    }
                    catch (Exception exp)
                    {
                        lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                        return;
                    }
                }
            }
        }
    }
}