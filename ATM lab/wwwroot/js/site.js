var pin = "";
var backgroundColor = "#a3a375";

function getInputNode() {
    return $("#inputNumber")[0];
}

function submitPin() {
    var input = getInputNode();

    input.style.color = backgroundColor; 
    input.value = pin;

    $("#Ok")[0].click();
}

function isPinView() {
    var url = window.location.pathname;

    return url == "/Home/Pin";
}

function onKeyPress(value) {
    var input = getInputNode();

    if (isPinView()) {
        pin += value;
        input.value += '*';

        if (pin.length === 4)
            submitPin()
    }
    else input.value += value;
}

function onClear() {
    var input = $("#inputNumber")[0];

    input.value = "";
    pin = "";
}