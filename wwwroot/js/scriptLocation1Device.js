﻿let jsDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl
let lat = 43.6043;
let lon = 1.4437;
let overview = null;
let markerClusters;

function initMap() {
    let markers = [];
    overview = L.map('location1device').setView([lat, lon], 11);
    markerClusters = L.markerClusterGroup();
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        attribution: 'données © OpenStreetMap/ODbL - rendu OSM France',
        minZoom: 1,
        maxZoom: 20
    }).addTo(overview);
    for (env in jsDeviceEnvironment) {
        let marker = L.marker([jsDeviceEnvironment[env].lat, jsDeviceEnvironment[env].lon]);
        marker.bindPopup('<h5>device id: ' + env + '</h5> <p> Last contact: ' + jsDeviceEnvironment[env].lastContact + ' </p><p>Temp mean: ' + jsDeviceEnvironment[env].tMean + ' °C</p><p>Total shock: ' + jsDeviceEnvironment[env].totalShock + ' </p><p> Smax: ' + jsDeviceEnvironment[env].sMax + ' </p><p> BatteryLvl: ' + jsDeviceEnvironment[env].batteryLvl + '% </p><p><a href="/Beon/Dashboard?IdDevice=' + env + '">link to dashboard </a></p>');
        markerClusters.addLayer(marker);
        markers.push(marker);
    }
    let group = new L.featureGroup(markers);
    overview.fitBounds(group.getBounds().pad(0.2));
    overview.addLayer(markerClusters);
}
window.onload = function () {
    initMap();
};