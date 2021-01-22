﻿let jsDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl

let lat = 43.6043;
let lon = 1.4437;
let overview = null;
let markerClusters;
let lastlat = 0;
let lastlon = 0
let myNewLatLng = new Array();
let myLatLng = new Array();
let lastLatLng = new Array();
//let firstEnv = jsDeviceEnvironment[0];
//let lastEnv = jsDeviceEnvironment[deviceEnvironmentInfo.length];
function initMap() {
    let markers = [];
    overview = L.map('location1device').setView([lat, lon], 11);
    markerClusters = L.markerClusterGroup();
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        attribution: 'données © OpenStreetMap/ODbL - rendu OSM France',
        minZoom: 2,
        maxZoom: 19
    }).addTo(overview);
    for (env in jsDeviceEnvironment) {
        myNewLatLng = L.latLng(jsDeviceEnvironment[env].lat, jsDeviceEnvironment[env].lon);
        lastLatLng = L.latLng(lastlat, lastlon);
        if (L.GeometryUtil.distance(overview,lastLatLng, myNewLatLng) >40) {
            lastlat = jsDeviceEnvironment[env].lat;
            lastlon = jsDeviceEnvironment[env].lon;
            let marker = L.marker([jsDeviceEnvironment[env].lat, jsDeviceEnvironment[env].lon]).addTo(overview);
            marker.bindPopup('<h5>device id: ' + env + '</h5> <p> Last contact: ' + jsDeviceEnvironment[env].lastContact + ' </p><p>Temp mean: ' + jsDeviceEnvironment[env].tMean + ' °C</p><p>Total shock: ' + jsDeviceEnvironment[env].totalShock + ' </p><p> Smax: ' + jsDeviceEnvironment[env].sMax + ' </p><p> BatteryLvl: ' + jsDeviceEnvironment[env].batteryLvl + '% </p><p><a href="/Beon/Dashboard?IdDevice=' + env + '">link to dashboard </a></p>');
            markerClusters.addLayer(marker);
            markers.push(marker);
            let arrayProvisoire = [lastlat , lastlon];
            myLatLng.push(arrayProvisoire);
        }
        else {
            continue;
        }
    }
    var markersRemove = document.getElementsByClassName("leaflet-marker-icon");
    markersRemove[markersRemove.length - 1].remove();
    markersRemove[0].remove();
    var iconeStart = L.icon({
        iconUrl: "https://icon-library.net/images/start-flag-icon/start-flag-icon-7.jpg",
        iconSize: [50, 50],
        iconAnchor: [15,50],
        popupAnchor: [0,-50]
    })
    //iconeStart.bindPopup('Start');
    L.marker([jsDeviceEnvironment[1].lat, jsDeviceEnvironment[1].lon], { icon: iconeStart }).addTo(overview);
    var iconeEnd = L.icon({
        iconUrl: "https://icon-library.net/images/start-flag-icon/start-flag-icon-11.jpg",
        iconSize: [50, 50],
        iconAnchor: [50, 40],
        popupAnchor: [0,- 50]
    })
    //iconeEnd.bindPopup('End');
    L.marker([lastlat, lastlon], { icon: iconeEnd }).addTo(overview);
    var polyline = L.polyline(myLatLng, { color: 'red' }).addTo(overview);
    let group = new L.featureGroup(markers);
    overview.fitBounds(group.getBounds().pad(0.2));

}
window.onload = function () {
    initMap();
};

function updateMapCarte(lat, lon, deviceName, AlertType, AlertTime, AlertValue, Unit) {
    //Chercher et supprime les markers + popups existants
    var shadows = document.getElementsByClassName("leaflet-marker-shadow");
    shadows[0].remove();
    var markers = document.getElementsByClassName("leaflet-marker-icon");
    markers[0].remove();
    var popups = document.getElementsByClassName("leaflet-popup");
    if (popups.length > 0)
        popups[0].remove();


    overview.setView([lat, lon], 9);
    marker = L.marker([lat, lon]).addTo(overview);
    marker.bindPopup(deviceName + " : " + AlertType + "<br>" + AlertTime + "<br> Value : " + AlertValue + Unit);
    marker.openPopup();
};

function ChangeColor() {
    document.getElementById("sortButton72").classList.toggle("btn-success");
    document.getElementById("sortButton72").classList.toggle("btn-dark");
    document.getElementById("sortButton24").classList.toggle("btn-success");
    document.getElementById("sortButton24").classList.toggle("btn-dark");
}
function UpdateLocation72() {
    ChangeColor();
    let jsDeviceEnvironment24 = JSON.parse('{' + deviceEnvironmentInfo24 + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl

    overview.setView([lat, lon], 9);
    var polyline = L.polyline(myLatLng, { color: 'green' }).addTo(overview);
};


function UpdateLocation24() {
    ChangeColor();
     jsDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo24 + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl

};

function UpdateLocationBetweenDate() {

};