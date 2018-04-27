var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents: function () {
        $(document).ready(function () {
            changeClass();
            changeClassmodel();
            hidePleaseWait();
            changeTest();
        });
    }
}
result.init();
var isUpdatable = false;
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
            showTSByIdCaCT();
            $.getJSON('/MakeTest/getMonThi', { id: $('#cathi').val() }, function (data) {
                $('#monthi').append('<option value=' +
                    data.IDMon + '>' + data.NameSubject + '</option>');
            })
        })
    });

    $('#cathi').on('change', function () {
        showTSByIdCaCT();
        $('#monthi option').remove();
        var kq = $('#cathi').val();
        $.getJSON('/MakeTest/getMonThi', { id: $('#cathi').val() }, function (data) {
            $('#monthi').append('<option value=' +
                data.IDMon + '>' + data.NameSubject + '</option>');
        })
    });
    $('#monthi').on('change', function () {
        showTSByIdCaCT();
    });

function changeClass() {
    // Get a list of classes and a list of lecturers of the first lectuers.
    $.getJSON('/Students/GetListUsers', null, function (data) {
        $.each(data, function () {
            $('#lecturer').append('<option value=' +
              this.ID + '>' + this.Name + '</option>');
        });
        $.getJSON('/Students/GetListClass', { userid: $('#lecturer').val() }, function (data) {
            $.each(data, function () {
                $('#class').append('<option value=' +
                  this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting this class!');
        });
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert('Error getting this lecturer!' + errorThrown);
    });

    // Dropdown list change event.
    $('#lecturer').change(function () {
        $('#class option').remove();
        $.getJSON('/Students/GetListClass', { userid: $('#lecturer').val() }, function (data) {
            $.each(data, function () {
                $('#class').append('<option value=' +
                    this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting class change event!');
        });
    });
};
function changeClassmodel() {
    // Get a list of classes and a list of lecturers of the first lectuers.
    $.getJSON('/Students/GetListUsers', null, function (data) {
        $.each(data, function () {
            $('#IDLecturer').append('<option value=' +
              this.ID + '>' + this.Name + '</option>');
        });
        $.getJSON('/Students/GetListClass', { userid: $('#IDLecturer').val() }, function (data) {
            $.each(data, function () {
                $('#IDClass').append('<option value=' +
                  this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting this class!');
        });
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert('Error getting this lecturer!' + errorThrown);
    });

    // Dropdown list change event.
    $('#IDLecturer').change(function () {
        $('#IDClass option').remove();
        $.getJSON('/Students/GetListClass', { userid: $('#IDLecturer').val() }, function (data) {
            $.each(data, function () {
                $('#IDClass').append('<option value=' +
                    this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting class change event!');
        });
    });
};
var isUpdatable = false;
$('#btnFilterClass').click(function () {
    var kq = $('#class').val();
    
    $.getJSON('/Admin/Students/GetListStudentByClass', { classid: kq }, function (data) {
                    var rows = '';
                    if (data != null) {
                        $.each(data, function (i, item) {
                            rows += "<tr>"
                            rows += "<td>" +
                                   "<button type='button' id='btnUpdate' class='btn btn-success' onclick='return getDetailStudent(" + item.ID + ")'>Sửa</button>" +
                                   "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteStudent(" + item.ID + ")'>Xóa</button>"
                                    + "</td>"
                            rows += "<td>" + item.Name + "</td>"
                            rows += "<td>" + (item.Gender ? "Nữ" : "Nam") + "</td>"
                            rows += "<td>" + item.Born + "</td>"
                            rows += "<td>" + item.Address + "</td>"
                            rows += "<td>" + item.Mobile + "</td>"
                            rows += "<td>" + item.CMND + "</td>"
                            rows += "<td>" + item.Email + "</td>"
                            rows += "<td>" + item.Password + "</td>"
                            rows += "<td>" + item.UserName + "</td>"
                            rows += "<td>" + (item.Active? "Hoạt động" : "Bị khóa") + "</td>"
                            rows += "<td>" + (item.TrangThai ? "Cho phép sử dụng" : "Không được phép sử dụng") + "</td>"
                            $("#dataTables-example tbody").html(rows);
                        });
                    }
                    else
                        alert("Lớp này không có sinh viên");
                });
});
$('#btnSubmit').click(function () {
    var x = {
        idclass: $('#class').val(), 
        idlect: $('#lecturer').val()
            };
    $.ajax({
        url: "/Students/getInfoLecClass",
        type: "POST",
        dataType: "json",
        data:x,
        success: function (data) {
        }
    });

    showPleaseWait();
});
function showPleaseWait() {
    var modalLoading = '<div class="modal" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false role="dialog">\
        <div class="modal-dialog">\
            <div class="modal-content">\
                <div class="modal-header">\
                    <h4 class="modal-title">Please wait...</h4>\
                </div>\
                <div class="modal-body">\
                    <div class="progress">\
                      <div class="progress-bar progress-bar-success progress-bar-striped active" role="progressbar"\
                      aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width:100%; height: 40px">\
                      </div>\
                    </div>\
                </div>\
            </div>\
        </div>\
    </div>';
    $(document.body).append(modalLoading);
    $("#pleaseWaitDialog").modal("show");
}
/**
 * Hides "Please wait" overlay. See function showPleaseWait().
 */
function hidePleaseWait() {
    $("#pleaseWaitDialog").modal("hide");
}

var idmod;
function getDetailStudent(id) {
    idmod = id;
    $("#title").text("Thông tin sinh viên");
    $.ajax({
        url: "/Admin/Students/Get/" + id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#Name").val(data.Name);
            $("#Born").val(data.Born);
            $("#Mobile").val(data.Mobile);
            $("#Address").val(data.Address);
            $("#Email").val(data.Email);
            $("#UserName").val(data.UserName);
            $("#Password").val(data.Password);
            $("#CMND").val(data.CMND);
            $("#Active").prop('checked', data.Active);
            $("#Status").prop('checked', data.Status);
            if (data.Gender == true) //nam la true, nu la false
            {
                $("#Nam").prop('checked', true);
                $("#Nu").prop('checked', false);
            }
            else
            {
                $("#Nam").prop('checked', false);
                $("#Nu").prop('checked', true);
            }
            isUpdatable = true;
            $("#bookModal").modal('show');
        },
        error: function (err) {
            alert(id);
            alert("Error: " + err.responseText);
        }
    });
}
function createStudent() {
    $("#title").text("Thông tin thêm mới sinh viên");
    isUpdatable = false;
    $("#bookModal").modal('show');
}
// hàm Insert và Update một record
$("#btnSave").click(function (e) {
    e.preventDefault();
    var sta, act, gender;
    var x = document.getElementById("Status");
    if (x.checked = true)
        sta = true;
    else
        sta = false;
    var y = document.getElementById("Active");
    if (y.checked = true)
        act = true;
    else
        act = false;
    var nam = document.getElementById("Nam");
    var nu = document.getElementById("Nu");
    if (nam.checked = true)
        gender = true;
    if (nu.checked = true)
        gender = false;
    if (!isUpdatable) {
        var data = {
            IDLecturer: $("#lecturer").val(),
            IDClass: $("#class").val(),
            Name:$("#Name").val(),
            Born:$("#Born").val(),
            Mobile:$("#Mobile").val(),
            Address:$("#Address").val(),
            Email:$("#Email").val(),
            UserName:$("#UserName").val(),
            Password:$("#Password").val(),
            CMND:$("#CMND").val(),
            Active:act,
            Status:sta,
            Gender:gender
        }
        $.ajax({
            url: '/Admin/Students/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                //changeClass(); changeClassmodel();
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
            ID: idmod,
            IDLecturer: $("#lecturer").val(),
            IDClass: $("#class").val(),
            Name: $("#Name").val(),
            Born: $("#Born").val(),
            Mobile: $("#Mobile").val(),
            Address: $("#Address").val(),
            Email: $("#Email").val(),
            UserName: $("#UserName").val(),
            Password: $("#Password").val(),
            CMND: $("#CMND").val(),
            Active: act,
            Status: sta,
            Gender: gender
        }

        $.ajax({
            url: '/Admin/Students/Edit/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                //changeClass(); changeClassmodel();
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
function deleteStudent(id) {
    var confirmDelete = confirm("Bạn có muốn xóa thông tin sinh viên này không?");

    if (confirmDelete) {
        $.ajax({
            url: "/Admin/Students/Delete/",
            type: "POST",
            dataType: 'json',
            data: { idm: id },
            success: function (data) {
                alert("Dữ liệu đã xóa");
                //changeClass();
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
    $("#lecturer").val(""),
    $("#class").val(""),
    $("#Name").val(""),
    $("#Born").val(""),
    $("#Born").val(""),
    $("#Address").val(""),
    $("#Email").val(""),
    $("#UserName").val(""),
    $("#Password").val(""),
    $("#CMND").val("")
}

function showTSByIdCaCT()
{
        id= $('#cathi').val();
    $.ajax({
        url: "/Admin/Students/GetListThiSinh/" + id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            var rows = '';
            if (data != null) {
                $.each(data, function (i, item) {
                    rows += "<tr>"
                    rows += "<td>" +
                           "<button type='button' id='btnCantTest' class='btn btn-danger' onclick='return cantTest(" + item.ID + ")'>Tắt cho phép thi</button>"
                            + "</td>"
                    rows += "<td>" + item.HoTen + "</td>"
                    rows += "<td>" + item.Password + "</td>"
                    rows += "<td>" + item.MaDuThi + "</td>"
                    rows += "<td>" + item.SoMay + "</td>"
                    rows += "<td>" + item.MaDeThi + "</td>"
                    rows += "<td>" + (item.GioiTinh ? "Nữ" : "Nam") + "</td>"
                    rows += "<td>" + item.NgaySinh + "</td>"
                    rows += "<td>" + item.DiaChi + "</td>"
                    rows += "<td>" + item.SDT + "</td>"
                    rows += "<td>" + item.CMND + "</td>"
                    rows += "<td>" + item.Email + "</td>"
                    rows += "<td>" + item.ThoiGian + "</td>"
                    rows += "<td>" + (item.DaHoanThanh ? "Đã hoàn thành" : "Chưa làm bài thi") + "</td>"
                    rows += "<td>" + (item.TrangThai ? "Cho phép sử dụng" : "Không được phép sử dụng") + "</td>"
                    $("#dssv tbody").html(rows);
                });
            }
            else
                alert("Chưa có thí sinh đăng kí thi");
        }
    });
}

$("#btnGetAccount").click(function () {
    var value = {
        idcathi: $('#cathi').val(),
        idclass: $('#class').val()
    };
    $.ajax({
        url: "/Admin/Students/ConvertStudentToThiSinh",
        type: "POST",
        dataType: "json",
        data: value,
        success: function (data) {
            showTSByIdCaCT();
        }
    });
});

$("#btnPhanDe").click(function () {
    var data = {
        idcathi: $('#cathi').val()
    };
    $.ajax({
        url: "/Admin/Students/PhanDeTS",
        type: "POST",
        dataType: "json",
        data: data,
        success: function (data) {
            if (data == false)
                alert("Không tìm thấy đề chuẩn của ca thi này");
            showTSByIdCaCT();
        }
    });
});