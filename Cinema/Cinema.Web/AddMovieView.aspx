<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMovieView.aspx.cs" Inherits="Cinema.Web.AddMovieView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Add Movie:</h3>
        <p>
            <asp:Label ID="TitleLabel" runat="server" Text="Title: "></asp:Label>
            <asp:TextBox ID="TitleInput" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="ImageUrlLabel" runat="server" Text="Image URL: "></asp:Label>
            <asp:TextBox ID="ImageUrlInput" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="InfoLabel" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="InfoInput" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="GenreLabel" runat="server" Text="Genre: "></asp:Label>
            <asp:TextBox ID="GenreInput" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="DirectorLabel" runat="server" Text="Director: "></asp:Label>
            <asp:TextBox ID="DirectorInput" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LengthLabel" runat="server" Text="Length (in minutes): "></asp:Label>
            <asp:TextBox ID="LengthInput" runat="server" TextMode="Number"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-success" />
        </p>
    </div>
</asp:Content>
