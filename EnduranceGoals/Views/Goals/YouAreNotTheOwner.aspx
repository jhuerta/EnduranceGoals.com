<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" MasterPageFile="~/Views/Shared/Smart.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">

</asp:Content>
<asp:Content runat="server" ID="JsHeader" ContentPlaceHolderID="JSHeader"></asp:Content>
<asp:Content runat="server" ID="PartialTitle" ContentPlaceHolderID="PartialTitle">
Sorry ... you dont have permissions to edit someoneelse's goals :(</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

<h3>You are not the owner of this goal ... only him can edit, but you can 
<%= Html.ActionLink("watch it!", "Details", new {Id = Model.Id})%></h3>



</asp:Content>