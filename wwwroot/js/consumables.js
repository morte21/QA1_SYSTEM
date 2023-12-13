//CALCULATE THE VALUE
function calculateTotals() {
    // Get the values of request_qty and unit_price
    var requestQty = parseFloat(document.getElementById('consum_qty').value) || 0;
    var unitPrice = parseFloat(document.getElementById('safety_qty').value) || 0;

    // Calculate the total_qty
    var totalPrice = requestQty + unitPrice;

    // Update the total_qty field
    document.getElementById('total_qty').value = totalPrice;
}

function calculateTotalValue() {
    // Get the values of request_qty and unit_price
    var requestQty = parseFloat(document.getElementById('unit_price').value) || 0;
    var unitPrice = parseFloat(document.getElementById('total_qty').value) || 0;

    // Calculate the total_price
    var totalPrice = requestQty * unitPrice;

    // Update the total_price field
    document.getElementById('total_price').value = totalPrice;

}

function calculateRequest() {
    // Get the values of request_qty and unit_price
    var requestQty = parseFloat(document.getElementById('request_qty').value) || 0;
    var unitPrice = parseFloat(document.getElementById('total_qty').value) || 0;

    // Calculate the total_price
    var totalPrice = requestQty * unitPrice;

    // Update the total_price field
    document.getElementById('total_price').value = totalPrice;

}

//function calculateRequestQty() {
//    // Get the values of request_qty and unit_price
//    var requestQty = parseFloat(document.getElementById('request_item_qty').value) || 0;
//    var consumQty = parseFloat(document.getElementById('consum_qty').value) || 0;
//    var safetyQty = parseFloat(document.getElementById('safety_qty').value) || 0;

//    if (consumQty > 0) {
//        totalQty = Math.max(consumQty - requestQty, 0);
//    } else {
//        totalQty = Math.max(safetyQty - requestQty, 0);
//    }

//    // Update the total_price field
//    document.getElementById('total_qty').value = totalQty;

//}

document.getElementById('closeModalButton').addEventListener('click', function () {
    // Retrieve the value from the label in the modal view
    var requestQty = document.getElementById('request_qty').innerText.trim();

    // Set the value to the input field in the main view
    document.getElementById('request_item_qty').value = requestQty;
});





//Function to show the modal
function showModal() {
    var modal = document.getElementById('myModal');
    modal.style.display = 'block';
}

// Function to hide the modal
function hideModal() {
    var modal = document.getElementById('myModal');
    modal.style.display = 'none';
}

// Attach event listener to the button to open the modal
var btn = document.getElementById('modalBtn');
btn.addEventListener('click', showModal);

// Close the modal when clicking on the close button (assuming the "close" element inside the modal)
var closeBtn = document.querySelector('.close');
closeBtn.addEventListener('click', hideModal);
