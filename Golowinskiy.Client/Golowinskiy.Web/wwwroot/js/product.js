function attachMainImage(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            document.getElementById('mainImg').src = e.target.result;
        };

        reader.readAsDataURL(input.files[0]);
    }

    if (document.getElementById('mainImage').value !== '') {
        let element = document.getElementById("addt-imgs");
        let countChildDivs = element.getElementsByClassName('upload').length;
        document.getElementById('additionalImage' + countChildDivs).disabled = false;
        document.getElementsByClassName('disabled')[0].classList.remove("disabled");
    }

    checkFilledRequiredFields();
}

function attachAdditImage(input) {
    let element = document.getElementById("addt-imgs");
    if (input.files && input.files[0]) {
        let reader = new FileReader();
  
        reader.onload = function (e) {
            let countChildDivs = element.getElementsByClassName('upload').length;
            document.getElementById('addtImg' + countChildDivs).src = e.target.result;

            let array = document.getElementsByClassName('delete');
            array[array.length - 1].style["visibility"] = "visible";

            let html = '<div class="upload btn-file" id="additional-div-img' + (countChildDivs + 1) + '">' +
                '<input id="additionalImage' + (countChildDivs + 1) + '" type="file" onchange="attachAdditImage(this)">' +
                '<img id="addtImg' + (countChildDivs + 1) + '" style="width:100px; height:70px" alt="">' +
                '<i class="fa fa-upload arrow" aria-hidden="true"></i>' +
                '<i class="fa fa-rotate-right"></i>' +
                '</div>' +
                '<i class="fa fa-times delete" id="removeImg' + (countChildDivs + 1) + '" style="visibility:hidden" onclick="RemoveAdditionalImage(this, ' + (countChildDivs + 1) + ')"></i>';

            $('#addt-imgs').append(html);
        };

        reader.readAsDataURL(input.files[0]);
    }
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
        document.getElementById('removeImg' + index).setAttribute("onClick", "RemoveAdditionalImage(this," + index + ")");
    } 
}

function saveProduct() {
    if (document.getElementById('btn-sbmt').style.cursor !== 'pointer') {
        return;
    }

    let formData = new FormData();
    formData.append('UserId', $('#userId').val());
    formData.append('MainImage', $('#mainImage')[0].files[0]);

    let listAddtImgs = [];
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
    let inputs = document.getElementsByTagName('input');
    for (let i = 1; i < inputs.length; i++) {
        inputs[i].value = "";
    }

    let descr = document.getElementById('TDescription');
    descr.value = "";

    document.getElementById('btn-sbmt').style.opacity = 0.65;
    document.getElementById('btn-sbmt').style.cursor = 'default';

    document.getElementsByClassName('alert')[0].textContent = 'Объявление успешно добавлено';
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
    let image = document.getElementById('mainImage').value;

    if (name && descripton && price && image) {    
        isFilled = true;
    }      

    if (isFilled) {
        document.getElementById('btn-sbmt').style.opacity = 1;
        document.getElementById('btn-sbmt').style.cursor = 'pointer';
    } else {
        document.getElementById('btn-sbmt').style.opacity = 0.65;
        document.getElementById('btn-sbmt').style.cursor = 'default';
    }
}

