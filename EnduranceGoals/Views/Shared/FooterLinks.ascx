<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<p id="footer">
    <%= Html.ActionLink("Home", "Index", "Home")%>
    |
    <%= Html.ActionLink("Goals for 10K", "JsonSport", "goalsexperiment", new { id = "10K" }, null)%>
    |
    <%= Html.ActionLink("Goals for 10K (HTML output)", "html", "goalsexperiment", new { id = "10K" }, null)%>
    |
    <%= Html.ActionLink("List of goals (JSON)", "index_json","goalsexperiment") %>
    |
    <%= Html.ActionLink("Venues in Madrid", "in", "venues", new { id = "Madrid" }, null)%>
    |
    <%= Html.ActionLink("Cities of Spain", "of", "cities", new { id = "Spain" }, null)%>
    |
    <%= Html.ActionLink("Upcoming Events", "index", "goals")%>
    |
    <%= Html.ActionLink("Next Goal", "next", "Goals")%>
    |
    <%= Html.ActionLink("Add Goal", "create", "Goals")%>
    |
    <%= Html.ActionLink("Action returning HTML", "html", "GoalsExperiment", new { id = "10K" },null)%>
</p>