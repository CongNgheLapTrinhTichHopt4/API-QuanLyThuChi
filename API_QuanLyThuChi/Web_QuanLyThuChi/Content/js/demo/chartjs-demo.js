

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