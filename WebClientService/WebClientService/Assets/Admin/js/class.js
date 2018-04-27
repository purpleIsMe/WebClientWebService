
var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents: function () {
        $('#filter').off('click').on('click', function (e) {
            e.preventDefault();

            changeClass();
        });

        $(document).ready(function () { changeClass(); });
    }
}
result.init();



function changeClass() {
    var ke = document.getElementById("IDLecturer");
    var kq = ke.options[ke.selectedIndex].value;
    var tenmon = ke.options[ke.selectedIndex].text;

    $.ajax({
        url: "/Admin/Classes/ChangeClass",
        type: "POST",
        dataType: "json",
        data: { idsub: kq },
        success: function (response) {
            var valitem = response.result;
            
            var rows = '';
            if (valitem.length != 0) {
                $.each(valitem, function (i, item) {
                    rows += "<tr>"
                    rows += "<td>" +
                           "<button type='button' id='btnUpdate' class='btn btn-success' onclick='return getDetailClass(" + item.IDClass + ")'>Sửa</button>" +
                           "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteClass(" + item.IDClass + ")'>Xóa</button>"
                            + "</td>"
                    rows += "<td>" + tenmon + "</td>"
                    rows += "<td>" + item.NameClass + "</td>"
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
function getDetailClass(id) {
    idmod = id;
    $("#title").text("Thông tin lớp");
    $.ajax({
        url: "/Admin/Classes/Get/" + id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#IDLecturer").val(data.IDLecturer);
            $("#NameClass").val(data.NameClass);
            $("#Status").prop('checked', data.TrangThai);
            isUpdatable = true;
            $("#bookModal").modal('show');
        },
        error: function (err) {
            alert(id);
            alert("Error: " + err.responseText);
        }
    });
}
function createClass() {
    $("#title").text("Thông tin thêm mới lớp");
    isUpdatable = false;
    $("#bookModal").modal('show');
}
// hàm Insert và Update một record
$("#btnSave").click(function (e) {
    e.preventDefault();
    var sta;
    var x = document.getElementById("Status");
    if (x.checked = true)
        sta = true;
    else
        sta = false;
    if (!isUpdatable) {
        var data = {
            IDLecturer: $("#IDLecturer").val(),
            NameClass: $("#NameClass").val(),
            TrangThai: sta
        }
        $.ajax({
            url: '/Admin/Classes/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                changeClass();
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
            IDClass: idmod,
            IDLecturer: $("#IDLecturer").val(),
            NameClass: $("#NameClass").val(),
            TrangThai: sta
        }
        
        $.ajax({
            url: '/Admin/Classes/Edit/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                changeClass();
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
function deleteClass(id) {
    var confirmDelete = confirm("Bạn có muốn xóa thông tin lớp này không?");
    
    if (confirmDelete) {
        $.ajax({
            url: "/Admin/Classes/Delete/",
            type: "POST",
            dataType: 'json',
            data: { idm: id },
            success: function (data) {
                alert("Dữ liệu đã xóa");
                changeClass();
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
    $("#NameClass").val("");
    $("#Status").val("");
}