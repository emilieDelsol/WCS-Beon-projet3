let batteryLevel = document.getElementById('batteryLevel');

document.getElementById("batteryTitle").innerHTML = batteryLvl + "%";

if (batteryLvl <= 1) {
    batteryLevel.classList.toggle("batteryLevelHS");
    batteryLevel.style.backgroundColor = "red";
}
if (batteryLvl > 1 && batteryLvl <= 5) {
    batteryLevel.classList.toggle("batteryLevel5");
    batteryLevel.style.backgroundColor = "red";
}
if (batteryLvl > 5 && batteryLvl <= 10) {
    batteryLevel.classList.toggle("batteryLevel10");
    batteryLevel.style.backgroundColor = "red";
}
if (batteryLvl > 10 && batteryLvl <= 15) {
    batteryLevel.classList.toggle("batteryLevel15");
    batteryLevel.style.backgroundColor = "red";
}
if (batteryLvl > 15 && batteryLvl <= 20) {
    batteryLevel.classList.toggle("batteryLevel20");
    batteryLevel.style.backgroundColor = "red";
}
if (batteryLvl > 20 && batteryLvl <= 25) {
    batteryLevel.classList.toggle("batteryLevel25");
    batteryLevel.style.backgroundColor = "red";
}
if (batteryLvl > 25 && batteryLvl <= 30) {
    batteryLevel.classList.toggle("batteryLevel30");
    batteryLevel.style.backgroundColor = "red";
}
if (batteryLvl > 30 && batteryLvl <= 35) {
    batteryLevel.classList.toggle("batteryLevel35");
    batteryLevel.style.backgroundColor = "orange";
}
if (batteryLvl > 35 && batteryLvl <= 40) {
    batteryLevel.classList.toggle("batteryLevel40");
    batteryLevel.style.backgroundColor = "orange";
}
if (batteryLvl > 40 && batteryLvl <= 45) {
    batteryLevel.classList.toggle("batteryLevel45");
    batteryLevel.style.backgroundColor = "orange";
}
if (batteryLvl > 45 && batteryLvl <= 50) {
    batteryLevel.classList.toggle("batteryLevel50");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 50 && batteryLvl <= 55) {
    batteryLevel.classList.toggle("batteryLevel55");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 55 && batteryLvl <= 60) {
    batteryLevel.classList.toggle("batteryLevel60");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 60 && batteryLvl <= 65) {
    batteryLevel.classList.toggle("batteryLevel65");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 65 && batteryLvl <= 70) {
    batteryLevel.classList.toggle("batteryLevel70");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 70 && batteryLvl <= 75) {
    batteryLevel.classList.toggle("batteryLevel75");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 75 && batteryLvl <= 80) {
    batteryLevel.classList.toggle("batteryLevel80");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 80 && batteryLvl <= 85) {
    batteryLevel.classList.toggle("batteryLevel85");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl > 85 && batteryLvl <= 90) {
    batteryLevel.classList.toggle("batteryLevel90");
    batteryLevel.style.backgroundColor = "green";
}
if (batteryLvl >= 90) {
    batteryLevel.classList.toggle("batteryLevel95");
    batteryLevel.style.backgroundColor = "green";
}


