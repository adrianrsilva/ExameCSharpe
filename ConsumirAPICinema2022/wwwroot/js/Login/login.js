function entrar(param) {

    var url = 'https://localhost:44383/api/Login/autenticar';

    
   
    var dados = {
        Id: 0,
        Email: $('#txtUsuario').val(),
        Senha: $('#txtSenha').val(),
        Hash: param
    };

    console.log(dados);

    const formulario = document.querySelector("#validacaoformulario");
    formulario.onsubmit = evento => {
        //Receber valor do campo
        var email = document.querySelector("#txtUsuario").value;
        var senha = document.querySelector("#txtSenha").value;


        // verificar se o campo está vazio
        if (email == '' && senha == '') {
            evento.preventDefault();
            document.getElementById("msgAlerta").innerHTML = "<p style='color: #f00;'>Favor preencher e-mail!</p>";
            document.getElementById("msgAlertaSenha").innerHTML = "<p style='color: #f00;'>Favor preencher senha!</p>";
            return;
        } else if (senha == '') {
            evento.preventDefault();
            document.getElementById("msgAlertaSenha").innerHTML = "<p style='color: #f00;'>Favor preencher senha!</p>";
            document.getElementById("msgAlerta").innerHTML = "<p style='color: #f00;'></p>";
            return;
        } else if (email == '') {
            evento.preventDefault();
            document.getElementById("msgAlerta").innerHTML = "<p style='color: #f00;'>Favor preencher e-mail!</p>";
            document.getElementById("msgAlertaSenha").innerHTML = "<p style='color: #f00;'></p>";
            return;
        } else {
            document.getElementById("msgAlertaSenha").innerHTML = "<p style='color: #f00;'></p>";
            document.getElementById("msgAlerta").innerHTML = "<p style='color: #f00;'></p>";
            return;
        };

        evento.preventDefault();
    }

    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(dados),
        success: function (jsonResult) {
           

            if (jsonResult.status) {

                sessionStorage.setItem("token", jsonResult.token);
                sessionStorage.setItem("seguranca", param);
                if (param == 'f013197e-9e2e-4ec7-8c89-4763d6a50e1e') {
                    sessionStorage.setItem("IdCliente", jsonResult.idCliente);
                    window.location.href = jsonResult.caminho;
                } else {
                    sessionStorage.setItem("IdFuncionario", jsonResult.IdFuncionario);
                    window.location.href = jsonResult.caminho;
                }
                

            }
            else {

                alert("Ops: " + jsonResult.mensagem);

            }

        },
        failure: function (response) {
            
        }
    });

}

