////EXPORT ITEM REQUEST
//function exportItemRequest() {
//    // Get the DataTable instance
//    var dataTable = $('#itemRequest_table').DataTable();

//    // Get the visible rows and their data
//    var visibleRows = dataTable.rows({ 'search': 'applied' }).data().toArray();

//    // Create a new workbook
//    var workbook = XLSX.utils.book_new();

//    // Create a new worksheet
//    var worksheet = XLSX.utils.aoa_to_sheet([]);

//    // Add headers to the worksheet
//    var headers = [
//        "Status",
//        "Date Request",
//        "Description",
//        "Request quantity",
//        "Reason of request",
//        "Requestor"
//    ];

//    var visibleData = visibleRows.map(function (row) {
//        return row.filter(function (_, index) {
//            // Exclude column 0 (Action) and columns 25 to 34
//            return index !== 0 && (index < 25 || index > 34);
//        });
//    });

//    var dataWithHeaders = [headers].concat(visibleData);

//    XLSX.utils.sheet_add_aoa(worksheet, dataWithHeaders);

//    // Add the worksheet to the workbook
//    XLSX.utils.book_append_sheet(workbook, worksheet, 'Item Request');

//    // Generate the Excel file
//    var excelFile = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

//    // Save the file
//    saveAs(new Blob([excelFile], { type: 'application/octet-stream' }), 'item_request.xlsx');
//}


////EXPORT REQUESTOR
//function exportRequestor() {
//    // Get the DataTable instance
//    var dataTable = $('#requestor_table').DataTable();

//    // Get the visible rows and their data
//    var visibleRows = dataTable.rows({ 'search': 'applied' }).data().toArray();

//    // Create a new workbook
//    var workbook = XLSX.utils.book_new();

//    // Create a new worksheet
//    var worksheet = XLSX.utils.aoa_to_sheet([]);

//    // Add headers to the worksheet
//    var headers = [
//        "Register Date",
//        "Category",
//        "Part Number",
//        "Description",
//        "Maker",
//        "Supplier",
//        "Total quantity",
//        "Consumable quantity",
//        "Safety stocks quantity",
//        "Unit",
//        "Unit Price",
//        "Currency",
//        "Total Price",
//        "Remarks"
//    ];

//    var visibleData = visibleRows.map(function (row) {
//        return row.filter(function (_, index) {
//            // Exclude column 0 (Action) and columns 25 to 34
//            return index !== 0 && (index < 25 || index > 34);
//        });
//    });

//    var dataWithHeaders = [headers].concat(visibleData);

//    XLSX.utils.sheet_add_aoa(worksheet, dataWithHeaders);

//    // Add the worksheet to the workbook
//    XLSX.utils.book_append_sheet(workbook, worksheet, 'Requestor');

//    // Generate the Excel file
//    var excelFile = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

//    // Save the file
//    saveAs(new Blob([excelFile], { type: 'application/octet-stream' }), 'requestor.xlsx');
//}


////EXPORT CONSUMABLES
//function exportConsumable() {
//    // Get the DataTable instance
//    var dataTable = $('#consumable_table').DataTable();

//    // Get the visible rows and their data
//    var visibleRows = dataTable.rows({ 'search': 'applied' }).data().toArray();

//    // Create a new workbook
//    var workbook = XLSX.utils.book_new();

//    // Create a new worksheet
//    var worksheet = XLSX.utils.aoa_to_sheet([]);

//    // Add headers to the worksheet
//    var headers = [
//        "Register Date",
//        "Category",
//        "Part Number",
//        "Description",
//        "Maker",
//        "Supplier",
//        "Total quantity",
//        "Consumable quantity",
//        "Safety stocks quantity",
//        "Unit",
//        "Unit Price",
//        "Currency",
//        "Total Price",
//        "Remarks"
//    ];

//    var visibleData = visibleRows.map(function (row) {
//        return row.filter(function (_, index) {
//            // Exclude column 0 (Action) and columns 25 to 34
//            return index !== 0 && (index < 25 || index > 34);
//        });
//    });

//    var dataWithHeaders = [headers].concat(visibleData);

//    XLSX.utils.sheet_add_aoa(worksheet, dataWithHeaders);

//    // Add the worksheet to the workbook
//    XLSX.utils.book_append_sheet(workbook, worksheet, 'Consumables');

//    // Generate the Excel file
//    var excelFile = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

//    // Save the file
//    saveAs(new Blob([excelFile], { type: 'application/octet-stream' }), 'consumables.xlsx');
//}

////EXPORT COMPUTERS
//function exportComputers() {
//    // Get the DataTable instance
//    var dataTable = $('#computers_table').DataTable();

//    // Get the visible rows and their data
//    var visibleRows = dataTable.rows({ 'search': 'applied' }).data().toArray();

//    // Create a new workbook
//    var workbook = XLSX.utils.book_new();

//    // Create a new worksheet
//    var worksheet = XLSX.utils.aoa_to_sheet([]);

//    // Add headers to the worksheet
//    var headers = [
//        "Register Date",
//        "Category",
//        "Processor",
//        "RAM capacity",
//        "HDD capacity",
//        "OS",
//        "IP SDP",
//        "IP LOCAL",
//        "USER"
        
//    ];

//    var visibleData = visibleRows.map(function (row) {
//        return row.filter(function (_, index) {
//            // Exclude column 0 (Action) and columns 25 to 34
//            return index !== 0 && (index < 25 || index > 34);
//        });
//    });

//    var dataWithHeaders = [headers].concat(visibleData);

//    XLSX.utils.sheet_add_aoa(worksheet, dataWithHeaders);

//    // Add the worksheet to the workbook
//    XLSX.utils.book_append_sheet(workbook, worksheet, 'Computers');

//    // Generate the Excel file
//    var excelFile = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

//    // Save the file
//    saveAs(new Blob([excelFile], { type: 'application/octet-stream' }), 'computers.xlsx');
//}

////EXPORT EQUIPMENT MACHINE
//function exporteqp() {
//    // Get the DataTable instance
//    var dataTable = $('#equipmachine_table').DataTable();

//    // Get the visible rows and their data
//    var visibleRows = dataTable.rows({ 'search': 'applied' }).data().toArray();

//    // Create a new workbook
//    var workbook = XLSX.utils.book_new();

//    // Create a new worksheet
//    var worksheet = XLSX.utils.aoa_to_sheet([]);

//    // Add headers to the worksheet
//    var headers = [
//        "Register Date",
//        "Category",
//        "Part number",
//        "Description",
//        "Machine type",
//        "User"
        

//    ];

//    var visibleData = visibleRows.map(function (row) {
//        return row.filter(function (_, index) {
//            // Exclude column 0 (Action) and columns 25 to 34
//            return index !== 0 && (index < 25 || index > 34);
//        });
//    });

//    var dataWithHeaders = [headers].concat(visibleData);

//    XLSX.utils.sheet_add_aoa(worksheet, dataWithHeaders);

//    // Add the worksheet to the workbook
//    XLSX.utils.book_append_sheet(workbook, worksheet, 'Equipment and machine');

//    // Generate the Excel file
//    var excelFile = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

//    // Save the file
//    saveAs(new Blob([excelFile], { type: 'application/octet-stream' }), 'equipment_machine.xlsx');
//}
