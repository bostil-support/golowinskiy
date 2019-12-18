window.onload = function () {
    $.ajax({
        type: "GET",
        url: "/Auth/Login",
        success: function (data) {
            $('.modal_inner').html(data);
            $('#spanCab').text('Вернуться к каталогу');
            $('#spanCab').attr("onclick", "LocationCatalog()");
            $('#categories').hide();
        }
    });

    let backgroundImgs = [
        'http://golowinskiy-api.bostil.ru/mainimages/08.12.2018.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/10.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/18.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/19.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/21.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/20.09.2019.jpg'
    ];

    let fon = this.document.getElementById('fon-image');
    let index = Math.floor(Math.random() * 5);
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
    if (document.getElementById('btnLog').style.opacity === "1") {
        let spinner = document.getElementsByClassName('showSpinner')[0];
        spinner.style.display = 'block';
        let showMessage = document.getElementsByClassName('showMessage')[0];
        let alert = document.getElementsByClassName('alert')[0];

        let mobile = document.getElementById("mobile").value;
        let password = document.getElementById("password").value;

        $.ajax({
            type: 'POST',
            url: '/Auth/LoginAsync',
            data: {
                PhoneNumber: mobile,
                Password: password
            },
            success: function (data) {
                spinner.style.display = 'none';
                showMessage.style.display = 'block';
                alert.classList.remove('alert-danger');
                alert.classList.add('alert-success');
                alert.innerHTML = data;
                setTimeout(() => window.location.href = '/Cabinet/Cabinet', 2000);
            },
            error: function (jqXHR, exception) {
                spinner.style.display = 'none';
                showMessage.style.display = 'block';
                alert.classList.remove('alert-success');
                alert.classList.add('alert-danger');
                alert.innerHTML = jqXHR.responseText;
            }
        });
    }
}

function Registration() {
    if (document.getElementById('btnReg').style.opacity === "1") {
        let spinner = document.getElementsByClassName('showSpinner')[0];
        spinner.style.display = 'block';
        let showMessage = document.getElementsByClassName('showMessage')[0];
        let alert = document.getElementsByClassName('alert')[0];

        let userName = document.getElementById("userName").value;
        let mobile = document.getElementById("mobile").value;
        let email = document.getElementById("email").value;
        let password = document.getElementById("password").value;

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
                spinner.style.display = 'none';
                showMessage.style.display = 'block';
                alert.classList.remove('alert-danger');
                alert.classList.add('alert-success');
                alert.innerHTML = data;
                setTimeout(() => window.location.href = '/Home/Index', 2000);
            },
            error: function (jqXHR, exception) {
                spinner.style.display = 'none';
                showMessage.style.display = 'block';
                alert.classList.remove('alert-success');
                alert.classList.add('alert-danger');
                if (jqXHR.responseText === "DuplicateUserName") {
                    alert.innerHTML = jqXHR.responseText;
                    alert.innerHTML = "Пользователь с именем " + userName + " уже существует";
                } else {
                    alert.innerHTML = jqXHR.responseText;
                }
            }
        });
    }
}

function RecoveryPassword() {
    if (document.getElementById('btnRec').style.opacity === "1") {
        let spinner = document.getElementsByClassName('showSpinner')[0];
        spinner.style.display = 'block';
        let showMessage = document.getElementsByClassName('showMessage')[0];
        let alert = document.getElementsByClassName('alert')[0];

        let email = document.getElementById("Email").value;

        $.ajax({
            type: 'POST',
            url: '/Password/RecoveryPassword',
            data: { Email: email },
            success: function (data) {
                spinner.style.display = 'none';
                showMessage.style.display = 'block';
                alert.classList.remove('alert-danger');
                alert.classList.add('alert-success');
                alert.innerHTML = data.message;
            },
            error: function (jqXHR, exception) {
                spinner.style.display = 'none';
                showMessage.style.display = 'block';
                alert.classList.remove('alert-success');
                alert.classList.add('alert-danger');
                alert.innerHTML = JSON.parse(jqXHR.responseText).message;
            }
        });
    }
}

function checkFilledRequiredLoginFields() {
    let isFilled = false;
    let mobile = document.getElementById("mobile").value;
    let password = document.getElementById("password").value;

    if (mobile && password) {
        isFilled = true;
    }
    else {
        isFilled = false;
    }

    if (isFilled) {
        document.getElementById('btnLog').style.opacity = 1;
        document.getElementById('btnLog').style.cursor = 'pointer';
    } else {
        document.getElementById('btnLog').style.opacity = 0.65;
        document.getElementById('btnLog').style.cursor = 'default';
    }
}

function checkFilledRequiredRegFields() {
    let isFilled = false;
    let userName = document.getElementById("userName").value;
    let mobile = document.getElementById("mobile").value;
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;

    if (userName && mobile && email && password) {
        isFilled = true;
    }
    else {
        isFilled = false;
    }

    if (isFilled) {
        document.getElementById('btnReg').style.opacity = 1;
        document.getElementById('btnReg').style.cursor = 'pointer';
    } else {
        document.getElementById('btnReg').style.opacity = 0.65;
        document.getElementById('btnReg').style.cursor = 'default';
    }
}

function checkFilledRequiredRecoveryFields() {
    let isFilled = false;
    let email = document.getElementById("Email").value;

    if (email) {
        isFilled = true;
    }
    else {
        isFilled = false;
    }

    if (isFilled) {
        document.getElementById('btnRec').style.opacity = 1;
        document.getElementById('btnRec').style.cursor = 'pointer';
    } else {
        document.getElementById('btnRec').style.opacity = 0.65;
        document.getElementById('btnRec').style.cursor = 'default';
    }
}

function CloseModalWindow() {
    let modal = document.getElementById("myModal");
    modal.style.display = "none";
}

function LocationCatalog() {
    document.getElementById('mobileUl').style.display = 'none';
    window.location.href = '../Home/Index';
}
