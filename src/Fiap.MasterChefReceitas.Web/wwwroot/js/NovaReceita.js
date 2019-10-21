//requide('./Utils.js');

// util
//Compose template string
String.prototype.compose = (function () {
    var re = /\{{(.+?)\}}/g;
    return function (o) {
        return this.replace(re, function (_, k) {
            return typeof o[k] != 'undefined' ? o[k] : '';
        });
    }
}());


function AddIngrediente(){
    var nome = $("#txtNomeIngrediente").val();
    var qtd = $("#txtQuantidadeIngrediente").val();

    //obtem texto
    var ingredientesTexto = $('#IngredientesTexto').val();

    //cria array
    var array = [];

    // se existir texto transforma em array
    if (ingredientesTexto != undefined && ingredientesTexto != "") {
        array = ingredientesTexto.split("|");
        ingredientesTexto = "";
    }

    // add elemento
    var elem = array.length;
    var novoItem = nome + "," + qtd;
    
    array.push(novoItem);
    console.log("teste");
    console.log(array);

    //volta para string
    for (index in array) {
        var value = array[index];
        if (ingredientesTexto.length > 0) {
            value = "|" + value;
        }
        ingredientesTexto += value;
    }
    $('#IngredientesTexto').val(ingredientesTexto);

    AddIngredientesTabela(nome, qtd)

    $("#txtNomeIngrediente").val('');
    $("#txtQuantidadeIngrediente").val('')

}

function AddIngredientesTabela(nome, qtd) {
    var row = "<tr><td>{{nome}}</td><td>{{qtd}}</td></tr>";
    var tbody = $('#tblIngredientes').children('tbody');
    var table = tbody.length ? tbody : $('#tblIngredientes');

    table.append(row.compose({
        'nome': nome,
        'qtd': qtd
    }));
}

//function ObtemTabelaIngredientes(tab) {
//        var json = '[';
//        var otArr = [];
//        var tbody = $('#' + tab).children('tbody');
//        var table = tbody.length ? tbody : $('#' + tab);
            
//        //var tbl2 = $('#' + table + ' tboby tr').each(function (i) {
//        var tbl2 = table.find('tr').each(function (i) {
//            x = $(this).children();
//            var itArr = [];
//            x.each(function () {
//                itArr.push('"' + $(this).text() + '"');
//                //console.log($(this).text());
//            });
//            //otArr.push('"' + i + '": [' + itArr.join(',') + ']');
//            otArr.push('{' + itArr.join(':') + '}');
//        })
//        json += otArr.join(",") + ']'

//    console.log(json);

//    return json;
//}

//function teste() {
//        var rows = [];

//        var tbody = $('#tblIngredientes').children('tbody');
//        var table = tbody.length ? tbody : $('#' + tab);

//        table.find('tr').each(function (i, n) {
//            var $row = $(n);
//            rows.push({
//                NomeIngrediente: $row.find('td:eq(0)').text(),
//                Quantidade: $row.find('td:eq(1)').text()
//            });
//        });
//        console.log("TESTE");
//        console.log(JSON.stringify(rows));
//        return JSON.stringify(rows);
//    };

//function SalvaReceita(form) {  

//    var token = $('input[name="__RequestVerificationToken"]').val();
//    var tokenadr = $('form[action="/Receita/Novo"] input[name="__RequestVerificationToken"]').val();
//    var headers = {};
//    var headersadr = {};
//    headers['__RequestVerificationToken'] = token;
//    headersadr['__RequestVerificationToken'] = tokenadr;

//    //Gravar
//    var url = "/Receita/Novo";

//    console.log($('#' + form).serializeArray());

//    $.ajax({
//        url: url
//        , type: "POST"
//        , datatype: "json"
//        , headers: headersadr
//        , data: dataIngredientes
//        , success: function (data) {
//            if (data.Resultado > 0) {
//                alert(data.Resultado);
//            }
//        }
//    });
//}