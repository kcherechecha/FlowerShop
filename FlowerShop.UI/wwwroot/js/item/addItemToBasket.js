function addItemToBasket(itemId) {
    Url = '/Item/AddItemToBasket';

    $.ajax({
        type: 'POST',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            console.log(`${response} added to basket`)
            openModal('Item added to basket');
        },
        error: function (xhr, status, error) {
            if (xhr.status === 401) {
                window.location.href = "/Account/Login";
            }
        }
    });
}