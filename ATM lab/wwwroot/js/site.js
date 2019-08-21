function onClear() {
    $("#number").text('');
}

function onKeyPress(value) {
    var cardNumber = $("#number").text();
    cardNumber += value;

    $("#number").text(cardNumber);
}