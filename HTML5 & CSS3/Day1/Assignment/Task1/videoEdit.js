let video = document.getElementById("videoId");
let videoBar = document.getElementById("videoLength");
let videoLable = document.getElementById("videoLabel");
let playButton = document.getElementById("play");
let stopButton = document.getElementById("stop");
let back10sec = document.getElementById("back10");
let back5sec = document.getElementById("back5");
let forward10sec = document.getElementById("forward10");
let forward5sec = document.getElementById("forward5");
let volumeBar = document.getElementById("volume");
let muteButton = document.getElementById("mute");
let speedBar = document.getElementById("speed");

video.poster = "frozen.jpg";

video.addEventListener("timeupdate", function (event) {
  videoBar.value = event.target.currentTime;
  videoLable.innerHTML = Math.floor(event.target.currentTime);
});
videoBar.addEventListener("input", function () {
  video.currentTime = videoBar.value;
});
playButton.addEventListener("click", function () {
  video.play();
});
stopButton.addEventListener("click", function () {
  video.pause();
});
back10sec.addEventListener("click", function () {
  video.currentTime -= 10;
});
back5sec.addEventListener("click", function () {
  video.currentTime -= 5;
});
forward10sec.addEventListener("click", function () {
  video.currentTime += 10;
});
forward5sec.addEventListener("click", function () {
  video.currentTime += 5;
});
muteButton.addEventListener("click", function () {
  video.muted = !video.muted;
});
volumeBar.addEventListener("input", function () {
  video.volume = volumeBar.value;
});
speedBar.addEventListener("input", function () {
  video.playbackRate = speedBar.value;
});
