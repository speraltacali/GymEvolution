class Session {
    CerrarSession() {
        $get(
            "Login",
            $('.formCerrar').serialize(),
            (response) => {
                console.log(response);
            }
        );
    }
}