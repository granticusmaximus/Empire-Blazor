document.addEventListener('DOMContentLoaded', function () {
	const dropZone = document.getElementById('dragDropArea');
	const fileInput = dropZone.querySelector('input[type=file]');
	const fileNameDisplay = document.getElementById('fileDragName');
	const imagePreview = document.getElementById('imagePreview');

	function updateImageDisplay() {
		if (fileInput.files && fileInput.files[0]) {
			const reader = new FileReader();
			reader.onload = function (e) {
				imagePreview.src = e.target.result;
				imagePreview.style.display = 'block';
			};
			reader.readAsDataURL(fileInput.files[0]);
		}
	}

	dropZone.addEventListener('click', function () {
		fileInput.click();
	});

	fileInput.addEventListener('change', function () {
		if (fileInput.files.length) {
			fileNameDisplay.textContent = fileInput.files[0].name;
			updateImageDisplay();
		}
	});

	['dragenter', 'dragover', 'dragleave', 'drop'].forEach((eventName) => {
		dropZone.addEventListener(eventName, preventDefaults, false);
	});

	function preventDefaults(e) {
		e.preventDefault();
		e.stopPropagation();
	}

	['dragenter', 'dragover'].forEach((eventName) => {
		dropZone.addEventListener(eventName, highlight, false);
	});

	['dragleave', 'drop'].forEach((eventName) => {
		dropZone.addEventListener(eventName, unhighlight, false);
	});

	function highlight() {
		dropZone.classList.add('dragover-border');
	}

	function unhighlight() {
		dropZone.classList.remove('dragover-border');
	}

	dropZone.addEventListener('drop', handleDrop, false);

	function handleDrop(e) {
		const dt = e.dataTransfer;
		fileInput.files = dt.files;
		if (fileInput.files.length) {
			fileNameDisplay.textContent = fileInput.files[0].name;
			updateImageDisplay();
		}
	}
});
