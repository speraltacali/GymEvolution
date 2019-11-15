class Clase {
    AgregarClase() {
        $post.(
            "Create" ,
            $('.formClase').serialize(),
            (response) => {
                console.log(response);
            }
        )
    }
}