var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents: function () {
        $(document).ready(function () { showRoom(); });
    }
}
result.init();

function showRoom() {
    $.ajax({
        url: "/Admin/Rooms/showRoom",
        type: "POST",
        dataType: "json",
        success: function (response) {
            var valitem = response.result;
            var rows = '';
            if (valitem.length != 0) {
                $.each(valitem, function (i, item) {
                    rows += "<tr>"
                    rows += "<td>" +
                           "<button type='button' id='btnUpdate' class='btn btn-success' onclick='return getDetailRoom(" + item.id + ")'>Sửa</button>" +
                           "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteRoom(" + item.id + ")'>Xóa</button>"
                            + "</td>"
                    rows += "<td>" + item.MaPhong + "</td>"
                    rows += "<td>" + item.TenPhong + "</td>"
                    rows += "<td>" + item.SoLuongMay + "</td>"
                    rows += "<td>" + item.GhiChu + "</td>"
                    rows += "<td>" + (item.TrangThai ? "Cho phép sử dụng" : "Không được phép sử dụng") + "</td>"
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
function getDetailRoom(id) {
    idmod = id;
    $("#title").text("Thông tin phòng");
    $.ajax({
        url: "/Admin/Rooms/Get/" + id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#MaPhong").val(data.MaPhong);
            $("#TenPhong").val(data.TenPhong);
            $("#SoLuongMay").val(data.SoLuongMay);
            $("#GhiChu").val(data.GhiChu);
            $("#TrangThai").prop('checked', data.TrangThai);
            isUpdatable = true;
            $("#bookModal").modal('show');
        },
        error: function (err) {
            alert(id);
            alert("Error: " + err.responseText);
        }
    });
}
function createRoom() {
    $("#title").text("Thông tin thêm mới phòng");
    isUpdatable = false;
    $("#bookModal").modal('show');
}
// hàm Insert và Update một record
$("#btnSave").click(function (e) {
    e.preventDefault();
    var sta;
    var x = document.getElementById("TrangThai");
    if (x.checked = true)
        sta = true;
    else
        sta = false;
    if (!isUpdatable) {
        var data = {
            MaPhong: $("#MaPhong").val(),
            TenPhong: $("#TenPhong").val(),
            SoLuongMay: $("#SoLuongMay").val(),
            GhiChu:$("#GhiChu").val(),
            TrangThai: sta
        }
        $.ajax({
            url: '/Admin/Rooms/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                showRoom();
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
            id:idmod,
            MaPhong: $("#MaPhong").val(),
            TenPhong: $("#TenPhong").val(),
            SoLuongMay: $("#SoLuongMay").val(),
            GhiChu: $("#GhiChu").val(),
            TrangThai: sta
        }

        $.ajax({
            url: '/Admin/Rooms/Edit/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                showRoom();
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
function deleteRoom(id) {
    var confirmDelete = confirm("Bạn có muốn xóa thông tin phòng này không?");

    if (confirmDelete) {
        $.ajax({
            url: "/Admin/Rooms/Delete/",
            type: "POST",
            dataType: 'json',
            data: { idm: id },
            success: function (data) {
                alert("Dữ liệu đã xóa");
                showRoom();
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
    $("#MaPhong").val("");
    $("#TenPhong").val("");
    $("#SoLuongMay").val("");
    $("#GhiChu").val("");
    $("#TrangThai").val("");
}