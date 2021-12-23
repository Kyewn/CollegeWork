// Get relevant elements
var myFlag = document.getElementById("flag-list__my");
var cnFlag = document.getElementById("flag-list__cn");
var usFlag = document.getElementById("flag-list__us");
var sgFlag = document.getElementById("flag-list__sg");
var jpFlag = document.getElementById("flag-list__jp");
var modal = document.getElementById("modal");
var modalCloseBtn = document.getElementById("modal__close-btn");
var modalImage = document.getElementById("modal__img");
var modalText = document.getElementById("modal__text");

// Set onclick event functions for each flag element
myFlag.onclick = function() {
    modal.style.display = "block";
    modalImage.src = "images/newNotes/MYR.png";
    modalText.innerHTML = "MYR : Malaysian Ringgit";
};

cnFlag.onclick = function() {
    modal.style.display = "block";
    modalImage.src = "images/newNotes/CNY.png";
    modalText.innerHTML = "CNY : Chinese Yuan";
};

usFlag.onclick = function() {
    modal.style.display = "block";
    modalImage.src = "images/newNotes/USD.png";
    modalText.innerHTML = "USD : United States Dollar";
};

sgFlag.onclick = function() {
    modal.style.display = "block";
    modalImage.src = "images/newNotes/SGD.png";
    modalText.innerHTML = "SGD : Singapore Dollar";
};

jpFlag.onclick = function() {
    modal.style.display = "block";
    modalImage.src = "images/newNotes/JPY.png";
    modalText.innerHTML = "JPY : Japanese Yen";
};

// Close modal when user clicks close button
modalCloseBtn.onclick = function() {
    modal.style.display = "none";
}

// Close modal when user clicks anywhere outside of it
window.onclick = function(event) {
    if (event.target == modal)
        modal.style.display = "none";
}