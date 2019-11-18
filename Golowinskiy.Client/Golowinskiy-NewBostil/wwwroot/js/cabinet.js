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
            $('#spanCab').text('Вернуться к каталогу');
            $('#spanCab').attr("onclick", "LocationCatalog()");
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
        success: categoriesSuccess
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
};

function categoriesSuccess(data) {
    $('#categories').append(data);
    let categoryId = localStorage.getItem('id');
    if (categoryId !== null) {
        let li = document.getElementById(categoryId);
        li.classList.add('choose');
        li.classList.remove('active');

        if (li.childNodes[1] !== undefined && $(window).width() >= 900) {
            li.childNodes[1].style.display = 'block !important';
            li.childNodes[1].style.position = 'absolute';
            li.childNodes[1].style.top = '-2px';
            li.childNodes[1].style.left = '246px';
            li.parentNode.style.overflow = 'visible';
        }

        if ($(window).width() <= 1079) {
            checkChoosenCategory(li.parentNode);
        }

        li = li.parentNode.parentNode;


        while (li.id > 0) {
            showSubCategories(li, event);
            li = li.parentNode.parentNode;
        }
    }

    localStorage.clear();
}

function openLogOut() {
    if ($('#logMenu').css('display') === 'block') {
        $('#logMenu').css('display', 'none'); 
    } else {
        $('#logMenu').css('display', 'block');
    }
}

function categoryClick(li, categoryId, event) {
    event.cancelBubble = true;
    //if ($(window).width() <= 900) {
    //    localStorage.setItem('categoryId', categoryId);
    //}

    //chooseCategoryId = categoryId;

    //$.ajax({
    //    type: 'GET',
    //    url: '/Product/GetProductsByCategory?categoryId=' + categoryId,
    //    success: categoryClickSuccess
    //});

    if ($(window).width() <= 900) {
        let parent = li.parentNode;
        li.classList.remove('choose');
        li.classList.add('active');

        let activeChilds = $(parent).children('.active');
        let chlds = $(parent).children();
        $(chlds).css('display', 'none');
        $(activeChilds).css('display', 'block');

        localStorage.setItem('categoryId', categoryId);

        if (li.classList.contains('choose')) {
            li.classList.remove('choose');
            li.classList.add('active');

            let widget = $(parent).children('.active');
            $(widget).css('display', 'block');
        } else {
            li.classList.remove('active');
            li.classList.add('choose');

            let widget = $(parent).children('.active');
            $(widget).css('display', 'none');
        }
    }

    chooseCategoryId = categoryId;

    $.ajax({
        type: 'GET',
        url: '/Product/GetProductsByCategory?categoryId=' + categoryId,
        success: categoryClickSuccess
    });
}

function categoryClickSuccess(data) {
    $('#categories').hide();
    if ($(window).width() >= 900) {
        $('.ps-widget__content').remove();
    }
    $('.middle').empty();
    $('.middle').append(data);

    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'block';
    if ($(window).width() <= 900) {
        //$.ajax({
        //    type: "GET",
        //    url: "/Category/GetNotNullCategories",
        //    success: getNotNullCategoriesSuccess
        //});
    } else {
        $.ajax({
            type: "GET",
            url: "/Product/BreadCrumbs?categoryId=" + chooseCategoryId + "&action=" + false,
            success: function (data) {
                $('#breadcrumbs').append(data);
            }
        });
    }

    spinner.style.display = 'none';
}

function goToCategory(categoryId) {
    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'block';

    localStorage.setItem('id', categoryId);
    $('#categories').show();
    $('.middle').empty();

    $.ajax({
        type: "GET",
        url: "/Category/GetCategoriesByUser",
        success: this.categoriesSuccess
    });

    spinner.style.display = 'none';
}

function LocationCatalog() {
    document.getElementById('mobileUl').style.display = 'none';
    window.location.href = '../Home/Index';
}