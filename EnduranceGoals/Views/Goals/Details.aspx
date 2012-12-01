<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>
<%@ Import Namespace="EnduranceGoals.Helpers" %>
<%@ Import Namespace="System.Collections.ObjectModel" %>
<%@ Import Namespace="EnduranceGoals.Models.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>


        <asp:Content ID="Content3" ContentPlaceHolderID="PartialTitle" runat="server">
        <%= Html.Encode(Model.Name) %>
        <b>(<%= Html.ActionLink("edit", "edit", new { id = Model.Id })%>) </b>
        </asp:Content>
        
<asp:Content ID="Content5" ContentPlaceHolderID="Map" runat="server">
    <% Html.RenderPartial("Map", new[] { Model });%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <ul>
            <li><span class="display-label">What: </span><span class="display-field">
                <%= Html.Encode(Model.Description) %></span> </li>
            <li><span class="display-label">When: </span><span class="display-field">
                <%= Html.Encode(String.Format("{0:D}", Model.Date)) %></span> </li>
            <li><span class="display-label">Where: </span><span class="display-field">
                <%= Html.Encode( String.Format(Model.Location))%></span>
            </li>
            <li><span class="display-label">Added By: </span><span class="display-field">
            <%= Html.ActionLink(Model.UserCreatorUsername)%></span>
            </li>
            <li>
                <span class="display-label">Current Participants: </span>
                   <span class="display-field">
                 <% if (Model.ListOrParticipants.Count > 0)
                    {%>
                            <%=Model.ListOrParticipants.Select(
                            participant =>
                            Html.ActionLink(participant.Value, "Details", "Goals", new { Id = participant.Key }).
                                ToHtmlString())
                                              .Aggregate((current, next) => current + "," + next)%>
                
                 <% }else{%>
                    None, go for it!
                    <% }%>
                 
                    </span>
            </li>
            <li><span class="display-label">More info at: </span><span class="display-field">
                <%= Html.Encode(Model.Web) %></span> </li>
            <li><span class="display-label">Sport: </span><span class="display-field">
                <%= Html.Encode(Model.SportName) %></span> </li>
        </ul>
    </fieldset>
    
</asp:Content>
