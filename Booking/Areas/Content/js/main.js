ClassicEditor
    .create(document.querySelector('#editor'))
    .catch(error => {
        console.error(error);
    });
let fileInput = document.getElementById("file-input");
let imageContainer = document.getElementById("images");
let numOfFiles = document.getElementById("num-of-files");
function preview() {
    numOfFiles.textContent = `${fileInput.files.length} Ảnh Được Chọn`;
    for (let i = 0; i < fileInput.files.length; i++) {
        let reader = new FileReader();
        let file = fileInput.files[i];
        reader.onload = (event) => {
            let img = document.createElement("img");
            img.setAttribute("src", event.target.result);
            img.setAttribute("alt", file.name);
            imageContainer.appendChild(img);
        };

        reader.readAsDataURL(file);
    }
}


const boxes = document.querySelectorAll('.room__box');
const nextButtons = document.querySelectorAll('.btn-next');
const prevButtons = document.querySelectorAll('.btn-prev');
nextButtons.forEach((item, index) => {
    item.addEventListener("click", () => {
        boxes[index].classList.add("active");
        boxes[index+1].classList.remove("active");
       
    })
})
prevButtons.forEach((item, index) => {
    item.addEventListener("click", () => {
        boxes[index].classList.add("active");
        boxes[index-1].classList.remove("active");
        updateBtnState();
    })
})
let updateBtnState = () => {
    boxes.forEach((item, index) => {
        if (index === 0) {
            prevButtons[index].disabled = true;
        } else {
            prevButtons[index].disabled = false;
        }
    })
}
