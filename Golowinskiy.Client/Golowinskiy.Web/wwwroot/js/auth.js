window.onload = function () {
    $.ajax({
        type: "GET",
        url: "/Auth/Login",
        success: function (data) {
            $('.modal_inner').html(data);
        }
    });
};

function ShowRegistrationWindow() {
    $.ajax({
        type: "GET",
        url: "/Auth/Registration",
        success: function (data) {
            $('.modal_inner').html(data);
        }
    });
}

function ShowRecoveryWindow() {
    $.ajax({
        type: "GET",
        url: "/Auth/Recovery",
        success: function (data) {
            $('.modal_inner').html(data);
        }
    });
}

function Login() {
    var mobile = document.getElementById("mobile").value;
    var password = document.getElementById("password").value;

    $.ajax({
        type: 'POST',
        url: '/Auth/LoginAsync',
        data: {
            PhoneNumber: mobile,
            Password: password
        },
        success: function (data) {
            $('.alert').text(data);
            setTimeout(() => window.location.href = '/Cabinet/Cabinet', 2000);
        },
        error: function (jqXHR, exception) {
            $('.alert').text(jqXHR.responseText);
        }
    });
}

function Registration() {
    var userName = document.getElementById("userName").value;
    var mobile = document.getElementById("mobile").value;
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    $.ajax({
        type: 'POST',
        url: '/Auth/RegistrationAsync',
        data: {
            UserName: userName,
            PhoneNumber: mobile,
            Email: email,
            Password: password
        },
        success: function (data) {
            $('.alert').text(data);
            setTimeout(() => window.location.href = '/Home/Index', 2000);
        },
        error: function (jqXHR, exception) {
            if (jqXHR.responseText === "DuplicateUserName") {
                $('.alert').text("Пользователь с именем " + userName + " уже существует");
            } else {
                $('.alert').text(jqXHR.responseText);
            }
        }
    });
}

function CloseModalWindow() {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
}