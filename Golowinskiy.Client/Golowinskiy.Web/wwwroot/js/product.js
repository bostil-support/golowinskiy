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

function RemoveAdditionalImage(i, numberImg) {
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

function SaveProduct() {

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
        success: function () {

        }
    });
}

function IsEmptyTName() {
    let text = document.getElementById('TName').value;
    if (text.length === 0) {
        document.getElementsByClassName('form-help-text')[0].style.display = 'inline';
    } else {
        document.getElementsByClassName('form-help-text')[0].style.display = 'none';
    }
}