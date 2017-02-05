<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoviesListView.aspx.cs" Inherits="Cinema.Web.MoviesListView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <div>
        <asp:Repeater ID="MoviesRepeater" runat="server" ItemType="Cinema.Data.Models.Movie">
            <ItemTemplate>
                <div  class="jumbotron">
                    <div style="display: inline-block; float:left">
                        <img src='<%#: Item.ImageUrl %>' border="0" alt='<%#: Item.Name %>' style="width: 200px" />
                    </div>
                    <div style="overflow-y:scroll; max-height:300px; width:70%; display:inline-block; text-align:center; margin-left:50px">
                        <p>Title: </p>
                        <strong><%#: Item.Name %></strong>
                    
                        <p>Director:</p>
                        <strong><%#: Item.Director %></strong>
                    
                        <p>Genre: </p>
                        <strong><%#: Item.Genre %></strong>
                   
                        <p>Description:</p>
                        <strong><%#: Item.Info %></strong>
                   
                        <p>Duration:</p>
                        <strong><%#: Item.LengthInMinutes %> min.</strong>
                    </div>
                    <div>
                        <a href='MovieDetailsView.aspx?id=<%#: Item.Id %>'>Details</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>--%>
    <div class="jumbotron" style="padding: 15px 15px 15px 15px">
        <asp:ListView ID="ListViewMovies" runat="server" ItemPlaceholderID="ListViewMovies"
            DataKeyNames="ID" ItemType="Cinema.Data.Models.Movie">

            <LayoutTemplate>
                <h3>Available Movies</h3>
                <asp:PlaceHolder runat="server" ID="ListViewMovies"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <div style="display: inline-block; float: left">
                        <img src='<%#: Item.ImageUrl %>' border="0" alt='<%#: Item.Name %>' style="max-height: 150px" />
                    </div>
                    <div style=" min-height: 150px; width: 80%; display: inline-block; text-align: center; margin-left: 50px">
                        
                        <strong><%#: Item.Name %></strong>
                    </div>
                    <div>
                        <a href='MovieDetailsView.aspx?id=<%#: Item.Id %>'>Details</a>
                    </div>
                </div>
            </ItemTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

        </asp:ListView>
        <asp:DataPager ID="DataPagerMovies" runat="server"
            PagedControlID="ListViewMovies" PageSize="2"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>
