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
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
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
            [5, 10, -1],
            [5, 10, 'All'],
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

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel', // Change the button text here
            },
        ],

    });
});