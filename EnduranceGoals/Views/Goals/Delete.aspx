<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>


        <asp:Content ID="Content3" ContentPlaceHolderID="PartialTitle" runat="server">
        Delete event! 
        </asp:Content>
        
        
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    
    <fieldset>
        
        
            <h3>Are you sure you want to delete "<%= Html.Encode(Model.Name) %>" on
    <%= String.Format("{0:d}", Html.Encode(Model.Name)) %> </h3>
    
            <%= Html.Hidden("Id", Model.Id)%>

    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
            <%= Html.ActionLink("Back to List", "index") %>
        </p>
    <% } %>

</asp:Content>

