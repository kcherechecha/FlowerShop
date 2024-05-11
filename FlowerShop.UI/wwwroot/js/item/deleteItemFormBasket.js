function deleteItemFromBasket(itemId) {
    Url = '/Item/DeleteItemFromBasket';

    $.ajax({
        type: 'DELETE',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            console.log(`${response} deleted from basket`)

            var itemContainers = document.querySelectorAll('.item-container');
            itemContainers.forEach(function (container) {
                if (container.dataset.itemId === itemId) {
                    container.remove();
                }
            });

        },
        error: function (xhr, status, error) {
            
        }
    });
}