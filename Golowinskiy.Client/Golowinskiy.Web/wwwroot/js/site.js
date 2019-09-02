﻿window.onload = function () {

    var backgroundImgs = [
        'http://golowinskiy-api.bostil.ru/mainimages/08.12.2018.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/10.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/18.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/19.01.2019.jpg',
        'http://golowinskiy-api.bostil.ru/mainimages/21.01.2019.jpg'
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
