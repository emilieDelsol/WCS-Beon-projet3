let line = document.getElementById('tempsChart');
let tempMax24 = [11, 12, 15, 20, 25, 20, 10, 10, 12, 50, 20, 25, 11, 12, 15, 20, 25, 20, 10, 10, 12, 15, 20, 25];
let tempMin24 = [-25, -20, -15, -12, -10, -10, -20, - 25, -20, -15, -12, -11, - 25, -20, -15, -12, -10, -10, -20, - 25, -20, -15, -12, -11];
let tempMean24 = [-7, -4, 0, 8, 15, 0, 0, -15, -8, 0, 4, 7, -7, -4, 0, 8, 15, 0, 0, -15, -8, 0, 4, 7];
let labels24 = ['1', ' 2', ' 3', ' 4', ' 5', '6', ' 7', ' 8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '23', '24'];
let tempMax72h = [21, 32, 34, 45, 66, 77, 33, 55, 43, 43, 42, 41, 45, 78, 54, 32, 22, 21, 12];
let tempMin72h = [1, 3, 4, 5, 6, 7, 3, 5, -3, -4, -42, -41, -25, -8, -5, 3, 2, 1, 1];
let tempMean72h = [10, 12, 14, 15, 16, 17, 13, 15, 13, 13, 12, 21, 15, 38, 4, 2, 2, 1, 1];
let labels72 = ['1', ' 2', ' 3', ' 4', ' 5', '6', ' 7', ' 8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20'];
let myLineChart = new Chart(line, {
    type: 'line',
    data: {
        labels: labels24,
        datasets: [
            {
                label: "# temp max",
                data: tempMax24,
                radius: 2,
                borderColor: "red",
                backgroundColor:"#ffd7d8",
                showLine: false,
                
            },
            {
                label: "# temp min",
                data: tempMin24,
                radius: 2,
                borderColor: "blue",
                backgroundColor: "#d6e5fc",
                showLine: false
            },
            {
                label: "# temp mean",
                data: tempMean24,
                radius: 0,
                borderColor: "green",
                backgroundColor:"#d8fed7"
            }
        ]
    },
    options: {
        legend: {
            labels: { },
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
    
    if (myLineChart.data.datasets[0].data == tempMax24) {
        ChangeColor();
    }
    myLineChart.data.datasets[0].data = tempMax72h;
    myLineChart.data.datasets[1].data = tempMin72h;
    myLineChart.data.datasets[2].data = tempMean72h;
    myLineChart.data.labels = labels72;
    myLineChart .update();
};


function UpdateChart24() {
   if (myLineChart.data.datasets[0].data == tempMax72h) {
        ChangeColor();
    }
    myLineChart.data.datasets[0].data = tempMax24;
    myLineChart.data.datasets[1].data = tempMin24;
    myLineChart.data.datasets[2].data = tempMean24;
    myLineChart.data.labels = labels24;
    myLineChart.update();
};


