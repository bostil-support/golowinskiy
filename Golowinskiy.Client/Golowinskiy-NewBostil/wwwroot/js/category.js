window.onload = function () {
    $.ajax({
        type: "GET",
        url: "/Category/GetCategories",
        success: function (data) {
            $('#categories').html(data);
        }
    });
};
