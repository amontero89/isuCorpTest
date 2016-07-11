$(document).ready(function () {
    $('.ranking').barrating({
        theme: 'css-stars',
        onSelect: function (value, text, event, objectId) {

            $.ajax({
                type: 'POST',
                url: '/Reservation/PutRanking',
                cache: false,
                dataType: 'json',
                data: {
                    id: objectId,
                    value: value
                },
                success: function (data) {

                },
                error: function () {

                }
            })
        }
    });

    $('.set-favorite').click(function () {
        let element = this;
        let objectId = $(element).attr('object');
        let isFavoriteOn = $('.cuore', this).hasClass('cuore-on');

        $.ajax({
            type: 'POST',
            url: '/Reservation/PutFavorite',
            cache: false,
            dataType: 'json',
            data: {
                id: objectId,
                value: !isFavoriteOn
            },
            success: function (data) {
                if (data.status) {
                    if (data.isFavorite) {
                        $('.cuore', element).removeClass('cuore-off');
                        $('.cuore', element).addClass('cuore-on');
                        $('.favorite-style', element).addClass('fovorite-text-on');
                    } else {
                        $('.cuore', element).removeClass('cuore-on');
                        $('.cuore', element).addClass('cuore-off');
                        $('.favorite-style', element).removeClass('fovorite-text-off');
                    }
                            
                }
            },
            error: function () {

            }
        });
    });
});