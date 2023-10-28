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

preview();
