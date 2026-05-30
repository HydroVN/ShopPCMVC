document.addEventListener("DOMContentLoaded", function () {
    const deleteButtons = document.querySelectorAll(".btn-trigger-delete");

    deleteButtons.forEach(button => {
        button.addEventListener("click", function (event) {
            event.preventDefault();

            const tableRow = this.closest("tr");
            const computerName = tableRow.querySelector(".computer-name-target").textContent.trim();

            const isConfirmed = confirm(`HỆ THỐNG CẢNH BÁO:\nBạn có chắc chắn muốn xóa bỏ sản phẩm máy tính:\n"${computerName}" ra khỏi cơ sở dữ liệu kho hàng?`);

            if (isConfirmed) {
                const hiddenForm = this.closest(".delete-computer-form");
                if (hiddenForm) {
                    hiddenForm.submit();
                }
            }
        });
    });

    const imageInput = document.getElementById("ImageInputUrl");
    const imagePreview = document.getElementById("ImagePreview");

    if (imageInput && imagePreview) {
        imageInput.addEventListener("input", function () {
            const urlValue = this.value.trim();
            if (urlValue !== "") {
                imagePreview.src = urlValue;
                imagePreview.classList.remove("d-none");
            } else {
                imagePreview.classList.add("d-none");
            }
        });
    }
});