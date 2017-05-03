$(document).ready(function () {
    $('#btn').click(function () {
        $('#btn').toggleClass("cart_clk");

    });
    $("#btn").one("click", function () {
        $('.cart .fa').attr('data-before', '1');
    });



    var prnum = $('.num').text();
    $('.inc').click(function () {
        if (prnum > 0) {
            prnum++;
            $('.num').text(prnum);
            $('.cart .fa').attr('data-before', prnum);
        }

    });
    $('.dec').click(function () {
        if (prnum > 1) {
            prnum--;
            $('.num').text(prnum);
            $('.cart .fa').attr('data-before', prnum);
        }

    });

    var addEvent = $('.num').text();
    $('.inc').click(function () {
        if (addEvent > 0) {
            addEvent++;
            $('.num').text(addEvent);
            $('.cart .fa').attr('data-before', addEvent);
        }

    });
    $('.dec').click(function () {
        if (removeEvent > 1) {
            removeEvent--;
            $('.num').text(removeEvent);
            $('.cart .fa').attr('data-before', removeEvent);
        }

    });
});