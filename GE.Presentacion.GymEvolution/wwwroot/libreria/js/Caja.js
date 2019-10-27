class AperturaCaja{
    AbrirCaja() {
        $post(
            "Abrir",
            $('.formCaja').serialize(),
            (response) => {
                console.log(response);
            }
        );
    }
}