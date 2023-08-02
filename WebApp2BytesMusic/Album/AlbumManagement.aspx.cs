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

namespace WebApp2BytesMusic.Album
{
    public partial class AlbumManagement : System.Web.UI.Page
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
            try
            {
                //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                //DataTable dtAlbum = new BL_BytesMusic.Album(strConnString).Read();
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/readAlbum";
                DataTable dtAlbum = new DataTable();
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);

                    dtAlbum = response != "" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();
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
            dt.Columns.Add("ID_ALBUM", typeof(int));
            dt.Columns.Add("TITLE_ALBUM", typeof(String));
            dt.Columns.Add("RELEASE_YEAR", typeof(String));
            dt.Columns.Add("ALBUM_IMAGE_PATH", typeof(String));

            return dt;

        }
        protected void gridViewAlbum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridViewAlbum.EditIndex)
            {
                //Label lblId = gridViewAlbum.Rows[e.RowIndex].FindControl("lblId") as Label;
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void gridViewAlbum_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewAlbum.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void gridViewAlbum_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewAlbum.EditIndex = -1;
            BindData();
        }

        protected void gridViewAlbum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string messageValidations = string.Empty;
                TextBox txtNewAlbumTitle = (TextBox)gridViewAlbum.FooterRow.FindControl("txtNewAlbumTitle");
                TextBox txtNewReleaseYear = (TextBox)gridViewAlbum.FooterRow.FindControl("txtNewReleaseYear");
                FileUpload fileUploadAlbumPhoto = (FileUpload)gridViewAlbum.FooterRow.FindControl("fileUploadNewAlbumPhoto");
                string albumTitle = txtNewAlbumTitle.Text;
                string releaseYear = txtNewReleaseYear.Text;
                string newImageName = albumTitle.Replace(" ", string.Empty);

                string strImageFolder = ConfigurationManager.AppSettings["albumImagePath"];
                string strFileNameExtension = Path.GetExtension(fileUploadAlbumPhoto.FileName);
                string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

                EAlbum album = new EAlbum();
                album.Title_Album = albumTitle;
                album.Release_Year = releaseYear;
                album.Album_Image_Path = newFileNameWithExtension;

                messageValidations = AlbumValidations(album);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }

                messageValidations = new FileManagement().SaveImageOnServer(fileUploadAlbumPhoto, strImageFolder, newImageName);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }

                try
                {
                    string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/saveAlbum";
                    var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                    request.Accept = "application/json";
                    request.ContentType = "application/json";
                    request.Method = "POST";
                    string requestJson = JsonConvert.SerializeObject(album);
                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    Stream newStream = request.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream);
                    // new BL_BytesMusic.User(strConnString).Save(user);
                    lblMessage.Text = string.Empty;
                    BindData();
                    lblMessage.Text = "Se Agrego correctamente el album";

                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo más tarde";

                }
            }
        }
        protected void gridViewAlbum_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string messageValidations = string.Empty;
            Label lblId = gridViewAlbum.Rows[e.RowIndex].FindControl("lblId") as Label;
            TextBox txtAlbumTitle = (TextBox)gridViewAlbum.Rows[e.RowIndex].FindControl("txtAlbumTitle");
            TextBox txtReleaseYear = (TextBox)gridViewAlbum.Rows[e.RowIndex].FindControl("txtReleaseYear");
            FileUpload fileUploadAlbumPhoto = (FileUpload)gridViewAlbum.Rows[e.RowIndex].FindControl("fileUploadAlbumPhoto");

            int albumId = Convert.ToInt32(lblId.Text);
            string albumTitle = txtAlbumTitle.Text;
            string releaseYear = txtReleaseYear.Text;
            string newImageName = albumTitle.Replace(" ", string.Empty);

            string strImageFolder = ConfigurationManager.AppSettings["albumImagePath"];
            string strFileNameExtension = Path.GetExtension(fileUploadAlbumPhoto.FileName);
            string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

            EAlbum album = new EAlbum();
            album.Id_Album = albumId;
            album.Title_Album = albumTitle;
            album.Release_Year = releaseYear;
            album.Album_Image_Path = newFileNameWithExtension;
            
            if (album.Title_Album == string.Empty)
            {
                lblMessage.Text = "Album Title is required!";
                return;
            }

            messageValidations = new FileManagement().SaveImageOnServer(fileUploadAlbumPhoto, strImageFolder, newImageName);
            if (messageValidations != string.Empty)
            {
                lblMessage.Text = messageValidations;
                return;
            }

            try
            {
                string urlUpdate = ConfigurationManager.AppSettings["apiGateway"] + "/updateAlbum";
                var request = (HttpWebRequest)WebRequest.Create(new Uri(urlUpdate));

                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "PUT";
                string requestJson = JsonConvert.SerializeObject(album);
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                lblMessage.Text = string.Empty;
                gridViewAlbum.EditIndex = -1;
                BindData();
                lblMessage.Text = "Se actualizo correctamente el album";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;

            }
           
        }

        protected void gridViewAlbum_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = System.Convert.ToInt32(gridViewAlbum.DataKeys[e.RowIndex].Values[0]);

                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deleteAlbum";
                url += "/" + id;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                lblMessage.Text = "Se elimino correctamente el album";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;
            }

            BindData();
        }
        public string AlbumValidations(EAlbum album)
        {
            if (album.Title_Album == string.Empty)
            {
                return "Album Title is required!";
            }
            var client = new System.Net.WebClient();
               client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers[HttpRequestHeader.Accept] = "application/json";
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistAlbum/" + album.Title_Album;
            string response = client.DownloadString(url);

            int returnValue = int.Parse(response);
            if (returnValue != 0)
            {
                return "Album already exist!";
            }
            if (album.Release_Year != string.Empty && ! Util.Validator.IsDigitsOnly(album.Release_Year))
            {
                return "Release Year must be a number!";
            }
            return string.Empty;
        }
    }
}