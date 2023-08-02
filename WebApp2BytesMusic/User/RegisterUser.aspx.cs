using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using WebApp2BytesMusic.E_BytesMusic;
using WebApp2BytesMusic.Util;

namespace WebApp2BytesMusic.User
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }
        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            string messageValidations = string.Empty;
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string birthday = string.Empty;
            if (txtBirthDate.Text != string.Empty)
            {
                //birthday = DateTime.ParseExact(txtBirthDate.Text, "yyyy-MM-dd", null).ToString();
                DateTime d;
                if (DateTime.TryParseExact(txtBirthDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out d))
                {
                    birthday = d.ToString("yyyy-MM-dd");
                }
            }
            string photoName = fupPhoto.FileName;
            int type = Constants.ID_USER_NORMAL;

            string newImageName = userName.Replace(" ", string.Empty);

            string strImageFolder = ConfigurationManager.AppSettings["userPhotoPath"];
            string strFileNameExtension = Path.GetExtension(fupPhoto.FileName);
            string newFileNameWithExtension = strImageFolder + newImageName + strFileNameExtension;

            EUser user = new EUser();
            user.Username = userName;
            user.Email = email;
            user.Password = password;
            user.Birthday = birthday;
            user.User_Type = type;
            user.User_Photo = newFileNameWithExtension;
            //string strConnString = ConfigurationManager.ConnectionStrings["BDD_BytesMusicConnectionString"].ConnectionString;
            messageValidations = new UserRules().UserFieldsRequiredValidations(user);
            if (messageValidations != string.Empty)
            {
                lblMessage.Text = messageValidations;
                return;
            }
            //messageValidations = new BL_BytesMusic.User(strConnString).ValidationsDuplicated(user);
            //messageValidations = new ServiceReferenceUser.UserSoapClient().ValidationsDuplicated(user);
            //if (messageValidations != string.Empty)
            //{
            //    lblMessage.Text = messageValidations;
            //    return;
            //}
            //if (fupPhoto.HasFile)
            //{
            //    messageValidations = new FileManagement().SaveImageOnServer(fupPhoto, strImageFolder, newImageName);
            //}
            //else
            //{
            //    messageValidations = new FileManagement().SaveDefaultImageOnServer(strImageFolder, newImageName);
            //    user.Photo += ".jpg";
            //}
            //if (messageValidations != string.Empty)
            //{
            //    lblMessage.Text = messageValidations;
            //    return;
            //}
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
                    if (fupPhoto.HasFile)
                    {
                        messageValidations = new FileManagement().SaveImageOnServer(fupPhoto, strImageFolder, newImageName);
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
                }
                catch (Exception exp)

                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                }

            }

            //user.Password = Util.Hash.GeneratePasswordHash(password);
            //new ServiceReferenceUser.UserSoapClient().Save(user);
            //lblMessage.Text = "User registered successfully!. Please go to login page.";
            try
            {
                string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/saveUser";
                var request = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "POST";
                user.Password = Util.Hash.GeneratePasswordHash(password);
                user.Birthday = Convert.ToDateTime(user.Birthday.ToString()).ToString("yyyy-MM-dd");
                string requestJson = JsonConvert.SerializeObject(user);
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);

                lblMessage.Text = "User registered successfully!. Please go to login page.";

            }
            catch(Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos" +exp;

            }
        }
    }
}