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
    var codFuncionario = 

    return false;
}

function IncluirDependente() {

    jQuery.ajax({
        type: "GET",
        url: "../../Handler/ManutencaoFuncionario.ashx",
        data: {
            Metodo: 'CadastroFuncionario',
            Acao: 'Inclusao',
            NumeroOrdemMatricula: jQuery('#txtNumeroOrdemMatricula').val(),
            NumeroMatricula: jQuery('#txtNumeroMatricula').val(),
            NomeFuncionario: jQuery('#txtNomeFuncionario').val(),
            DataNascimento: jQuery('#txtDataNascimento').val(),
            NacionalidadeFuncionario: jQuery('#ddlNacionalidadeFuncionario option:selected').val(),
            EstadoCivil: jQuery('#ddlEstadoCivil  option:selected').val(),
            NomeConjuge: jQuery('#txtNomeConjuge').val(),
            QtdFilhos: jQuery('#txtQtdFilhos').val(),
            TipoEndereco: jQuery('#ddlTipoEndereco option:selected').val(),
            TipoLogradouro: jQuery('#ddlTipoLogradouro option:selected').val(),
            Logradouro: jQuery('#txtLogradouro').val(),
            NumeroEndereco: jQuery('#txtNumeroEndereco').val(),
            Bairro: jQuery('#txtBairro').val(),
            Complemento: jQuery('#txtComplemento').val(),
            CEP: jQuery('#txtCEP').val(),
            NomePai: jQuery('#txtNomePai').val(),
            NacionalidadePai: jQuery('#ddlNacionalidadePai option:selected').val(),
            NomeMae: jQuery('#txtNomeMae').val(),
            NacionalidadeMae: jQuery('#ddlNacionalidadeMae option:selected').val(),
            RG: jQuery('#txtRG').val(),
            CarteiraTrabalho: jQuery('#txtCarteiraTrabalho').val(),
            NumeroSerie: jQuery('#txtNumeroSerie').val(),
            NumeroCertificadoReservista: jQuery('#txtNumeroCertificadoReservista').val(),
            Categoria: jQuery('#txtCategoria').val(),
            CPF: jQuery('#txtCPF').val(),
            TituloEleitor: jQuery('#txtTituloEleitor').val(),
            CateiraSaude: jQuery('#txtCateiraSaude').val(),
            CBO: jQuery('#txtCBO').val(),
            Carteira19: jQuery('#txtCarteira19').val(),
            RegistroGeral: jQuery('#txtRegistroGeral').val(),
            CasadoBrasileiro: jQuery('input[@name=<%=rdbCasadoBrasileiro.ClientID%>]:radio:checked').val(),
            //CasadoBrasileiro: jQuery('input[name$:rdbCasadoBrasileiro]:checked').val(),
            //$("input[@name=<%=rdlMinor.ClientID%>]:radio:checked").val();
            Naturalizado: jQuery('input[@name=<%=rblNaturalizado.ClientID%>]:radio:checked').val(),
            //Naturalizado: jQuery('input[name$:rblNaturalizado]:checked').val(),
            FilhoBrasileiro: jQuery('input[@name=<%=rblFilhoBrasileiro.ClientID%>]:radio:checked').val(),
            //FilhoBrasileiro: jQuery('input[name$:rblFilhoBrasileiro]:checked').val(),
            DataChegadaBrasil: jQuery('#txtDataChegadaBrasil').val(),
            CadastroPIS: jQuery('#txtCadastroPIS').val(),
            SobNumero: jQuery('#txtSobNumero').val(),
            BancoPIS: jQuery('#txtBancoPIS').val(),
            Agencia: jQuery('#txtAgencia').val(),
            Digito: jQuery('#txtDigito').val(),
            TipoEnderecoPIS: jQuery('#ddlTipoEnderecoPIS').val(),
            TipoLogradouroPIS: jQuery('#ddlTipoLogradouroPIS').val(),
            LogradouroPIS: jQuery('#txtLogradouroPIS').val(),
            NumeroEnderecoPIS: jQuery('#txtNumeroEnderecoPIS').val(),
            BairroPIS: jQuery('#txtBairroPIS').val(),
            ComplementoPIS: jQuery('#txtComplementoPIS').val(),
            CEPPIS: jQuery('#txtCEPPIS').val(),
            OptanteFGTS: jQuery('#rdpOptanteFGTS').val(),
            DataOpcao: jQuery('#txtDataOpcao').val(),
            DataRetratacao: jQuery('#txtDataRetratacao').val(),
            BancoFGTS: jQuery('#txtBancoFGTS').val(),
            AgenciaFGTS: jQuery('#txtAgenciaFGTS').val(),
            DigitoFGTS: jQuery('#txtDigitoFGTS').val(),
            Cor: jQuery('#ddlCor').val(),
            Altura: jQuery('#txtAltura').val(),
            Peso: jQuery('#txtPeso').val(),
            Cabelo: jQuery('#ddlCabelo').val(),
            Olho: jQuery('#ddlOlho').val(),
            Sinais: jQuery('#txtSinais').val()
        },
        contentType: "json",
        cache: false,
        success: function (data) {
            alert(data);


            for (var i = 0; i < data.le; i++) {
                alert(data[i].FUNC_NOME_FUNCIONARIO)
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
        }
    });

}
