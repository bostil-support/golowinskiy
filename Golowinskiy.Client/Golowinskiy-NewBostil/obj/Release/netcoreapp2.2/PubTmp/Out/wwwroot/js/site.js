window.onload = function () {

    let backgroundImgs = [
        'http://golowinskiy-api.bostil.ru/mainimages/08.12.2018.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/10.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/18.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/19.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/21.01.2019.jpg'
    ];

    $.ajax({
        type: "GET",
        url: "/Category/GetNotNullCategories",
        success: this.categoriesSuccess
    });

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

let lastChoosenElement;

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

function showSubCategories(li, event) {
    event.cancelBubble = true;

    if ($(window).width() <= 900) {
        showMobileSubCategories(li);
        return;
    }

    let parent = li.parentNode;
    checkChoosenCategory(parent);

    li.classList.remove('active');
    li.classList.add('choose');
    function screen_check() {

        if ($(window).width() >= 1079) {

            li.childNodes[1].style.display = 'block !important';
            li.childNodes[1].style.position = 'absolute';
            li.childNodes[1].style.top = '-2px';
            li.childNodes[1].style.left = '246px';
            li.parentNode.style.overflow = 'visible';

        } else {
            let widget = parent.querySelectorAll(".active");
            widget.style.display = "none";
        }
    }

    screen_check();
    $(window).on('resize', function () {
        screen_check();
    });

    lastChoosenElement = li;
}

function checkChoosenCategory(parent) {
    let x = Array.from(parent.childNodes)
        .filter(node => node.className.includes('choose'));

    if ($(window).width() <= 1079) {
        let widget = $(parent).children('.active');
        $(widget).css('display', 'block');
    }

    if (x.length !== 0) {
        let ul = x[0].childNodes[1];
        if (ul !== undefined) {
            checkChoosenCategory(ul);
        }
    }

    x.forEach(node => node.className = node.className.replace('choose', 'active'));
}

function showMobileSubCategories(li) {
    let products = document.getElementsByClassName('products_list')[0];
    if (products !== undefined) {
        products.remove();
    }

    let parent = li.parentNode;
   
    if (li.classList.contains('choose')) {
        checkChoosenCategory(parent);
        li.classList.remove('choose');
        li.classList.add('active');
           
        let widget = $(parent).children('.active');
        $(widget).css('display', 'block');
    } else {

        checkChoosenCategory(parent);

        li.classList.remove('active');
        li.classList.add('choose');

        let widget = $(parent).children('.active');
        $(widget).css('display', 'none');
    }
}

let chooseCategoryId;
function categoryClick(li, categoryId, event) {
    event.cancelBubble = true;

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

function getNotNullCategoriesSuccess(data) {
    $('#categories').append(data);
    let categoryId = localStorage.getItem('categoryId');
    if (categoryId !== null) {
        let li = document.getElementById(categoryId);
        li.classList.add('choose');
        li.classList.remove('active');

        li = li.parentNode.parentNode;
        while (li.id > 0) {
            showSubCategories(li, event);
            li = li.parentNode.parentNode;
        }
    }

    localStorage.clear();
    $("li").attr("onclick", "openCategory(this, event)");
}

function openMenu() {
    if ($(window).width() <= 900) {
        document.getElementById('mobileUl').style.display = 'grid';
    }
}

function closeMenu() {
    document.getElementById('mobileUl').style.display = 'none';
}

function LocationCabinet() {
    document.getElementById('mobileUl').style.display = 'none';
    window.location.href = '../Cabinet/Cabinet';
}

function LocationAddProduct() {
    document.getElementById('mobileUl').style.display = 'none';
    window.location.href = '../Product/GetProductView';
}

function goToCategory(categoryId) {
    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'block';

    localStorage.setItem('id', categoryId);
    $('#categories').show();
    $('.middle').empty();

    $.ajax({
        type: "GET",
        url: "/Category/GetNotNullCategories",
        success: this.categoriesSuccess
    });

    spinner.style.display = 'none';
}

function getDetails(choosenDiv, id) {
    event.cancelBubble = true;

    choosenDiv.classList.add('choose');
    let show = document.getElementsByTagName("body");
    for (let i = 0; i < show.length; i++) {
        show[i].style.overflow = "hidden";
    }

    if (document.getElementsByClassName('detail_product')[0] === undefined) {
        let url = "/Product/ProductsDetail?categoryId=" + chooseCategoryId + "&isChange=";
        if (window.location.href.includes('Cabinet')) {
            url += 'true';
        } else {
            url += 'false';
        }

        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                $('.middle').append(data);
                showProductDetail(id);
            }
        });
    } else {
        showProductDetail(id);
    }
}

function showProductDetail(id) {
    if (document.getElementsByClassName('products_list_item').length > 1) {
        $('.detail_product').hide();
        let currDiv = document.getElementById('detail-page' + id);
        $(currDiv).show();
        currDiv.querySelectorAll('.arrows')[0].style.display = 'block';
        currDiv.querySelectorAll('.arrows')[1].style.display = 'block';
    }
}

function closeWindow() {
    $('.detail_product').hide();
    let show = document.getElementsByTagName("body");
    for (let i = 0; i < show.length; i++) {
        show[i].style.overflow = "auto";
    }
    let choosenDiv = document.getElementsByClassName('choose');
    choosenDiv[choosenDiv.length - 1].classList.remove('choose');
}

function showAddtImage(src) {
    let mainImg = document.getElementById('mainImg');
    mainImg.src = src;
}

function showNextProduct() {
    let choosenDiv = document.querySelector('div.choose');
    let arrProdDivs = Array.from(document.getElementsByClassName('products_list_item'));
    let index = arrProdDivs.indexOf(choosenDiv);

    choosenDiv.classList.remove('choose');
    if (index !== arrProdDivs.length - 1) {
        $(arrProdDivs[index + 1]).click();
    } else {
        $(arrProdDivs[0]).click();
    }
}

function showPrevProduct() {
    let choosenDiv = document.querySelector('div.choose');
    let arrProdDivs = Array.from(document.getElementsByClassName('products_list_item'));
    let index = arrProdDivs.indexOf(choosenDiv);

    choosenDiv.classList.remove('choose');
    if (index !== 0) {
        $(arrProdDivs[index - 1]).click();
    } else {
        $(arrProdDivs[arrProdDivs.length - 1]).click();
    }
}


function deleteProduct(id) {
    $.ajax({
        type: "Delete",
        url: "/Product/DeleteProduct?id=" + id,
        success: deleteProducSuccess
    });
}

function deleteProducSuccess() {
    closeWindow();
    $('.middle').empty();

    $.ajax({
        type: 'GET',
        url: '/Product/GetProductsByCategory?categoryId=' + chooseCategoryId,
        success: categoryClickSuccess
    });
}

function openCategory(li, event) {
    event.cancelBubble = true;
    localStorage.setItem('id', li.id);
    window.location.href = '../Home/Index';
}