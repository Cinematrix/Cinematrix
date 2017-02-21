<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Cinema.Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
        <h2><%: Title %></h2>
        <h2>Cinematrix</h2>
        <br />
        <p>This application allows existing cinemas to provide online seats booking for registered users.</p>
        <p>
            Administration part gives the possibility to calculate ticket price for certain reservation.
            <br />
            Admin and cashiers can add new movies to the catalogue.
            <br />
            Admin and cashiers can introduce new film screenings with custom movie, date and price.
        </p>
    </div>
</asp:Content>
