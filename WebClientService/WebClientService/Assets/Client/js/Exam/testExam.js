var idDeTron = 1;

$(document).ready(function () {
    console.log("vô đây rồi");
    getTest();
});
var x;

function getTest()
{
    $.ajax({
        url: "getQuestion/"+idDeTron,
        type: "GET",
        dataType: "json",
        //data: { iddetron: idDeTron },
        success: function (data) {
            console.log("vô kq");
            var valitem = data.result;
            alert(valitem);
            console.log(data.sl);
            //var rows = '';
            //$.each(valitem, function (i, item) {
            //    alert(count);
            //    console.log(valitem);
            //    //rows += "<tr>"
            //    //rows += "<td>" +
            //    //       "<button type='button' id='btnUpdate' class='btn btn-success' onclick='return getDetailQClass(" + item.IDQClass + ")'>Sửa</button>" +
            //    //       "<button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteQClass(" + item.IDQClass + ")'>Xóa</button>"
            //    //        + "</td>"
            //    //rows += "<td>" + tenmon + "</td>"
            //    //rows += "<td>" + item.Descr + "</td>"
            //    //rows += "<td>" + item.ClassNbr + "</td>"
            //    //rows += "<td>" + item.ChuThich + "</td>"
            //    //rows += "<td>" + (item.TrangThai ? "Cho phép sử dụng" : "Không được phép sử dụng") + "</td>"
            //    //rows += "</tr>";
            //    //$("#dataTables-example tbody").html(rows);
            //});
        },
        error: function (err) {
        alert("Error: " + err.responseText);
        }
    });
}