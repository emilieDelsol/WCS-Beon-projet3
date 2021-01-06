// On initialise la latitude et la longitude de Paris (centre de la carte)
var lat = 43.6043 ;
var lon = 1.4437;
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
        inconAnchor: [25, 50],
        popupAnchor: [0,-50]
    })
    // Nous ajoutons un marqueur + popup
    var marker = L.marker([43.6043, 1.4437]/*, { icon: icone }*/).addTo(overview);
    marker.bindPopup("<h2>Tracker 001</h2><p>description</p>");
}
window.onload = function () {
    // Fonction d'initialisation qui s'exécute lorsque le DOM est chargé
    initMap();
};

function updateMapCarte(lat, lon, deviceName, AlertType) {
    //Chercher et supprime les markers existants
    var markers = document.getElementsByClassName("leaflet-marker-icon");
    markers[0].remove();

    overview.setView([lat, lon], 9);
    marker = L.marker([lat, lon]).addTo(overview);
    marker.bindPopup(String(deviceName) + " : " + AlertType);
};



//https://nouvelle-techno.fr/actualites/pas-a-pas-inserer-une-carte-openstreetmap-sur-votre-site
//https://www.youtube.com/watch?v=MtY9J2frbsM&feature=youtu.be&t=1080