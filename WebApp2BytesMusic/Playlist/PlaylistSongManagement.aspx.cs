using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using WebApp2BytesMusic.E_BytesMusic;
using WebApp2BytesMusic.Util;

namespace WebApp2BytesMusic.Playlist
{
    public partial class PlaylistSongManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataUser();
            }
            lblMessage.Text = string.Empty;
        }
        //private void BindDataUser()
        //{
        //    DataTable dtUser = new ServiceReferenceUser.UserSoapClient().Read();

        //    if (dtUser != null && dtUser.Rows.Count > 0)
        //    {
        //        gridViewUser.DataSource = dtUser;
        //        gridViewUser.DataBind();
        //    }
        //    else
        //    {
        //        dtUser.Rows.Add(dtUser.NewRow());
        //        gridViewUser.DataSource = dtUser;
        //        gridViewUser.DataBind();
        //        int columncount = gridViewUser.Rows[0].Cells.Count;
        //        gridViewUser.Rows[0].Cells.Clear();
        //        gridViewUser.Rows[0].Cells.Add(new TableCell());
        //        gridViewUser.Rows[0].Cells[0].ColumnSpan = columncount;
        //        gridViewUser.Rows[0].Cells[0].Text = "No Records Found";
        //    }
        //}
        private void BindDataUser()
        {
            try
            {
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/readUser";
                DataTable dtUser = new DataTable();
                using (var client = new WebClient())
                {

                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);

                    dtUser = response != "" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();
                    if (dtUser != null && dtUser.Rows.Count > 0)
                    {
                        gridViewUser.DataSource = dtUser;
                        gridViewUser.DataBind();
                    }
                    else
                    {
                        dtUser.Rows.Add(dtUser.NewRow());
                        gridViewUser.DataSource = dtUser;
                        gridViewUser.DataBind();
                        int columncount = gridViewUser.Rows[0].Cells.Count;
                        gridViewUser.Rows[0].Cells.Clear();
                        gridViewUser.Rows[0].Cells.Add(new TableCell());
                        gridViewUser.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewUser.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;

            }
        }
        protected DataTable setColumnsInNewDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_USER", typeof(int));
            dt.Columns.Add("USERNAME", typeof(String));
            dt.Columns.Add("EMAIL", typeof(String));
            dt.Columns.Add("PASSWORD", typeof(String));
            dt.Columns.Add("BIRTHDAY", typeof(String));
            dt.Columns.Add("USER_PHOTO", typeof(String));
            return dt;

        }
     protected DataTable setColumnsInNewPlaylistDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_PLAYLIST", typeof(int));
            dt.Columns.Add("TITLE", typeof(String));
            dt.Columns.Add("CREATION_DATE", typeof(String));
            dt.Columns.Add("type", typeof(int));
            dt.Columns.Add("PHOTO", typeof(String));

            return dt;

        }
        protected void gridViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewUser.Rows)
            {
                if (row.RowIndex == gridViewUser.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
            Label lblId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
            int userId = Convert.ToInt32(lblId.Text);
            BindDataPlaylist(userId);
            gridViewSong.DataSource = null;
            gridViewSong.DataBind();
            gridViewPlaylistSong.DataSource = null;
            gridViewPlaylistSong.DataBind();
        }
        private void BindDataPlaylist(int userId)
        {
            //DataTable dtPlayerlist = new ServiceReferencePlaylist.PlaylistSoapClient().ReadById(userId);

            //if (dtPlayerlist != null && dtPlayerlist.Rows.Count > 0)
            //{
            //    gridViewPlaylist.DataSource = dtPlayerlist;
            //    gridViewPlaylist.DataBind();
            //}
            //else
            //{
            //    dtPlayerlist.Rows.Add(dtPlayerlist.NewRow());
            //    gridViewPlaylist.DataSource = dtPlayerlist;
            //    gridViewPlaylist.DataBind();
            //    int columncount = gridViewPlaylist.Rows[0].Cells.Count;
            //    gridViewPlaylist.Rows[0].Cells.Clear();
            //    gridViewPlaylist.Rows[0].Cells.Add(new TableCell());
            //    gridViewPlaylist.Rows[0].Cells[0].ColumnSpan = columncount;
            //    gridViewPlaylist.Rows[0].Cells[0].Text = "No Records Found";
            //}
             //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            //DataTable dtPlayerlist = new BL_BytesMusic.Playlist(strConnString).Read(userId);
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readPlaylist";
            url += "/" + userId;
            DataTable dtPlayerlist = new DataTable();
            using (var client = new WebClient())
            {


                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";
                string response = client.DownloadString(url);
                dtPlayerlist = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewPlaylistDataTable();
                if (dtPlayerlist != null && dtPlayerlist.Rows.Count > 0)
                {
                    gridViewPlaylist.DataSource = dtPlayerlist;
                    gridViewPlaylist.DataBind();
                }
                else
                {
                    dtPlayerlist.Rows.Add(dtPlayerlist.NewRow());
                    gridViewPlaylist.DataSource = dtPlayerlist;
                    gridViewPlaylist.DataBind();
                    int columncount = gridViewPlaylist.Rows[0].Cells.Count;
                    gridViewPlaylist.Rows[0].Cells.Clear();
                    gridViewPlaylist.Rows[0].Cells.Add(new TableCell());
                    gridViewPlaylist.Rows[0].Cells[0].ColumnSpan = columncount;
                    gridViewPlaylist.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        protected void gridViewPlaylist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)// && e.Row.RowIndex != gridViewUser.EditIndex)
            {
                DropDownList ddList = (DropDownList)e.Row.FindControl("ddlType");
                //DataTable dt = new ServiceReferenceCatalog.CatalogSoapClient().GetPlaylistType();
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/getPlaylistType";
                DataTable dt = new DataTable();
                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        string response = client.DownloadString(url);
                        dt = response != "" ? Util.DataConvert.JSONToDataTable(response) : null;

                        ddList.DataSource = dt;
                        ddList.DataTextField = "VALUE";
                        ddList.DataValueField = "COD_CATALOG";
                        ddList.DataBind();
                        DataRowView dr = e.Row.DataItem as DataRowView;
                        ddList.SelectedValue = dr["TYPE"].ToString();
                    }catch(Exception exp)
                    {
                        return;
                    }
                   
                }
                    
            }


        }

        protected void gridViewPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewPlaylist.Rows)
            {
                if (row.RowIndex == gridViewPlaylist.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
            Label lblUserId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
            int userId = Convert.ToInt32(lblUserId.Text);
            Label lblPlaylistId = gridViewPlaylist.SelectedRow.FindControl("lblId") as Label;
            int playlistId = Convert.ToInt32(lblPlaylistId.Text);
            BindDataSong();
            BindDataPlaylistSong(playlistId);
        }
        protected void gridViewPlaylist_OnDataBound(object sender, EventArgs e)
        {
            DropDownList ddlPlaylistTypes = gridViewPlaylist.FooterRow.FindControl("ddlNewType") as DropDownList;
            //DataTable dt = new ServiceReferenceCatalog.CatalogSoapClient().GetPlaylistType();
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/getPlaylistType";
            DataTable dt = new DataTable();
            using (var client = new WebClient())
            {
                try

                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);
                    dt = response != "" ? Util.DataConvert.JSONToDataTable(response) : null;
                    ddlPlaylistTypes.DataSource = dt;
                    ddlPlaylistTypes.DataTextField = "VALUE";
                    ddlPlaylistTypes.DataValueField = "COD_CATALOG";
                    ddlPlaylistTypes.DataBind();
                }
                catch(Exception exp)
                {
                    return;
                }
            }
                
            //ddlPlaylistTypes.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void gridViewPlaylist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewPlaylist.EditIndex = e.NewEditIndex;
            Label lblUserId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
            int userId = Convert.ToInt32(lblUserId.Text);
            BindDataPlaylist(userId);
        }
        protected void gridViewPlaylist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewPlaylist.EditIndex = -1;
            Label lblUserId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
            int userId = Convert.ToInt32(lblUserId.Text);
            BindDataPlaylist(userId);
        }

        protected void gridViewPlaylist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string messageValidations = string.Empty;
                Label lblUserId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
                int userId = Convert.ToInt32(lblUserId.Text);
                TextBox txtNewTitle = (TextBox)gridViewPlaylist.FooterRow.FindControl("txtNewTitle");
                TextBox txtNewCreationDate = (TextBox)gridViewPlaylist.FooterRow.FindControl("txtNewCreationDate");
                //TextBox txtNewType = (TextBox)gridViewPlaylist.FooterRow.FindControl("txtNewType");
                DropDownList ddlNewType = (DropDownList)gridViewPlaylist.FooterRow.FindControl("ddlNewType");
                FileUpload fileUploadNewPlaylistPhoto = (FileUpload)gridViewPlaylist.FooterRow.FindControl("fileUploadNewPlaylistPhoto");
                string title = txtNewTitle.Text;
                string creationDate = string.Empty;
                if (txtNewCreationDate.Text != string.Empty)
                    creationDate = DateTime.ParseExact(txtNewCreationDate.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                //string typeDescription = txtNewType.Text;
                //int type = (typeDescription == "Public") ? 0 : 1;
                int type = Convert.ToInt32(ddlNewType.SelectedValue);
                string newImageName = title.Replace(" ", string.Empty);

                string strImageFolder = ConfigurationManager.AppSettings["playlistFolderPath"];
                string strFileNameExtension = Path.GetExtension(fileUploadNewPlaylistPhoto.FileName);
                string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

                EPlaylist playList = new EPlaylist();
                playList.Id_User = userId;
                playList.Title = title;
                playList.Creation_Date = creationDate;
                playList.Type = type;
                playList.Photo = newFileNameWithExtension;

                messageValidations = Validator.FieldsRequiredValidations(playList);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }
                try
                {
                    //int retorno = new BL_BytesMusic.Playlist(strConnString).CheckExist(playList);
                    string urlCheck = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistPlaylist";
                    var request = (HttpWebRequest)WebRequest.Create(new Uri(urlCheck));
                    request.Accept = "application/json";
                    request.ContentType = "application/json";
                    request.Method = "POST";
                    string requestJson = JsonConvert.SerializeObject(playList);
                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    Stream newStream = request.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream).ReadToEnd(); ;
                    int retorno = Int32.Parse(sr);
                    if (retorno != 0)
                    {
                        lblMessage.Text = "Title is already used";
                        return;
                    }
                    if (fileUploadNewPlaylistPhoto.HasFile)
                    {
                        messageValidations = new FileManagement().SaveImageOnServer(fileUploadNewPlaylistPhoto, strImageFolder, newImageName);
                    }
                    else
                    {
                        messageValidations = new FileManagement().SaveDefaultImageOnServer(strImageFolder, newImageName);
                        playList.Photo += ".jpg";
                    }
                    if (messageValidations != string.Empty)
                    {
                        lblMessage.Text = messageValidations;
                        return;
                    }


                    //new BL_BytesMusic.Playlist(strConnString).Save(playList);
                    string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/savePlaylist";
                    var requestSave = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                    requestSave.Accept = "application/json";
                    requestSave.ContentType = "application/json";
                    requestSave.Method = "POST";
                    string requestJsonSave = JsonConvert.SerializeObject(playList);
                    byte[] bytesSave = Encoding.UTF8.GetBytes(requestJsonSave);
                    Stream newStreamSave = requestSave.GetRequestStream();
                    newStreamSave.Write(bytesSave, 0, bytesSave.Length);
                    newStreamSave.Close();
                    var responseSave = requestSave.GetResponse();
                    var streamSave = responseSave.GetResponseStream();
                    var srSave = new StreamReader(stream).ReadToEnd();
                    lblMessage.Text = "Se guardo correctamente la playlist";


                    BindDataPlaylist(userId);
                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                    return;
                }
            }
        }
        protected void gridViewPlaylist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string messageValidations = string.Empty;
            Label lblUserId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
            int userId = System.Convert.ToInt32(lblUserId.Text);
            Label lblId = gridViewPlaylist.Rows[e.RowIndex].FindControl("lblId") as Label;
            TextBox txtTitle = (TextBox)gridViewPlaylist.Rows[e.RowIndex].FindControl("txtTitle");
            TextBox txtCreationDate = (TextBox)gridViewPlaylist.Rows[e.RowIndex].FindControl("txtCreationDate");
            //TextBox txtType = (TextBox)gridViewPlaylist.Rows[e.RowIndex].FindControl("txtType");
            DropDownList ddlType = (DropDownList)gridViewPlaylist.Rows[e.RowIndex].FindControl("ddlType");
            System.Web.UI.WebControls.Image imageEditPlaylistPhoto = (System.Web.UI.WebControls.Image)gridViewPlaylist.Rows[e.RowIndex].FindControl("imageEditPlaylistPhoto");
            FileUpload fileUploadPlaylistPhoto = (FileUpload)gridViewPlaylist.Rows[e.RowIndex].FindControl("fileUploadPlaylistPhoto");

            int playlistId = System.Convert.ToInt32(lblId.Text);
            string title = txtTitle.Text;
            //string typeDescription = txtType.Text;
            //int type = (typeDescription == "Public") ? 0 : 1;
            int type = System.Convert.ToInt32(ddlType.SelectedValue);
            string creationDate = string.Empty;
            //if (txtCreationDate.Text != string.Empty)
            //    creationDate = DateTime.ParseExact(txtCreationDate.Text, "dd/MM/yyyy", null).ToString();
            DateTime dateValue;
            if (DateTime.TryParseExact(txtCreationDate.Text, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                creationDate = dateValue.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            else if (DateTime.TryParseExact(txtCreationDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                creationDate = dateValue.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            if (creationDate == "") creationDate = txtCreationDate.Text;



            string newImageName = title.Replace(" ", string.Empty);

            string strImageFolder = ConfigurationManager.AppSettings["playlistFolderPath"];
            string strFileNameExtension = Path.GetExtension(fileUploadPlaylistPhoto.FileName);
            string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

            EPlaylist playList = new EPlaylist();
            playList.Id_Playlist = playlistId;
            playList.Id_User = userId;
            playList.Title = title;
            playList.Creation_Date = creationDate;
            playList.Type = type;
            if (fileUploadPlaylistPhoto.HasFile)
            {
                playList.Photo = newFileNameWithExtension;
            }
            else
            {
                playList.Photo = imageEditPlaylistPhoto.ImageUrl;
            }

            //    string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            messageValidations = Validator.FieldsRequiredValidations(playList);
            if (messageValidations != string.Empty)
            {
                lblMessage.Text = messageValidations;
                return;
            }
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistPlaylist";
            var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "POST";
            string requestJson = JsonConvert.SerializeObject(playList);
            byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();
            newStream.Dispose();
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream).ReadToEnd();

            int retorno = Int32.Parse(sr);
            //int retorno = new BL_BytesMusic.Playlist(strConnString).CheckExist(playList);
            if (retorno != 0)
            {
                lblMessage.Text = "Title is already used";
                return;
            }
            if (fileUploadPlaylistPhoto.HasFile)
            {
                messageValidations = new FileManagement().SaveImageOnServer(fileUploadPlaylistPhoto, strImageFolder, newImageName);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }
            }

            //new BL_BytesMusic.Playlist(strConnString).Update(playList);
            string urlUpdate = ConfigurationManager.AppSettings["apiGateway"] + "/updatePlaylist";
            var requestUpdate = (HttpWebRequest)WebRequest.Create(new Uri(urlUpdate));
            requestUpdate.Accept = "application/json";
            requestUpdate.ContentType = "application/json";
            requestUpdate.Method = "PUT";
            string requestJsonUpdate = JsonConvert.SerializeObject(playList);
            byte[] bytesUpdate = Encoding.UTF8.GetBytes(requestJsonUpdate);
            Stream newStreamUpdate = requestUpdate.GetRequestStream();
            newStreamUpdate.Write(bytesUpdate, 0, bytesUpdate.Length);
            newStreamUpdate.Close();
            var responseUpdate = requestUpdate.GetResponse();
            var streamUpdate = responseUpdate.GetResponseStream();
            var srUpdate = new StreamReader(stream).ReadToEnd();
            //new BL_BytesMusic.Playlist(strConnString).Save(playList);
            lblMessage.Text = string.Empty;


            gridViewPlaylist.EditIndex = -1;
            BindDataPlaylist(userId);
            lblMessage.Text = "Se actualizo la playlist correctamente.";


        }

        protected void gridViewPlaylist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = System.Convert.ToInt32(gridViewPlaylist.DataKeys[e.RowIndex].Values[0]);
                // string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deletePlaylist";
                url += "/" + id;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                response = (HttpWebResponse)request.GetResponse();
                //new BL_BytesMusic.Playlist(strConnString).Delete(id);

                Label lblUserId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
                int userId = System.Convert.ToInt32(lblUserId.Text);
                BindDataPlaylist(userId);
                lblMessage.Text = "Se elimino la playlist correctamente.";

            }
            catch (Exception exp)
            {

                lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                return;
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
                    return;
                }

            }
        }
        protected void gridViewSong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                /*if (gridViewUser.SelectedRow == null)
                {
                    lblMessage.Text = "Select a user, first!";
                    return;
                }*/
                if (gridViewPlaylist.SelectedRow == null)
                {
                    lblMessage.Text = "Select an Artist, first!";
                    return;
                }
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                Label lblId = row.FindControl("lblId") as Label;
                int songId = Convert.ToInt32(lblId.Text);

                //Label lblUserId = gridViewUser.SelectedRow.FindControl("lblId") as Label;
                //int userId = Convert.ToInt32(lblUserId.Text);
                Label lblPlaylistId = gridViewPlaylist.SelectedRow.FindControl("lblId") as Label;
                int playlistId = Convert.ToInt32(lblPlaylistId.Text);

                //int result = new ServiceReferencePlaylistSong.PlaylistSongSoapClient().CheckExist(playlistId, songId);

                //if (result != 0)
                //{
                //    lblMessage.Text = "Song already added!";
                //    return;
                //}

                //new ServiceReferencePlaylistSong.PlaylistSongSoapClient().Save(playlistId, songId);

                //BindDataPlaylistSong(playlistId);
                using (var client = new System.Net.WebClient())
                {
                    try
                    {
                        //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                        
                        //checkExistPlaylistSong?playlistId=6&songId=6
                        string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistPlaylistSong";
                        url += "?playlistId=" + playlistId + "&songId=" + songId;
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        string response = client.UploadString(url,"POST","");
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
                        lblMessage.Text = "Se agrego correctamente la cancion";

                    }
                    catch (Exception exp)
                    {
                        lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                        return;
                    }
                }
            }
        }
        protected void gridViewPlaylistSong_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gridViewPlaylist.SelectedDataKey == null)
            {
                lblMessage.Text = "Select an Playlist, first!";
                return;
            }
            Label lblPlaylistId = gridViewPlaylist.SelectedRow.FindControl("lblId") as Label;
            int playlistId = Convert.ToInt32(lblPlaylistId.Text);

            int songId = Convert.ToInt32(gridViewPlaylistSong.DataKeys[e.RowIndex].Values[0]);
            try
            {
              

                // string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deletePlaylistSong";
                url += "/" + playlistId + "/" + songId;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                //new BL_BytesMusic.Player(strConnString).Delete(playerId, songId);

                BindDataPlaylistSong(playlistId);
                lblMessage.Text = "Se elimino correctamente la cancion";

            }
            catch (Exception exp)
            {
                return;
            }
        }
        private void BindDataPlaylistSong(int playlistId)
        {
            try
            {
                DataTable dtPlayerlistSong = new DataTable();
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/readPlaylistSong/"+playlistId;

                var client = new WebClient();

                // Establecer las cabeceras de la solicitud
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";
                string response = client.UploadString(url, "POST", "");



                dtPlayerlistSong = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();
                //DataTable dtPlayerlistSong = new BL_BytesMusic.PlaylistSong(strConnString).Read(playlistId);

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
                return;
            }


        }
    }
}