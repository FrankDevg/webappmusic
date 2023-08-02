<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Desktop.aspx.cs" Inherits="WebApp2BytesMusic.Desktop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div><h2>Your playlist</h2></div>
    <div class="jumbotron">
        <h1>BytesMusic</h1>
        <p class="lead">BytesMusic App is a free web application for music streaming.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:DataList ID="dlPlaylist" runat="server" RepeatColumns="4" CellSpacing="3" RepeatLayout="Table" OnItemDataBound="dlPlaylist_ItemDataBound">  
            <ItemTemplate>  
            <table class="table">  
                <tr>  
                    <th>  
                        <b><%# Eval("TITLE") %></b> <asp:DropDownList ID="ddlType" Enabled="false" runat="server"></asp:DropDownList>
                    </th>  
                </tr>  
                <tr>  
                    <td> <a href="Playlist/UserPlaylistSong.aspx?uid=<%=userId%>&id=<%# Eval("ID_PLAYLIST") %>">
                        <img runat="server" alt='PlaylistImage' src='<%# Eval("PHOTO") %>' style='cursor: pointer;' width="256" height="256" />
                        </a>
                    </td>  
                </tr>  
                <tr>  
                    <td>  
                        <a class="btn btn-default" href="Playlist/UserPlaylistSong.aspx?uid=<%=userId%>&id=<%# Eval("ID_PLAYLIST") %>">View &raquo;</a>
                    </td>  
                    <td>  
                        
                    </td>  
                </tr>  
            </table>  
        </ItemTemplate>  
        </asp:DataList>  
        </div>
    </div>
</asp:Content>
