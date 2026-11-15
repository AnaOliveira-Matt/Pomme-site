function myFunction() {
    var element = document.body;
    element.classList.toggle("dark-mode");
 }

function mudarImagem() {
    let imagem = document.getElementById("imagens-tema");
    if (imagem.src.match("lua-icon.png")) {
        imagem.src = "sol-icon.png";
    } else {
        imagem.src = "lua-icon.png";
    }
    let logo = document.getElementById("Pomme_logo");
     if (logo.src.match("parceiros_pommeLogoModoEscuro.jpeg")) {
        logo.src = "parceiros_pommeLogo.jpeg";
    } else {
        logo.src = "parceiros_pommeLogoModoEscuro.jpeg";
    }
}

