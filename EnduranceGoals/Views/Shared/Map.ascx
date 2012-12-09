<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<EnduranceGoals.Models.ViewModels.GoalViewModel>>" %>
<%@ Import Namespace="EnduranceGoals.Models.Repositories" %>
<div>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>


    <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>

    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>

    <script type="text/javascript" src="<%= Url.Content("~/Content/Smart/js/jquery.gmap.min.js")%>"></script>

    <script type="text/javascript" src="<%= Url.Content("~/Content/js/Map.js")%>"></script>

    <div id="googlemaps-container-top">
    </div>
    <div id="googlemaps" class="google-map google-map-full">
    </div>
    <div id="googlemaps-container-bottom">
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            var MadridLatitude = 40.044438;
            var MadridLongitude = -4.746094;
            
            
            
            
            var initLongitude = 0;
            var initLatitude = 0;
            <% if(Model.Count > 0) { %>
            initLatitude = "<%= Model[0].VenueLatitude %>";
            initLongitude = "<%= Model[0].VenueLongitude %>";
            <% } %>
            
            var initZoom = 8;
            var iconSize = 40;
            
            var title,address,date,description,pushPinIcon,center, detailsUrl, pushPinId;
            
            <% if(Model.Count > 1) {%>
                initZoom = 2;
                initLongitude = MadridLongitude;
                initLatitude = initLatitude;
                iconSize = 15;
            <% }%>
                LoadMap(initLatitude, initLongitude, initZoom);
            
            <% foreach (var goal in Model){ %>
                detailsUrl = '<%= Html.ActionLink("more","Details", new { id = goal.Id })%>'
                title = "<%= goal.Name %>";
                address = "<%= goal.Location %>";
                date = "<%= String.Format("{0:d}",goal.Date)%>";
                description = "<%= goal.Description %>";
                pushPinIcon = "<%= Url.Content("~/Content/smart/img/pushpin.png") %>";
                center = new MM.Location("<%= goal.VenueLatitude%>", "<%= goal.VenueLongitude%>");
                pushPinId = "<%= goal.Id %>";
                var pushPin = CreatePushPin(center, date, title,address,description, pushPinIcon,iconSize, detailsUrl, pushPinId);
                  <% } %>

            });
          
    </script>

</div>
