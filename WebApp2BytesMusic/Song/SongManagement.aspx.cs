using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using WebApp2BytesMusic.E_BytesMusic;
using WebApp2BytesMusic.Util;

namespace WebApp2BytesMusic.Song
{
    public partial class SongManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            lblMessage.Text = string.Empty;
        }
        private void BindData()
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
                    return;
                }

            }
        }
        protected void gridViewSong_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridViewSong.EditIndex)
            {
            }
        }

        protected void gridViewSong_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewSong.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void gridViewSong_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewSong.EditIndex = -1;
            BindData();
        }
        protected DataTable setColumnsInNewDataTable()
        {
            DataTable dtSong = new DataTable();
            dtSong.Columns.Add("Id_Song", typeof(int));
            dtSong.Columns.Add("Song_Name", typeof(String));
            dtSong.Columns.Add("Song_Path", typeof(String));
            return dtSong;

        }
        protected void gridViewSong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                try
                {
                    string messageValidations = string.Empty;
                    TextBox txtNewSongName = (TextBox)gridViewSong.FooterRow.FindControl("txtNewSongName");
                    FileUpload fileUploadSong = (FileUpload)gridViewSong.FooterRow.FindControl("fileUploadNewSong");

                    string songName = txtNewSongName.Text;
                    string newSongName = songName.Replace(" ", string.Empty);


                    string strSongFolder = ConfigurationManager.AppSettings["songFolderPath"];
                    string strFileNameExtension = Path.GetExtension(fileUploadSong.FileName);
                    string newFileNameWithExtension = strSongFolder + newSongName + strFileNameExtension;

                    ESong song = new ESong(0, songName, newFileNameWithExtension);

                    // string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                    messageValidations = SongValidations(song);
                    if (messageValidations != string.Empty)
                    {
                        lblMessage.Text = messageValidations;
                        return;
                    }

                    messageValidations = new FileManagement().SaveSongOnServer(fileUploadSong, strSongFolder, newSongName);
                    if (messageValidations != string.Empty)
                    {
                        lblMessage.Text = messageValidations;
                        return;
                    }
                    //SAVE
                    string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/saveSong";
                    var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                    request.Accept = "application/json";
                    request.ContentType = "application/json";
                    request.Method = "POST";
                    string requestJson = JsonConvert.SerializeObject(song);
                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    Stream newStream = request.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream);
                    //   new BL_BytesMusic.Song(strConnString).Save(song);
                    lblMessage.Text = string.Empty;
                    BindData();
                    lblMessage.Text = "Se ingreso correctamente la canción";


                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                    return;
                }

            }

        }
        protected void gridViewSong_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string messageValidations = string.Empty;
            Label lblId = gridViewSong.Rows[e.RowIndex].FindControl("lblId") as Label;
            TextBox txtSongName = (TextBox)gridViewSong.Rows[e.RowIndex].FindControl("txtSongName");
            FileUpload fileUploadSong = (FileUpload)gridViewSong.Rows[e.RowIndex].FindControl("fileUploadSong");

            int songId = System.Convert.ToInt32(lblId.Text);
            string songName = txtSongName.Text;
            string newSongName = songName.Replace(" ", string.Empty);

            string strSongFolder = ConfigurationManager.AppSettings["songFolderPath"];
            string strFileNameExtension = Path.GetExtension(fileUploadSong.FileName).ToLower();
            string newFileNameWithExtension = strSongFolder + newSongName + strFileNameExtension;

            ESong song = new ESong(songId, songName, newFileNameWithExtension);

            if (song.Song_Name == string.Empty)
            {
                lblMessage.Text = "Song Name is required!";
                return;
            }

            messageValidations = new FileManagement().SaveSongOnServer(fileUploadSong, strSongFolder, newSongName);
            if (messageValidations != string.Empty)
            {
                lblMessage.Text = messageValidations;
                return;
            }
            try
            {
                string urlUpdate = ConfigurationManager.AppSettings["apiGateway"] + "/updateSong";
                var request = (HttpWebRequest)WebRequest.Create(new Uri(urlUpdate));

                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "PUT";
                string requestJson = JsonConvert.SerializeObject(song);
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);

                //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                //new BL_BytesMusic.Song(strConnString).Update(song);

                lblMessage.Text = string.Empty;
                gridViewSong.EditIndex = -1;
                BindData();
                lblMessage.Text = "Se actualizo correctamente la canción";
            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                return;
            }
        }

        protected void gridViewSong_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int id = Convert.ToInt32(gridViewSong.DataKeys[e.RowIndex].Values[0]);
            //new ServiceReferenceSong.SongSoapClient().Delete(id);
            //BindData();
            try
            {
                int id = System.Convert.ToInt32(gridViewSong.DataKeys[e.RowIndex].Values[0]);
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deleteSong";
                url += "/" + id;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                //new BL_BytesMusic.Song(strConnString).Delete(id);
                BindData();
                lblMessage.Text = "Se elimino correctamente la canción";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                return;
            }
        }
        public string SongValidations(ESong song)
        {
            if (song.Song_Name == string.Empty)
            {
                return "Song Name is required!"; ;
            }
            using (var client = new System.Net.WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string urlSong = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistSong/" + song.Song_Name;
                    string songResponse = client.DownloadString(urlSong);
                    int returnValue = Int32.Parse(songResponse);
                    if (returnValue != 0)
                    {
                        return "Song already exist!";
                    }
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    return "Error en el servidor intentelo en unos momentos";


                }

            }
        }

    }
}