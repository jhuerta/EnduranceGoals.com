<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>
<%@ Import Namespace="EnduranceGoals.Models.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PartialTitle" runat="server">
                Add your goal!
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Map" runat="server">
    <% Html.RenderPartial("Map", new[] { new GoalViewModel()
       {
           VenueLatitude = 44,
           VenueLongitude = 3
       }
       });%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("EditableForm"); %>
</asp:Content>
