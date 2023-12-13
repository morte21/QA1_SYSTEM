

//CALCULATE THE VALUE
function calculateTotal() {
    // Get the values of request_qty and unit_price
    var requestQty = parseFloat(document.getElementById('request_qty').value) || 0;
    var unitPrice = parseFloat(document.getElementById('unit_price').value) || 0;

    // Calculate the total_price
    var totalPrice = requestQty * unitPrice;

    // Update the total_price field
    document.getElementById('total_price').value = totalPrice;

}

$('#editmodal').on('shown.bs.modal', function (e) {
    // Code to execute when the modal is shown
    calculateTotal(); // Re-bind event listeners for inputs
});

$('#createmodal').on('shown.bs.modal', function (e) {
    // Code to execute when the modal is shown
    calculateTotal(); // Re-bind event listeners for inputs
});



function setupListeners() {
    $('#request_qty, #unit_price').on('input', function () {
        // Your calculateTotal function here
    });
}





function loadEditModal(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/Purchase/EditGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#editmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}

function loadDetailsModal(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/Purchase/DetailGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#detailmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}


function loadEditModalItemRequest(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/ItemRequest/EditGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#editmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}



function loadDetailsModalItemRequest(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/ItemRequest/DetailsGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#editmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}

function loadDetailsModalConsumables(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/Consumables/DetailsGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#detailmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}

function loadEditModalConsumables(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/Consumables/EditGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#editmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}


function loadEditModalComputer(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/Computers/EditGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#editmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}


function loadDetailsModalComputer(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/Computers/DetailsGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#detailmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}


function loadEditModalEQP(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/EquipmentMachine/EditGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#editmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}


function loadDetailsModalEQP(itemId) {
    // Perform an AJAX request to fetch data for the specific item
    $.ajax({
        url: '/EquipmentMachine/DetailsGet', // Replace with your endpoint to fetch item details
        type: 'GET',
        data: { id: itemId },
        success: function (data) {
            // Inject the fetched data into the modal
            $('#detailmodal .modal-body').html(data);
        },
        error: function (error) {
            console.log('Error fetching item details: ', error);
        }
    });
}


   

