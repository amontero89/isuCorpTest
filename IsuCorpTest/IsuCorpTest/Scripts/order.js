$(document).ready(function () {

    $('select[name=orderType]').change(function () {
        let value = $(this).val();
        window.location.href = "/Reservation/OrderBy?orderType=" + $(this).val() + "&pageNumber=" + $('#pageNumber').val();
        
    });
    
})