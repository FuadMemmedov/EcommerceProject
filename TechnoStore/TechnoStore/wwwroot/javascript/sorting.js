$(document).ready(function () {
    $('#order').change(function () {
        var order = $(this).val();
        $.ajax({
            url: '/Shop/Index', // Replace with the actual URL to your controller action
            type: 'GET',
            data: {
                order: order,
                page: 1 // Assuming you want to start at the first page
            },
            success: function (response) {
                $('#sort-box').html(response); // Update the product list container
                console.log('Sorted successfully.');
                // Optionally, update the UI or perform other actions
            },
            error: function (xhr, status, error) {
                console.error('Error sorting:', status, error);
                // Optionally, handle the error
            }
        });
    });
});

