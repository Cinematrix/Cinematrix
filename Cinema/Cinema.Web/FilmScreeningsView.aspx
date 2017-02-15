<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilmScreeningsView.aspx.cs" Inherits="Cinema.Web.FilmScreeningsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="background-color: rgba(255, 255, 255, 0.8); padding: 5px 5px 5px 5px; border-radius: 5px 5px 5px 5px">
            <h2 style="display: inline-block">Screenings:</h2>
            <h3 style="display: inline-block; margin-left: 20px">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="FilmScreeningsView">clear</asp:HyperLink>
            </h3>
            <h4 style="display: inline-block; margin-left: 30px">
                <asp:Label ID="DatePickerLabel" runat="server" Text="Show by Date:"></asp:Label>
                <asp:TextBox ID="DatePickerInput" runat="server" TextMode="Date" OnTextChanged="DatePickerInput_TextChanged" AutoPostBack="true"></asp:TextBox>
            </h4>
            <h4 style="display: inline-block; margin-left: 30px">
                <asp:Label ID="SearchLabel" runat="server" Text="Search by Movie:"></asp:Label>
                <asp:TextBox ID="SearchInput" runat="server" OnTextChanged="SearchInput_TextChanged" AutoPostBack="true"></asp:TextBox>
            </h4>
            <h4 style="display: inline-block; margin-left: 30px">
                <asp:Label ID="ResultLabel" runat="server" Text="Results:"></asp:Label>
                <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
            </h4>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
        <asp:Repeater ID="ScreeningsRepeater" runat="server" ItemType="Cinema.Data.Models.FilmScreening">
            <ItemTemplate>
                <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
                    <div style="display: inline-block; float: left">
                        <img src='<%#: Item.TargetMovie.ImageUrl %>' alt='<%#: Item.TargetMovie.Name %>' style="width: 200px" />
                    </div>
                    <div style="max-height: 300px; width: 75%; display: inline-block; text-align: center; margin-left: 50px">
                        <p><strong><%#:String.Format("{0:f}", Item.Start) %></strong></p>

                        <p>Movie: </p>
                        <strong><%#: Item.TargetMovie.Name %></strong>

                        <p>Price: 
                        <strong><%#: String.Format("{0:C}", Item.Price) %></strong></p>

                        <p>Available Seats:
                        <strong><%#: Item.AvailableSeatsCount %></strong> </p>

                        <p>Duration:
                        <strong><%#: Item.TargetMovie.LengthInMinutes %> min.</strong></p>
                        <p>
                            <a href='FilmScreeningDetailsView.aspx?id=<%#: Item.Id %>'>Book seats</a>
                        </p>
                    </div>

                    <div>
                        
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
