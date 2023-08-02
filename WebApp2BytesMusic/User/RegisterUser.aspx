<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="WebApp2BytesMusic.User.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Styles/validationEngine.jquery.css" type="text/css"/>
	<link rel="stylesheet" href="../Styles/template.css" type="text/css"/>
	<script src="../Scripts/jquery/1.11.2/jquery.min.js" type="text/javascript"></script>
	<script src="../Scripts/languages/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
	<script src="../Scripts/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
	<script>
		jQuery(document).ready(function(){
			// binds form submission and fields to the validation engine
			jQuery("#formID").validationEngine();
		});

		/**
		*
		* @param {jqObject} the field where the validation applies
		* @param {Array[String]} validation rules for this field
		* @param {int} rule index
		* @param {Map} form options
		* @return an error string if validation failed
		*/
        function DateFormat(field, rules, i, options) {
            var regex = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
            if (!regex.test(field.val())) {
                return "Please enter date in dd/MM/yyyy format."
            }
        }
    </script>
</head>
<body>
    <form id="formID" class="formular" runat="server">
        <div>
            <h2>User's Enrollment</h2>
        </div>
        <div>
            <fieldset>

            <table>
                <tr>
                    <td>User name:<br /><asp:TextBox ID="txtUserName" runat="server" CssClass="validate[required]"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Email:<br /><asp:TextBox ID="txtEmail" runat="server" CssClass="validate[required,custom[email]]"></asp:TextBox></td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td>Password:<br /><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="validate[required,minSize[8]]" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Confirm Password:<br /><asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="validate[required,equals[txtPassword]]" /></td>
                    <td></td>
                </tr>
                <tr>
        <td>
            Birth Date (dd/MM/yyyy):<br /><asp:TextBox ID="txtBirthDate" runat="server" CssClass="validate[required,funcCall[DateFormat[]] " />
        </td>
        <td>
            
        </td>
    </tr>
                <tr>
        <td>
            Photo:<br /><asp:FileUpload ID="fupPhoto" runat="server" />
        </td>
        <td>
            
        </td>
    </tr>
                <tr>
        <td>
            <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" /><br /> <asp:HyperLink ID="HyperLink1" NavigateUrl="~/login.aspx" runat="server">Back to Login</asp:HyperLink>
        </td>
                    <td>
                        </td>
    </tr>
            </table>
                </fieldset>

        </div>
        <div>
            <asp:Panel ID="frmConfirmation" Visible="true" Runat="server">
                            <asp:Label id="lblMessage" ForeColor="Red" Font-Bold="true" Runat="server"></asp:Label>
                        </asp:Panel>
        </div>
    </form></body>
</html>
