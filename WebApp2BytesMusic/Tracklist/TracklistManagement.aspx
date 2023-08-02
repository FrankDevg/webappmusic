<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="TracklistManagement.aspx.cs" Inherits="WebApp2BytesMusic.Tracklist.TracklistManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Tracklist Management</h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Select an album</th>
                    <th>Select some songs</th>
                </tr>
                <tr>
                    <td>
<asp:GridView ID="gridViewAlbum" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_ALBUM" 
            OnSelectedIndexChanged="gridViewAlbum_SelectedIndexChanged" 
            > 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_ALBUM") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Album Title" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("TITLE_ALBUM") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Release Year" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblReleaseYear" runat="server" Text='<%# Eval("RELEASE_YEAR") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Photo Album" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Image ID="imageAlbumPhoto" runat="server" ImageUrl='<%# Eval("ALBUM_IMAGE_PATH") %>' Width="100" Height="100" />
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ShowHeader="True" /> 
        </Columns> 
        </asp:GridView>
                    </td>
                    <td>
            <asp:GridView ID="gridViewSong" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID_SONG" 
            OnRowCommand="gridViewSong_RowCommand" 
            > 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_SONG") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Song Name" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("SONG_NAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Song File" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <audio id="mp3PlayerHtml5"  runat="server" controls="controls" src='<%# Eval("SONG_PATH") %>'>Your browser does not support the <code>audio</code> element.</audio>
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Add" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Add" Text="Add"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 
        </Columns> 
        </asp:GridView>
                    </td>
                </tr>
            </table>         
        </div>
        <div>
            <h4>Tracklist</h4>
            <asp:GridView ID="gridViewTracklist" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID_SONG" 
                OnRowDeleting="gridViewTracklist_RowDeleting"
            > 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_SONG") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Song Name" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("SONG_NAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Song File" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <audio id="mp3PlayerHtml5"  runat="server" controls="controls" src='<%# Eval("SONG_PATH") %>'>Your browser does not support the <code>audio</code> element.</audio>
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
