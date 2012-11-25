<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>
<div>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

    <script charset="UTF-8" type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0">
    </script>

    <script type="text/javascript"  src="http://maps.google.com/maps/api/js?sensor=true"></script>

    <script type="text/javascript" src="<%= Url.Content("~/Content/Smart/js/jquery.gmap.min.js")%>"></script>

    <div id="googlemaps-container-top">
    </div>
    <div id="googlemaps" class="google-map google-map-full">
    </div>
    <div id="googlemaps-container-bottom">
    </div>

    <script type="text/javascript">

    $(document).ready(
    
    function () {
        var latitude = <%= Model.VenueLatitude %>
        var longitude = <%= Model.VenueLongitude %>
        console.log("Lat: " + latitude);
        console.log("Lon: " + longitude);
        if((latitude == 0) || (longitude ==0))
        {
        //alert("a");
            LoadMap();
        }
        else
        {
        //alert("b");
        
            LoadMap(latitude,longitude, mapLoaded);
        }
        
        function mapLoaded() {
            
            var title = "<%= Model.Name %>";
            var address = "<%= Model.Location %>";
            LoadPin(center, title, address);
            map.SetZoomLevel(14);
        }
        
        function LoadMap()
        {
            //alert("nothing");
        }
        
        function LoadMap(a,b,c)
        {
           // alert("something");
        }
    });
    $('#googlemaps').gMap({
				                maptype: 'ROADMAP',
				                scrollwheel: true,
				                zoom: 14,
				                markers: [
					                {
						                address: 'Somerset MRT, Singapore', // Your Adress Here
						                html: '',
						                popup: false,
					                }
				                ],
			                });
			            
		            </script>

</div>
