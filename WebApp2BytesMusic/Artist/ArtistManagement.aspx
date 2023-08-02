<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ArtistManagement.aspx.cs" Inherits="WebApp2BytesMusic.Artist.ArtistManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Artist Management</h2>
        </div>
        <div>
            <asp:GridView ID="gridViewArtist" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_ARTIST" 
                OnRowDataBound="gridViewArtist_RowDataBound" 
                OnRowCancelingEdit="gridViewArtist_RowCancelingEdit" 
                OnRowEditing="gridViewArtist_RowEditing" 
                OnRowUpdating="gridViewArtist_RowUpdating" 
                OnRowCommand="gridViewArtist_RowCommand" 
                ShowFooter="True" 
                OnRowDeleting="gridViewArtist_RowDeleting"> 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_ARTIST") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_ARTIST") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="First Name" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("ARTIST_NAME") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewName" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("ARTIST_NAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("ARTIST_LASTNAME") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewLastName" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("ARTIST_LASTNAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:FileUpload ID="fileUploadArtistPhoto" runat="server" />
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Image ID="imageArtistPhoto" runat="server" ImageUrl='<%# Eval("ARTIST_IMAGE") %>' Width="100" Height="100" />
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:FileUpload ID="fileUploadNewArtistPhoto" runat="server" />
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
