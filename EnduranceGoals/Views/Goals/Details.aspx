<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.Goal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>


        <asp:Content ID="Content3" ContentPlaceHolderID="PartialTitle" runat="server">
        <%= Html.Encode(Model.Name) %>
        <b>(<%= Html.ActionLink("edit", "edit", new { id = Model.Id })%>) </b>
        </asp:Content>
        
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    
    <fieldset>
        <ul>
            <li><span class="display-label">What: </span><span class="display-field">
                <%= Html.Encode(Model.Description) %></span> </li>
            <li><span class="display-label">When: </span><span class="display-field">
                <%= Html.Encode(String.Format("{0:D}", Model.Date)) %></span> </li>
            <li><span class="display-label">Where: </span><span class="display-field">
                <%= Html.Encode(String.Format("{0}, {1} ({2})", Model.Venue, Model.Venue.City, Model.Venue.City.Country))%></span>
            </li>
            <li><span class="display-label">Added By: </span><span class="display-field">
                <%= Html.Encode(String.Format("{0:D}", Model.UserCreator.Username)) %></span>
            </li>
            <li><span class="display-label">Current Participants: </span><span class="display-field">
                <%= Html.Encode(String.Format("{0}", string.Join(",", Model.Participants.Select(participant => participant.User.Username).ToArray())))%></span>
            </li>
            <li><span class="display-label">More info at: </span><span class="display-field">
                <%= Html.Encode(Model.Web) %></span> </li>
            <li><span class="display-label">Sport: </span><span class="display-field">
                <%= Html.Encode(Model.Sport) %></span> </li>
        </ul>
    </fieldset>
    
</asp:Content>
