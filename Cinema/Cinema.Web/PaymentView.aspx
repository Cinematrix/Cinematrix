<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentView.aspx.cs" Inherits="Cinema.Web.PaymentView" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
         Film Screening:
            <asp:DropDownList ID="FilmScreeningsDropDownList" runat="server"  
                AutoPostBack="true" DataTextField="Start" OnSelectedIndexChanged="FilmScreeningsDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />

         Users:
            <asp:DropDownList ID="UsersDropDownList" runat="server" AutoPostBack="true" 
                ItemType="Cinema.Data.Models.User" DataTextField="UserName" OnSelectedIndexChanged="UsersDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br /> 

            <asp:Button Text="Print" runat="server" OnClick="PrintButtonClick" CssClass="btn btn-success" />

            <br />

        <asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
    </div>
</asp:Content>