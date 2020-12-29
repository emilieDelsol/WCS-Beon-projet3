let jsonDevicesEnvironment = JSON.parse('{' + devicesEnvironmentInfos + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl
let lat = 43.6043;
let lon = 1.4437;
let overview = null;
let markerClusters;

function initMap() {
    let markers = [];
    overview = L.map('overview').setView([lat, lon], 11);
    markerClusters = L.markerClusterGroup();
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        attribution: 'données © OpenStreetMap/ODbL - rendu OSM France',
        minZoom: 1,
        maxZoom: 20
    }).addTo(overview);
    for (device in jsonDevicesEnvironment) {
        let marker = L.marker([jsonDevicesEnvironment[device].lat, jsonDevicesEnvironment[device].lon]);
        marker.bindPopup('<h5>device id:  ' + device + '</h5> <p> Last contact: ' + jsonDevicesEnvironment[device].lastContact + ' </p><p>Temp mean: ' + jsonDevicesEnvironment[device].tMean + ' °C</p><p>Total shock: ' + jsonDevicesEnvironment[device].totalShock + ' </p><p> Smax: ' + jsonDevicesEnvironment[device].sMax + ' </p><p> BatteryLvl: ' + jsonDevicesEnvironment[device].batteryLvl + '% </p><p><a href="/Beon/TestDashboard?IdDevice='+device+'">link to dashboard </a></p>');
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