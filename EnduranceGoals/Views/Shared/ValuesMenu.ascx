<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>


	<div id="three-columns">
		<div id="column1">
			<h2>Goals</h2>
			<p>Check out the next goals that have been added. Sign up and commit. Achieve your goal!</p>
			<p><%= Html.ActionLink("Find it!", "index", "goals", new { @class = "link-style" })%></p>
		</div>
		<div id="column2">
			<h2>New Goal?</h2>
			<p>Do you have a goal in mind? Do you know of this special dream that you would like to pursue? This is it!</p>
			<p><%= Html.ActionLink("Shared it!", "create", "goals", new { @class = "link-style" })%></p>
		</div>
		<div id="column3">
			<h2>What is all this about?</h2>
			<p>This is a learning process. Wanna know more about this page? Here you will find it!.</p>
			<p><%= Html.ActionLink("More, more!", "About", "Home", new { @class = "link-style" })%></p>
		</div>
	</div>