$(document).ready(function () {
    $("#TownId").change(function () {

        var townId = $(this).val();

        $.ajax({
            type: "POST",
            url: "/Towns/" + townId + "/Neighborhoods",
            contentType: "html",
            success: function (responce) {
                $("#NeighborhoodId").empty();

                $("#NeighborhoodId").append(responce);
            }
        });
    });
});