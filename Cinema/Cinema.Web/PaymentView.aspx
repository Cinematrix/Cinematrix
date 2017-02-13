<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentView.aspx.cs" Inherits="Cinema.Web.PaymentView" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
        Film Screening:
            <asp:DropDownList ID="FilmScreeningsDropDownList" runat="server"
                AutoPostBack="true" DataTextField="Start" OnSelectedIndexChanged="FilmScreeningsDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
        <asp:Literal ID="MovieInfoLiteral" runat="server"></asp:Literal>
        <br />

        Users:
            <asp:DropDownList ID="UsersDropDownList" runat="server" AutoPostBack="true"
                ItemType="Cinema.Data.Models.User" DataTextField="UserName" OnSelectedIndexChanged="UsersDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
        <br />

        <asp:Button Text="Print" runat="server" OnClick="PrintButtonClick" CssClass="btn btn-success" />

        <br />
        Preview:
        <br />
        <asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="SeatsSummaryLiteral" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="TotalPriceLiteral" runat="server"></asp:Literal>

    </div>
    <div id="TicketContainer" runat="server" visible="false" style="background-image: url('http://www.emergenceentertainment.com/wp-content/uploads/2015/01/ticket.png'); background-size: 100% 100%; text-align: center; min-height: 300px; font-size: x-large; color: black; text-shadow: 0 0 15px #fff">
        <br />
        <br />

        <p>
            <strong>
                <asp:Literal ID="PrintScreeningLiteral" runat="server" Text="Date: "></asp:Literal>
                <asp:Literal ID="PrintMovieLiteral" runat="server" Text="Movie: "></asp:Literal>
            </strong>
        </p>

        <p>
            <strong>
                <asp:Literal ID="PrintCountLiteral" runat="server"></asp:Literal>
            </strong>
        </p>
        <p>
            <strong>
                <asp:Literal ID="PrintSeatsSummaryLiteral" runat="server"></asp:Literal>
            </strong>
        </p>
        <p>
            <strong>
                <asp:Literal ID="PrintTotalPriceLiteral" runat="server"></asp:Literal>
            </strong>
        </p>
    </div>
</asp:Content>
