<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

	<div id="welcome">
		<h2 class="title"><a href="#">
		    <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server" />
		</a></h2>
		<div class="entry">
            <asp:ContentPlaceHolder ID="MainContent" runat="server" />
		</div>
	</div>

