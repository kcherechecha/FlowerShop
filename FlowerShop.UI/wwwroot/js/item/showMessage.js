function openModal(text) {
    $('#Modal .modal-body').text(text);

    $('#Modal').modal('show');

    $('#Modal').css('top', '100px');

    setTimeout(function () {
        $('#Modal').modal('hide');
    }, 2000);
}