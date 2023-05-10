// Event size
const sizeList = document.querySelectorAll('#list_size .size');

// Thêm sự kiện click cho từng phần tử <li>
sizeList.forEach(size => {
  size.addEventListener('click', () => {
    // Loại bỏ lớp "active" từ phần tử <li> hiện tại
    document.querySelector('#list_size .size.active').classList.remove('active');
    // Thêm lớp "active" cho phần tử <li> được click
    size.classList.add('active');
  });
});
