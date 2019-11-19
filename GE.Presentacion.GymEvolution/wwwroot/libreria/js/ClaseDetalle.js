
class ClaseDetalle {

    AgregarClaseDetalle() {
        $.post(
            "Create",
            $('.formDetalle').serialize(),
            (response) => {
                console.log(response);
            }
        );
    }
}