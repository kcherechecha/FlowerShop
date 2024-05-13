function deleteItemFromBasket(itemId) {
    Url = '/Item/DeleteItemFromBasket';

    $.ajax({
        type: 'DELETE',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            console.log(`${response} deleted from basket`)
            window.location.reload();
        },
        error: function (xhr, status, error) {
            
        }
    });
}