<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilmScreeningsView.aspx.cs" Inherits="Cinema.Web.FilmScreeningsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2 style="background-color: rgba(255, 255, 255, 0.8); padding: 5px 5px 5px 5px; border-radius: 5px 5px 5px 5px">Screenings:</h2>
        <asp:Repeater ID="ScreeningsRepeater" runat="server" ItemType="Cinema.Data.Models.FilmScreening">
            <ItemTemplate>
                <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
                    <div style="display: inline-block; float: left">
                        <img src='<%#: Item.TargetMovie.ImageUrl %>' alt='<%#: Item.TargetMovie.Name %>' style="width: 200px" />
                    </div>
                    <div style="max-height: 300px; width: 75%; display: inline-block; text-align: center; margin-left: 50px">
                        <h2><%#:String.Format("{0:f}", Item.Start) %></h2>
                        <p>Movie: </p>
                        <strong><%#: Item.TargetMovie.Name %></strong>

                        <p>Available Seats: </p>
                        <strong><%#: Item.AvailableSeatsCount %></strong>

                        <p>Duration:</p>
                        <strong><%#: Item.TargetMovie.LengthInMinutes %> min.</strong>
                    </div>

                    <div>
                        <a href='FilmScreeningDetailsView.aspx?id=<%#: Item.Id %>'>Book seats</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
