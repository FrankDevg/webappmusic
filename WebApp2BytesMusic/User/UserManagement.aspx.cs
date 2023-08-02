using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using WebApp2BytesMusic.E_BytesMusic;
using WebApp2BytesMusic.Util;


namespace WebApp2BytesMusic.User
{
    public partial class UserManagement : System.Web.UI.Page
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
            //DataTable dtUser = new ServiceReferenceUser.UserSoapClient().Read();

            //if (dtUser != null && dtUser.Rows.Count > 0)
            //{
            //    gridViewUser.DataSource = dtUser;
            //    gridViewUser.DataBind();
            //}
            //else
            //{
            //    dtUser.Rows.Add(dtUser.NewRow());
            //    gridViewUser.DataSource = dtUser;
            //    gridViewUser.DataBind();
            //    int columncount = gridViewUser.Rows[0].Cells.Count;
            //    gridViewUser.Rows[0].Cells.Clear();
            //    gridViewUser.Rows[0].Cells.Add(new TableCell());
            //    gridViewUser.Rows[0].Cells[0].ColumnSpan = columncount;
            //    gridViewUser.Rows[0].Cells[0].Text = "No Records Found";
            //}
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
        protected void gridViewUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)// && e.Row.RowIndex != gridViewUser.EditIndex)
            {
                DropDownList ddList = (DropDownList)e.Row.FindControl("ddlType");
                //TODO: Cambiar por endpoint microservice CATALOG
                //DataTable dt = new ServiceReferenceCatalog.CatalogSoapClient().GetUserType();
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/getUserType";
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
                        ddList.SelectedValue = dr["USER_TYPE"].ToString();
                    }catch(Exception exp)
                    {
                        return;
                    }
                }
                
            }
        }
        protected void gridViewUser_OnDataBound(object sender, EventArgs e)
        {
            //DropDownList ddlUserType = gridViewUser.FooterRow.FindControl("ddlNewType") as DropDownList;
            //DataTable dt = new ServiceReferenceCatalog.CatalogSoapClient().GetUserType();
            //ddlUserType.DataSource = dt;
            //ddlUserType.DataTextField = "VALUE";
            //ddlUserType.DataValueField = "COD_CATALOG";
            //ddlUserType.DataBind();
            ////ddlUserType.Items.Insert(0, new ListItem("Select", "0"));
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/getUserType";
            DataTable dtCatalog = new DataTable();
            using (var client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);
                    dtCatalog = response != "" ? Util.DataConvert.JSONToDataTable(response) : null;
                    DropDownList ddlUserType = gridViewUser.FooterRow.FindControl("ddlNewType") as DropDownList;
                    // DataTable dt = new BL_BytesMusic.Catalog(strConnString).GetUserType();
                    ddlUserType.DataSource = dtCatalog;
                    ddlUserType.DataTextField = "VALUE";
                    ddlUserType.DataValueField = "COD_CATALOG";
                    ddlUserType.DataBind();
                }
                catch (Exception exp)
                {
                    return;
                }

            }

        }
        protected void gridViewUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewUser.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void gridViewUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewUser.EditIndex = -1;
            BindData();
        }

        protected void gridViewUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string messageValidations = string.Empty;
                TextBox txtNewUserName = (TextBox)gridViewUser.FooterRow.FindControl("txtNewUserName");
                TextBox txtNewEmail = (TextBox)gridViewUser.FooterRow.FindControl("txtNewEmail");
                TextBox txtNewPassword = (TextBox)gridViewUser.FooterRow.FindControl("txtNewPassword");
                TextBox txtNewBirthday = (TextBox)gridViewUser.FooterRow.FindControl("txtNewBirthday");
                DropDownList ddlNewType = (DropDownList)gridViewUser.FooterRow.FindControl("ddlNewType");
                FileUpload fileUploadUserPhoto = (FileUpload)gridViewUser.FooterRow.FindControl("fileUploadNewUserPhoto");
                string userName = txtNewUserName.Text;
                string email = txtNewEmail.Text;
                string password = txtNewPassword.Text;
                string birthday = string.Empty;
                if (txtNewBirthday.Text != string.Empty)
                    birthday = DateTime.ParseExact(txtNewBirthday.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                int type = Convert.ToInt32(ddlNewType.SelectedValue);
                string newImageName = userName.Replace(" ", string.Empty);

                string strImageFolder = ConfigurationManager.AppSettings["userPhotoPath"];
                string strFileNameExtension = Path.GetExtension(fileUploadUserPhoto.FileName);
                string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

                EUser user = new EUser();
                user.Username = userName;
                user.Email = email;
                user.Password = password;
                user.Birthday = birthday;
                user.User_Type = type;
                user.User_Photo = newFileNameWithExtension;

                messageValidations = new UserRules().UserFieldsRequiredValidations(user);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }
               // messageValidations = new ServiceReferenceUser.UserSoapClient().ValidationsDuplicated(user);
                using (var client = new System.Net.WebClient())
                {
                    try
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        string urlEmail = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistEmail/" + user.Email;
                        string emailResponse = client.DownloadString(urlEmail);
                        string urlUser = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistUser/" + user.Username;
                        string userResponse = client.DownloadString(urlUser);

                        messageValidations = Validator.ValidationsDuplicated(Int32.Parse(userResponse), Int32.Parse(emailResponse));


                        if (messageValidations != string.Empty)
                        {
                            lblMessage.Text = messageValidations;
                            return;
                        }
                        if (fileUploadUserPhoto.HasFile)
                        {
                            messageValidations = new FileManagement().SaveImageOnServer(fileUploadUserPhoto, strImageFolder, newImageName);
                        }
                        else
                        {
                            messageValidations = new FileManagement().SaveDefaultImageOnServer(strImageFolder, newImageName);
                            user.User_Photo += ".jpg";
                        }
                        if (messageValidations != string.Empty)
                        {
                            lblMessage.Text = messageValidations;
                            return;
                        }
                        string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/saveUser";
                        var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                        request.Accept = "application/json";
                        request.ContentType = "application/json";
                        request.Method = "POST";
                        user.Password = Util.Hash.GeneratePasswordHash(password);
                        string requestJson = JsonConvert.SerializeObject(user);
                        byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                        Stream newStream = request.GetRequestStream();
                        newStream.Write(bytes, 0, bytes.Length);
                        newStream.Close();
                        var response = request.GetResponse();
                        var stream = response.GetResponseStream();
                        var sr = new StreamReader(stream);
                       // new BL_BytesMusic.User(strConnString).Save(user);
                        lblMessage.Text = "Usuario registrado Correctamente";
                        BindData();
                    }catch(Exception exp)
                    {
                        lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                        return;
                    }
                   
                }
            }
        }
        protected void gridViewUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string messageValidations = string.Empty;
            Label lblId = gridViewUser.Rows[e.RowIndex].FindControl("lblId") as Label;
            TextBox txtUserName = (TextBox)gridViewUser.Rows[e.RowIndex].FindControl("txtUserName");
            TextBox txtEmail = (TextBox)gridViewUser.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox txtPassword = (TextBox)gridViewUser.Rows[e.RowIndex].FindControl("txtPassword");
            TextBox txtBirthday = (TextBox)gridViewUser.Rows[e.RowIndex].FindControl("txtBirthday");
            DropDownList ddlType = (DropDownList)gridViewUser.Rows[e.RowIndex].FindControl("ddlType");
            FileUpload fileUploadUserPhoto = (FileUpload)gridViewUser.Rows[e.RowIndex].FindControl("fileUploadUserPhoto");

            int userId = Convert.ToInt32(lblId.Text);
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string birthday = string.Empty;
            DateTime dateValue;
            if (DateTime.TryParseExact(txtBirthday.Text, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                birthday = dateValue.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            else if (DateTime.TryParseExact(txtBirthday.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                birthday = dateValue.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            int type = Convert.ToInt32(ddlType.SelectedValue);
            string newImageName = userName.Replace(" ", string.Empty);

            string strImageFolder = ConfigurationManager.AppSettings["userPhotoPath"];
            string strFileNameExtension = Path.GetExtension(fileUploadUserPhoto.FileName);
            string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

            EUser user = new EUser();
            user.Id_User = userId;
            user.Username = userName;
            user.Email = email;
            user.Password = password;
            user.Birthday = birthday;
            user.User_Type = type;
            if (fileUploadUserPhoto.HasFile)
                user.User_Photo = newFileNameWithExtension;
            if (user.User_Photo==null)
                user.User_Photo = "";
            messageValidations = new UserRules().UserFieldsRequiredValidations(user);
            if (messageValidations != string.Empty)
            {
                lblMessage.Text = messageValidations;
                return;
            }
            if (password == "*****")
                user.Password = string.Empty;
            if (fileUploadUserPhoto.HasFile)
            {
                messageValidations = new FileManagement().SaveImageOnServer(fileUploadUserPhoto, strImageFolder, newImageName);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }
            }

            //user.Password = Util.Hash.GeneratePasswordHash(password);

            //new ServiceReferenceUser.UserSoapClient().Update(user);
            try
            {
                string urlUpdate = ConfigurationManager.AppSettings["apiGateway"] + "/updateUser";
                var request = (HttpWebRequest)WebRequest.Create(new Uri(urlUpdate));

                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "PUT";
                user.Password = Util.Hash.GeneratePasswordHash(password);
                string requestJson = JsonConvert.SerializeObject(user);
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                lblMessage.Text = string.Empty;
                gridViewUser.EditIndex = -1;
                BindData();
                lblMessage.Text = "Usuario Actualizado Correctamente";
            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;

            }

            
        }

        protected void gridViewUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int id = Convert.ToInt32(gridViewUser.DataKeys[e.RowIndex].Values[0]);
            //new ServiceReferenceUser.UserSoapClient().Delete(id);
            //BindData();
            try
            {
                int id = System.Convert.ToInt32(gridViewUser.DataKeys[e.RowIndex].Values[0]);
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deleteUser";
                url += "/" + id;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                lblMessage.Text = "Usuario Eliminado Correctamente";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;
            }



            //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            //new BL_BytesMusic.User(strConnString).Delete(id);

            BindData();
        }
    }
}