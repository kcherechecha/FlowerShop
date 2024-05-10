function addItemToBasket(itemId) {
    Url = '/Item/AddItemToBasket';

    $.ajax({
        type: 'POST',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            
        },
        error: function (xhr, status, error) {
            console.error("Modal failure:", status, error);
        }
    });
}