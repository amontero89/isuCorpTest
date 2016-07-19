$(document).ready(function () {

    $('#BirthDate').datepicker({ format: $('#BirthDate').attr('format') });

    $('div#BodyText').Editor();
    $('div#BodyText').Editor('setText', $('#BodyText').val());

    $('#reservation-form').submit(function (event) {
        $('#BodyText').val($('div#BodyText').Editor('getText'));
    });

    $('#BirthDate').keypress(function (event) {
        if (event.keyCode == 47 || event.keyCode == 13 || 
            (event.keyCode == 65 && event.ctrlKey === true) || // Allow: Ctrl+A
                                (event.keyCode == 67 && event.ctrlKey === true) || // Allow: Ctrl+C
                                (event.keyCode == 86 && event.ctrlKey === true) || // Allow: Ctrl+C
                                (event.keyCode >= 35 && event.keyCode < 39)) {
            return;
        }
        else {
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode >= 97)) {  // Ensure that it is a number and stop the keypress
                event.preventDefault();
            }
        }
    });

    $('#Phone').keypress(function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||  // Allow: backspace, delete, tab, escape, and enter
                                (event.keyCode == 65 && event.ctrlKey === true) || // Allow: Ctrl+A
                                (event.keyCode == 67 && event.ctrlKey === true) || // Allow: Ctrl+C
                                (event.keyCode == 86 && event.ctrlKey === true) || // Allow: Ctrl+C
                                (event.keyCode >= 35 && event.keyCode < 39)) // Allow: home, end, left, right
        {
            return; // let it happen, don't do anything
        }
        else {
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode >= 97)) {  // Ensure that it is a number and stop the keypress
                event.preventDefault();
            }
        }
    });

});