﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var SearchIn = document.getElementById("SearchIn");
SearchIn.addEventListener("keyup", function() {

    // Creating Our XMLHttpRequest object 
    let xhr = new XMLHttpRequest();

    // Making our connection  
    let url = `https://localhost:44365/Emp/Index?SearchIn=${SearchIn.value}`;
    xhr.open("POST", url, true);

    // function execute after request is successful 
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(this.responseText);
            console.log(SearchIn.value);
        }
    }
    // Sending our request 
    xhr.send();
})
