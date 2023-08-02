<%@ Page Title="User Playlist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPlaylistSong.aspx.cs" Inherits="WebApp2BytesMusic.Playlist.UserPlaylistSong" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function ShowHide(e) {
            var x = document.getElementById("divGridViewSong");
            if (x.style.display === "none") {
                e.text = "Hide \u00AB";
                x.style.display = "block";
            } else {
                x.style.display = "none";
                e.text = "Show \u00BB";
            }
        }
    </script>
        <div>
            <h2>Song for: <asp:Label ID="lblPlaylistTitle" runat="server" Text="Label"></asp:Label></h2>
        </div>
        <div>
            <asp:Panel ID="frmConfirmation" Visible="true" Runat="server">
                            <asp:Label id="lblMessage" ForeColor="Red" Font-Bold="true" Runat="server"></asp:Label>
                        </asp:Panel>
        </div>
        <div>
        <asp:GridView ID="gridViewPlaylistSong" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID_SONG" 
                OnRowDeleting="gridViewPlaylistSong_RowDeleting"
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
            <h3>Add some Songs to this Playlist</h3><a class="btn btn-default" onclick="ShowHide(this)" href="#">Show &raquo;</a>
        </div>
        <div id="divGridViewSong" style="display:none">
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
        </div>
</asp:Content>
