var productCategoryId;

window.onload = function () {
    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'block';
    $.ajax({
        type: "GET",
        url: "/Category/GetAllCategories",
        success: categoriesSuccess
    });
};

function categoriesSuccess(data) {
    $('#categories').append(data);
    let categoryId = localStorage.getItem('id');
    if (categoryId !== null) {
        let li = document.getElementById(categoryId);
        li.classList.add('choose');
        li.classList.remove('active');

        if (li.childNodes[1] !== null && $(window).width() >= 900) {
            li.childNodes[1].style.display = 'block !important';
            li.childNodes[1].style.position = 'absolute';
            li.childNodes[1].style.top = '-2px';
            li.childNodes[1].style.left = '246px';
            li.parentNode.style.overflow = 'visible';
        } else {
            checkChoosenCategory(li.parentNode);
        }

        li = li.parentNode.parentNode;
        while (li.id > 0) {
            showSubCategories(li, event);
            li = li.parentNode.parentNode;
        }
    }

    localStorage.clear();
    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'none';
}

function attachMainImage(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            document.getElementById('mainImg').src = e.target.result;
            document.getElementById('mainImg').style.width = '100%';
            document.getElementById('mainImg').style.height = '100%';
        };

        reader.readAsDataURL(input.files[0]);
    }

    if (document.getElementById('mainImage').value !== '') {
        let element = document.getElementById('addt-imgs');
        let countChildDivs = element.getElementsByClassName('upload').length;
        document.getElementById('additionalImage' + countChildDivs).disabled = false;
        document.getElementsByClassName('disabled')[0].classList.remove('disabled');
        document.getElementById('remove-main').style.visibility = 'visible';
    }
}

