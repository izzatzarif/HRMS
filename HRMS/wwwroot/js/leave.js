function confirmDelete(leaveId, employeeName) {
    document.getElementById('leaveName').textContent = `Adakah anda pasti ingin menghapuskan cuti ${employeeName}?`;
    $('#confirmDeleteModal').modal('show');
    
    document.getElementById('confirmDeleteBtn').onclick = function () {
        fetch(`/Leave/DeleteConfirmed/${leaveId}`, {
            method: 'POST',
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
                'Content-Type': 'application/json'
            },
        }).then(response => {
            if (response.ok) {
                location.reload();
            } else {
                alert('Pemadaman gagal!');
            }
        }).catch(error => {
            console.error('Error:', error);
            alert('Pemadaman gagal!');
        });
    };
}
