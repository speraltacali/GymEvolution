
class Cliente {

    AgregarCliente() {
        $.post(
            "Create" ,
            $('.formCliente').serialize(),
            (response) => {
                console.log(response);
            }
        );
    }
}
