// On initialise la latitude et la longitude de Toulouse (centre de la carte)
var lat = 43.6043 ;
var lon = 1.4437;

// Check des valeurs Longitude et Latitude récupérées dans Dashboard.cshtml
if (Math.abs(LastLatitude) < 90)
    lat = LastLatitude;
if (Math.abs(LastLongitude) < 180 )
    lon = LastLongitude;

var overview = null;


// Fonction d'initialisation de la carte
function initMap() {
    // Créer l'objet "macarte" et l'insèrer dans l'élément HTML qui a l'ID "map"
    overview = L.map('map').setView([lat, lon], 9); //Changer le nombre ici pour dézoomer la carte 
    // Leaflet ne récupère pas les cartes (tiles) sur un serveur par défaut. Nous devons lui préciser où nous souhaitons les récupérer. Ici, openstreetmap.fr
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        // Il est toujours bien de laisser le lien vers la source des données
        attribution: 'données © <a href="//osm.org/copyright">OpenStreetMap</a>/ODbL - rendu <a href="//openstreetmap.fr">OSM France</a>',
        minZoom: 1,
        maxZoom: 20
    }).addTo(overview);
    var icone = L.icon({
        iconUrl: "https://img2.freepng.fr/20180702/qu/kisspng-temperature-computer-icons-celsius-thermometer-cli-5b39e62a1b47e8.1921838915305211301118.jpg",
        iconSize: [50, 50],
        iconAnchor: [25, 50],
        popupAnchor: [0, -50]
    });

    // Nous ajoutons un marqueur
    var marker = L.marker([lat, lon]/*, { icon: icone }*/).addTo(overview);
}

window.onload = function () {
    // Fonction d'initialisation qui s'exécute lorsque le DOM est chargé
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



