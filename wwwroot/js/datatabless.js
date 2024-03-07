//DATATABLE LAYOUT
$(function () {
    new DataTable('#consStocks_table', {
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [25, 40, 50, 100, -1],
            [25, 40, 50, 100, 'All'],
        ],

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
                exportOptions: {
                    modifier: {
                        page: 'all' // Include data from all pages
                    }
                }
            },
        ],

    });
});

//DATATABLE LAYOUT
$(function () {
    new DataTable('#consumable_table', {
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [25, 40, 50, 100, -1],
            [25, 40, 50, 100, 'All'],
        ],

       

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
                exportOptions: {
                    modifier: {
                        page: 'all' // Include data from all pages
                    }
                }
            },
        ],

    });
});

//DATATABLE LAYOUT
$(function () {
    new DataTable('#purchase_table', {
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [25, 40, 50, 100, -1],
            [25, 40, 50, 100, 'All'],
        ],

        

        processing: true,
        serverSide: true,
        ajax: {
            url: '/Purchase/purchaseLoadData',
            type: 'POST'
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                &nbsp;&nbsp;<a href="/Purchase/Edit/${row.id}">Edit</a>&nbsp;&nbsp; |
                &nbsp;&nbsp;<a href="/Purchase/Details/${row.id}" data-bs-toggle="modal" data-bs-target="#detailmodal" onclick="loadDetailsModal(${row.id})">Details</a>&nbsp;&nbsp; |
                &nbsp;&nbsp;<a href="/Purchase/Delete/${row.id}">Delete</a>
                </td>`;
                }
            },

            { data: 'pr_number' },
            { data: 'request_status' },
            { data: 'purchase_order' },

            {
                data: 'date_request',
                render: function (data, type, row) {
                    // Assuming 'data' is a date string in a specific format
                    return moment(data).format('MM/DD/YYYY'); // Format using moment.js
                }
            },
            { data: 'purchase_dept' },
            { data: 'category' },
            { data: 'part_number' },
            { data: 'item_description' },
            { data: 'maker' },
            { data: 'supplier' },
            { data: 'request_qty', visible: false },
            { data: 'request_unit', visible: false },
            { data: 'unit_price', visible: false },
            { data: 'total_price', visible: false },
            { data: 'item_currency', visible: false },
            { data: 'request_reason' },
            
            { data: 'date_submitPR', visible: false },
            { data: 'person_submitPR', visible: false },
            { data: 'po_path', visible: false },
            { data: 'est_time_arrival' },
            { data: 'date_needed', visible: false },
            { data: 'date_received', visible: false },
            { data: 'received_qty' },
            { data: 'item_comment' },
            

            { data: 'pr_path', visible: false }
        ],

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                exportOptions: {
                    modifier: {
                        page: 'all',
                        selected: true // Include data from all pages
                    }
                }
            },
        ],

    });
});



$(function () {
    new DataTable('#requestor_table', {
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [25, 40, 50, 100, -1],
            [25, 40, 50, 100, 'All'],
        ],



        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
                exportOptions: {
                    modifier: {
                        page: 'all' // Include data from all pages
                    }
                }
            },
        ],

    });
});





//DATATABLE LAYOUT
$(function () {
    new DataTable('#computers_table', {
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [25, 40, 50, 100, -1],
            [25, 40, 50, 100, 'All'],
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
                exportOptions: {
                    modifier: {
                        page: 'all' // Include data from all pages
                    }
                }
            },
        ],

    });
});




//DATATABLE LAYOUT
$(function () {
    new DataTable('#equipmachine_table', {
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": true,
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [25, 40, 50, 100, -1],
            [25, 40, 50, 100, 'All'],
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
                exportOptions: {
                    modifier: {
                        page: 'all' // Include data from all pages
                    }
                }
            },
        ],

    });
});

//HOME
$(function () {
    new DataTable('#consumableHome_table', {
        "scrollY": '50vh',
        "scrollX": '50vh',
        "scrollCollapse": false,
        paging: true,
        searching: true,
        ordering: true,

        lengthMenu: [
            [10, 20, -1],
            [10, 20, 'All'],
        ],
        

    });
});



$(function () {
    new DataTable('#itemRequest_table', {
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": true,
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [25, 40, 50, 100, -1],
            [25, 40, 50, 100, 'All'],
        ],

        processing: true,
        serverSide: true,
        ajax: {
            url: '/ItemRequest/ItemReqLoadData',
            type: 'POST'
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/ItemRequest/Edit/${row.id}">Edit</a> |
                    &nbsp;&nbsp;<a href="/ItemRequest/Details/${row.id}">Details</a> |
                    &nbsp;&nbsp;<a href="/ItemRequest/Notif/${row.id}">Send Notification</a>
                    </td>`;
                }
            },

            { data: 'status' },
            { data: 'req_date' },
            { data: 'description' },
            { data: 'req_qty' },
            { data: 'reason' },
           
            { data: 'requestor' }
        ],





        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
                exportOptions: {
                    modifier: {
                        page: 'all' // Include data from all pages
                    }
                }
            },
        ],

    });
});