function onKeyPress(value) {
    var input = $("#inputNumber")[0];

    input.value += value;
}

function onClear() {
    var input = $("#inputNumber")[0];

    input.value = "";
}