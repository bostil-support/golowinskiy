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
    if (index != arrProdDivs.length - 1) {
        arrProdDivs[index + 1].click();
    } else {
        arrProdDivs[0].click();
    }
}
