class PagoCuota {
    FacturaPago() {
        $post(
            "PagoFactura",
            $('.formPago').serialize(),
            (response) => {
                console.log(response);
            }
        );
    }
    
}