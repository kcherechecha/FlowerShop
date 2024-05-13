document.addEventListener('DOMContentLoaded', function () {
    updateTotalPrice();
});

function calculateTotalPrice() {
    var total = 0;
    var items = document.getElementsByClassName('innerproductsection');

    for (var i = 0; i < items.length; i++) {
        var priceElement = items[i].getElementsByClassName('price')[0].textContent;
        var price = parseFloat(priceElement.replace(' ���', ''));

        var quantityElement = items[i].getElementsByClassName('item-quantity')[0];
        var quantity = parseInt(quantityElement.value);

        total += price * quantity;
    }

    return total;
}

function updateTotalPrice() {
    var totalPrice = calculateTotalPrice();
    var totalPriceElement = document.getElementById('totalPrice');
    totalPriceElement.textContent = 'Total Price: ' + totalPrice + ' uah';

    var totalPrice = calculateTotalPrice();
    var totalPriceInput = document.getElementById('totalPriceInput');
    totalPriceInput.value = totalPrice;
}

function orderItems() {
    var items = document.getElementsByClassName('innerproductsection');

    var itemsCountUpdate = [];

    for (var i = 0; i < items.length; i++) {
        var quantityElement = items[i].getElementsByClassName('item-quantity')[0];
        var quantity = parseInt(quantityElement.value);
        var itemOrderId = items[i].getAttribute('data-itemOrderId');

        var itemData = {
            itemId: itemOrderId,
            quantity: quantity
        };

        itemsCountUpdate.push(itemData);
    }

    var Url = "/Order/UpdateItemOrderCount";

    $.ajax({
        type: 'PATCH',
        url: Url,
        contentType: 'application/json', 
        data: JSON.stringify(itemsCountUpdate),
        success: function (response) {
            console.log(`Added to order`);
        },
        error: function (xhr, status, error) {
        }
    });
}
