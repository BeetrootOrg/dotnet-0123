const lightThemeButton = document.getElementById("light-theme");
const darkThemeButton = document.getElementById("dark-theme");

lightThemeButton.addEventListener('click', function() {
    document.getElementById("css-link").setAttribute("href", "resources/css/lightmode.css");
});

darkThemeButton.addEventListener('click', function() {
    document.getElementById("css-link").setAttribute("href", "resources/css/darkmode.css");
});