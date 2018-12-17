
$(document).ready(function () {
    $.getJSON("/BaoCao/BieuDoTronPhanTichThu", function (data) {
        var doughnutData = {
            labels: ["Được Cho", "Lương", "Thu Khác"],
            datasets: [{
                data: [data[0].SoTien, data[1].SoTien, data[2].SoTien],
                backgroundColor: ["#a3e1d4", "#dedede", "#b5b8cf"]
            }]
        };

        var doughnutOptions = {
            responsive: true
        };

        var ctx4 = document.getElementById("doughnutChart2").getContext("2d");
        new Chart(ctx4, { type: 'doughnut', data: doughnutData, options: doughnutOptions });
    });


    $.getJSON("/BaoCao/BieuDoTronPhanTichChi", function (data) {
        var doughnutData = {
            labels: ["Ăn Uống", "Mua Sắm", "Xăng Xe", "Xem Phim", "Liên Hoan", "Hiếu Hỉ", "Khác"],
            datasets: [{
                data: [data[0].SoTien, data[1].SoTien, data[2].SoTien, data[3].SoTien, data[4].SoTien, data[5].SoTien, data[6].SoTien, data[7].SoTien, data[8].SoTien, data[9].SoTien, data[10].SoTien, data[11].SoTien],
                backgroundColor: ["#FF0040", "#2E2EFE", "#01DF01", "#2EFEF7", "#FFFF00", "#CECEF6", "#FACC2E", "#BDBDBD", "#BCF5A9", "#190707", "#F5A9F2", "#F5A9A9"]
            }]
        };

        var doughnutOptions = {
            responsive: true
        };

        var ctx4 = document.getElementById("doughnutChart1").getContext("2d");
        new Chart(ctx4, { type: 'doughnut', data: doughnutData, options: doughnutOptions });
    });

   


});