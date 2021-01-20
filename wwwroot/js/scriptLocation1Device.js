jsonDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl
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
    for (env in jsonDeviceEnvironment) {
        let marker = L.marker([jsonDeviceEnvironment[env].lat, jsonDeviceEnvironment[env].lon]);
        marker.bindPopup('<h5>device id:  ' + env + '</h5> <p> Last contact: ' + jsonDeviceEnvironment[env].lastContact + ' </p><p>Temp mean: ' + jsonDeviceEnvironment[env].tMean + ' °C</p><p>Total shock: ' + jsonDeviceEnvironment[env].totalShock + ' </p><p> Smax: ' + jsonDeviceEnvironment[env].sMax + ' </p><p> BatteryLvl: ' + jsonDeviceEnvironment[env].batteryLvl + '% </p><p><a href="/Beon/Dashboard?IdDevice=' + env + '">link to dashboard </a></p>');
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