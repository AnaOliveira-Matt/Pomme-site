function myFunction() {
    var element = document.body;
    element.classList.toggle("dark-mode");
 }

 function mascara_telefone() { 
    var tel = document.getElementById("telefone").value;
    tel = tel.replace(/\D/g, "");
    if (tel.length > 0) tel = "(" + tel;
    if (tel.length > 3) tel = tel.slice(0, 3) + ")" + tel.slice(3);
    if (tel.length > 9) tel = tel.slice(0, 9) + "-" + tel.slice(9, 13);
     document.getElementById("telefone").value = tel
     }

function mudarImagem() {
    let imagem = document.getElementById("imagens-tema");
    if (imagem.src.match("lua-icon.png")) {
        imagem.src = "sol-icon.png";
    } else {
        imagem.src = "lua-icon.png";
    }}


