document.addEventListener("DOMContentLoaded", function() {
    const dropZone = document.getElementById("dragDropArea");
    const fileInput = dropZone.querySelector("input[type=file]");
    const fileNameDisplay = document.getElementById("fileDragName");

    dropZone.addEventListener("click", function() {
        fileInput.click();
    });

    fileInput.addEventListener("change", function() {
        if (fileInput.files.length) {
            fileNameDisplay.textContent = fileInput.files[0].name;
        }
    });

    ["dragenter", "dragover", "dragleave", "drop"].forEach(eventName => {
        dropZone.addEventListener(eventName, preventDefaults, false);
    });

    function preventDefaults(e) {
        e.preventDefault();
        e.stopPropagation();
    }

    ["dragenter", "dragover"].forEach(eventName => {
        dropZone.addEventListener(eventName, highlight, false);
    });

    ["dragleave", "drop"].forEach(eventName => {
        dropZone.addEventListener(eventName, unhighlight, false);
    });

    function highlight() {
        dropZone.classList.add("dragover-border");
    }

    function unhighlight() {
        dropZone.classList.remove("dragover-border");
    }

    dropZone.addEventListener("drop", handleDrop, false);

    function handleDrop(e) {
        const dt = e.dataTransfer;
        fileInput.files = dt.files;
        if (fileInput.files.length) {
            fileNameDisplay.textContent = fileInput.files[0].name;
        }
    }
});
