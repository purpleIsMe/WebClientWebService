$(document).ready(function () {
    document.getElementById('cau').setAttribute("disabled", "disabled");
    getInfo();
    alert("Lưu ý sau khi hoàn thành bài thi và nhấn nút Kết thúc.\nBạn sẽ được xem điểm và đáp án trong vòng 10p\nBạn sẽ không thể quay lại thi được nữa");
    getTest(numAns);
});
var idde;
var numAns = {};
var setTime = {};
var dapAn = new Array();

function getTest(numAns)
{
    $.ajax({
        url: "TestExam/getQuestion/",
        type: "GET",
        dataType: "json",
        success: function (data) {
            
            var length = data.length;
            numAns.value = length;

            getTheAnswer(data);

            var id = $('#cau').val();
            $('#stt').val("Câu " + id);
            if (id == 1) {
                getTestExtracted(data, 0);
                document.getElementById('back').setAttribute("disabled", "disabled");
                document.getElementById('next').setAttribute("disabled","disabled");
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
                    getTestExtracted(data, id);
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

function saveAnswer()
{
    var score = Math.round(diem.value);
    var time = $("#counttime").val();
    var res1 = time.split(":");
    var timetotal;
    if (res1[1] > 40)
        timetotal = Math.ceil(res1[0]);
    else
        timetotal = res1[0];
    
    var j = 0; var x = 0;
    var maduthi = $("#maduthi").val();

    var jsonStr = {};
    var json = [];


    for (var i = 0, j, x; i < numAns.value; i++, j = j + 4, x = x + 2) {
        json.push({"ThuTuCauHoi": valueAns[x],
            "Answer": valueAns[x + 1], "DapAn": dapAn[j + 3], "QuestionID": dapAn[j + 2]
        });
    }
      
    jsonStr = { "IDThiSinh": maduthi, "DiemSo": score, "DiemThuc": diem.value, "RemainTime": timetotal, "answerSheet":json};
    
    var jsonStr1 = JSON.stringify(jsonStr);
    
    $.ajax({
        url: "TestExam/saveAns/",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: jsonStr1,
        success: function (data) {
            alert("save answersheet");
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });

}

$("#start-end").click(function () {
    var x = $("#start-end").text();
    if (x == "Kết thúc")
    {
        getAnswer(numAns.value);
        saveAnswer();
        $("#start-end").text("Điểm của bạn " + diem.value);
        clock(0);
    }
    if (x == "Bắt đầu") {
        $("#start-end").text("Kết thúc");
        clock(1);
        loadAnswer(numAns.value);
        document.getElementById('next').removeAttribute("disabled");        
    }
});

function getTestExtracted(valitem, i)
{
    var rows = '';
    if (valitem[i] != null) {
        rows = "<img src='" + valitem[i].sQues + "'" + "height=auto width='1100'/>";
        $("#question div").html(rows);

        rows = "<img src='" + valitem[i].sAns1 + "'" + "height=75 width='400'/>";
        $("#answer #answer1").html(rows);

        rows = "<img src='" + valitem[i].sAns2 + "'" + "height=75 width='400'/>";
        $("#answer #answer2").html(rows);

        rows = "<img src='" + valitem[i].sAns3 + "'" + "height=75 width='400'/>";
        $("#answer #answer3").html(rows);

        rows = "<img src='" + valitem[i].sAns4 + "'" + "height=75 width='400'/>";
        $("#answer #answer4").html(rows);

        if ($("#idans").val() == i) {
            $("#idans").val(valitem[i].ID);
        }       
    }
}

function getTheAnswer(valitem)
{
    for(var i = 0, j = 0; i < numAns.value; i++, j=j+4)
    {
        dapAn[j] = i;
        dapAn[j + 1] = valitem[i].ID;
        dapAn[j + 2] = valitem[i].QuestionID;
        dapAn[j + 3] = valitem[i].DapAn;
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
                    setTime.value = data.TGThi;

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

function clock(i)
{
    var time = setTime.value;
    // Thiết lập thời gian đích mà ta sẽ đếm
   
    time = time * 60;
    // cập nhập thời gian sau mỗi 1 giây
    var k = setInterval(function () {
        if (i == 1) {
            time = time - 1;
            var x = time;
            var y = time;
            // Tính toán số ngày, giờ, phút, giây từ thời gian chênh lệch
            var minutes = Math.floor(x / 60);
            var seconds = Math.floor(y - (minutes * 60));

            // HIển thị chuỗi thời gian trong thẻ p
            $("#counttime").val(minutes + " : " + seconds);

            // Nếu thời gian kết thúc, hiển thị chuỗi thông báo
            if (time <= 0) {
                $("#counttime").val("00:00");
                alert("Thời gian làm bài đã kết thúc");
                clearInterval(k);
                setTimeout(window.history.back(-1), 10000000);
            }
        }
        else {
            clearInterval(k);
            setTimeout(window.history.back(-1), 10000000);
        }
    }, 1000);
}

function loadAnswer(length)
{
    //load field answer 
    var i = 1;
    var row = "";
    row += "<tr>";
    row += "<th class='control-label col-md-3 col-sm-3 col-xs-11'><center>Câu hỏi</center></th>";
    row += "<th><center>A</center></th>";
    row += "<th><center>B</center></th>";
    row += "<th><center>C</center></th>";
    row += "<th><center>D</center></th>";
    // row += "<th></th>";
    row += "</tr>";
    $("#loadans").html(row);
    for (i; i <= length; i++) {
        row += "<tr>";
        row += "<td id='sttAns' class='control-label col-md-3 col-sm-3 col-xs-11'><center>" + i + "</center></td>";
        row += "<td><center><input type = 'radio' name='" + i + "' value= '" + i + "A' id= '" + i + "A'></center></td>";
        row += "<td><center><input type = 'radio' name='" + i + "' value= '" + i + "B' id= '" + i + "B'></center></td>";
        row += "<td><center><input type = 'radio' name='" + i + "' value= '" + i + "C' id= '" + i + "C'></center></td>";
        row += "<td><center><input type = 'radio' name='" + i + "' value= '" + i + "D' id= '" + i + "D'></center></td>";
        //row += "<td><center><input value='" + i + "' id='idans' hidden></center></td>";
        row += "</tr>";
        $("#loadans").html(row);
    }
}
var valueAns = new Array();
var diem = {};
function getAnswer(length)
{
    var j = 0;
    var x = 0;
    var score = 0;
    for (var i=1, j, x; i <= length; i++, j = j+2, x = x+4) {
        valueAns[j] = i-1;
        if($('#' + i + 'A').prop("checked")==true) //jquery version >= 1.6 or < 1.6 use $("#radio_1").attr('checked', 'checked');
        {
            valueAns[j+1] = 1;
        }
        if($('#' + i + 'B').prop("checked")==true)
        {
            valueAns[j+1] = 2;
        }
        if ($('#' + i + 'C').prop("checked") == true) {
            valueAns[j+1] = 3;
        }
        if ($('#' + i + 'D').prop("checked") == true) {
            valueAns[j+1] = 4;
        }
        if(dapAn[x] == valueAns[j] && dapAn[x+3] == valueAns[j+1])
        {
            score += 10 / length;
        }
    }

    diem.value = score;
}