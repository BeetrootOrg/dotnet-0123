const inputFirstName = document.getElementById("inputFirstName");
const inputLastName = document.getElementById("inputLastName");
const inputEmail = document.getElementById("inputEmail");
const inputPassword = document.getElementById("inputPassword");
const rememberMeCheck = document.getElementById("rememberMeCheck");
const submitButton = document.getElementById("submitButton");

const registrationsKey = "registrations";

submitButton.addEventListener("click", (e) => {
  e.preventDefault();

  const firstName = inputFirstName.value;
  const lastName = inputLastName.value;
  const email = inputEmail.value;
  const password = inputPassword.value;
  const rememberMe = rememberMeCheck.checked;

  if (!firstName || !lastName || !email || !password) {
    alert("Please fill all the fields");
    return;
  }

  const data = {
    firstName,
    lastName,
    email,
    password,
    rememberMe,
  };

  let value = localStorage.getItem(registrationsKey);
  let registrations = JSON.parse(value);
  if (!registrations) {
    registrations = [];
  }

  if (registrations.some((r) => r.email === email)) {
    alert("Email already exists");
    return;
  }

  registrations.push(data);
  localStorage.setItem(registrationsKey, JSON.stringify(registrations));
});
