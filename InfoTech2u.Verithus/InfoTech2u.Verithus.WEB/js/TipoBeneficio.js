jQuery(document).ready(function () {

    // delete row in a table
    jQuery('.deleterow').click(function () {
        var conf = confirm('Continue delete?');
        if (conf)
            jQuery(this).parents('tr').fadeOut(function () {
                jQuery(this).remove();
                // do some other stuff here
            });
        return false;
    });

});