<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilmScreeningsView.aspx.cs" Inherits="Cinema.Web.FilmScreeningsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Screenings:</h2>
        <asp:Repeater ID="ScreeningsRepeater" runat="server" ItemType="Cinema.Data.Models.FilmScreening">
            <ItemTemplate>
                <div class="jumbotron">
                    <div style="display: inline-block;">
                        <img src='<%#: Item.TargetMovie.ImageUrl %>' border="0" alt='<%#: Item.TargetMovie.Name %>' style="width: 200px" />
                    </div>
                    <div style="max-height: 300px; width: 75%; display: inline-block; text-align: center; margin-left: 50px">
                        <h2><%#: Item.Start.ToString() %></h2>
                        <p>Title: </p>
                        <strong><%#: Item.TargetMovie.Name %></strong>

                        <p>Seats Count: </p>
                        <strong><%#: Item.Seats.Count %></strong>

                        <%-- <p>Director:</p>
                        <strong><%#: Item.Director %></strong>
                    
                        <p>Genre: </p>
                        <strong><%#: Item.Genre %></strong>
                   
                        <p>Description:</p>
                        <strong><%#: Item.Info %></strong>--%>

                        <p>Duration:</p>
                        <strong><%#: Item.TargetMovie.LengthInMinutes %> min.</strong>
                    </div>

                    <div>
                        <a href='FilmScreeningDetailsView.aspx?id=<%#: Item.TargetMovie.Id %>'>Book seats</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="jumbotron">
            <p>Seats: </p>
            <asp:Repeater runat="server" ID="SeatsRepeater" ItemType="Cinema.Data.Models.Seat">
                <ItemTemplate>
                    <p>
                        Seat number:
                    <strong><%#: Item.Id %></strong>
                        Available:
                    <strong><%#: Item.IsFree %></strong>
                    </p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
