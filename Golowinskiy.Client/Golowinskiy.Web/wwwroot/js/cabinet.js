window.onload = function () {
        $.ajax({
            type: "GET",
            url: "/Cabinet/Header",
            success: function (data) {
                $('#sumLink').css('display', 'none');
                $('.header_list_item_cabinet').css('display', 'none');
                $('#spanBack').css('display', 'inline');
                $('#cbn-u').html(data);
                $('.name').css('display', 'inline');
                $('#userName').css('display', 'inline');
            }
        });
   
    var backgroundImgs = [
        'http://golowinskiy-api.bostil.ru/mainimages/08.12.2018.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/10.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/18.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/19.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/21.01.2019.jpg'
    ];

    $.ajax({
        type: "GET",
        url: "/Category/GetCategoriesByUser",
        success: function (data) {
            $('#categories').append(data);
        }
    });

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
}

function openLogOut() {
    if ($('#logMenu').css('display') === 'block') {
        $('#logMenu').css('display', 'none');
    } else {
        $('#logMenu').css('display', 'block');
    }
}

function categoryClick(categoryId) {
    window.location.href = "/Product/GetProductsByCategory?categoryId=" + categoryId;
}
