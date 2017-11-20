var pass = document.getElementById("Password");
var repass = document.getElementById("RePass");
var mess = document.getElementById("Message");

mess.textContent = "";
pass.onfocus = function () {
    document.getElementById("Message").style.display = "block";
}
// When the user starts to type something inside the password field
pass.onkeyup = function () {
    // Validate lowercase letters
    var lowerCaseLetters = /[a-z]/g;
    if (!pass.value.match(lowerCaseLetters)) {
        mess.textContent = "Phải có kí tự chữ cái viết thường";
    }

    // Validate capital letters
    var upperCaseLetters = /[A-Z]/g;
    if (!myInput.value.match(upperCaseLetters)) {
        mess.textContent = "Phải có kí tự chữ cái viết hoa";
    }

    // Validate numbers
    var numbers = /[0-9]/g;
    if (!myInput.value.match(numbers)) {
        mess.textContent = "Phải có kí tự chữ số";
    }

    // Validate length
    if (myInput.value.length < 8) {
        mess.textContent = "Phải có ít nhất 8 kí tự";
    }

    repass.onblur = function () {
        if (pass != repass)
            mess.textContent = "Mật khẩu nhập lại không trùng khớp";
    }
}