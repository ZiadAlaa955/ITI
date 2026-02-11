const toggleBtn = document.getElementById("themeToggle");
const themeIcon = document.getElementById("themeIcon");
const themeText = document.getElementById("themeText");

const currentTheme = localStorage.getItem("theme") || "dark";
document.documentElement.setAttribute("data-bs-theme", currentTheme);
updateButton(currentTheme);

toggleBtn.addEventListener("click", () => {
  const activeTheme = document.documentElement.getAttribute("data-bs-theme");
  const newTheme = activeTheme === "dark" ? "light" : "dark";

  document.documentElement.setAttribute("data-bs-theme", newTheme);
  localStorage.setItem("theme", newTheme);

  updateButton(newTheme);
});

function updateButton(theme) {
  if (theme === "dark") {
    themeIcon.innerHTML = "🌙";
    themeText.innerHTML = "Dark Mode";
    toggleBtn.classList.add("text-white");
    toggleBtn.classList.remove("text-dark");
  } else {
    themeIcon.innerHTML = "🌙";
    themeText.innerHTML = "Light Mode";
    toggleBtn.classList.add("text-white");
    toggleBtn.classList.remove("text-dark");
  }
}
