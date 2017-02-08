<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFilmScreeningView.aspx.cs" Inherits="Cinema.Web.AddFilmScreeningView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Add Film Screening:</h3>
        <p>
            <asp:Label ID="DateLabel" runat="server" Text="Start: "></asp:Label>
            <asp:TextBox ID="DateInput" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
        </p>
        <p>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label ID="SelectMovieLabel" runat="server" Text="Movie: "></asp:Label>
                    <asp:DropDownList ID="SelectMovieDropDownList" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true"></asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-success" />
        </p>
    </div>
</asp:Content>
