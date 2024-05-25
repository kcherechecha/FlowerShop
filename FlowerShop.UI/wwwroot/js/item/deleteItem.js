function deleteItem(itemId) {
    Url = '/Item/DeleteItem';

    $.ajax({
        type: 'DELETE',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            console.log(`${response} deleted`)
            window.location.reload();
        },
        error: function (xhr, status, error) {

        }
    });
}