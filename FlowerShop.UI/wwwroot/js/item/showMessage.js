function showSuccessMessage() {
    var messageElement = document.createElement('p');
    messageElement.textContent = 'Додано до корзини!';
    messageElement.style.color = 'green'; 

    var checkOnAddDiv = document.getElementById('check-on-add');
    checkOnAddDiv.appendChild(messageElement);

    setTimeout(function () {
        messageElement.remove(); 
    }, 3000);
}