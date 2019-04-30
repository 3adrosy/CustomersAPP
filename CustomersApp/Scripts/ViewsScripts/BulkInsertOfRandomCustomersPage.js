$(document).ready(function () {

    $('#bulkForm').submit(function () {
        if ($(this).valid()) {
            $(':submit', this).attr('disabled', 'disabled');
            $(':submit', this).val('Processing...');
        }
    });
});
