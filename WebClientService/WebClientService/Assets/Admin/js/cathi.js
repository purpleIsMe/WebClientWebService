$(function () {
   $('#datetimepicker2').datetimepicker({
    language: 'en',
    pick12HourFormat: true,
    viewMode: 'HH:mm:ss',

   });
   $('#datetimepicker4').datetimepicker({
       language: 'en',
       pick12HourFormat: true,
       viewMode: 'HH:mm:ss'
   });
    $('#datetimepicker3').datetimepicker({
        pickDate: false,
        viewMode:'dd/MM/yyyy'
    });
//$("#datetimepicker2").data("datetimepicker").getDate();
//$("#datetimepicker4").data("datetimepicker").getDate();
    //$("#datetimepicker3").data("datetimepicker").getDate();
var x = $("#datetimepicker2").find("input").val();
console.log(x);
});



var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents: function () {
        $(document).ready(function () { showSchedule(); });
    }
}
result.init();

function showSchedule() {
    $.ajax({
        url: "/Admin/Schedule/showSchedule",
        type: "POST",
        dataType: "json",
        success: function (response) {
            var valitem = response.result;
            var rows = '';
            if (valitem.length != 0) {
                $.each(valitem, function (i, item) {
                    rows += "<tr>"
                    rows += "<td>" +
                           "<button type='button' id='btnUpdate' class='btn btn-success' onclick='return getDetailSchedule(" + item.ID + ")'>Sửa</button>" +
                           "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteSchedule(" + item.ID + ")'>Xóa</button>"
                            + "</td>"
                    rows += "<td>" + item.MaKhoaThi + "</td>"
                    rows += "<td>" + item.Ca + "</td>"
                    rows += "<td>" + item.GioBatDau + "</td>"
                    rows += "<td>" + item.GioKetThuc + "</td>"
                    rows += "<td>" + item.Ngay + "</td>"
                    rows += "<td>" + (item.TrangThai ? "Cho phép sử dụng" : "Không được phép sử dụng") + "</td>"
                    rows += "<td>" + (item.DaHoanThanh ? "Đã hoàn thành ca thi" : "Chưa hoàn thành ca thi") + "</td>"
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
var isUpdatable = false;
var idmod;
function getDetailSchedule(id) {
    idmod = id;
    $("#title").text("Thông tin ca thi");
    $.ajax({
        url: "/Admin/Schedule/Get/" + id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#MaKhoaThi").val(data.MaKhoaThi);
            $("#Ca").val(data.Ca);
            $("#GioBatDau").val(data.GioBatDau);
            $("#GioKetThuc").val(data.GioKetThuc);
            $("#Ngay").val(data.Ngay);
            $("#TrangThai").prop('checked', data.TrangThai);
            $("#DaHoanThanh").prop('checked', data.DaHoanThanh);
            isUpdatable = true;
            $("#bookModal").modal('show');
        },
        error: function (err) {
            alert(id);
            alert("Error: " + err.responseText);
        }
    });
}
function createSchedule() {
    $("#title").text("Thông tin thêm mới ca thi");
    isUpdatable = false;
    $("#bookModal").modal('show');
}
// hàm Insert và Update một record
$("#btnSave").click(function (e) {
    e.preventDefault();
    var sta, ht;
    var x = document.getElementById("TrangThai");
    if (x.checked = true)
        sta = true;
    else
        sta = false;
    var y = document.getElementById("DaHoanThanh");
    if (y.checked = true)
        ht = true;
    else
        ht = false;
    if (!isUpdatable) {
        var data = {
            MaKhoaThi: $("#MaKhoaThi").val(),
            Ca: $("#Ca").val(),
            GioBatDau: $("#GioBatDau").val(),
            GioKetThuc: $("#GioKetThuc").val(),
            Ngay: $("#Ngay").val(),
            TrangThai: sta,
            DaHoanThanh: ht
        }
        $.ajax({
            url: '/Admin/Schedule/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                showSchedule();
                $("#bookModal").modal('hide');
                clear();
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        })
    }
    else {
        var data = {
            id: idmod,
            MaKhoaThi: $("#MaKhoaThi").val(),
            Ca: $("#Ca").val(),
            GioBatDau: $("#GioBatDau").val(),
            GioKetThuc: $("#GioKetThuc").val(),
            Ngay: $("#Ngay").val(),
            TrangThai: sta,
            DaHoanThanh: ht
        }

        $.ajax({
            url: '/Admin/Schedule/Edit/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                showSchedule();
                isUpdatable = false;
                $("#bookModal").modal('hide');
                clear();
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        })
    }
});
function deleteSchedule(id) {
    var confirmDelete = confirm("Bạn có muốn xóa thông tin ca thi này không?");

    if (confirmDelete) {
        $.ajax({
            url: "/Admin/Schedule/Delete/",
            type: "POST",
            dataType: 'json',
            data: { idm: id },
            success: function (data) {
                alert("Dữ liệu đã xóa");
                showSchedule();
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        });
    }
}
$("#btnClose").click(function () {
    clear();
});
function clear() {
    $("#MaKhoaThi").val("");
    $("#Ca").val("");
    $("#GioBatDau").val("");
    $("#GioKetThuc").val("");
    $("#Ngay").val("");
    $("#TrangThai").val("");
    $("#DaHoanThanh").val("");
}