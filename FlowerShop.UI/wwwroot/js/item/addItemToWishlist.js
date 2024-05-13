function addItemToWishlist(itemId) {
    Url = '/Item/AddItemToWishlist';

    $.ajax({
        type: 'POST',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            console.log(`${response} added to wishlist`);
        },
        error: function (xhr, status, error) {
            if (xhr.status === 401) {
                window.location.href = "/Account/Login";
            }
        }
    });
}