function attachAdditImage(input) {
    let element = document.getElementById("addt-imgs");
    if (input.files && input.files[0]) {
        let reader = new FileReader();
  
        reader.onload = function (e) {
            let srcAddtImgs = document.getElementsByClassName('upload-add');
            for (let i = 0; i < srcAddtImgs.length; i++) {
                if (srcAddtImgs[i].src === e.target.result) {
                    return;
                } else {
                    continue;
                }
            }

            let countChildDivs = element.getElementsByClassName('upload').length;
            document.getElementById('addtImg' + countChildDivs).src = e.target.result;
            document.getElementById('addtImg' + countChildDivs).style.width = '100%';
            document.getElementById('addtImg' + countChildDivs).style.height = '100%';

            let array = document.getElementsByClassName('delete');
            array[array.length - 1].style["visibility"] = "visible";

            let html = '<div class="upload btn-file" id="additional-div-img' + (countChildDivs + 1) + '">' +
                '<input id="additionalImage' + (countChildDivs + 1) + '" type="file" onchange="attachAdditImage(this)">' +
                '<img id="addtImg' + (countChildDivs + 1) +'" class="upload-add">' +
                '<i class="fa fa-upload arrow" aria-hidden="true"></i>' +
                '<i class="fa fa-rotate-right"></i>' +
                '</div>' +
                '<i class="fa fa-times delete" id="removeImg' + (countChildDivs + 1) + '" style="visibility:hidden" onclick="removeAdditionalImage(this, ' + (countChildDivs + 1) + ')"></i>';

            $('#addt-imgs').append(html);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function removeMainImage() {
    let mainImg = document.getElementById('mainImg');
    mainImg.removeAttribute('src');
    mainImg.value = '';
    mainImg.style = '';

    document.getElementById('mainImage').value = '';

    document.getElementById('remove-main').style.visibility = 'hidden';

    let element = document.getElementById("addt-imgs");
    let countChildDivs = element.getElementsByClassName('upload').length;
    document.getElementById('additionalImage' + countChildDivs).disabled = true;

    let arrow = document.getElementById('additional-div-img' + countChildDivs).querySelector('.arrow');
    arrow.classList.add('disabled');

    checkFilledRequiredFields();
}

function removeAdditionalImage(i, numberImg) {
    let removeDiv = document.getElementById('additional-div-img' + numberImg);
    removeDiv.remove();
    i.remove();

    let currentAddtImg = document.getElementById('addt-imgs');
    let count = currentAddtImg.getElementsByTagName('div').length;

    for (let index = numberImg; index <= count; index++)
    {
        document.getElementById('additional-div-img' + (index + 1)).id = 'additional-div-img' + index;
        document.getElementById('additionalImage' + (index + 1)).id = 'additionalImage' + index;
        document.getElementById('addtImg' + (index + 1)).id = 'addtImg' + index;
        document.getElementById('removeImg' + (index + 1)).id = 'removeImg' + index;
        document.getElementById('removeImg' + index).setAttribute("onClick", "removeAdditionalImage(this," + index + ")");
    } 
}

function removeExistAdditionalImage(i, numberImg, id) {
    $.ajax({
        type: 'DELETE',
        url: '/Product/DeleteAddtImage?id=' + id,
        success: removeAdditionalImage(i, numberImg)
    });
}

function saveProduct() {
    if (document.getElementById('btn-sbmt').style.cursor !== 'pointer') {
        return;
    }

    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'block';

    let formData = new FormData();
    formData.append('CategoryId', productCategoryId);
    formData.append('UserId', $('#userId').val());
    formData.append('MainImage', $('#mainImage')[0].files[0]);

    let addtImgs = document.getElementById('addt-imgs');
    let count = addtImgs.getElementsByTagName('div').length;

    for (let i = 0; i < count - 1; i++) {
        formData.append('AdditionalImages', $('#additionalImage' + (i + 1))[0].files[0]);
    }

    formData.append('ProductName', $('#TName').val());
    formData.append('Description', $('#TDescription').val());
    formData.append('Price', $('#TCost').val());
    formData.append('VideoLink', $('#youtube').val());
    formData.append('ProductType', $('#TypeProd').val());
    formData.append('ProductArticle', $('#Article').val());
    formData.append('TransformationMechanism', $('#TransformMech').val());

    $.ajax({
        method: 'POST',
        url: '/Product/AddNewProduct',
        processData: false,
        contentType: false,
        data: formData,
        success: saveProductSuccess
    });
}

function saveProductSuccess() {
    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'none';

    let inputs = document.getElementsByTagName('input');
    for (let i = 1; i < inputs.length; i++) {
        inputs[i].value = "";
    }

    let descr = document.getElementById('TDescription');
    descr.value = "";
    removeMainImage();
    removeAddtImg();

    document.getElementById('btn-sbmt').style.opacity = 0.65;
    document.getElementById('btn-sbmt').style.cursor = 'default';

    document.getElementsByClassName('alert')[0].textContent = 'Объявление успешно добавлено';
    window.setTimeout(() => {
        document.getElementsByClassName('alert')[0].textContent = '';
    }, 10000);
}

function removeAddtImg() {
    let addtDiv = document.getElementById('addt-imgs');
    let countImgs = addtDiv.getElementsByClassName('upload').length;

    for (let i = 1; i < countImgs; i++) {
        let removeDiv = document.getElementById('additional-div-img' + i);
        let removeCross = document.getElementById('removeImg' + i);
        removeDiv.remove();
        removeCross.remove();
    }

    document.getElementById('additional-div-img' + countImgs).id = 'additional-div-img1';
    document.getElementById('additionalImage' + countImgs).id = 'additionalImage1';
    document.getElementById('addtImg' + countImgs).id = 'addtImg1';
    document.getElementById('removeImg' + countImgs).id = 'removeImg1';
}

function editProduct() {
    if (document.getElementById('btn-sbmt').style.cursor !== 'pointer') {
        return;
    }

    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'block';

    let formData = new FormData();
    formData.append('Id', $('#productId').val());
    formData.append('MainImage', $('#mainImage')[0].files[0]);

    let addtImgs = document.getElementById('addt-imgs');
    let count = addtImgs.getElementsByTagName('div').length;
    let mainIMG = document.getElementById('mainImg').style.visibility = "hidden";
 
    let removeImg1 = document.getElementById('removeImg1');
    let addtImg1 = document.getElementById('addtImg1').style.visibility = "hidden";
   
    let cross = document.getElementById('remove-main');
   
    cross.style.display = "none";
    removeImg1.style.display = "none";
    
    mainIMG.style = "width:0px;height:0px";
    for (let i = 0; i < count - 1; i++) {
        formData.append('AdditionalImages', $('#additionalImage' + (i + 1))[0].files[0]);
    }

    formData.append('ProductName', $('#TName').val());
    formData.append('Description', $('#TDescription').val());
    formData.append('Price', $('#TCost').val());
    formData.append('VideoLink', $('#youtube').val());
    formData.append('ProductType', $('#TypeProd').val());
    formData.append('ProductArticle', $('#Article').val());
    formData.append('TransformationMechanism', $('#TransformMech').val());

    $.ajax({
        method: 'PUT',
        url: '/Product/EditProduct',
        processData: false,
        contentType: false,
        data: formData,
        success: editProductSuccess
    });
}

function editProductSuccess() {
    let spinner = document.getElementsByClassName('showSpinner')[0];
    spinner.style.display = 'none';

    let inputs = document.getElementsByTagName('input');
    for (let i = 1; i < inputs.length; i++) {
        inputs[i].value = "";
    }

    let descr = document.getElementById('TDescription');
    descr.value = "";

    document.getElementById('btn-sbmt').style.opacity = 0.65;
    document.getElementById('btn-sbmt').style.cursor = 'default';

    document.getElementsByClassName('alert')[0].textContent = 'Объявление изменено';
    window.setTimeout(() => {
        document.getElementsByClassName('alert')[0].textContent = '';
    }, 10000);
}

function isEmptyTName() {
    let text = document.getElementById('TName').value;
    if (text === "") {
        document.getElementsByClassName('form-help-text')[0].style.display = 'inline';
    } else {
        document.getElementsByClassName('form-help-text')[0].style.display = 'none';
    }
}

function checkFilledRequiredFields() {
    let isFilled = false;

    let name = document.getElementById('TName').value;
    let descripton = document.getElementById('TDescription').value;
    let price = document.getElementById('TCost').value;

    if ($('#categories').length) {
        if (productCategoryId && name && descripton && price) {
            isFilled = true;
        }
    } else {
        if (name && descripton && price) {
            isFilled = true;
        }
    }

    if (isFilled) {
        document.getElementById('btn-sbmt').style.opacity = 1;
        document.getElementById('btn-sbmt').style.cursor = 'pointer';
    } else {
        document.getElementById('btn-sbmt').style.opacity = 0.65;
        document.getElementById('btn-sbmt').style.cursor = 'default';
    }
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

        if ($(window).width() >= 600) {
            li.childNodes[1].style.display = 'block !important';
            li.childNodes[1].style.position = 'absolute';
            li.childNodes[1].style.top = '-2px';
            li.childNodes[1].style.left = '246px';
            li.parentNode.style.overflow = 'visible';
           
        }
        else {
            //li.childNodes[1].style.position = 'unset';
            let widget = parent.querySelectorAll(".active");
            widget.style.display = "none";
        }
    }

    lastChoosenElement = li;
    screen_check();
    $(window).on('resize', function () {
        screen_check();
    });

    let height = li.childNodes[1].offsetHeight;
    document.getElementsByClassName('choosed')[0].style.marginTop = height;
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

    //if (x.length !== 0) {
    //    let ul = x[0].childNodes[1];
    //    checkChoosenCategory(ul);
    //}

    x.forEach(node => node.className = node.className.replace('choose', 'active'));
}

function showMobileSubCategories(li) {
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

function categoryClick(li, categoryId, event) {
    event.cancelBubble = true;

    let x = Array.from(document.getElementsByClassName('choose'));
    if (x.length !== 0) {
        x.forEach(node => node.classList.remove('choose'));
    }

    productCategoryId = categoryId;
    $.ajax({
        type: "GET",
        url: "/Product/BreadCrumbs?categoryId=" + productCategoryId + "&action=" + true,
        success: function (data) {
            $('#breadcrumbs').empty();
            $('#breadcrumbs').append(data);
            $('#categories').hide();
            $('#categ').hide();
        }
    });

    checkFilledRequiredFields();
}

function goToCategory(categoryId) {
    $('#breadcrumbs').empty();
    $('.ps-widget__content').empty();
    $('#categories').show();
    $('#categ').show();

    localStorage.setItem('id', categoryId);

    $.ajax({
        type: "GET",
        url: "/Category/GetAllCategories",
        success: categoriesSuccess
    });  
}