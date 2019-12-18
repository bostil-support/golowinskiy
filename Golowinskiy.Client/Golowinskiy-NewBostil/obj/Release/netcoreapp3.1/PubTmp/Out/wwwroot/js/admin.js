window.onload = function () {
    let title = document.querySelector('.header_list_item_welcom > h2');
    title.innerText = "Административная панель";
    title.style.color = "black";

    if ($(window).width() <= 900) {
        $('.header_list_item_welcom > span').text('Административная панель');
    }

    var backgroundImgs = [
        'http://golowinskiy-api.bostil.ru/mainimages/08.12.2018.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/10.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/18.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/19.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/21.01.2019.jpg'
    ];

    var fon = this.document.getElementById('fon-image');
    var index = Math.floor(Math.random() * 5);
    fon.style.background = 'url("' + backgroundImgs[index] + '") 50% 50% no-repeat';

    let now = new Date();
    document.getElementById('doc_clock').textContent = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', hour12: false });
    document.getElementById('doc_day').textContent = now.toLocaleDateString('ru', { weekday: 'long', month: 'long', day: 'numeric' });

    setTimeout(() => {
        document.getElementById('doc_clock').style.opacity = 0;
        document.getElementById('doc_day').style.opacity = 0;
    }, 3000);

    $.ajax({
        type: "GET",
        url: "/Admin/Header",
        success: function (data) {
            $('#header-viget').html(data);
            $('.name').css('display', 'inline');
            $('#userName').css('display', 'inline');
        }
    });

    $('.firstBlockMobile').css('display', 'none');
};

let coef = document.querySelectorAll('.coef');

for (let elem of coef) {
    
    const input = elem.querySelector('input');
    const send = elem.querySelector('button');
    const p = elem.querySelector('p');
    elem.style.position = "relative";
    p.onclick = () => {
        input.style.display = "block ";
        send.style.display = "block ";

    };

    send.innerHTML = "изменить";

    send.addEventListener('click', function () {
        let tr = input.parentNode.parentNode;
        let userId = tr.querySelector('.fa-user').getAttribute('value');
        updateCoefficient(input.value, userId);
        p.innerText = input.value;
        input.style.display = "none";
        send.style.display = "none ";       
    });
}

function GetUserProducts(userId) {
    window.location.href = "/Admin/GetUserProducts?userId=" + userId;
}

function showDetails(choosenDiv, id) {
    choosenDiv.classList.add('choose');

    if (document.getElementById('detail-page') !== null) {
        let child = document.getElementById('detail-page');
        let parent = child.parentNode;
        parent.removeChild(child);
    }

    $.ajax({
        type: "GET",
        url: "/Product/ProductDetail?id=" + id,
        success: function (data) {
            $('.container.body-content').append(data);
            if (document.getElementsByClassName('products_list_item').length > 1) {
                document.getElementsByClassName('arrows')[0].style.display = 'block';
                document.getElementsByClassName('arrows')[1].style.display = 'block';
            }
        }
    });
}

function closeWindow() {
    let child = document.getElementById('detail-page');
    let parent = child.parentNode;
    parent.removeChild(child);

    let choosenDiv = document.getElementsByClassName('choose')[0];
    choosenDiv.classList.remove('choose');
}

function showAddtImage(src) {
    let mainImg = document.getElementById('mainImg');
    mainImg.src = src;
}

function showNextProduct(currProd) {
    let choosenDiv = document.getElementsByClassName('choose')[0];
    let arrProdDivs = Array.from(document.getElementsByClassName('products_list_item'));
    let index = arrProdDivs.indexOf(choosenDiv);

    choosenDiv.classList.remove('choose');
    if (index !== arrProdDivs.length - 1) {
        arrProdDivs[index + 1].click();
    } else {
        arrProdDivs[0].click();
    }
}

function setEdit(coef, index) {
    let input = document.getElementsByClassName('formReplace')[index];
    input.textContent = coef;
}

function updateCoefficient(coefficient, userId) {
    $.ajax({
        type: "PUT",
        data: { Coefficient: parseFloat(coefficient), UserId: userId },
        url: "/Admin/UpdateCoefficient",
        success: function (data) {
        }
    });
}

function openLogOut() {
    if ($('#logMenu').css('display') === 'block') {
        $('#logMenu').css('display', 'none');
    } else {
        $('#logMenu').css('display', 'block');
    }
}