$(document).ready(function () {
    let currentPage = 1;
    let sortOrder = 'asc';
    let searchQuery = '';

    function fetchData() {
        $.ajax({
            url: `https://localhost:44311/api/settlements?page=${currentPage}&sortOrder=${sortOrder}&search=${searchQuery}`,
            method: 'GET',
            success: function (data) {
                populateTable(data.settlements);
                updatePagination(data.totalPages);
            },
            error: function (error) {
                console.error('שגיאה בשליפת נתונים', error);
            }
        });
    }

    function populateTable(settlements) {
        const tbody = $('#settlementsTable tbody');
        tbody.empty();
        settlements.forEach(settlement => {
            const row = `
                <tr>
                    <td>${settlement.name}</td>
                    <td><button class="editBtn" data-id="${settlement.id}">ערוך</button></td>
                    <td><button class="deleteBtn" data-id="${settlement.id}">מחק</button></td>
                </tr>
            `;
            tbody.append(row);
        });
    }

    function updatePagination(totalPages) {
        $('#currentPage').text(`עמוד ${currentPage}`);
        $('#prevPage').prop('disabled', currentPage === 1);
        $('#nextPage').prop('disabled', currentPage === totalPages);
    }

    $('#searchBtn').click(function () {
        searchQuery = $('#search').val();
        currentPage = 1;
        fetchData();
    });

    $('#sortAsc').click(function () {
        sortOrder = 'asc';
        fetchData();
    });

    $('#sortDesc').click(function () {
        sortOrder = 'desc';
        fetchData();
    });

    $('#prevPage').click(function () {
        if (currentPage > 1) {
            currentPage--;
            fetchData();
        }
    });

    $('#nextPage').click(function () {
        currentPage++;
        fetchData();
    });

    $(document).on('click', '.deleteBtn', function () {
        const id = $(this).data('id');
        $.ajax({
            url: `https://localhost:44311/api/settlements/${id}`,
            method: 'DELETE',
            success: function () {
                fetchData();
            },
            error: function (error) {
                console.error('שגיאה במחיקת ישוב', error);
            }
        });
    });

    $(document).on('click', '.editBtn', function () {
        const id = $(this).data('id');
        const settlementName = prompt('הכנס שם חדש לישוב:');
        if (settlementName) {
            $.ajax({
                url: `https://localhost:44311/api/settlements/${id}`,
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify({ name: settlementName }),
                success: function () {
                    fetchData();
                },
                error: function (error) {
                    console.error('שגיאה בעדכון ישוב', error);
                }
            });
        }
    });

    $('#addNewBtn').click(function () {
        const settlementName = prompt('הכנס שם לישוב חדש:');
        if (settlementName) {
            $.ajax({
                url: 'https://localhost:44311/api/settlements',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ name: settlementName }),
                success: function () {
                    fetchData();
                },
                error: function (error) {
                    console.error('שגיאה בהוספת ישוב', error);
                }
            });
        }
    });

    fetchData();
});
