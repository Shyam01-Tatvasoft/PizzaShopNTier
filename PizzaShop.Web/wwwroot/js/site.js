// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let eyeButton = document.getElementById("eye-icon");
let eyeButtonResetPass1 = document.getElementById("resetPassEyeBtn1");
let eyeButtonResetPass2 = document.getElementById("resetPassEyeBtn2");
let eyeButtonAddUserPass = document.getElementById("addUserEyeBtn");
let passwordField = document.getElementById("Password");
let passwordResetField1 = document.getElementById("PasswordReset1");
let passwordResetField2 = document.getElementById("PasswordReset2");
let passwordAddUserField = document.getElementById("addUserPassword");

let loginForm = document.getElementById("loginForm");

let LoginHandler = (data) => {
  console.log(data);
};

eyeButton?.addEventListener("click", () => {
  if (passwordField.type == "password") {
    passwordField.type = "text";
    eyeButton.classList.remove("fa-eye");
    eyeButton.classList.add("fa-eye-slash");
  } else {
    passwordField.type = "password";
    eyeButton.classList.add("fa-eye");
    eyeButton.classList.remove("fa-eye-slash");
  }
});

eyeButtonResetPass1?.addEventListener("click", () => {
  if (passwordResetField1.type == "password") {
    passwordResetField1.type = "text";
    eyeButtonResetPass1.classList.remove("fa-eye");
    eyeButtonResetPass1.classList.add("fa-eye-slash");
  } else {
    passwordResetField1.type = "password";
    eyeButtonResetPass1.classList.add("fa-eye");
    eyeButtonResetPass1.classList.remove("fa-eye-slash");
  }
});

eyeButtonResetPass2?.addEventListener("click", () => {
  if (passwordResetField2.type == "password") {
    passwordResetField2.type = "text";
    eyeButtonResetPass2.classList.remove("fa-eye");
    eyeButtonResetPass2.classList.add("fa-eye-slash");
  } else {
    passwordResetField2.type = "password";
    eyeButtonResetPass2.classList.add("fa-eye");
    eyeButtonResetPass2.classList.remove("fa-eye-slash");
  }
});

eyeButtonAddUserPass?.addEventListener("click",()=>{
  if (passwordAddUserField.type == "password") {
    passwordAddUserField.type = "text";
    eyeButtonAddUserPass.classList.remove("fa-eye");
    eyeButtonAddUserPass.classList.add("fa-eye-slash");
  } else {
    passwordAddUserField.type = "password";
    eyeButtonAddUserPass.classList.add("fa-eye");
    eyeButtonAddUserPass.classList.remove("fa-eye-slash");
  }
})