window.onload = function () {
    $.ajax({
        type: "GET",
        url: "/Auth/Login",
        success: function (data) {
            $('.modal_inner').html(data);
        }
    });

    var backgroundImgs = [
        'http://golowinskiy-api.bostil.ru/mainimages/08.12.2018.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/10.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/18.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/19.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/21.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/20.09.2019.jpg'
    ];

    var fon = this.document.getElementById('fon-image');
    var index = Math.floor(Math.random() * 6);
    fon.style.background = 'url("' + backgroundImgs[index] + '") 50% 50% no-repeat';

    let now = new Date();
    document.getElementById('doc_clock').textContent = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', hour12: false });
    document.getElementById('doc_day').textContent = now.toLocaleDateString('ru', { weekday: 'long', month: 'long', day: 'numeric' });

    setTimeout(() => {
        document.getElementById('doc_clock').style.opacity = 0;
        document.getElementById('doc_day').style.opacity = 0;
    }, 3000);
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