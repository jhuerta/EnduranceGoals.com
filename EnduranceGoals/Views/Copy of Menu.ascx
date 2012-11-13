<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

	<div id="Div1">
		<ul>
			<li class="current_page_item"><a href="#">Home</a></li>
			<li><%= Html.ActionLink("Goals", "index","goals")%></li>
			<li><%= Html.ActionLink("Create Goal", "create", "goals")%></li>
			<li><%= Html.ActionLink("About", "About", "Home")%></li>
		</ul>
	</div>