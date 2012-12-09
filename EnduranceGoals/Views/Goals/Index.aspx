<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="ViewPage<EnduranceGoals.Models.PaginatedList<EnduranceGoals.Models.ViewModels.GoalViewModel>>" %>

<%@ Import Namespace="EnduranceGoals.Models.ViewModels" %>
<asp:Content ID="Content6" ContentPlaceHolderID="CSSHeader" runat="server">
    <link href="<%= Url.Content("~/Content/css/custom.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSHeader" runat="server">
    <script src="<%= Url.Content("~/Scripts/MicrosoftAjax.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/MicrosoftMvcAjax.js") %>" type="text/javascript"></script>
    <script type="text/javascript" src="<%= Url.Content("~/Content/js/Goals.js")%>"></script>
    <script type="text/javascript" src="<%= Url.Content("~/Content/js/jquery.tmpl.min.js")%>"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Map" runat="server">
    <%
        Html.RenderPartial("Map", Model);%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upcoming
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PartialTitle" runat="server">
    Upcoming Goals!
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="GoalListJson"></div>
    
    <div class="row">     
        <div class="span12 center">
            <div id="paginationIndex"></div>
        </div> 
    </div>​
    
    
    <script id="paginationTemplate" type="text/x-jquery-tmpl">
            {{if CurrentPage > 1}}
                <span id='prevPage-${Prev}' class = "onPage btn btn-micro btn-custom-info"><<</span>
                {{else}}
                <span id='prevPage-${Prev}' class = "onPage btn btn-micro btn-custom-info disabled"><<</span>
            {{/if}} 
            ${CurrentPage} of ${Pages} 
            {{if CurrentPage < Pages}}
                <span id='nextPage-${Next}' class = "onPage btn btn-micro btn-custom-info">>></span>
                {{else}}
                <span id='nextPage-${Next}' class = "onPage btn btn-micro btn-custom-info disabled">>></span>
            {{/if}}
    </script>    

    <script id="goalListTemplate" type="text/x-jquery-tmpl">
	    <div>
    	    ${Date}:
    	    ${Name}
    	    ${Location}
    	    ${Sport}
    	    {{tmpl "#goalElement"}}
    	    <a class = "btn btn-micro btn-custom-info"  href="<%= HttpUtility.UrlDecode(Url.Action("details", "Goals", new { id = "${Id}" })) %>">
    	        details
    	    </a>
    	    <% if (HttpContext.Current.User.Identity.IsAuthenticated)
    	      {%>
                    {{if IsParticipant}}
                        <a  id='${Id}' class = "unsubscribeBtn btn btn-warning btn-micro" >I want out!</a>
                    {{else}}
                        <a id='${Id}' class = "subscribeBtn btn btn-success btn-micro" >I want in!</a>                            
                    {{/if}}
                 
                 {{if UserCanModifyEvent}}
                    <a class = "btn btn-micro btn-custom-wantin"  href="<%= HttpUtility.UrlDecode(Url.Action("edit", "Goals", new { id = "${Id}" })) %>">edit</a>
                    <span id="delete-${Id}">
                        {{if GoalCanBeDeleted}}
                            <a class = "btn btn-micro btn-danger"  href="<%= HttpUtility.UrlDecode(Url.Action("delete", "Goals", new { id = "${Id}" })) %>">delete</a>
                        {{else}}
                            <a class = "hidden btn btn-micro btn-danger"  href="<%= HttpUtility.UrlDecode(Url.Action("delete", "Goals", new { id = "${Id}" })) %>">delete</a>
                        {{/if}}
                    </span>
                {{/if}}
                                 
            <% }%>
	    </div>  
    </script>
    

    <script id="goalElement" type="text/x-jquery-tmpl">
	    ${Participants}
    </script>

</asp:Content>
