var idDeTron = 10;

$(document).ready(function () {
    console.log("vô đây rồi");
    getTest();
    getInfo();
});
var x;

function getTest()
{
    $.ajax({
        url: "TestExam/getQuestion/"+idDeTron,
        type: "GET",
        dataType: "json",
        //data: { iddetron: idDeTron },
        success: function (data) {
            var length = data.length;
            //load field answer 
            var i = 1;
            var row = "";
            row += "<tr>";
            row += "<th> Câu hỏi</th>";
            row += "<th>A</th>";
            row += "<th>B</th>";
            row += "<th>C</th>";
            row += "<th>D</th>";
            row += "<th></th>";
            row += "</tr>";
            $("#loadans").html(row);
            for(i;i<=length;i++)
            {
                row += "<tr>";
                row += "<td id='sttAns'><center>" + i + "</center></td>";
                row += "<td><center><input type = 'Radio' name= 'valA' value= 'A'></center></td>";
                row += "<td><center><input type = 'Radio' name= 'valB' value= 'B'></center></td>";
                row += "<td><center><input type = 'Radio' name= 'valC' value= 'C'></center></td>";
                row += "<td><center><input type = 'Radio' name= 'valD' value= 'D'></center></td>";
                row += "<td><center><input value='" + i + "' id='idans' hidden></center></td>";
                row += "</tr>";
                $("#loadans").html(row);
            }
          


            console.log("da vo gettest roi");
            console.log(data);
            var k=1;
            document.getElementById('cau').setAttribute("disabled", "disabled");
            
            var id = $('#cau').val();
            $('#stt').val("Câu " + id);
            if (id == 1) {
                getTestExtracted(data, 0);
                document.getElementById('back').setAttribute("disabled", "disabled");
                document.getElementById('next').removeAttribute("disabled");
            }
            
            $("#next").click(function ()
            {
                if (id == length) {
                    getTestExtracted(data, id - 1);

                    document.getElementById('next').setAttribute("disabled", "disabled");
                    document.getElementById('back').removeAttribute("disabled");
                }
                else {
                    document.getElementById('back').removeAttribute("disabled");
                    document.getElementById('next').removeAttribute("disabled");

                    k = id;
                    getTestExtracted(data, k);
                    id++;
                    $('#cau').val(id);
                    $('#stt').val("Câu " + id);
                }
            });
            $("#back").click(function ()
            {
                if (id == 1) {
                    document.getElementById('back').setAttribute("disabled", "disabled");
                    document.getElementById('next').removeAttribute("disabled");
                }
                else {
                    document.getElementById('back').removeAttribute("disabled");
                    document.getElementById('next').removeAttribute("disabled");
                    id--;
                    id--;
                    getTestExtracted(data, id);

                    id++;
                    $('#cau').val(id);
                    $('#stt').val("Câu "+id);
                }
            });

            
        },
        error: function (err) {
        alert("Error: " + err.responseText);
        }
    });
}

$("#start-end").click(function () {
   // clock();
});

function getTestExtracted(valitem, i)
{
    var rows = '';
    if (valitem[i] != null) {
        rows = "<img src='" + valitem[i].sQues + "'" + "height=auto width='1100'/>";
        $("#question div").html(rows);

        rows = "<img src='" + valitem[i].sAns1 + "'" + "height=100 width='400'/>";
        $("#answer #answer1").html(rows);

        rows = "<img src='" + valitem[i].sAns2 + "'" + "height=100 width='400'/>";
        $("#answer #answer2").html(rows);

        rows = "<img src='" + valitem[i].sAns3 + "'" + "height=100 width='400'/>";
        $("#answer #answer3").html(rows);

        rows = "<img src='" + valitem[i].sAns4 + "'" + "height=100 width='400'/>";
        $("#answer #answer4").html(rows);

        if($("#idans").val() == i)
            $("#idans").val(valitem[i].id);
    }
}

function getInfo()
{
    $.ajax({
        url: "TestExam/getInfo/",
        type: "GET",
        dataType: "json",
        success: function (data) {

                    $("#maduthi").val(data.MaDuThi);
                    $("#hoten").val(data.HoTen);
                    $("#monthi").val(data.MonThi);
                    $("#thoigian").val(data.TGThi);


                    var n = new Date();
                    var y = n.getFullYear();
                    var m = n.getMonth() + 1;
                    var d = n.getDate();
                    $("#ngaythi").val(m + "/" + d + "/" + y);
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

function clock()
{
    var time = $("#thoigian").val();
    // Thiết lập thời gian đích mà ta sẽ đếm
    //var countDownDate = new Date("April 9, 2018 15:37:25").getTime();

    // cập nhập thời gian sau mỗi 1 giây
    var x = setInterval(function () {

        // Tính toán số ngày, giờ, phút, giây từ thời gian chênh lệch
        var minutes = Math.floor(time % 60);
        var seconds = Math.floor(time % (minutes * 60));

        // HIển thị chuỗi thời gian trong thẻ p
        //  document.getElementById("counttime").innerHTML = minutes + " : " + seconds;
        $("#counttime").val(minutes + " : " + seconds);

        // Nếu thời gian kết thúc, hiển thị chuỗi thông báo
        if (ctime < 0) {
            clearInterval(x);
            document.getElementById("counttime").innerHTML = "Thời gian đếm ngược đã kết thúc";
        }
    }, 1000);
}

