$(document).ready(function () {
    var categoryCounts = {};

    $('#con_table tbody tr').each(function () {
        var category = $(this).find('td:nth-child(1)').text().trim();

        if (category in categoryCounts) {
            categoryCounts[category]++;
        } else {
            categoryCounts[category] = 1;
        }
    });

    var categoryNames = Object.keys(categoryCounts);
    var categoryData = Object.values(categoryCounts);

    // Define an array of custom colors for the bars
    var customColors = [
        'rgba(255, 99, 132, 0.5)',
        'rgba(54, 162, 235, 0.5)',
        'rgba(255, 206, 86, 0.5)',
        'rgba(75, 192, 192, 0.5)',
        // Add more colors as needed
    ];

    // Assign different colors to each bar in the dataset
    var backgroundColors = customColors.slice(0, categoryNames.length);


    var ctx = document.getElementById('categoryChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        
        data: {
            labels: categoryNames,
            datasets: [{
                label: 'Inventory',
                data: categoryData,
                backgroundColor: backgroundColors,
                borderColor: backgroundColors.map(color => color.replace('0.5', '1')), // Adjust alpha for border color
                borderWidth: 1
            }]
        },
        options: {
            indexAxis: 'y',
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            animation: true,
            plugins: {
                legend: {
                    display: true
                },
                tooltip: {
                    enabled: true
                }
            }
        }
    });
});




$(document).ready(function () {
    var categoryCounts2 = {};

    $('#pur_table tbody tr').each(function () {
        var category2 = $(this).find('td:nth-child(2)').text().trim();

        if (category2 in categoryCounts2) {
            categoryCounts2[category2]++;
        } else {
            categoryCounts2[category2] = 1;
        }
    });

    var categoryNames2 = Object.keys(categoryCounts2);
    var categoryData2 = Object.values(categoryCounts2);

    // Define an array of custom colors for the bars
    var customColors2 = [
        'rgba(255, 99, 132, 0.5)',
        'rgba(54, 162, 235, 0.5)',
        'rgba(255, 206, 86, 0.5)',
        'rgba(75, 192, 192, 0.5)',
        // Add more colors as needed
    ];

    // Assign different colors to each bar in the dataset
    var backgroundColors2 = customColors2.slice(0, categoryNames2.length);


    var ctx2 = document.getElementById('categoryChart2').getContext('2d');
    var myChart2 = new Chart(ctx2, {
        type: 'bar',

        data: {
            labels: categoryNames2,
            datasets: [{
                label: 'Purchase Category',
                data: categoryData2,
                backgroundColor: backgroundColors2,
                borderColor: backgroundColors2.map(color => color.replace('0.5', '1')), // Adjust alpha for border color
                borderWidth: 1
            }]
        },
        options: {
            indexAxis: 'y',
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            animation: true,
            plugins: {
                legend: {
                    display: true
                },
                tooltip: {
                    enabled: true
                }
            }
        }
    });
});

$(document).ready(function () {
    var categoryCounts3 = {};

    $('#pur_table tbody tr').each(function () {
        var category3 = $(this).find('td:nth-child(6)').text().trim();

        if (category3 in categoryCounts3) {
            categoryCounts3[category3]++;
        } else {
            categoryCounts3[category3] = 1;
        }
    });

    var categoryNames3 = Object.keys(categoryCounts3);
    var categoryData3 = Object.values(categoryCounts3);

    // Define an array of custom colors for the bars
    var customColors3 = [
        'rgba(255, 99, 132, 0.5)',
        'rgba(54, 162, 235, 0.5)',
        'rgba(255, 206, 86, 0.5)',
        'rgba(75, 192, 192, 0.5)',
        // Add more colors as needed
    ];

    // Assign different colors to each bar in the dataset
    var backgroundColors3 = customColors3.slice(0, categoryNames3.length);


    var ctx3 = document.getElementById('categoryChart3').getContext('2d');
    var myChart3 = new Chart(ctx3, {
        type: 'bar',

        data: {
            labels: categoryNames3,
            datasets: [{
                label: 'Purchase Status',
                data: categoryData3,
                backgroundColor: backgroundColors3,
                borderColor: backgroundColors3.map(color => color.replace('0.5', '1')), // Adjust alpha for border color
                borderWidth: 1
            }]
        },
        options: {
            indexAxis: 'y',
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            animation: true,
            plugins: {
                legend: {
                    display: true
                },
                tooltip: {
                    enabled: true
                }
            }
        }
    });
});




