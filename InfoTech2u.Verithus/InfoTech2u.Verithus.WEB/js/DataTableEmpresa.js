jQuery(document).ready(function () {
    jQuery('#example').dataTable({
        'sPaginationType': 'full_numbers',
        'bProcessing': true,
        'bServerSide': true,
        'sAjaxSource': '../../Handler/DataTablesHandlerGeneric.ashx',
        "columns": [
            { "aaData": "Id" },
            { "aaData": "NomeEmpresa" },
            { "aaData": "documentoCNPJ" }
        ]
    });
});