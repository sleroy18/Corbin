﻿var animation_elements;
var web_window;
(function () {
    var count = 0;
    var rDiv;
    var li;
    for (var i = 0; i < 6; i++) {

        if (i % 3 === 0) {
            count++;
            li = document.createElement("li");
            li.id = "liItem" + count;

            rDiv = document.createElement("div");
            rDiv.id = "divItem" + count;
            rDiv.classList.add("row");
            li.appendChild(rDiv);
        }

        var card = generateCard("Test: " + i, "/Content/Images/feeder.jpg");
        rDiv.appendChild(card);
        //li.appendChild(rDiv);

        if ((i + 1) % 3 === 0) {
            document.getElementById("projectContainer").appendChild(li);
        }

    }

    if (!document.querySelector ||
        !('classList' in document.body)) {
        return false;
    }

    // Read necessary elements from the DOM once
    var box = document.querySelector('.carouselbox');
    var next = box.querySelector('#next-btn');
    var prev = box.querySelector('#prev-btn');

    // Define the global counter, the items and the 
    // current item 
    var counter = 0;
    var items = box.querySelectorAll('.content li');
    var amount = items.length;
    var current = items[0];

    // hide all elements and apply the carousel styling
    box.classList.add('active-slide');

    // navigate through the carousel

    function navigate(direction) {

        // hide the old current list item 
        current.classList.remove('current');

        // calculate th new position
        counter = counter + direction;

        // if the previous one was chosen
        // and the counter is less than 0 
        // make the counter the last element,
        // thus looping the carousel
        if (direction === -1 &&
            counter < 0) {
            counter = amount - 1;
        }

        // if the next button was clicked and there 
        // is no items element, set the counter 
        // to 0
        if (direction === 1 &&
            !items[counter]) {
            counter = 0;
        }

        // set new current element 
        // and add CSS class
        current = items[counter];
        current.classList.add('current');
    }

    // add event handlers to buttons
    next.addEventListener('click', function (ev) {
        navigate(1);
    });
    prev.addEventListener('click', function (ev) {
        navigate(-1);
    });

    navigate(0);
})();

function generateCard(title, img) {
    var cardOuter = document.createElement("Div");
    cardOuter.classList.add("col-sm");
    cardOuter.classList.add("cardOuter");
    console.log("url(" + img + ")");
    cardOuter.style.backgroundImage = "url(" + img + ")";

    var cardInner = document.createElement("Div");
    cardInner.classList.add("cardInner");
    cardInner.innerText = title;
    cardOuter.appendChild(cardInner);

    return cardOuter;
}