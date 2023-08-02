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

namespace WebApp2BytesMusic.Artist
{
    public partial class ArtistManagement : System.Web.UI.Page
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
            //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readArtist";
            DataTable dtArtist = new DataTable();
            using (var client = new WebClient())
            {
                //DataTable dtArtist = new BL_BytesMusic.Artist(strConnString).ReadArtist();
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);
                    dtArtist = response != "" && response != "[]" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();

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
        protected DataTable setColumnsInNewDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_ARTIST", typeof(int));
            dt.Columns.Add("ARTIST_NAME", typeof(String));
            dt.Columns.Add("ARTIST_LASTNAME", typeof(String));
            dt.Columns.Add("ARTIST_IMAGE", typeof(String));
            return dt;

        }
        protected void gridViewArtist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridViewArtist.EditIndex)
            {
                //Label lblId = gridViewArtist.Rows[e.RowIndex].FindControl("lblId") as Label;
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void gridViewArtist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewArtist.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void gridViewArtist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewArtist.EditIndex = -1;
            BindData();
        }

        protected void gridViewArtist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string messageValidations = string.Empty;
                TextBox txtNewName = (TextBox)gridViewArtist.FooterRow.FindControl("txtNewName");
                TextBox txtNewLastName = (TextBox)gridViewArtist.FooterRow.FindControl("txtNewLastName");
                FileUpload fileUploadArtistPhoto = (FileUpload)gridViewArtist.FooterRow.FindControl("fileUploadNewArtistPhoto");
                string firstName = txtNewName.Text;
                string lastName = txtNewLastName.Text;
                string newImageName = firstName + "_" + lastName;

                string strImageFolder = ConfigurationManager.AppSettings["artistImagePath"];
                string strFileNameExtension = Path.GetExtension(fileUploadArtistPhoto.FileName);
                string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

                EArtist artist = new EArtist();
                artist.Artist_Name = firstName;
                artist.Artist_LastName = lastName;
                artist.Artist_Image = newFileNameWithExtension;
                messageValidations = Validator.ArtistValidations(artist);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }

                messageValidations = new FileManagement().SaveImageOnServer(fileUploadArtistPhoto, strImageFolder, newImageName);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }
                try
                {
                    string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/saveArtist";
                    var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                    request.Accept = "application/json";
                    request.ContentType = "application/json";
                    request.Method = "POST";
                    string requestJson = JsonConvert.SerializeObject(artist);
                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    Stream newStream = request.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream);
                    BindData();
                    lblMessage.Text = "Se guardo correctamente el artista";

                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                    return;
                }
                
            }
        }
        protected void gridViewArtist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string messageValidations = string.Empty;
            Label lblId = gridViewArtist.Rows[e.RowIndex].FindControl("lblId") as Label;
            TextBox txtFirstName = gridViewArtist.Rows[e.RowIndex].FindControl("txtName") as TextBox;
            TextBox txtLastName = gridViewArtist.Rows[e.RowIndex].FindControl("txtLastName") as TextBox;
            FileUpload fileUploadArtistPhoto = (FileUpload)gridViewArtist.Rows[e.RowIndex].FindControl("fileUploadArtistPhoto");

            int artistId = Convert.ToInt32(lblId.Text);
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string newImageName = firstName + "_" + lastName;

            string strImageFolder = ConfigurationManager.AppSettings["artistImagePath"];
            string strFileNameExtension = Path.GetExtension(fileUploadArtistPhoto.FileName);
            string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

            EArtist artist = new EArtist();
            artist.Id_Artist = artistId;
            artist.Artist_Name = firstName;
            artist.Artist_LastName = lastName;
            artist.Artist_Image = newFileNameWithExtension;

            if (artist.Artist_Name == string.Empty || artist.Artist_LastName == string.Empty)
            {
                lblMessage.Text = "First and LastName are required!";
                return;
            }

            messageValidations = new FileManagement().SaveImageOnServer(fileUploadArtistPhoto, strImageFolder, newImageName);
            if (messageValidations != string.Empty)
            {
                lblMessage.Text = messageValidations;
                return;
            }
            try
            {
                //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
                //new BL_BytesMusic.Artist(strConnString).UpdateArtist(artist);
                string urlUpdate = ConfigurationManager.AppSettings["apiGateway"] + "/updateArtist";
                var requestUpdate = (HttpWebRequest)WebRequest.Create(new Uri(urlUpdate));
                requestUpdate.Accept = "application/json";
                requestUpdate.ContentType = "application/json";
                requestUpdate.Method = "PUT";
                string requestJsonUpdate = JsonConvert.SerializeObject(artist);
                byte[] bytesUpdate = Encoding.UTF8.GetBytes(requestJsonUpdate);
                Stream newStreamUpdate = requestUpdate.GetRequestStream();
                newStreamUpdate.Write(bytesUpdate, 0, bytesUpdate.Length);
                newStreamUpdate.Close();
                var responseUpdate = requestUpdate.GetResponse();
                var streamUpdate = responseUpdate.GetResponseStream();
                var srUpdate = new StreamReader(streamUpdate).ReadToEnd();
                lblMessage.Text = string.Empty;
                lblMessage.Text = "Se actualizo correctamente el artista";


            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                return;
            }
            gridViewArtist.EditIndex = -1;
            BindData();
        }

        protected void gridViewArtist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int artistId = Convert.ToInt32(gridViewArtist.DataKeys[e.RowIndex].Values[0]);

                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deleteArtist";
                url += "/" + artistId;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                lblMessage.Text = "Artista eliminado correctamente";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                return;

            }
            BindData();
        }
    }
}