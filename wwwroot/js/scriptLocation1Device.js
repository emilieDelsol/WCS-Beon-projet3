let jsDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo24 + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl
let isActive24 = true;
let isActive72 = false;

let lat = 43.6043;
let lon = 1.4437;
let overview = null;
let marker;
let markers = new Array();
var shadows = new Array();
var popups = new Array();
let lastlat = 0;
let lastlon = 0
let myNewLatLng = new Array();
let myLatLng = new Array();
let lastLatLng = new Array();
var markersRemove = new Array();
var polyline;
function initMap()
{
    overview = L.map('location1device').setView([lat, lon], 11);
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        attribution: 'données © OpenStreetMap/ODbL - rendu OSM France',
        minZoom: 2,
        maxZoom: 19
    }).addTo(overview);

    InitialisationMarkersTrack(jsDeviceEnvironment);
    AddPolyline("green");
   
}
window.onload = function () {
    initMap();
};


function ChangeColor() {


        document.getElementById("sortButton72").classList.toggle("btn-success");
        document.getElementById("sortButton72").classList.toggle("btn-dark");
        document.getElementById("sortButton24").classList.toggle("btn-success");
        document.getElementById("sortButton24").classList.toggle("btn-dark");
}
function UpdateLocation72() {
    ChangeColor();
    isActive24 = false;
    RemoveMarkersAndPolyline();
    jsDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo72 + '}'); 
    InitialisationMarkersTrack(jsDeviceEnvironment);
    polyline.remove();
    AddPolyline("red");
};

function UpdateLocation24() {
    ChangeColor();
    RemoveMarkersAndPolyline();
    jsDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo24 + '}');
    InitialisationMarkersTrack(jsDeviceEnvironment);
    AddPolyline("green");
};

function UpdateLocationBetweenDate() {
    let jsDeviceEnvironmentBetween = JSON.parse('{' +  deviceEnvironmentInfoBetween  + '}');
    ChangeColor();
    RemoveMarkersAndPolyline();
    InitialisationMarkersTrack(jsDeviceEnvironmentBetween);
    AddPolyline("blue");
};
function RemoveMarkersAndPolyline()
{
    shadows = document.getElementsByClassName("leaflet-marker-shadow");
    popups = document.getElementsByClassName("leaflet-popup");
    for (var marker of markers) { marker.remove() };
    for (var shadow of shadows) { shadow.remove() };
    for (var popup of popups) { popup.remove() };
    polyline.remove();
    startMarker.remove();
    finishMarker.remove();
}
function AddPolyline(colorChoice)
{
    polyline = L.polyline(myLatLng, { color: colorChoice }).addTo(overview);
}

function InitialisationMarkersTrack(jsDeviceEnvironment )
{
    markers = [];
    myNewLatLng = [];
    myLatLng = [];
    var startIcon = L.icon({
        iconUrl: "https://image.flaticon.com/icons/png/512/1850/1850761.png",
        iconSize: [50, 50],
        iconAnchor: [25, 50],
        popupAnchor: [0, -50]
    });
    var finishIcon = L.icon({
        iconUrl: " https://image.flaticon.com/icons/png/128/1021/1021107.png",
        iconSize: [50, 50],
        iconAnchor: [25, 50],
        popupAnchor: [0, -50]
    });
   
    for (env in jsDeviceEnvironment) {
        myNewLatLng = L.latLng(jsDeviceEnvironment[env].lat, jsDeviceEnvironment[env].lon);
        lastLatLng = L.latLng(lastlat, lastlon);
        if (L.GeometryUtil.distance(overview, lastLatLng, myNewLatLng) > 40) {
            lastlat = jsDeviceEnvironment[env].lat;
            lastlon = jsDeviceEnvironment[env].lon;
         
            marker = L.marker([jsDeviceEnvironment[env].lat, jsDeviceEnvironment[env].lon]).addTo(overview);
            marker.bindPopup('<h5>device id: ' + env + '</h5> <p> Last contact: ' + jsDeviceEnvironment[env].lastContact + ' </p><p>Temp mean: ' + jsDeviceEnvironment[env].tMean + ' °C</p><p>Total shock: ' + jsDeviceEnvironment[env].totalShock + ' </p><p> Smax: ' + jsDeviceEnvironment[env].sMax + ' </p><p> BatteryLvl: ' + jsDeviceEnvironment[env].batteryLvl + '% </p><p><a href="/Beon/Dashboard?IdDevice=' + env + '">link to dashboard </a></p>');
            marker.addTo(overview);
            markers.push(marker);
            let arrayProvisoire = [lastlat, lastlon];
            myLatLng.push(arrayProvisoire);
        }
        else {
            continue;
        }
    }
    startMarker = L.marker([markers[0]._latlng.lat, markers[0]._latlng.lng], { icon: startIcon }).addTo(overview);
    startMarker.bindPopup('<h5>device id: ' + env + '</h5> <p> Last contact: ' + jsDeviceEnvironment[env].lastContact + ' </p><p>Temp mean: ' + jsDeviceEnvironment[env].tMean + ' °C</p><p>Total shock: ' + jsDeviceEnvironment[env].totalShock + ' </p><p> Smax: ' + jsDeviceEnvironment[env].sMax + ' </p><p> BatteryLvl: ' + jsDeviceEnvironment[env].batteryLvl + '% </p><p><a href="/Beon/Dashboard?IdDevice=' + env + '">link to dashboard </a></p>');
    markers[0].remove();
    startMarker.addTo(overview);

    finishMarker = L.marker([markers[markers.length - 1]._latlng.lat, markers[markers.length-1]._latlng.lng], { icon: finishIcon }).addTo(overview);
    finishMarker.bindPopup('<h5>device id: ' + env + '</h5> <p> Last contact: ' + jsDeviceEnvironment[env].lastContact + ' </p><p>Temp mean: ' + jsDeviceEnvironment[env].tMean + ' °C</p><p>Total shock: ' + jsDeviceEnvironment[env].totalShock + ' </p><p> Smax: ' + jsDeviceEnvironment[env].sMax + ' </p><p> BatteryLvl: ' + jsDeviceEnvironment[env].batteryLvl + '% </p><p><a href="/Beon/Dashboard?IdDevice=' + env + '">link to dashboard </a></p>');
    markers[markers.length-1].remove();
    finishMarker.addTo(overview);

    let group = new L.featureGroup(markers);
    overview.fitBounds(group.getBounds().pad(0.2));

}