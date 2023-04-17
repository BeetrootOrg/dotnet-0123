const inputFirstName = document.getElementById("inputFirstName");
const inputLastName = document.getElementById("inputLastName");
const inputEmail = document.getElementById("inputEmail");
const inputPassword = document.getElementById("inputPassword");
const inputBirthDate = document.getElementById("inputBirthDate");
const inputFavoriteColor = document.getElementById("inputFavoriteColor");
const inputRange = document.getElementById("inputRange");
const rememberMeCheck = document.getElementById("rememberMeCheck");
const submitButton = document.getElementById("submitButton");

const registrationsKey = "registrations";

submitButton.addEventListener("click", (e) => {
  e.preventDefault();

  const firstName = inputFirstName.value;
  const lastName = inputLastName.value;
  const email = inputEmail.value;
  const password = inputPassword.value;
  const birthDate = inputBirthDate.value;
  const favoriteColor = inputFavoriteColor.value;
  const range = inputRange.value;
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
    birthDate,
    favoriteColor,
    range,
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
