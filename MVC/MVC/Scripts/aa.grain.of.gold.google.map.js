//Current.Place Start
function addPlaceMarker() {

    var map = new google.maps.Map(document.getElementById('mapCanvasPlace'), {
	    zoom: 18,
	    center: new google.maps.LatLng(State.CurrentPlace.Latitude, State.CurrentPlace.Longitude),
	    mapTypeId: google.maps.MapTypeId.ROADMAP,
        mapTypeId: 'satellite'
    });

    new google.maps.Marker({
	    position: new google.maps.LatLng(State.CurrentPlace.Latitude, State.CurrentPlace.Longitude),
	    map: map,
    })
}
	


