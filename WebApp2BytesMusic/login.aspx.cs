using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp2BytesMusic.E_BytesMusic;
//using WebApp2BytesMusic.ServiceReferenceUser;

namespace WebApp2BytesMusic
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>if (window.parent != window.top) window.parent.location.href = window.location.origin+'/login.aspx'; </script>");
#if DEBUG
                txtLogin.Text = "userPlayer";
                //txtLogin.Text = "userAdmin";
                txtPassword.Text = "12345678";
                txtPassword.Attributes.Add("value", txtPassword.Text);
                txtPassword.TextMode = TextBoxMode.Password;
#endif
                lblMessage.Text = string.Empty;
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please, write a login/password";
                return;
            }
            /*
            if (login != "userAdmin" || password != "12345678")//TODO: Read from database
            {
                lblMessage.Text = "Login/password incorrect, try again";
                return;
            }
            //FormsAuthentication.RedirectFromLoginPage(login, true);
            Response.Redirect("Default.aspx");
            */
            password = Util.Hash.GeneratePasswordHash(password);
            //DataTable dtUser = new BL_BytesMusic.User(strConnString).AuthenticateUser(login, password);
            //DataTable dtUser = new ServiceReferenceUser.UserSoapClient().AuthenticateUser(login, password);
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/authenticateUser";
            DataTable dtUser = new DataTable();
            using (var client = new WebClient())
            {
                try
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";
                url += '/' + login + '/' + password;
                string response = client.DownloadString(url);

                dtUser = response != "" ? Util.DataConvert.JSONToDataTable(response) : null;
                if (dtUser != null && dtUser.Rows.Count > 0)
            {
                EUser user = new EUser();
                user.Id_User = Convert.ToInt32(dtUser.Rows[0]["ID_USER"]);
                user.Username = login;
                user.User_Photo = dtUser.Rows[0]["USER_PHOTO"].ToString();
                user.Email = dtUser.Rows[0]["EMAIL"].ToString();
                user.Birthday = dtUser.Rows[0]["BIRTHDAY"].ToString();
                user.User_Type = Convert.ToInt32(dtUser.Rows[0]["USER_TYPE"]);
                if (user.User_Type == Util.Constants.ID_USER_NORMAL)
                {
                    Session[Util.Constants.USER] = user.Id_User;
                    FormsAuthentication.RedirectFromLoginPage(login, true);
                    Response.Redirect("~/Desktop.aspx?uid=" + user.Id_User, true);
                }
                else if (user.User_Type == Util.Constants.ID_USER_ADMIN)
                {
                    Session[Util.Constants.USER] = user.Id_User;
                    FormsAuthentication.RedirectFromLoginPage(login, true);
                    Response.Redirect("~/DesktopAdmin.aspx?uid=" + user.Id_User, true);
                }
                else
                {
                    lblMessage.Text = "Login/password incorrect, try again";
                    return;
                }
            }
            else
            {
                lblMessage.Text = "Login/password incorrect, try again";
                return;
            }
            //#endif
        }catch(Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                    return;
                }
            }


            lblMessage.Text = string.Empty;
        }
    }
}