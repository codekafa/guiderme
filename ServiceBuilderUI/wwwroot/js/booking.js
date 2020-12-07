



function OpenRequestModal(id, text) {

    $('#requestModalTitle').html(text);
    $('#categoryId').val(id);

    $.ajax({
        type: "GET",
        url: "/content/GetCategoryProperties?category_id=" + id,
        processData: false,
        contentType: false,
        success: function (e) {
            if (e.isSuccess == true) {
                $('#categoryPorperties').html("");
                $.each(e.data, function (index, value) {
                    var item = "<div class='col-md-12'><span>" + value.name + " : </span> <input type='text' dataid='" + value.id + "' class='form-control requestproperty' name='property_" + value.id + "' id='property_" + value.id + "' /></div>";
                    $('#categoryPorperties').append(item);
                });
            } else {
                toastrDanger(e.message);
            }
        },
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            toastrDanger(msg);
        }
    });

    $('#requestModal').modal();
}

function createBooking() {

    var requestModel = new Object();
    requestModel = getRequestData();
    requestModel.UserID = $('#CurrentUserID').val();

    $.ajax({
        type: "POST",
        url: "/booking/createnewbooking",
        processData: false,
        data: requestModel,
        contentType: false,
        success: function (e) {
            if (e.isSuccess == true) {
                toastrSuccess(e.message);
                location.href = "my-bookings";
            } else {
                toastrDanger(e.message)
            }
        }
    });

}


$(document).ready(function () {
    $('#RequestCountryId').on('change', function () {
        var id = $(this).val();
        if (id > 0) {
            loadCities(id);
        }
    });
});

$(document).ready(function () {

    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;
    var current = 1;
    var steps = $("fieldset").length;

    setProgressBar(current);

    $(".next").click(function () {

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

        //Add Class Active
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

        //show the next fieldset
        next_fs.show();
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                next_fs.css({ 'opacity': opacity });
            },
            duration: 500
        });
        setProgressBar(++current);
    });

    $(".previous").click(function () {

        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

        previous_fs.show();

        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                previous_fs.css({ 'opacity': opacity });
            },
            duration: 500
        });
        setProgressBar(--current);
    });

    function setProgressBar(curStep) {
        var percent = parseFloat(100 / steps) * curStep;
        percent = percent.toFixed();
        $(".progress-bar")
            .css("width", percent + "%")
    }

    $(".submit").click(function () {
        return false;
    })

});

function loadCities(id) {
    $.ajax({
        type: "POST",
        url: "/content/GetCitiesSelectViewModel?country_id=" + id,
        processData: false,
        contentType: false,
        success: function (e) {
            $.each(e, function (index, value) {
                var opt = "<option value='" + value.id + "'>" + value.name + "</option>";
                $('#RequestCityId').append(opt);
            });

        }
    });
}