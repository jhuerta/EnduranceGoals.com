<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PartialTitle" runat="server">
                <%=String.Format("{0} (created on {1:d} by {2})", Model.Name, Model.CreatedOn, Model.UserCreatorUsername)%>
                <b>(<%= Html.ActionLink("preview", "Details", new { id=Model.Id})%>) </b>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("EditableForm"); %>
</asp:Content>
