var swiper = new Swiper(".swiper", {
  slidesPerView: 6,
  direction: getDirection(),
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
});

function getDirection() {
  var windowWidth = window.innerWidth;
  var direction = windowWidth <= 760 ? "vertical" : "horizontal";

  return direction;
}

var swiper1 = new Swiper(".swiper1", {
  slidesPerView: 4  ,
  direction: getDirection(),
  navigation: {
    nextEl: ".roomtple__btn-next",
    prevEl: ".roomtple__btn-prev",
  },
});
