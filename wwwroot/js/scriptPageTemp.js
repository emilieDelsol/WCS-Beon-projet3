let line = document.getElementById('tempsChart');
let myLineChart = new Chart(line, {
    type: 'line',
    data: {
        labels: myLabel24,
        datasets: [
            {
                label: "# temp max",
                data: max24,
                radius: 2,
                borderColor: "red",
                backgroundColor: "#ffd7d8",
                showLine: false,

            },
            {
                label: "# temp min",
                data: min24,
                radius: 2,
                borderColor: "blue",
                backgroundColor: "#d6e5fc",
                showLine: false
            },
            {
                label: "# temp mean",
                data: mean24,
                radius: 0,
                borderColor: "green",
                backgroundColor: "rgba(255, 255, 255, .4)"
            }
        ]
    },
    options: {
        legend: {
            labels: {},
        },
        label: "diagramme",
        scales: {
            xAxes: [
                {
                    ticks: {
                        beginAtZero: false,


                    }
                }
            ],
            yAxes: [
                {
                    ticks: {
                        beginAtZero: false,

                    }
                }
            ]

        }
    }
});
function ChangeColor() {
    document.getElementById("sortButton72").classList.toggle("btn-success");
    document.getElementById("sortButton72").classList.toggle("btn-dark");
    document.getElementById("sortButton24").classList.toggle("btn-success");
    document.getElementById("sortButton24").classList.toggle("btn-dark");
}
function UpdateChart72() {

    if (myLineChart.data.labels == myLabel24) {
        ChangeColor();
    }
    myLineChart.data.datasets[0].data = max72;
    myLineChart.data.datasets[1].data = min72;
    myLineChart.data.datasets[2].data = mean72;
    myLineChart.data.labels = myLabel72;
    myLineChart.update();
    document.getElementById("tMax").textContent = Math.max(...max72);
    document.getElementById("tMin").textContent = Math.min(...min72);
    document.getElementById("tMean").textContent = Math.max(...mean72);
    document.getElementById("dateSort").textContent = "Last 72h:";
    document.getElementById("valuesFound").textContent = myLabel72.length;
};


function UpdateChart24() {
    if (myLineChart.data.labels == myLabel72) {
        ChangeColor();
    }
    myLineChart.data.datasets[0].data = max24;
    myLineChart.data.datasets[1].data = min24;
    myLineChart.data.datasets[2].data = mean24;
    myLineChart.data.labels = myLabel24;
    myLineChart.update();
    document.getElementById("tMax").textContent = Math.max(...max24);
    document.getElementById("tMin").textContent = Math.min(...min24);
    document.getElementById("tMean").textContent = Math.max(...mean24);
    document.getElementById("dateSort").textContent = "Last 24h:";
    document.getElementById("valuesFound").textContent = myLabel24.length;

};


