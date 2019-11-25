
function myFunction() {
    var a = document.getElementById("myCenter");
    if (a.className === "center") {
        a.className += " responsive";
    } else {
        a.className = "center";
    }
}