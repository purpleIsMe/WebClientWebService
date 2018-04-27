var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents: function () {
        $(document).ready(function () {
            showchangetest(); changeTest(); showchangetestDT();
        });
    }
}
result.init();
function changeTest() {
    // Get a list of classes and a list of lecturers of the first lectuers.
    $.getJSON('/MakeTest/getKhoaThi', null, function (data) {
        $.each(data, function () {
            $('#khoathi').append('<option value=' +
              this.MaKhoaThi + '>' + this.TenKhoaThi + '</option>');
        });

        $.getJSON('/MakeTest/getCaThi', { id: $('#khoathi').val() }, function (data) {
            $.each(data, function () {
                $('#cathi').append('<option value=' +
                  this.ID + '>' + this.Ca + '</option>');
            });
            showchangetestDT();
            $.getJSON('/MakeTest/getMonThi', { id: $('#cathi').val() }, function (data) {
                $('#monthi').append('<option value=' +
                    data.IDMon + '>' + data.NameSubject + '</option>');
            })
        })
    })
};

$('#khoathi').on('change', function () {
    $('#cathi option').remove();
    $.getJSON('/MakeTest/getCaThi', { id: $('#khoathi').val() }, function (data) {
        $.each(data, function () {
            $('#cathi').append('<option value=' +
                this.ID + '>' + this.Ca + '</option>');
        });
        showchangetest(); showchangetestDT();
        $.getJSON('/MakeTest/getMonThi', { id: $('#cathi').val() }, function (data) {
            $('#monthi').append('<option value=' +
                data.IDMon + '>' + data.NameSubject + '</option>');
        })
    })
});

$('#cathi').on('change', function () {
    showchangetest(); showchangetestDT();
    $('#monthi option').remove();
    var kq = $('#cathi').val();
    $.getJSON('/MakeTest/getMonThi', { id: $('#cathi').val() }, function (data) {
        $('#monthi').append('<option value=' +
            data.IDMon + '>' + data.NameSubject + '</option>');
    })
});
$('#monthi').on('change', function () {
    showchangetest(); showchangetestDT();
});

$('#taodechuan').click(function () {
    var data = {
        MaCaThi: $('#cathi').val(),
        MaDeChuan: $('#monthi').val(),
        TenDeChuan: $('#tendechuan').val(),
        SoDeHoanVi: $('#soluongdetron').val(),
        ThoiGian: $('#thoigian').val()
    };
    $.ajax({
        url: "/Admin/MakeTest/SaveTest",
        type: "POST",
        dataType: "json",
        data: data,
        success: function (data) {
            showchangetest();
            showchangetestDT();
        }
    });
});

function showchangetest()
{
    var idca = $('#cathi').val();
    if (idca == null)
        idca = -1;
    console.log(idca);
    $.ajax({
        url: "/Admin/MakeTest/showAllTest",
        type: "POST",
        dataType: "json",
        data: {id:idca},
        success: function (response) {
            var rows = '';
            if (response.length != 0) {
                $.each(response, function (i, item) {
                    
                    rows += "<tr>"
                    rows += "<td>" +
                           "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteTest(" + item.MaDeChuan + ")'>Xóa</button>"
                            + "</td>"
                    rows += "<td>" + item.TenDeChuan + "</td>"
                    rows += "<td>" + $('#monthi').text() + "</td>"
                    rows += "<td>" + item.SoDeHoanVi + "</td>"
                    rows += "<td>" + item.ThoiGian + "</td>"
                    rows += "<td>" + (item.TrangThaiTron ? "Đề trộn rồi" : "Đề chưa trộn") + "</td>"
                    rows += "<td>" + (item.Lock ? "Đã khóa đề" : "Đề chưa khóa") + "</td>"
                    rows += "</tr>";
                    $("#dataTables-example tbody").html(rows);
                });
            }
            else {
                rows = '';
                $("#dataTables-example tbody").html(rows);
            }
        }
    });
}

function deleteTest(id)
{
    var confirmDelete = confirm("Bạn có muốn xóa đề chuẩn này không?");
    if (confirmDelete) {
        $.ajax({
            url: "/Admin/MakeTest/deleteTest/" + id,
            type: "GET",
            dataType: "json",
            success: function (data) {
                alert("đã xóa");
                showchangetest();
            }
        });
    }
}
var numberTest = {};
function showchangetestDT() {
    var idca = $('#cathi').val();
    if (idca == null)
        idca = -1;

    $.ajax({
        url: "/Admin/MakeTest/showAllTest",
        type: "POST",
        dataType: "json",
        data: { id: idca },
        success: function (response) {
            var rows = '';
            numberTest.result = response.length;
            console.log("idca: "+idca+"n"+response);
            if (response.length != 0) {
                $.each(response, function (i, item) {

                    rows += "<tr>"
                    rows += "<td>" +
                           "<input type='radio' name='test' value='"+item.MaDeChuan+"' id='iddechuan' onclick='check("+item.MaDeChuan+")'/>"
                            + "</td>"
                    rows += "<td>" + item.TenDeChuan + "</td>"
                    rows += "<td>" + $('#monthi').text() + "</td>"
                    rows += "<td>" + item.SoDeHoanVi + "</td>"
                    rows += "<td>" + item.ThoiGian + "</td>"
                    rows += "<td>" + (item.TrangThaiTron ? "Đề trộn rồi" : "Đề chưa trộn") + "</td>"
                    rows += "<td>" + (item.Lock ? "Đã khóa đề" : "Đề chưa khóa") + "</td>"
                    rows += "</tr>";
                    $("#bangdechuan tbody").html(rows);
                });
            }
            else {
                rows = '';
                $("#bangdechuan tbody").html(rows);
            }
        }
    });

   
}

$('#tronde').click(function () {
    var selValue = $('input[name=test]:checked').val();
    
    $.ajax({
        url: "/Admin/MakeTest/taoDeTron",
        type: "POST",
        dataType: "json",
        data: {id: selValue},
        success: function (data) {
            check(selValue); showchangetestDT();
        }
    });
});

function check(id) {
    $.ajax({
        url: "/Admin/MakeTest/getListDeTron",
        type: "POST",
        dataType: "json",
        data: { idde: id },
        success: function (data) {
            var rows = '';
            if (data.length != 0) {
                $.each(data, function (i, item) {
                    rows += "<tr>"
                    rows += "<td>" + item.MaDeTron + "</td>"
                    rows += "<td>" + item.TenDeTron + "</td>"
                    rows += "<td>" + item.MaDeChuan + "</td>"
                    rows += "</tr>";
                    $("#bangdetron tbody").html(rows);
                });
            }
            else {
                rows = '';
                $("#bangdetron tbody").html(rows);
            }
        }
    });
};

$('#khoade').click(function () {
    var selValue = $('input[name=test]:checked').val();

    $.ajax({
        url: "/Admin/MakeTest/khoaDeChuan",
        type: "POST",
        dataType: "json",
        data: { idde: selValue },
        success: function (data) {
            check(selValue); showchangetestDT();
        }
    });
});

$('#mokhoa').click(function () {
    var selValue = $('input[name=test]:checked').val();

    $.ajax({
        url: "/Admin/MakeTest/moKhoaDeChuan",
        type: "POST",
        dataType: "json",
        data: { idde: selValue },
        success: function (data) {
            check(selValue); showchangetestDT();
        }
    });
});