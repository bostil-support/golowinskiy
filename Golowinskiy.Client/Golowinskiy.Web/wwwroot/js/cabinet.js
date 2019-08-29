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
}

function openLogOut() {
    if ($('#logMenu').css('display') == 'block') {
        $('#logMenu').css('display', 'none');
    } else {
        $('#logMenu').css('display', 'block');
    }
}