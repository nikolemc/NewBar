let addToCart = (itemId) => {
    // ajax to get the new cart
    $.ajax({
        url: "/home/AddToCart",
        dataType: "html",
        contentType: "application/json",
        data: JSON.stringify({ eventId: itemId }),
        type: "POST",
        success: (newCart) => {
            $("#modelBody").html(newCart);
            // update shopping cart counter
            var count = $("#counter").html();
            count++;
            $("#counter").html(count);
        }
    })
}