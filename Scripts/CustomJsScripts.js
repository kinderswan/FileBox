
$(document).ready(function () {
    $('.edit-file').click(function () {
        var url = "/File/EditFile"; // the url to the controller
        var id = $(this).attr('data-id'); // the id that's given to each button in the list
        $.get(url + '/' + id, function (data) {
            $('#edit-file-container').html(data);
            $('#edit-file').modal('show');
        });
    });
});