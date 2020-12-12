var line = document.getElementById('tempsChart');
var myLineChart = new Chart(line, {
    type: 'line',
    data: {
        labels: ['1',' 2',' 3',' 4',' 5', '6',' 7',' 8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '23', '24'],
        datasets: [
            {
                label: "# temp max",
                data: [11, 12, 15, 20, 25, 20, 10, 10, 12, 15, 20, 25, 11, 12, 15, 20, 25, 20, 10, 10, 12, 15, 20, 25,],
                radius: 5,
                borderColor: "red",
                backgroundColor:"red",
                showLine: false,
                
            },
            {
                label: "# temp min",
                data: [-25, -20, -15, -12, -10, -10, -20, - 25, -20, -15, -12, -11, - 25, -20, -15, -12, -10, -10, -20, - 25, -20, -15, -12, -11],
                radius: 5,
                borderColor: "blue",
                backgroundColor: "blue",
                showLine: false
            },
            {
                label: "# temp mean",
                data: [-7, -4, 0, 8, 15, 0, 0, -15, -8, 0, 4, 7, -7, -4, 0, 8, 15, 0, 0, -15, -8, 0, 4, 7],
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

