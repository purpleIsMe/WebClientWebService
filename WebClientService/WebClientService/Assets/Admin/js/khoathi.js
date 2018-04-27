var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents: function () {
        $(document).ready(function () { showKhoaThi(); });
    }
}
result.init();

function showKhoaThi() {
    $.ajax({
        url: "/Admin/KhoaThi/showKHOATHI",
        type: "POST",
        dataType: "json",
        success: function (response) {
            var valitem = response.result;
            var rows = '';
            if (valitem.length != 0) {
                $.each(valitem, function (i, item) {
                    rows += "<tr>"
                    rows += "<td>" +
                           "<button type='button' id='btnUpdate' class='btn btn-success' onclick='return getDetailKhoaThi(" + item.id + ")'>Sửa</button>" +
                           "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteKhoaThi(" + item.id + ")'>Xóa</button>"
                            + "</td>"
                    rows += "<td>" + item.MaKhoaThi + "</td>"
                    rows += "<td>" + item.TenKhoaThi + "</td>"
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
function getDetailKhoaThi(id) {
    idmod = id;
    $("#title").text("Thông tin khóa thi");
    $.ajax({
        url: "/Admin/KhoaThi/Get/" + id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#MaKhoaThi").val(data.MaKhoaThi);
            $("#TenKhoaThi").val(data.TenKhoaThi);
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
function createKhoaThi() {
    $("#title").text("Thông tin thêm mới khóa thi");
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
            MaKhoaThi: $("#MaKhoaThi").val(),
            TenKhoaThi: $("#TenKhoaThi").val(),
            TrangThai: sta
        }
        $.ajax({
            url: '/Admin/KhoaThi/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                showKhoaThi();
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
            MaKhoaThi: $("#MaKhoaThi").val(),
            TenKhoaThi: $("#TenKhoaThi").val(),
            TrangThai: sta
        }

        $.ajax({
            url: '/Admin/KhoaThi/Edit/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                showKhoaThi();
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
function deleteKhoaThi(id) {
    var confirmDelete = confirm("Bạn có muốn xóa thông tin khóa thi này không?");

    if (confirmDelete) {
        $.ajax({
            url: "/Admin/KhoaThi/Delete/",
            type: "POST",
            dataType: 'json',
            data: { idm: id },
            success: function (data) {
                alert("Dữ liệu đã xóa");
                showKhoaThi();
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
    $("#TenKhoaThi").val("");
    $("#TrangThai").val("");
}