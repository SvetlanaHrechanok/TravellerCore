'use strict';

let country = document.getElementsByClassName('country');
let aboutCountryTours = document.getElementsByClassName('aboutCountryTours');

for (let i = 0; i < country.length; i++) {

    country[i].addEventListener('click', () => {
        let display = aboutCountryTours[i].style.display;
        if (aboutCountryTours[i].style.display == "none") {
            document.getElementsByClassName('aboutCountryTours')[i].style.display = "block";
        } else {
            document.getElementsByClassName('aboutCountryTours')[i].style.display = "none";
        }
    });
}

let deleteTour = document.getElementsByClassName('deleteTour');
let idTour = document.getElementsByClassName('idTour');

for (let i = 0; i < deleteTour.length; i++) {

    deleteTour[i].addEventListener('click', () => {

        let delTour = confirm("Delete this tour?");
        if (delTour == true) {
            let id = parseInt(idTour[i].innerHTML);
            DeleteTour(id);
        }
    });
}

function DeleteTour(id) {
    $.ajax({
        method: "GET",
        url: "/Home/DeleteTour?id=" + id,
        data: id,
        success: function (context) {
            alert(context);
            location.assign("/Home/Index");
        },
        error: function (errorData) {
            alert("Error!" + errorData);
        }
    });

    
}

