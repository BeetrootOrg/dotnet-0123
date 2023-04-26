const loginButton = document.getElementById("login-button");
const loginForm = document.getElementById("login-form");

const questionButton = document.getElementById("question-button");
const questionForm = document.getElementById("question-form");

const orderButton = document.getElementById("order-button");
const orderForm = document.getElementById("order-form");

loginButton.addEventListener('click', function() {
    loginButton.setAttribute("disabled", true);
    questionButton.removeAttribute("disabled");
    orderButton.removeAttribute("disabled");

    loginForm.classList.remove("d-none");
    questionForm.classList.add("d-none");
    orderForm.classList.add("d-none");
});
questionButton.addEventListener('click', function() {
    loginButton.removeAttribute("disabled");
    questionButton.setAttribute("disabled", true);
    orderButton.removeAttribute("disabled");

    loginForm.classList.add("d-none");
    questionForm.classList.remove("d-none");
    orderForm.classList.add("d-none");
});
orderButton.addEventListener('click', function() {
    loginButton.removeAttribute("disabled");
    questionButton.removeAttribute("disabled");
    orderButton.setAttribute("disabled", true);

    loginForm.classList.add("d-none");
    questionForm.classList.add("d-none");
    orderForm.classList.remove("d-none");
});