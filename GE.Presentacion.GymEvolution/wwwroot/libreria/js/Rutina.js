class Rutina {
    AgregarRutina() {
        $.post(
            "Create",
            $('.formRutina').serialize(),
            (response) => {
                console.log(response);
            });
    }
}