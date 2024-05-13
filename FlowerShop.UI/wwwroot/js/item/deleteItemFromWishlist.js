function deleteItemFromWishlist(itemId) {
    Url = '/Item/DeleteItemFromWishlist';

    $.ajax({
        type: 'DELETE',
        url: Url,
        data: { itemId: itemId },
        success: function (response) {
            console.log(`${response} deleted from wishlist`)
            window.location.reload();
        },
        error: function (xhr, status, error) {

        }
    });
}