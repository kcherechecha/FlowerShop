function addItemToBasket(itemId) {
    Url = '/Item/AddItemToBasket';

    $.ajax({
        type: 'POST',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            console.log(`${response} added to basket`)
            showNotification('����� ������ �� �������!');
        },
        error: function (xhr, status, error) {
            if (xhr.status === 401) {
                window.location.href = "/Account/Login";
            }
        }
    });
}