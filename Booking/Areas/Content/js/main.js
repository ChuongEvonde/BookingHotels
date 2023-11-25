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

function changePage(pageName) {
    var content = document.getElementById('content');

    // Đổi nội dung trang dựa trên tên trang
    switch (pageName) {
        case 'home':
            content.innerHTML = '<h2>Chào mừng bạn đến Trang Chủ</h2>';
            break;
        case 'booking':
            content.innerHTML = '<h2>Đặt Phòng</h2><p>Điền thông tin để đặt phòng</p>';
            break;
        case 'room-info':
            content.innerHTML = '<h2>Thông Tin Phòng</h2><p>Xem chi tiết về các loại phòng</p>';
            break;
        case 'invoice':
            content.innerHTML = '<h2>Hóa Đơn</h2><p>Xem và quản lý hóa đơn của bạn</p>';
            break;
        default:
            break;
    }
}
