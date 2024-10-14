function confirmDelete(employeeId, employeeName) {
    // Mengisi nama pekerja dalam modal
    document.getElementById('employeeName').textContent = `Adakah anda pasti ingin menghapuskan pekerja ${employeeName}?`;
    
    // Menunjukkan modal
    $('#confirmDeleteModal').modal('show');

    // Menangani butang hapus dalam modal
    document.getElementById('confirmDeleteBtn').onclick = function () {
        // Menghantar permintaan pemadaman ke server
        fetch(`/Employee/DeleteConfirmed/${employeeId}`, {
            method: 'DELETE',
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
                'Content-Type': 'application/json'
            },
        }).then(response => {
            if (response.ok) {
                // Memuat semula halaman selepas pemadaman berjaya
                location.reload(); // Memuat semula halaman untuk menunjukkan perubahan
            } else {
                alert('Pemadaman gagal!'); // Mesej jika pemadaman gagal
            }
        }).catch(error => {
            console.error('Error:', error); // Mencetak ralat ke konsol jika ada masalah
            alert('Pemadaman gagal!');
        });
    };
}
