<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Goal not found</h2>
    <div>The goal with Id ViewData["IdNotFound"] %>  could not be found!. Check the <%= Html.ActionLink("list of goals", "index", "Goals")%></div>

</asp:Content>
