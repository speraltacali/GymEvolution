
class Cliente {

    AgregarCliente() {
        $.post(
            "Create" ,
            $('.formCliente').serialize(),
            (response) => {

                try {
                    var item = JSON.parse(reponse);
                    if (item.code == "Done") {
                        window.location.href = "Index";
                    } else {
                        document.getElementById("mensaje").innerHTML = item.Description;
                    }
                } catch (e) {
                    document.getElementById("mensaje").innerHTML = reponse;
                } 

                console.log(response);
            }
        );
    }
}

function postCreateAjax(action) {
    $.ajax({
        type = "POST",
        url = action,
        sucess: function(repose) {
            console.log(repose);
        }
    });
}
