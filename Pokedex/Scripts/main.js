if (!jQuery) { throw new Error("Bootstrap requires jQuery") }

$(function () {

    $detailsToggle = $('#details-toggle');
    $pokeDetails = $('.poke-details');

    $pokeDetails.toggle();

    $detailsToggle.click(function (event) {
        $pokeDetails.toggle();
    })



})