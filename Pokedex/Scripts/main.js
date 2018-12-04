if (!jQuery) { throw new Error("Bootstrap requires jQuery") }

$(function () {

    $detailsToggle = $('#details-toggle');
    $pokeDetails = $('.poke-details');
    $pokeName = $('.poke-name');

    $pokeDetails.toggle();

    $pokeName.hover(function (event) {
        $(this).parent('tr').next('tr').toggle();
    })



})