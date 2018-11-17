$(function () {

    var lineData = {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [

            {
                label: "Data 1",
                backgroundColor: 'rgba(26,179,148,0.5)',
                borderColor: "rgba(26,179,148,0.7)",
                pointBackgroundColor: "rgba(26,179,148,1)",
                pointBorderColor: "#fff",
                data: [28, 48, 40, 19, 86, 27, 90]
            },{
                label: "Data 2",
                backgroundColor: 'rgba(220, 220, 220, 0.5)',
                pointBorderColor: "#fff",
                data: [65, 59, 80, 81, 56, 55, 40]
            }
        ]
    };

    var lineOptions = {
        responsive: true
    };


    var ctx = document.getElementById("lineChart").getContext("2d");
    new Chart(ctx, { type: 'line', data: lineData, options: lineOptions });

    ////////
   
    ////////


    var polarData = {
        datasets: [{
            data: [
                300,140,200
            ],
            backgroundColor: [
                "#a3e1d4", "#dedede", "#b5b8cf"
            ],
            label: [
                "My Radar chart"
            ]
        }],
        labels: [
            "App","Software","Laptop"
        ]
    };

    var polarOptions = {
        segmentStrokeWidth: 2,
        responsive: true

    };

    var ctx3 = document.getElementById("polarChart").getContext("2d");
    new Chart(ctx3, {type: 'polarArea', data: polarData, options:polarOptions});

    var doughnutData = {
        labels: ["App","Software","Laptop" ],
        datasets: [{
            data: [300,50,100],
            backgroundColor: ["#a3e1d4","#dedede","#b5b8cf"]
        }]
    } ;


    var doughnutOptions = {
        responsive: true
    };


    var ctx4 = document.getElementById("doughnutChart").getContext("2d");
    new Chart(ctx4, {type: 'doughnut', data: doughnutData, options:doughnutOptions});


    var radarData = {
        labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
        datasets: [
            {
                label: "My First dataset",
                backgroundColor: "rgba(220,220,220,0.2)",
                borderColor: "rgba(220,220,220,1)",
                data: [65, 59, 90, 81, 56, 55, 40]
            },
            {
                label: "My Second dataset",
                backgroundColor: "rgba(26,179,148,0.2)",
                borderColor: "rgba(26,179,148,1)",
                data: [28, 48, 40, 19, 96, 27, 100]
            }
        ]
    };

    var radarOptions = {
        responsive: true
    };

    var ctx5 = document.getElementById("radarChart").getContext("2d");
    new Chart(ctx5, {type: 'radar', data: radarData, options:radarOptions});

});


$(document).ready(function () {
    $.getJSON("/BaoCao/BieuDoCotDoi", function (data) {
        var barData = {
            labels: ["T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11","T12"],
            datasets: [
                {
                    label: "Thu",
                    backgroundColor: 'rgba(220, 220, 220, 0.5)',
                    pointBorderColor: "#fff",
                    data: [data[0].tongthu, data[1].tongthu, data[2].tongthu, data[3].tongthu, data[4].tongthu, data[5].tongthu, data[6].tongthu, data[7].tongthu,data[8].tongthu,data[9].tongthu,data[10].tongthu,data[11].tongthu]
                },
                {
                    label: "Chi",
                    backgroundColor: 'rgba(26,179,148,0.5)',
                    borderColor: "rgba(26,179,148,0.7)",
                    pointBackgroundColor: "rgba(26,179,148,1)",
                    pointBorderColor: "#fff",
                    data: [data[0].tongchi, data[1].tongchi, data[2].tongchi, data[3].tongchi, data[4].tongchi, data[5].tongchi, data[6].tongchi,data[7].tongchi,data[8].tongchi, data[9].tongchi,data[10].tongchi,,data[11].tongchi]
                }
            ]
        };

        var barOptions = {
            responsive: true
        };


        var ctx2 = document.getElementById("barChart").getContext("2d");
        new Chart(ctx2, { type: 'bar', data: barData, options: barOptions });
    });
});