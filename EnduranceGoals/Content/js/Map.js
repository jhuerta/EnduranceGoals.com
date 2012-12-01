
var points = [];
var shapes = [];
var center = null;
var MM = Microsoft.Maps;
var infoboxLayer, dataLayer, infobox = null;
var pinLayer = new Microsoft.Maps.EntityCollection();




function LoadMap(latitude, longitude, zoom) {

    map = new MM.Map(document.getElementById("googlemaps"),
                               { credentials: "Av1qD18A6j3BJTP3LWGWtosHci1W-cUAdFdLAiGqmc7XbYWRYNicd1hUehr0Hbzo",
                                   center: new MM.Location(latitude, longitude),
                                   mapTypeId: "r",
                                   zoom: zoom
                               });

    dataLayer = new Microsoft.Maps.EntityCollection();
    map.entities.push(dataLayer)

    var infoboxLayer = new Microsoft.Maps.EntityCollection();
    map.entities.push(infoboxLayer);

    infobox = new Microsoft.Maps.Infobox(new Microsoft.Maps.Location(0, 0),
                                         { width: 400, visible: false, offset: new Microsoft.Maps.Point(0, 20) }
                                         );

    map.getZoomRange = function() {
        return {
            max: 30,
            min: 2
        };
    };


    infoboxLayer.push(infobox);
}

function displayInfobox(e) {
    if (e.targetType == 'pushpin') {
        infobox.setLocation(e.target.getLocation());
        infobox.setOptions({ visible: true, title: e.target.Title, description: e.target.Description });
    }
}


function hideInfobox(e) {
    infobox.setOptions({ visible: false });
}

function DragHandler(e) {
    var loc = e.entity.getLocation();
    var longitudeId = loc.longitude.toFixed(4);
    var latitudeId = loc.latitude.toFixed(4);
    var goalId = e.entity.GoalId;
    $("#latitude-" + goalId).val(latitudeId);
    $("#longitude-" + goalId).val(longitudeId);

    $("#latitude-" + goalId).change();
    $("#longitude-" + goalId).change();
}

function CreatePushPin(locationPoint, date, name, location, description, image, size, link, id) {

    var pushPinDraggable = (document.URL.indexOf("edit") >= 0) || (document.URL.indexOf("create") >= 0);
    // Create the Pushpin
    var point = new Microsoft.Maps.Point(size/2, size/2);
    var pushpinOptions = { icon: image, width: size, height: size, draggable: pushPinDraggable, anchor: point };
    var pushpin = new Microsoft.Maps.Pushpin(locationPoint, pushpinOptions);
    pushpin.Title = name + " - " + date + "<br\>" + location;
    pushpin.Description = description + "<br\><br\>" + link;
    pushpin.GoalId = id;

    // Atach Pushpin to infobox
    Microsoft.Maps.Events.addHandler(pushpin, 'mouseover', displayInfobox);
    Microsoft.Maps.Events.addHandler(map, 'click', hideInfobox);

    dataLayer.push(pushpin);

    Microsoft.Maps.Events.addHandler(pushpin, 'drag', DragHandler);
    Microsoft.Maps.Events.addHandler(pushpin, 'dragstart', hideInfobox);
    Microsoft.Maps.Events.addHandler(pushpin, 'dragend', displayInfobox);

    return pushpin;
}

function FindAddressOnMap(where) {
    var numberOfResults = 20;
    var setBestMapView = true;
    var showResults = true;

    map.Find("", where, null, null, null, numberOfResults, showResults, true, true, setBestMapView, callbackForLocation);
}

function callbackForLocation(layer, resultsArray, places, hasMore, VEErrorMessage) {

    alert("callBackForLocation");
    clearMap();
    if (places == null) {
        return;
    }

    // Make a pushpin for each place we find
    $.each(places, function(i, item) {
        var description = "";
        if (item.Description !== undefined) {
            description = item.Description;
        }

        var LL = new VELatLong(item.LatLong.Latitude, item.LatLong.Longitude);
        LoadPin = (LL, item.Name, description);
    });

    // Make sure all pushpins are visible
    if (points.length > 1) {
        map.SetMapView(points);
    }

    // If we've found exactly one place, that's our address
    if (points.Length === 1) {
        $("#Latitude").val(points[0].Latitude);
        $("#Longitude").val(points[0].Longitude);
    }

    console.log("END END callBackForLocation END END");

}

function clearMap() {
    alert("clearing the map");
    map.Clear();
    points = [];
    shapes = [];
}
