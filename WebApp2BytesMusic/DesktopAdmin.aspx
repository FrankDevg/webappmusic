<%@ Page Title="Home Admin Page" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="DesktopAdmin.aspx.cs" Inherits="WebApp2BytesMusic.DesktopAdmin" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>BytesMusic Admin</h1>
        <table width="100%">
            <tr>
                <td><p class="lead">BytesMusic App is a free web application for music streaming.</p></td>
                <td><img alt="" src="Images/imageLogo.png" width="255" /></td>
            </tr>
        </table>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Songs</h2>
            <p>
                You can play a random song.
            </p>
            <p>
                <a class="btn btn-default" href="Song/SongManagement">Play some songs &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Artist</h2>
            <p>
                You can select any artist and play a song by this artist..
            </p>
            <p>
                <a class="btn btn-default" href="Artist/ArtistManagement">Choose some artist &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Album</h2>
            <p>
                You can easily find some albums and play the tracklist.
            </p>
            <p>
                <a class="btn btn-default" href="Album/AlbumManagement">Search by Album &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
