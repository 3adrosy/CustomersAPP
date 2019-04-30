$(document).ready(function () {

    $('#Search_All').keyup(function () {

        clearOthers('#Search_All');

        search_table($(this).val());
    });


    function search_table(value) {

        $('#customers_table tr').each(function () {
            var found = 'false';
            $(this).each(function () {

                if ($(this).hasClass('tableHeader')) {
                    found = 'true';
                }

                else if ($(this).text().toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                    found = 'true';
                }
            });
            if (found == 'true') {
                $(this).show();
            }
            else {
                $(this).hide();
            }
        });
    }

    //////////////////////////////////////////

    $('#Search_Id').keyup(function () {

        clearOthers('#Search_Id');

        search_Id($(this).val());
    });


    function search_Id(value) {

        $('#customers_table tr').each(function () {
            var found = 'false';

            $(this).each(function () {

                if ($(this).hasClass('tableHeader')) {
                    found = 'true';
                }

                else {

                    var currentRow = $(this);
                    var cell = currentRow.children('td.idColumn')

                    if (cell.text().toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                        found = 'true';
                    }

                    if (found == 'true') {
                        currentRow.show();
                    }
                    else {
                        currentRow.hide();
                    }

                }


            });
        });
    }



    //////////////////////////////////////////



    //////////////////////////////////////////

    $('#Search_Gender').keyup(function () {

        clearOthers('#Search_Gender');

        search_Gender($(this).val());
    });


    function search_Gender(value) {

        $('#customers_table tr').each(function () {
            var found = 'false';

            $(this).each(function () {

                if ($(this).hasClass('tableHeader')) {
                    found = 'true';
                }

                else {

                    var currentRow = $(this);
                    var cell = currentRow.children('td.genderColumn')

                    if (cell.text().toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                        found = 'true';
                    }

                    if (found == 'true') {
                        currentRow.show();
                    }
                    else {
                        currentRow.hide();
                    }

                }


            });
        });
    }



    //////////////////////////////////////////


    //////////////////////////////////////////

    $('#Search_Age').keyup(function () {

        clearOthers('#Search_Age');

        Search_Age($(this).val());
    });


    function Search_Age(value) {

        $('#customers_table tr').each(function () {
            var found = 'false';

            $(this).each(function () {

                if ($(this).hasClass('tableHeader')) {
                    found = 'true';
                }

                else {

                    var currentRow = $(this);
                    var cell = currentRow.children('td.ageColumn')

                    if (cell.text().toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                        found = 'true';
                    }

                    if (found == 'true') {
                        currentRow.show();
                    }
                    else {
                        currentRow.hide();
                    }

                }


            });
        });
    }



    //////////////////////////////////////////

    //////////////////////////////////////////

    $('#Search_Type').keyup(function () {

        clearOthers('#Search_Type');

        Search_Type($(this).val());
    });


    function Search_Type(value) {

        $('#customers_table tr').each(function () {
            var found = 'false';

            $(this).each(function () {

                if ($(this).hasClass('tableHeader')) {
                    found = 'true';
                }

                else {

                    var currentRow = $(this);
                    var cell = currentRow.children('td.typeColumn')

                    if (cell.text().toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                        found = 'true';
                    }

                    if (found == 'true') {
                        currentRow.show();
                    }
                    else {
                        currentRow.hide();
                    }

                }


            });
        });
    }



    //////////////////////////////////////////


    //////////////////////////////////////////

    $('#Search_Date').keyup(function () {

        clearOthers('#Search_Date');

        Search_Date($(this).val());
    });


    function Search_Date(value) {

        $('#customers_table tr').each(function () {
            var found = 'false';

            $(this).each(function () {

                if ($(this).hasClass('tableHeader')) {
                    found = 'true';
                }

                else {

                    var currentRow = $(this);
                    var cell = currentRow.children('td.dateColumn')

                    if (cell.text().toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                        found = 'true';
                    }

                    if (found == 'true') {
                        currentRow.show();
                    }
                    else {
                        currentRow.hide();
                    }

                }


            });
        });
    }



    //////////////////////////////////////////

    function clearOthers(exceptField) {

        $('input:text:not(' + exceptField + ')').val("");

    }

    //////////////////////////////////////////


});
