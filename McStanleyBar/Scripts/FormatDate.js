$(document).ready(() => {
    console.log("loaded")
    $(".startTime").each(function () {
        console.log("formatid", this)
        let _formattedDate = moment($(this).html()).format("h:mm a");
        $(this).html(_formattedDate);
    });

    $(".day").each(function () {
        console.log("formatid", this)
        let _formattedDay = moment($(this).html()).format("DD");
        $(this).html(_formattedDay);
    });

    $(".month").each(function () {
        console.log("formatid", this)
        let _formattedMonth = moment($(this).html()).format("MMM");
        $(this).html(_formattedMonth);
    });
});