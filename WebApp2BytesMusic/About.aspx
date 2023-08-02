<%@ Page Title="About" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp2BytesMusic.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>BytesMusic App is a free web application for music streaming.</h3>
    <p>&copy; <%: DateTime.Now.Year %> - BytesMusic v2.0 Application.</p>
</asp:Content>
