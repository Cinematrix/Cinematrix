<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetailsView.aspx.cs" Inherits="Cinema.Web.MovieDetailsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div style="display: inline-block">
            <asp:Image ID="MovieImg" runat="server" ImageAlign="Left" />
        </div>
        <div style="display: inline-block; margin-left:100px">
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
        <div>
            <a href="MoviesListView.aspx" class="btn btn-info">Back</a>
        </div>
    </div>
</asp:Content>
