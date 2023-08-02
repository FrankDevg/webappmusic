<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApp2BytesMusic.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/validationEngine.jquery.css" type="text/css"/>
	<link rel="stylesheet" href="Styles/template.css" type="text/css"/>
	<script src="Scripts/jquery/1.11.2/jquery.min.js" type="text/javascript"></script>
	<script src="Scripts/languages/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
	<script src="Scripts/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
	<script>
		jQuery(document).ready(function(){
			// binds form submission and fields to the validation engine
			jQuery("#formID").validationEngine();
		});
    </script>
</head>
<body>
    <form id="formID" class="formular" runat="server">
        <div>
            <h2>User's Login</h2>
        </div>
        <div>
            <fieldset>
			<table>
				<tr>
					<td>Login (username): <asp:TextBox ID="txtLogin"  CssClass="validate[required]" runat="server"></asp:TextBox></td>
					<td>
						</td>
				</tr>
				<tr>
					<td>Password: <asp:TextBox ID="txtPassword"  CssClass="validate[required]" runat="server" TextMode="Password"></asp:TextBox></td>
					<td>
						</td>
				</tr>
				<tr>
					<td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" /></td>
					<td>
						</td>
				</tr>
                <tr>

                    <td>Don't have an accout? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/User/RegisterUser.aspx">Singup</asp:HyperLink></td>
                    <td>
                        </td>
                </tr>
			</table>
                </fieldset>
			<br />
			<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body></body>
</html>
