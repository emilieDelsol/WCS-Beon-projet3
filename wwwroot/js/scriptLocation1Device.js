let jsDeviceEnvironment = JSON.parse('{' + deviceEnvironmentInfo + '}'); // -> lastContact - tMean - totalShock - sMax  - batteryLvl
let lat = 43.6043;
let lon = 1.4437;
let overview = null;
let markerClusters;
let lastlat = 0;
let lastlon = 0
let myNewLatLng = new Array();
let myLatLng = new Array();
let lastLatLng = new Array();
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
        let difflat = jsDeviceEnvironment[env].lat - lastlat;
        let difflon = jsDeviceEnvironment[env].lon - lastlon;
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
    var polyline = L.polyline(myLatLng, { color: 'red' }).addTo(overview);
    let group = new L.featureGroup(markers);
    overview.fitBounds(group.getBounds().pad(0.2));

}
window.onload = function () {
    initMap();
};