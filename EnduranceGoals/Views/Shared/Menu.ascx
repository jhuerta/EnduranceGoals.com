<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

	<div id="menu">
		<ul>
<li class="current_page_item"><%= Html.ActionLink("Home", "Index", "Home")%></li>
    <li><%= Html.ActionLink("Goals for 10K", "JsonSport", "goalsexperiment", new { id = "10K" }, null)%></li>
    <li><%= Html.ActionLink("Goals for 10K (HTML output)", "html", "goalsexperiment", new { id = "10K" }, null)%></li>
    <li><%= Html.ActionLink("List of goals (JSON)", "index_json","goalsexperiment") %></li>
        </ul></div>
        <div id="menu"><ul>
    <li><%= Html.ActionLink("Venues in Madrid", "in", "venues", new { id = "Madrid" }, null)%></li>
    <li><%= Html.ActionLink("Cities of Spain", "of", "cities", new { id = "Spain" }, null)%></li>
   <li> <%= Html.ActionLink("Upcoming Events", "index", "goals")%></li>
     </ul>
    	</div>
    	<div id="menu">
		<ul>
    <li><%= Html.ActionLink("Next Goal", "next", "Goals")%></li>
   <li> <%= Html.ActionLink("Add Goal", "create", "Goals")%></li>
   <li> <%= Html.ActionLink("Action returning HTML", "html", "GoalsExperiment", new { id = "10K" },null)%></li>
		</ul>
	</div>