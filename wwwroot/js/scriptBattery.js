let batteryLevel = document.getElementById('batteryLevel');

function UpdateBattery100() {
    batteryLevel.classList.remove("batteryLevel100","batteryLevel75", "batteryLevel50", "batteryLevel25", "batteryLevel5")
    batteryLevel.classList.add("batteryLevel100");
    document.getElementById("batteryTitle").innerHTML = "100%";
};

function UpdateBattery75() {
    batteryLevel.classList.remove("batteryLevel100", "batteryLevel75", "batteryLevel50", "batteryLevel25", "batteryLevel5")
    batteryLevel.classList.add("batteryLevel75");
    document.getElementById("batteryTitle").innerHTML = "75%";

};
function UpdateBattery50() {
    batteryLevel.classList.remove("batteryLevel100", "batteryLevel75", "batteryLevel50", "batteryLevel25", "batteryLevel5")
    batteryLevel.classList.add("batteryLevel50");
    document.getElementById("batteryTitle").innerHTML = "50%";

};
function UpdateBattery25() {
    batteryLevel.classList.remove("batteryLevel100", "batteryLevel75", "batteryLevel50", "batteryLevel25", "batteryLevel5")
    batteryLevel.classList.add("batteryLevel25");
    document.getElementById("batteryTitle").innerHTML = "25%";
};
function UpdateBattery5() {
    batteryLevel.classList.remove("batteryLevel100", "batteryLevel75", "batteryLevel50", "batteryLevel25", "batteryLevel5")
    batteryLevel.classList.add("batteryLevel5");
    document.getElementById("batteryTitle").innerHTML = "5%";

};

