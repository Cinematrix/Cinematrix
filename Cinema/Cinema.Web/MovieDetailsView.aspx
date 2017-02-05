<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetailsView.aspx.cs" Inherits="Cinema.Web.MovieDetailsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div style="text-align: center; margin-left: 50px">
            <asp:Image ID="MovieImg" runat="server" Width="200" />
        </div>
        <div style="text-align: center; margin-left: 50px">
            <div>
                <p><strong>Title: </strong></p>
                <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <p><strong>Director: </strong></p>
                <asp:Label ID="DirectorLabel" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <p><strong>Genre: </strong></p>
                <asp:Label ID="GenreLabel" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <p><strong>Duration: </strong></p>
                <asp:Label ID="DurationLabel" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <p><strong>Description: </strong></p>
                <asp:Label ID="DescriptionLabel" runat="server" Text=""></asp:Label>
            </div>

        </div>
        <div>
            <a href="MoviesListView.aspx" class="btn btn-info">Back</a>
        </div>
    </div>
</asp:Content>
