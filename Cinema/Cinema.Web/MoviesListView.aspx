<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoviesListView.aspx.cs" Inherits="Cinema.Web.MoviesListView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="padding: 15px 15px 15px 15px; background-color: rgba(255, 255, 255, 0.8); width: 100%;margin-top:100px">
        <asp:ListView ID="ListViewMovies" runat="server" ItemPlaceholderID="ListViewMovies"
            DataKeyNames="ID" ItemType="Cinema.Data.Models.Movie">

            <LayoutTemplate>
                <h3>Available Movies</h3>
                <table>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="ListViewMovies"></asp:PlaceHolder>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <td style=" min-width:600px">
                    <div style="display: inline-block">
                        <img src='<%#: Item.ImageUrl %>' border="0" alt='<%#: Item.Name %>' style="max-height: 150px" />
                    </div>
                    <div style="display: inline-block">
                        <strong><%#: Item.Name %></strong>
                    </div>
                    <div>
                        <a href='MovieDetailsView.aspx?id=<%#: Item.Id %>'>Details</a>
                    </div>
                </td>
            </ItemTemplate>
            <EmptyDataTemplate>
                <p>
                    There is no movies in catalogue.
                </p>
            </EmptyDataTemplate>

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
