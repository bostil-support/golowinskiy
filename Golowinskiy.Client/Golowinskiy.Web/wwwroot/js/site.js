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
        url: "/Category/GetCategories",
        success: function (data) {
            $('#categories').append(data);
        }
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


function showSubCategories(li, event) {
    event.cancelBubble = true;

    let parent = li.parentNode;
    checkChoosenCategory(parent);

    li.classList.remove('active');
    li.classList.add('choose');
    li.childNodes[1].style.display = 'block !important';
    li.childNodes[1].style.position = 'absolute';
    li.childNodes[1].style.top = '-2px';
    li.childNodes[1].style.left = '246px';
    li.parentNode.style.overflow = 'visible';

    lastChoosenElement = li;

    let height = li.childNodes[1].offsetHeight;
    document.getElementsByTagName('footer').style.marginTop = height;
}

function checkChoosenCategory(parent) {
    let x = Array.from(parent.childNodes)
        .filter(node => node.className.includes('choose'));

    if (x.length !== 0) {
        let ul = x[0].childNodes[1];
        checkChoosenCategory(ul);
    }
     
    x.forEach(node => node.className = node.className.replace('choose', 'active'));
}

function categoryClick(categoryId) {
    window.location.href = "/Product/GetProductsByCategory?categoryId=" + categoryId;
}

