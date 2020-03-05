$(document).ready(function () {
    $("#filter-block").load($("#filter-block").data('request-url'));
    $("#book-content").load($("#book-content").data('request-url'));
});

function deleteTask(id) {
    $.ajax({
        url: "/Home/DeleteBook/" + id,
        type: 'GET',
        success: function () {
            $("#book-content").load($("#book-content").data('request-url'));
        },
        error: function (xhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

};