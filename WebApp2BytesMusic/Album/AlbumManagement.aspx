<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AlbumManagement.aspx.cs" Inherits="WebApp2BytesMusic.Album.AlbumManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Album Management</h2>
        </div>
        <div>
        <asp:GridView ID="gridViewAlbum" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_ALBUM" 
            OnRowDataBound="gridViewAlbum_RowDataBound" 
            OnRowCancelingEdit="gridViewAlbum_RowCancelingEdit" 
            OnRowEditing="gridViewAlbum_RowEditing" 
            OnRowUpdating="gridViewAlbum_RowUpdating" 
            OnRowCommand="gridViewAlbum_RowCommand" 
            ShowFooter="True" OnRowDeleting="gridViewAlbum_RowDeleting"> 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_ALBUM") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_ALBUM") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Album Title" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtAlbumTitle" runat="server" Text='<%# Bind("TITLE_ALBUM") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewAlbumTitle" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("TITLE_ALBUM") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Release Year" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtReleaseYear" runat="server" Text='<%# Bind("RELEASE_YEAR") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewReleaseYear" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblReleaseYear" runat="server" Text='<%# Eval("RELEASE_YEAR") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Photo Album" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:FileUpload ID="fileUploadAlbumPhoto" runat="server" />
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Image ID="imageAlbumPhoto" runat="server" ImageUrl='<%# Eval("ALBUM_IMAGE_PATH") %>' Width="100" Height="100" />
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:FileUpload ID="fileUploadNewAlbumPhoto" runat="server" />
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
