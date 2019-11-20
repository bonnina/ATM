var pin;

function isPinView() {
    var url = window.location.pathname;

    return url == "/Home/Pin";
}

function onKeyPress(value) {
    var input = $("#inputNumber")[0];

    if (isPinView) {
        pin += value;
        input.value += '*';
    }
}

function onClear() {
    var input = $("#inputNumber")[0];

    input.value = "";
}