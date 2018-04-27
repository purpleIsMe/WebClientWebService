
var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents:function()
    {
        $('#filter').off('click').on('click', function (e) {
            e.preventDefault();

            changeSub();
        });

        $(document).ready(function () { changeSub();});
    }
}
result.init();



function changeSub()
{
    var ke = document.getElementById("idSub");
    var kq = ke.options[ke.selectedIndex].value;
    var tenmon = ke.options[ke.selectedIndex].text;

    $.ajax({
        url: "/Admin/Module/ChangeSubject",
        type: "POST",
        dataType: "json",
        data: { idsub: kq },
        success: function (response) {
            var valitem = response.result;
            var rows = '';
            if (valitem != null) {
                $.each(valitem, function (i, item) {
                    rows += "<tr>"
                    rows += "<td>" +
                           "<button type='button' id='btnUpdate' class='btn btn-success' onclick='return getDetailQClass(" + item.idQClass + ")'>Sửa</button>" +
                           "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteQClass(" + item.idQClass + ")'>Xóa</button>"
                            + "</td>"
                    rows += "<td>" + tenmon + "</td>"
                    rows += "<td>" + item.Descr + "</td>"
                    rows += "<td>" + item.ClassNbr + "</td>"
                    rows += "<td>" + item.ChuThich + "</td>"
                    rows += "<td>" + (item.TrangThai ? "Cho phép sử dụng" : "Không được phép sử dụng") + "</td>"
                    rows += "</tr>";
                    $("#dataTables-example tbody").html(rows);
                });
            }
            else
                alert("Môn học này không có module");
        }
    });
}
var isUpdatable = false;
var idmod;
function getDetailQClass(id)
{
    idmod=id;
    $("#title").text("Thông tin module");
    $.ajax({
        url: "/Admin/Module/Get/"+id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#NameModule").val(data.Descr);
            $("#NumQues").val(data.ClassNbr);
            $("#Note").val(data.ChuThich);
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
function createQClass()
{
    $("#title").text("Thông tin thêm mới module");
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
           idQClass: $("#idSub").val(),
            Descr: $("#NameModule").val(),
            ClassNbr: $("#NumQues").val(),
            ChuThich: $("#Note").val(),
            TrangThai: sta
        }
        $.ajax({
            url: '/Admin/Module/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                changeSub();
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
            idQClass: idmod,
            Descr: $("#NameModule").val(),
            ClassNbr: $("#NumQues").val(),
            ChuThich: $("#Note").val(),
            TrangThai: sta
        }
        $.ajax({
            url: '/Admin/Module/Edit/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                changeSub();
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
function deleteQClass(id)
{
    var confirmDelete = confirm("Bạn có muốn xóa module này không?");
    if (confirmDelete) {
        $.ajax({
            url: "/Admin/Module/Delete/",
            type: "POST",
            dataType: 'json',
            data:{idm: id},
            success: function (data) {
                alert("Dữ liệu đã xóa");
                changeSub();
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
    $("#NameModule").val("");
    $("#NumQues").val("");
    $("#Note").val("");
    $("#Status").val("");
}