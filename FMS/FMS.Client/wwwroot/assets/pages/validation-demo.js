/*
 Template Name: Heyqo - Admin & Dashboard Template
 Author: Myra Studio
 File: Validation
*/


! function () {
    "use strict";
    window.addEventListener("load", function () {
        var t = document.getElementsByClassName("needs-validation");
        Array.prototype.filter.call(t, function (t) {
            t.addEventListener("input", function (e) {
                !1 === t.checkValidity() && (e.preventDefault(), e.stopPropagation()), t.classList.add("was-validated")
            }, !1)
        })
    }, !1)
}();