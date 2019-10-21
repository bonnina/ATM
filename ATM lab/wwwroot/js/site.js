function onClear() {
    $("#number").text('');
}

function onKeyPress(value) {
 //   var cardNumber = $("#number").text();
 //   cardNumber += value;

 //   $("#number").text(cardNumber);

    var screen = $("#screen")[0];
    var input = screen.firstChild;
    input.value += value;
}