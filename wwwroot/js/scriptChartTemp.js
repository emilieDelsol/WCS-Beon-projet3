var line = document.getElementById('tempsChart');
var myLineChart = new Chart(line, {
    type: 'line',
    data: {
        labels: ['date1', 'date2', 'date3', 'date4', 'date5', 'date6', 'date7', 'date8', 'date9', 'date10', 'date11', 'date12'],
        datasets: [
            {
                label: "# temp max",
                data: [11, 12, 15, 20, 25, 20, 10, 10, 12, 15, 20, 25],
                radius: 5,
                borderColor: "red",
                backgroundColor:"red",
                showLine: false,
                
            },
            {
                label: "# temp min",
                data: [-25, -20, -15, -12, -10, -10, -20,- 25, -20, -15, -12, -11],
                radius: 5,
                borderColor: "blue",
                backgroundColor: "blue",
                showLine: false
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
        legend: {
            labels: { fontSize: 20},
        },
        label: "diagramme", 
        scales: {
            xAxes: [
                {
                    ticks: {
                        beginAtZero: false,
                        fontSize: 20

                    }
                }
            ],
            yAxes: [
                {
                    ticks: {
                        beginAtZero: false,
                        fontSize: 20
                    }
                }
            ]
            
        }
    }
});

