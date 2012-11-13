<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="header">

    <div id="title">
        <h1>
            Endurance Goals </h1>
            
    </div>
    
    <div id="subtitle">
        <h2>(Where dreams begin ...)</h2>
    </div>
    
    <div id="logindisplay">
        <% Html.RenderPartial("LogOnUserControl"); %>
    </div>
    <div id="menucontainer">
        <ul id="menu">
            <li>
                <%= Html.ActionLink("Goals", "index","goals")%></li>        
            <li>
                <%= Html.ActionLink("Create Goal", "create", "goals")%></li>
            <li>
                <%= Html.ActionLink("About", "About", "Home")%></li>
        </ul>
    </div>
</div>
