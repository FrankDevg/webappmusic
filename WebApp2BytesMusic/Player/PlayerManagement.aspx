<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PlayerManagement.aspx.cs" Inherits="WebApp2BytesMusic.Player.PlayerManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Player Management</h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Select an artist</th>
                    <th>Select some songs</th>
                </tr>
                <tr>
                    <td>
<asp:GridView ID="gridViewArtist" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_ARTIST" 
            OnSelectedIndexChanged="gridViewArtist_SelectedIndexChanged" 
            > 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_ARTIST") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Artist Name" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("ARTIST_NAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Artist Lastname" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("ARTIST_LASTNAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Artist Image" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Image ID="imageArtistPhoto" runat="server" ImageUrl='<%# Eval("ARTIST_IMAGE") %>' Width="100" Height="100" />
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
            <h4>Songs assigned to selected Artist</h4>
            <asp:GridView ID="gridViewArtistSong" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID_SONG" 
                OnRowDeleting="gridViewArtistSong_RowDeleting"
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
