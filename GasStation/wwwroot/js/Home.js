var timer;
var secondsPressed = 0;

document.addEventListener("DOMContentLoaded", function () {
    var buttons = document.querySelectorAll(".spend-button");

    buttons.forEach(function (button) {
        button.addEventListener("mousedown", function (event) {
            startTimer(event.target.id);
        });

        button.addEventListener("mouseup", function (event) {
            stopTimer(event.target.id);
        });
    });
});

function startTimer(id) {
    var pumpId = getPumpGuidFromElement(id);
    var priceElement = document.getElementById("Price_" + pumpId);
    secondsPressed = 0;

    timer = setInterval(function () {
        secondsPressed++;
        priceElement.innerText = "Price: " + secondsPressed;
    }, 1000);
}

function stopTimer(id) {
    clearInterval(timer);
    var pumpId = getPumpGuidFromElement(id);

    if (secondsPressed > 0) {
        $.ajax({
            url: '/Pump/SpendPrice',
            method: 'POST',
            data: { pumpId: pumpId, price: secondsPressed },
            success: function (response) {
                if (response.success) {
                    var priceElement = document.getElementById("Price_" + pumpId);
                    priceElement.innerText = "Price: 0";
                    secondsPressed = 0;
                }
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    }
}

function getPumpGuidFromElement(id) {
    var index = id.indexOf("_") + 1;
    var pumpId = id.substring(index);

    return pumpId;
}

function spendPump(pumpId) {
    var statusElement = document.getElementById("Status_" + pumpId);
    var priceElement = document.getElementById("Price_" + pumpId);

    if (statusElement.classList.contains("red")) {
        return;
    }

    if (secondsPressed > 0) {
        return;
    }

    var currentPrice = parseFloat(priceElement.innerText.replace("Price: ", ""));

    if (currentPrice > 0) {
        $.ajax({
            url: '/Pump/SpendPrice',
            method: 'POST',
            data: { pumpId: pumpId, price: currentPrice },
            success: function (response) {
                if (response.success) {
                    priceElement.innerText = "Price: 0";
                }
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    }
}

function lockPump(pumpId) {
    var statusElement = document.getElementById("Status_" + pumpId);

    if (statusElement.classList.contains("red")) {
        return;
    }

    $.post("/Pump/LockPump", { pumpId: pumpId })
        .done(function (response) {
            if (response.success) {
                var priceElement = document.getElementById("Price_" + pumpId);
                priceElement.innerText = "Price: 0";

                statusElement.classList.remove("green");
                statusElement.classList.add("red");

                $("#lock-Button_" + pumpId).prop("disabled", true);
                $("#lock-Button_" + pumpId).hide();
                $("#setPrice-Button_" + pumpId).prop("disabled", true);
                $("#spend-Button_" + pumpId).prop("disabled", true);
                $("#unlock-Button_" + pumpId).prop("disabled", false);
                $("#unlock-Button_" + pumpId).show();
            }
        })
        .fail(function (error) {
            console.error("Error locking pump:", error.responseText);
        });
}

function unlockPump(pumpId) {
    var statusElement = document.getElementById("Status_" + pumpId);

    if (statusElement.classList.contains("green")) {
        return;
    }

    $.post("/Pump/UnlockPump", { pumpId: pumpId })
        .done(function (response) {
            if (response.success) {
                statusElement.classList.remove("red");
                statusElement.classList.add("green");

                $("#lock-Button_" + pumpId).prop("disabled", false);
                $("#lock-Button_" + pumpId).show();
                $("#setPrice-Button_" + pumpId).prop("disabled", false);
                $("#spend-Button_" + pumpId).prop("disabled", false);
                $("#unlock-Button_" + pumpId).prop("disabled", true);
                $("#unlock-Button_" + pumpId).hide();
            }
        })
        .fail(function (error) {
            console.error("Error locking pump:", error.responseText);
        });
}

function setPredefinedPrice(pumpId) {
    var predefinedAmountElement = document.getElementById("predefinedAmount_" + pumpId);
    var statusElement = document.getElementById("Status_" + pumpId);

    if (parseInt(predefinedAmountElement.value) < 0 || predefinedAmountElement.value == "") {
        predefinedAmountElement.value = 0;
        return;
    }

    if (statusElement.classList.contains("red")) {
        return;
    }

    $.post("/Pump/SetPrice", { pumpId: pumpId, price: predefinedAmountElement.value })
        .done(function (response) {
            if (response.success) {
                var priceElement = document.getElementById("Price_" + pumpId);
                priceElement.innerText = "Price: " + predefinedAmountElement.value;

                predefinedAmountElement.value = 0;
            }
        })
        .fail(function (error) {
            console.error("Error setting predefined price:", error.responseText);
        });
}
