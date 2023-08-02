using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;

namespace WebApp2BytesMusic.Player
{
    public partial class PlayerManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataArtist();
                BindDataSong();
            }
            lblMessage.Text = string.Empty;
        }
        private void BindDataArtist()
        {
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readArtist";
            DataTable dtArtist = new DataTable();
            using (var client = new WebClient())
            {
                try
                {
                    // DataTable dtArtist = new BL_BytesMusic.Artist(strConnString).ReadArtist();
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);
                    dtArtist = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewPlayerDataTable();
                    if (dtArtist != null && dtArtist.Rows.Count > 0)
                    {
                        gridViewArtist.DataSource = dtArtist;
                        gridViewArtist.DataBind();
                    }
                    else
                    {
                        dtArtist.Rows.Add(dtArtist.NewRow());
                        gridViewArtist.DataSource = dtArtist;
                        gridViewArtist.DataBind();
                        int columncount = gridViewArtist.Rows[0].Cells.Count;
                        gridViewArtist.Rows[0].Cells.Clear();
                        gridViewArtist.Rows[0].Cells.Add(new TableCell());
                        gridViewArtist.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewArtist.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                    return;
                }

            }
        }
        private void BindDataSong()
        {
            //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            //DataTable dtSongS = new BL_BytesMusic.Song(strConnString).Read();
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
        protected void gridViewArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewArtist.Rows)
            {
                if (row.RowIndex == gridViewArtist.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
            Label lblId = gridViewArtist.SelectedRow.FindControl("lblId") as Label;
            int artistId = Convert.ToInt32(lblId.Text);
            BindDataArtistSong(artistId);
        }

        protected void gridViewSong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                if (gridViewArtist.SelectedRow == null)
                {
                    lblMessage.Text = "Select an Artist, first!";
                    return;
                }
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                Label lblId = row.FindControl("lblId") as Label;
                int songId = Convert.ToInt32(lblId.Text);

                Label lblIdArtist = gridViewArtist.SelectedRow.FindControl("lblId") as Label;
                int artistId = Convert.ToInt32(lblIdArtist.Text);

                using (var client = new System.Net.WebClient())
                {
                    try
                    {
                        string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistPlayer";
                        url += "?idArtist=" + artistId + "&idSong=" + songId;
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        string response = client.UploadString(url, "POST", "");

                        // int result = new BL_BytesMusic.Player(strConnString).CheckExist(artistId, songId);
                        int result = Int32.Parse(response);
                        if (result != 0)
                        {
                            lblMessage.Text = "Song already added!";
                            return;
                        }

                        //new BL_BytesMusic.Player(strConnString).Save(artistId, songId);
                        string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/savePlayer";
                        urlSave += "/" + artistId + "/" + songId;
                        var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                        request.Accept = "application/json";
                        request.ContentType = "application/json";
                        request.Method = "POST";
                        var responseSave = request.GetResponse();
                        var stream = responseSave.GetResponseStream();
                        var sr = new StreamReader(stream);
                        lblMessage.Text = "Se agrego la canción correctamente";
                    }
                    catch (Exception exp)
                    {
                        lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                        return;
                    }
                }




                BindDataArtistSong(artistId);
            
        }
        }

        protected void gridViewArtistSong_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idSong = Convert.ToInt32(gridViewArtistSong.DataKeys[e.RowIndex].Values[0]);

            Label lblIdArtist = gridViewArtist.SelectedRow.FindControl("lblId") as Label;
            int artistId = Convert.ToInt32(lblIdArtist.Text);

            string url = ConfigurationManager.AppSettings["apiGateway"] + "/deleteSongOnPlayer";
            url += "/" + artistId + "/" + idSong;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                lblMessage.Text = "Se elimino la canción correctamente";
            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;
            }
            // new BL_BytesMusic.Player(strConnString).Delete(artistId, idSong);

            BindDataArtistSong(artistId);
        }
        private void BindDataArtistSong(int idArtist)
        {
            try
            {
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/readPlayer";
                url += "/" + idArtist;
                DataTable dtPlayer = new DataTable();

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.UploadString(url, "POST", "");
                    dtPlayer = response != "" && response != "[]"? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();
                    if (dtPlayer != null && dtPlayer.Rows.Count > 0)
                    {
                        gridViewArtistSong.DataSource = dtPlayer;
                        gridViewArtistSong.DataBind();
                    }
                    else
                    {
                        dtPlayer.Rows.Add(dtPlayer.NewRow());
                        gridViewArtistSong.DataSource = dtPlayer;
                        gridViewArtistSong.DataBind();
                        int columncount = gridViewArtistSong.Rows[0].Cells.Count;
                        gridViewArtistSong.Rows[0].Cells.Clear();
                        gridViewArtistSong.Rows[0].Cells.Add(new TableCell());
                        gridViewArtistSong.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewArtistSong.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;

            }
        }
        protected DataTable setColumnsInNewPlayerDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id_Artist", typeof(int));
            dt.Columns.Add("Artist_Name", typeof(String));
            dt.Columns.Add("Artist_Lastname", typeof(String));
            dt.Columns.Add("Artist_Image", typeof(String));

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
    }
}