<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <legend>
            <%=String.Format("{0} (created on {1:d})", Model.Name, Model.CreatedOn) %> 
            <b>(<%= Html.ActionLink("preview", "Details", new { id=Model.Id})%>)  </b>
        </legend>
        
        <% Html.RenderPartial("EditableForm"); %>

</asp:Content>
