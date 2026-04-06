// --- KHỞI TẠO STATE (DỮ LIỆU RỖNG) ---
let state = {
    dashboard: [],
    books: [],
    readers: [],
    borrow: [],
    import: [],
    reference: { authors: [], categories: [], publishers: [] }
};

// --- HÀM ĐIỀU HƯỚNG ---
function showSection(id) {
    document.querySelectorAll('.content-section').forEach(s => s.style.display = 'none');
    document.getElementById(id).style.display = 'block';

    document.querySelectorAll('.sidebar li').forEach(li => li.classList.remove('active'));
    document.getElementById('menu-' + id).classList.add('active');

    // Tự động render lại bảng của mục đó
    renderAll();
}

// --- HÀM HIỂN THỊ KHI TRỐNG ---
function renderEmpty(targetId, colCount) {
    const tbody = document.getElementById(targetId);
    if (tbody) {
        tbody.innerHTML = `<tr><td colspan="${colCount}" style="text-align:center; padding:40px; color:#aaa;">
            Chưa có dữ liệu. Vui lòng kết nối database hoặc thêm mới.
        </td></tr>`;
    }
}

// --- RENDER TỔNG THỂ ---
function renderAll() {
    // 1. Thống kê Dashboard
    const statsContainer = document.getElementById('dashboard-stats');
    if (statsContainer) {
        const labels = ["Tổng sách", "Độc giả", "Mượn hôm nay", "Quá hạn"];
        const colors = ["blue", "green", "purple", "red"];
        statsContainer.innerHTML = labels.map((l, i) => `
            <div class="card ${colors[i]}"><h3>0</h3><span>${l}</span></div>
        `).join('');
    }

    // 2. Render các bảng dữ liệu rỗng
    renderEmpty('dashboard-recent-table', 5);
    //renderEmpty('books-table-body', 4);
    //renderEmpty('readers-table-body', 4);
    renderEmpty('borrow-table-body', 5);
    renderEmpty('import-table-body', 4);
    renderEmpty('ref-table-body', 3);
}

// --- XỬ LÝ DANH MỤC (TABS) ---
function switchRefTab(type) {
    document.querySelectorAll('.tab-btn').forEach(btn => btn.classList.remove('active'));
    event.target.classList.add('active');
    renderEmpty('ref-table-body', 3);
}

// Khởi tạo hệ thống
window.onload = renderAll;