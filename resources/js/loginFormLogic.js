let passwordInput = {
    inputField: document.getElementById("passwordInput"),
    isPasswordVisible: false
};

const passwordViewerButton = document.getElementById("button-addon2");
const viewIcon = document.getElementById("viewPassword");
const hideIcon = document.getElementById("hidePassword");

passwordViewerButton.addEventListener('click', function() {
    if (passwordInput.isPasswordVisible) {
        hideIcon.classList.add("d-none");
        viewIcon.classList.remove("d-none");
        passwordInput.inputField.setAttribute("type", "password");
    } else {
        hideIcon.classList.remove("d-none");
        viewIcon.classList.add("d-none");
        passwordInput.inputField.setAttribute("type", "email");
    }
    passwordInput.isPasswordVisible = !passwordInput.isPasswordVisible;
})