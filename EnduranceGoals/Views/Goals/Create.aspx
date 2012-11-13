<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Endurance.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <legend>
        Add your goal!
    </legend>

    <% Html.RenderPartial("EditableForm"); %>      
 
</asp:Content>

