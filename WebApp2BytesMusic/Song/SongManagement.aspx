<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="SongManagement.aspx.cs" Inherits="WebApp2BytesMusic.Song.SongManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Song Management</h2>
        </div>
        <div>
        <asp:GridView ID="gridViewSong" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_SONG" 
            OnRowDataBound="gridViewSong_RowDataBound" 
            OnRowCancelingEdit="gridViewSong_RowCancelingEdit" 
            OnRowEditing="gridViewSong_RowEditing" 
            OnRowUpdating="gridViewSong_RowUpdating" 
            OnRowCommand="gridViewSong_RowCommand" 
            ShowFooter="True" OnRowDeleting="gridViewSong_RowDeleting"> 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_SONG") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_SONG") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Song Name" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtSongName" runat="server" Text='<%# Bind("SONG_NAME") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewSongName" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("SONG_NAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Song File" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:FileUpload ID="fileUploadSong" runat="server" />
                </EditItemTemplate> 
                <ItemTemplate> 
                    <audio id="mp3PlayerHtml5"  runat="server" controls="controls" src='<%# Eval("SONG_PATH") %>'>Your browser does not support the <code>audio</code> element.</audio>
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:FileUpload ID="fileUploadNewSong" runat="server" />
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
