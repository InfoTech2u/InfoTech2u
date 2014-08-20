/*
 * Additional function for forms.html
 *	Written by ThemePixels	
 *	http://themepixels.com/
 *
 *	Copyright (c) 2012 ThemePixels (http://themepixels.com)
 *	
 *	Built for Katniss Premium Responsive Admin Template
 *  http://themeforest.net/category/site-templates/admin-templates
 */

jQuery(document).ready(function () {


    // Date Picker
    jQuery("#txtDataNascimento").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn',
        maxDate: '-1d'
    });

    // Select with Search
    jQuery(".chzn-select").chosen();


    // Spinner
    jQuery("#txtQtdFilhos").spinner({ min: 0, max: 100, increment: 2 });

    
    jQuery('#wizard3').smartWizard({ onFinish: onFinishCallback });
    
    function onFinishCallback() {
        alert('Finish Clicked');
    }

    //ddlNacionalidadeFuncionario
    /*
    jQuery("#ddlNacionalidadeFuncionario").change(function () {
        jQuery("#ddlNacionalidadeFuncionario option:selected").text();
    });
    */
    
    //jQuery('input:checkbox').uniform();

    

   


});