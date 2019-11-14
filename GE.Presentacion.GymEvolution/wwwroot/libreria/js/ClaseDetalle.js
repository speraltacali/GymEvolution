class ClaseDetalle {
    AgregarClaseDetalle() {
        $post(
            "Create" , serialize(),
            (response) => {
                console.log(response);
            }
        )
    }
}