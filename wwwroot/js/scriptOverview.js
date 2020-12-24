var lat = 48.852969;
var lon = 2.349903;
var overview = null;
var markerClusters;
var cities = {
	"Toulouse": { "lat": 43.6043, "lon": 1.4437},
	"New York": { "lat": 40.712784, "lon": -74.005941},
	"Hong Kong": { "lat": 22.396428, "lon": 114.109497},
    "Paris": { "lat": 48.852969, "lon": 2.349903 },
    "Brest": { "lat": 48.383, "lon": -4.500 },
    "Quimper": { "lat": 48.000, "lon": -4.100 },
    "Bayonne": { "lat": 43.500, "lon": -1.467 }
};
function initMap() {
	var markers = [];
	overview = L.map('overview').setView([lat, lon],11);
	markerClusters = L.markerClusterGroup();
	L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
		attribution: 'données © OpenStreetMap/ODbL - rendu OSM France',
		minZoom: 1,
		maxZoom: 20
	}).addTo(overview);
	for (city in cities) {
		var marker = L.marker([cities[city].lat, cities[city].lon]);
		marker.bindPopup(city);
		markerClusters.addLayer(marker);
		markers.push(marker);
	}
	var group = new L.featureGroup(markers);
	overview.fitBounds(group.getBounds().pad(0.2));
	overview.addLayer(markerClusters);
}
window.onload = function ()
{
    initMap();
};
