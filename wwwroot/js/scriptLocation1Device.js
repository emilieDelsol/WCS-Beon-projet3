let jsDeviceEnvironment =  JSON.parse('{' + deviceEnvironmentInfo24 + '}') ; // -> lastContact - tMean - totalShock - sMax  - batteryLvl
let jsDeviceEnvironment24;
let jsDeviceEnvironment72;
let isActive24= false;
let lat = 43.6043;
let lon = 1.4437;
let overview = null;
let marker;
let markers = new Array();
let shadows = new Array();
let popups = new Array();
let lastlat = 0;
let lastlon = 0
let myNewLatLng = new Array();
let myLatLng = new Array();
let lastLatLng = new Array();
let markersRemove = new Array();
let polyline;
function initMap()
{
    overview = L.map('location1device').setView([lat, lon], 11);
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        attribution: 'données © OpenStreetMap/ODbL - rendu OSM France',
        minZoom: 2,
        maxZoom: 19
    }).addTo(overview);

    InitialisationMarkersTrack(jsDeviceEnvironment);
    CreatePolyline("blue");
    polyline.addTo(overview);
    UpdateLocation24();
}
window.onload = function () {
    initMap();
    
};


function ChangeColor(firstDiv, secondDiv) {

    firstDiv.classList.remove("btn-dark");
    firstDiv.classList.add("btn-success");
    secondDiv.classList.remove("btn-success");
    secondDiv.classList.add("btn-dark");
}
function RemoveColorSortButton() {
    document.getElementById("sortButton72").classList.remove("btn-success");
    document.getElementById("sortButton24").classList.remove("btn-success");
    document.getElementById("sortButton72").classList.add("btn-dark");
    document.getElementById("sortButton24").classList.add("btn-dark");
}
function UpdateLocation72() {
    if (isActive24) {
        jsDeviceEnvironment72 = JSON.parse('{' + deviceEnvironmentInfo72 + '}'); 
        ChangeColor(document.getElementById("sortButton72"), document.getElementById("sortButton24"));
        RemoveAllMarkers();
        RemovePolyline();

        InitialisationMarkersTrack(jsDeviceEnvironment72);
        CreatePolyline("red");
        polyline.addTo(overview);
        isActive24 = false;
    }
};

function UpdateLocation24() {
    if (!isActive24) {
        jsDeviceEnvironment24 = JSON.parse('{' + deviceEnvironmentInfo24 + '}'); 
        ChangeColor(document.getElementById("sortButton24"), document.getElementById("sortButton72"));
        RemoveAllMarkers();
        RemovePolyline();

        InitialisationMarkersTrack(jsDeviceEnvironment24);
        CreatePolyline("green");
        polyline.addTo(overview);
        isActive24 = true;
    }
};

function UpdateLocationBetweenDate() {
    isActive24 = false;
    RemoveColorSortButton();
    let jsDeviceEnvironmentBetween = JSON.parse('{' +  deviceEnvironmentInfoBetween  + '}');
    RemoveAllMarkers();
    RemovePolyline();

    InitialisationMarkersTrack(jsDeviceEnvironmentBetween);
    CreatePolyline("orange");
    polyline.addTo(overview);
};

function RemoveAllMarkers()
{
    shadows = document.getElementsByClassName("leaflet-marker-shadow");
    popups = document.getElementsByClassName("leaflet-popup");
    for (var marker of markers) { marker.remove() };
    for (var shadow of shadows) { shadow.remove() };
    for (var popup of popups) { popup.remove() };
     startMarker.remove();
    finishMarker.remove();
}

function RemovePolyline() {
    polyline.remove();

}
function CreatePolyline(colorChoice) {
    polyline = L.polyline(myLatLng, { color: colorChoice }).arrowheads({size:'10%', yawn: 20, fill: true });
}

function InitialisationMarkersTrack(jsDeviceEnvironment )
{
    markers = [];
    myNewLatLng = [];
    myLatLng = [];
    lastLatLng = [];
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
    startMarker.bindPopup(markers[0]._popup._content);
    markers[0].remove();
    startMarker.addTo(overview);

    finishMarker = L.marker([markers[markers.length - 1]._latlng.lat, markers[markers.length - 1]._latlng.lng], { icon: finishIcon }).addTo(overview);
    finishMarker.bindPopup(markers[markers.length-1]._popup._content);
    markers[markers.length-1].remove();
    finishMarker.addTo(overview);

    let group = new L.featureGroup(markers);
    overview.fitBounds(group.getBounds().pad(0.2));

}