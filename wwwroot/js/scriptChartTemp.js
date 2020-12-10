var line = document.getElementById('tempsChart');
var myLineChart = new Chart(line, {
    type: 'line',
    data: {
        labels: ['date1', 'date2', 'date3', 'date4', 'date5', 'date6', 'date7', 'date8', 'date9', 'date10', 'date11', 'date12'],
        datasets: [
            {
                label: "# temp max",
                data: [11, 12, 15, 20, 25, 20, 10, 10, 12, 15, 20, 25],
                radius: 0,
                borderColor: "red"
            },
            {
                label: "# temp min",
                data: [-25, -20, -15, -12, -10, -10, -20,- 25, -20, -15, -12, -11],
                radius: 0,
                borderColor: "blue"
            },
            {
                label: "# temp mean",
                data: [-7, -4, 0, 8, 15, 0, 0, -15, -8, 0, 4, 7],
                radius: 0,
                borderColor: "green"
            }
        ]
    },
    options: {
        label: "diagramme",
        scales: {
            yAxes: [
                {
                    ticks: {
                        beginAtZero: false
                    }
                }
            ]
        }
    }
});

