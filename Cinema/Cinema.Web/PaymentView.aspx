<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentView.aspx.cs" Inherits="Cinema.Web.PaymentView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
         Film Screening:
            <asp:DropDownList ID="FilmScreeningsDropDownList" runat="server" 
                AutoPostBack="True" DataTextField="Start" OnSelectedIndexChanged="FilmScreeningsDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />

         Users:
            <asp:DropDownList ID="UsersDropDownList" runat="server" 
                ItemType="Cinema.Data.Models.User" DataTextField="UserName">
            </asp:DropDownList>
            <br /> 

            <asp:Button Text="Print" runat="server" OnClick="PrintButtonClick" CssClass="btn btn-success" />

            <br />

        <asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
    </div>
</asp:Content>