let line = document.getElementById('tempsChart');
let isActive24 = true;
let isActive72 = false;
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
})


function ChangeColor(firstDiv, secondDiv) {

    firstDiv.classList.remove("btn-dark");
    firstDiv.classList.add("btn-success");
    secondDiv.classList.remove("btn-success");
    secondDiv.classList.add("btn-dark");
}

function UpdateChart72() {

    if (!isActive72) {
        ChangeColor(document.getElementById("sortButton72"), document.getElementById("sortButton24"));
    }
    myLineChart.data.datasets[0].data = max72;
    myLineChart.data.datasets[1].data = min72;
    myLineChart.data.datasets[2].data = mean72;
    myLineChart.data.labels = myLabel72;
    myLineChart.update();
    isActive24 = false;
    isActive72 = true;
}


function UpdateChart24() {
    if (!isActive24) {
        ChangeColor(document.getElementById("sortButton24"), document.getElementById("sortButton72"));
    }
    myLineChart.data.datasets[0].data = max24;
    myLineChart.data.datasets[1].data = min24;
    myLineChart.data.datasets[2].data = mean24;
    myLineChart.data.labels = myLabel24;
    myLineChart.update();
    isActive24 = true;
    isActive72 = false; 
   
}


