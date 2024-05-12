function showNotification(message) {
    var notification = $('#notification'); // Звернення за допомогою jQuery
    notification.text(message);
    notification.addClass('show'); // Додавання класу для відображення сповіщення

    setTimeout(function () {
        notification.text('');
        notification.removeClass('show'); // Видалення класу для приховання сповіщення
    }, 3000);
}
