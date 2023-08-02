<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="WebApp2BytesMusic.User.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<script src="../Scripts/jquery-3.4.1.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../Styles/jqueryui/1.13.1/jquery-ui.css" type="text/css"/>
	<script src="../Scripts/jqueryui/1.13.1/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" charset="utf-8">
        $(document).ready(function() {

            $('input[id*=txtNewBirthday]').datepicker({
            showOn: "both",
            buttonImageOnly: true,
            buttonImage: "../Images/calendar.png",
            buttonText: "Calendar",
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            firstDay: 1,
            minDate: new Date(1922, 1 - 1, 1),
            showAnim:'slideDown'
            });

            $('input[id*=txtBirthday]').datepicker({
            showOn: "both",
            buttonImageOnly: true,
            buttonImage: "../Images/calendar.png",
            buttonText: "Calendar",
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            firstDay: 1,
            minDate: new Date(1922, 1 - 1, 1),
            showAnim:'slideDown'
            });

            $(function() {
                $("input[id$='txtPassword']").live("click", function() {
                $tb = $(this);
                    $("#PasswordEdited").val("true");
                    $tb.val("");                        
                })
            });
            $(function() {
                $(".blankPassword").each(function() {
                    $tb = $(this);
                    $tb.val('*****');
                    $tb.removeClass("blankPassword");
                })
            });
        });
    </script>
        <div>
            <h2>User Management</h2>
        </div>
        <div>
            <asp:GridView ID="gridViewUser" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_USER" 
            OnRowDataBound="gridViewUser_RowDataBound"
                 OnDataBound="gridViewUser_OnDataBound"
            OnRowCancelingEdit="gridViewUser_RowCancelingEdit" 
            OnRowEditing="gridViewUser_RowEditing" 
            OnRowUpdating="gridViewUser_RowUpdating" 
            OnRowCommand="gridViewUser_RowCommand" 
            ShowFooter="True" OnRowDeleting="gridViewUser_RowDeleting"> 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_USER") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_USER") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Username" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("USERNAME") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewUserName" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("USERNAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtEmail" runat="server" type="email" Text='<%# Bind("EMAIL") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewEmail" runat="server" type="email" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Password" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text='<%# Bind("PASSWORD") %>' CssClass="blankPassword"></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblPassword" runat="server" Text='*****'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Birthday" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtBirthday" runat="server" Text='<%# Eval("BIRTHDAY", "{0:dd/MM/yyyy}") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewBirthday" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblBirthday" runat="server" Text='<%# Eval("BIRTHDAY", "{0:dd/MM/yyyy}") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:DropDownList ID="ddlNewType" runat="server"></asp:DropDownList>
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:DropDownList ID="ddlType" Enabled="false" runat="server"></asp:DropDownList>
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Image ID="imageEditUserPhoto" runat="server" ImageUrl='<%# Eval("USER_PHOTO") %>' Width="25" Height="25" />
                    <asp:FileUpload ID="fileUploadUserPhoto" runat="server" />
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Image ID="imageUserPhoto" runat="server" ImageUrl='<%# String.Format("{0}?{1}", Eval("USER_PHOTO"), DateTime.Now.Ticks.ToString()) %>' Width="100" Height="100" />
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:FileUpload ID="fileUploadNewUserPhoto" runat="server" />
                </FooterTemplate> 
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 

            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" /> 
        </Columns> 
        </asp:GridView> 

        </div>
        <div>
            <asp:Panel ID="frmConfirmation" Visible="true" Runat="server">
                            <asp:Label id="lblMessage" ForeColor="Red" Font-Bold="true" Runat="server"></asp:Label>
                        </asp:Panel>
        </div>
</asp:Content>
