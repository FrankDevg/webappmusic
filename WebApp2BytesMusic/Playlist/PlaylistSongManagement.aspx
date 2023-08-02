<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PlaylistSongManagement.aspx.cs" Inherits="WebApp2BytesMusic.Playlist.PlaylistSongManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.4.1.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../Styles/jqueryui/1.13.1/jquery-ui.css" type="text/css"/>
	<script src="../Scripts/jqueryui/1.13.1/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" charset="utf-8">
        $(document).ready(function() {

            $('input[id*=txtNewCreationDate]').datepicker({
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

            $('input[id*=txtCreationDate]').datepicker({
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

           
        });
    </script>

        <div>
            <h2>Playlist Song Management</h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Select a user</th>
                    <th>Select a playlist</th>
                </tr>
                <tr>
                    <td>
                                    <asp:GridView ID="gridViewUser" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_USER" 
            OnSelectedIndexChanged="gridViewUser_SelectedIndexChanged" > 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_USER") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Username" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("USERNAME") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:Image ID="imageUserPhoto" runat="server" ImageUrl='<%# String.Format("{0}?{1}", Eval("USER_PHOTO"), DateTime.Now.Ticks.ToString()) %>' Width="100" Height="100" />
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ShowHeader="True" /> 
        </Columns> 
        </asp:GridView>
                                            </td>
                    <td>
                        <asp:GridView ID="gridViewPlaylist" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID_PLAYLIST" 
                            OnRowDataBound="gridViewPlaylist_RowDataBound"
                OnDataBound="gridViewPlaylist_OnDataBound"
            OnRowCancelingEdit="gridViewPlaylist_RowCancelingEdit" 
            OnRowEditing="gridViewPlaylist_RowEditing" 
            OnRowUpdating="gridViewPlaylist_RowUpdating" 
            OnRowCommand="gridViewPlaylist_RowCommand" 
            ShowFooter="True" OnRowDeleting="gridViewPlaylist_RowDeleting"
                            OnSelectedIndexChanged="gridViewPlaylist_SelectedIndexChanged" > 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_PLAYLIST") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID_PLAYLIST") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Title name" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("TITLE") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewTitle" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("TITLE") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Creation Date" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtCreationDate" runat="server" Text='<%# Eval("CREATION_DATE", "{0:dd/MM/yyyy}") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <%-- Text='<%# DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) %>' --%>
                    <asp:TextBox ID="txtNewCreationDate" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblCreationDate" runat="server" Text='<%# Eval("CREATION_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label> 
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
            <asp:TemplateField HeaderText="Playlist Photo" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Image ID="imageEditPlaylistPhoto" runat="server" ImageUrl='<%# Eval("PHOTO") %>' Width="25" Height="25" />
                    <asp:FileUpload ID="fileUploadPlaylistPhoto" runat="server" />
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Image ID="imagePlaylistPhoto" runat="server" ImageUrl='<%# String.Format("{0}?{1}", Eval("PHOTO"), DateTime.Now.Ticks.ToString()) %>' Width="100" Height="100" />
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:FileUpload ID="fileUploadNewPlaylistPhoto" runat="server" />
                </FooterTemplate> 
            </asp:TemplateField> 

            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ShowHeader="True" /> 
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
                    </td>
                </tr>
            </table>       
                        </div>
        <div>
                        <table>
                <tr>
                    <th>Add some songs</th>
                    <th>Songs assigned to selected Playlist</th>
                </tr>
                <tr>
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
                    <td>
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
                    </td>
                </tr>
            </table>       
        </div>
        <div>
            <asp:Panel ID="frmConfirmation" Visible="true" Runat="server">
                            <asp:Label id="lblMessage" ForeColor="Red" Font-Bold="true" Runat="server"></asp:Label>
                        </asp:Panel>
        </div>
</asp:Content>
