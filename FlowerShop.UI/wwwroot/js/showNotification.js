function showNotification(message) {
    var notification = $('#notification'); // ��������� �� ��������� jQuery
    notification.text(message);
    notification.addClass('show'); // ��������� ����� ��� ����������� ���������

    setTimeout(function () {
        notification.text('');
        notification.removeClass('show'); // ��������� ����� ��� ���������� ���������
    }, 3000);
}
