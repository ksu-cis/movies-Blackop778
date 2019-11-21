// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function ScrollToTop() {
    window.scrollTo(window.scrollX, 0);
}

var form = document.getElementById("search-and-filter-form");

form.addEventListener("submit", function (event) {
    event.preventDefault();

    var formData = new FormData();
    var inputs = document.getElementsByName("input");
    var token;
    for (var i = 0; i < inputs.length; i += 1) {
        var input = inputs[i];
        if (input.type === "checkbox") {
            if (input.checked) {
                formData.append(input.name, input.value);
            }
        } else {
            formData.set(input.name, input.value);
        }
        if (input.name === "__RequestVerificationToken") {
            token = input.value;
        }
    }

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/', true);
    xhr.setRequestHeader("RequestVerificationToken", token)
    xhr.onreadystatechange = function (event) {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            console.log(xhr.responseText);
        }
    }

    xhr.send(formData);
});
