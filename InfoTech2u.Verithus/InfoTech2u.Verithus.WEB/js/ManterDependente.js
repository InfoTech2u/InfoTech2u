jQuery(document).ready(function () {

    // dynamic table
    jQuery('#dyntable').dataTable({
        "sPaginationType": "full_numbers",
        "aaSortingFixed": [[0, 'asc']],
        "fnDrawCallback": function (oSettings) {
            jQuery.uniform.update();
        }
    });

    //Data dataddmmaaaa
    jQuery(".dataddmmaaaa").mask("99/99/9999");

    // Dual Box Select
    var db = jQuery('#dualselect').find('.ds_arrow button');	//get arrows of dual select
    var sel1 = jQuery('#dualselect select:first-child');		//get first select element
    var sel2 = jQuery('#dualselect select:last-child');			//get second select element

    sel2.empty(); //empty it first from dom.

    db.click(function () {
        var t = (jQuery(this).hasClass('ds_prev')) ? 0 : 1;	// 0 if arrow prev otherwise arrow next
        if (t) {
            sel1.find('option').each(function () {
                if (jQuery(this).is(':selected')) {
                    jQuery(this).attr('selected', false);
                    var op = sel2.find('option:first-child');
                    sel2.append(jQuery(this));
                }
            });
        } else {
            sel2.find('option').each(function () {
                if (jQuery(this).is(':selected')) {
                    jQuery(this).attr('selected', false);
                    sel1.append(jQuery(this));
                }
            });
        }
        return false;
    });

    //btnSaveChanges

    jQuery('#btnIncluir').click(function (event) {
        if (validar()) {

            jQuery('#dyntable > tbody:last').append('<tr class="gradeX"><td class="aligncenter"><span class="center"><input type="checkbox" /></span></td><td>Trident</td><td>Internet Explorer 4.0</td><td>Win 95+</td><td class="center">4</td></tr>');
            jQuery('#dyntable > tbody:last').append('<tr class="gradeX"><td class="aligncenter"><span class="center"><input type="checkbox" /></span></td><td>Trident</td><td>Internet Explorer 4.0</td><td>Win 95+</td><td class="center">4</td></tr>');
            jQuery('#dyntable > tbody:last').append('<tr class="gradeX"><td class="aligncenter"><span class="center"><input type="checkbox" /></span></td><td>Trident</td><td>Internet Explorer 4.0</td><td>Win 95+</td><td class="center">4</td></tr>');
            jQuery('#dyntable > tbody:last').append('<tr class="gradeX"><td class="aligncenter"><span class="center"><input type="checkbox" /></span></td><td>Trident</td><td>Internet Explorer 4.0</td><td>Win 95+</td><td class="center">4</td></tr>');

            jQuery('#myModal').modal('hide')
        }
    });

    /*
    <tr class="gradeX"><td class="aligncenter"><span class="center"><input type="checkbox" /></span></td><td>Trident</td><td>Internet Explorer 4.0</td><td>Win 95+</td><td class="center">4</td></tr>
    */

});

function validar() {
    return false;
}
