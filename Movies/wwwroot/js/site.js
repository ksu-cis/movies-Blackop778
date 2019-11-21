// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function ScrollToTop() {
    window.scrollTo(window.scrollX, 0);
}

var movieEntries = document.getElementsByClassName("movie-entry");

var form = document.getElementById("search-and-filter-form");

form.addEventListener("submit", function (event) {
    event.preventDefault();
    var i, entry;

    var term = document.getElementById("search").value;

    var mpaa = [];
    var mpaaCheckboxes = document.getElementsByClassName("mpaa");
    for (i = 0; i < mpaaCheckboxes.length; i += 1) {
        if (mpaaCheckboxes[i].checked) {
            mpaa.push(mpaaCheckboxes[i].value);
        }
    }

    var minIMDB = document.getElementById("imdb").value;


    for (i = 0; i < movieEntries.length; i += 1) {
        entry = movieEntries[i];
        entry.style.display = "block";

        if (term) {
            if (!entry.dataset.title.toLowerCase().includes(term.toLowerCase())) {
                entry.style.display = "none";
                continue;
            }
        }

        if (mpaa.length > 0) {
            if (!mpaa.includes(entry.dataset.mpaa)) {
                entry.style.display = "none";
                continue;
            }
        }

        if (minIMDB) {
            if (!entry.dataset.imdb || parseFloat(minIMDB) > parseFloat(entry.dataset.imdb)) {
                entry.style.display = "none";
                continue;
            }
        }
    }
});
