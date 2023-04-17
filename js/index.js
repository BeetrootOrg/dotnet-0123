const inputFirstName = document.getElementById("inputFirstName");
const inputLastName = document.getElementById("inputLastName");
const inputEmail = document.getElementById("inputEmail");
const inputPassword = document.getElementById("inputPassword");
const rememberMeCheck = document.getElementById("rememberMeCheck");
const submitButton = document.getElementById("submitButton");

submitButton.addEventListener("click", (e) => {
  e.preventDefault();

  const firstName = inputFirstName.value;
  const lastName = inputLastName.value;
  const email = inputEmail.value;
  const password = inputPassword.value;
  const rememberMe = rememberMeCheck.checked;

  const data = {
    firstName,
    lastName,
    email,
    password,
    rememberMe,
  };

  console.log(data);
});
