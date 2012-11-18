<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
       <%=Html.ActionLink("Log Off | " + Page.User.Identity.Name, "LogOff", "Account") %>
<%
    }
    else {
%> 
        <%= Html.ActionLink("Log On", "LogOn", "Account") %>
<%
    }
%>
