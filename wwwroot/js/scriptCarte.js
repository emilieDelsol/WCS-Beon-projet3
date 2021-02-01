let lat = 43.6043 ;
let lon = 1.4437;
let markers;
let marker; 

if (Math.abs(LastLatitude) < 90)
    lat = LastLatitude;
if (Math.abs(LastLongitude) < 180 )
    lon = LastLongitude;

let overview = null;

function initMap() {
    overview = L.map('map').setView([lat, lon], 9);
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        attribution: 'données © <a href="//osm.org/copyright">OpenStreetMap</a>/ODbL - rendu <a href="//openstreetmap.fr">OSM France</a>',
        minZoom: 1,
        maxZoom: 20
    }).addTo(overview);
    marker = L.marker([lat, lon]).addTo(overview);
}

window.onload = function () {
    initMap();
};

function updateMapCarte(lat, lon, deviceName, AlertType, AlertTime, AlertValue, Unit) {
    let shadows = document.getElementsByClassName("leaflet-marker-shadow");
    shadows[0].remove();
    markers = document.getElementsByClassName("leaflet-marker-icon");
    markers[0].remove();
    let popups = document.getElementsByClassName("leaflet-popup");
    if (popups.length > 0)
        popups[0].remove();
  

    overview.setView([lat, lon], 9);
    marker = L.marker([lat, lon]).addTo(overview);
    marker.bindPopup(deviceName + " : " + AlertType + "<br>" + AlertTime + "<br> Value : " + AlertValue + Unit);
    marker.openPopup();
}



