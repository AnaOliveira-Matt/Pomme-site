// Endereço da API em C# (
const API_URL = "https://localhost:3006";

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
    }}


                function alerta(){
            alert("Login confirmado!");
        }

        // Tem de conectar com o FrmlOGIN 

        async function realizarLogin(event) {
             event.preventDefault();
              // Captura os dados dos campos id="nome" (ou email) e id="senha" do HTML 
               const credenciais = {
                 Email: document.getElementById("nome").value.trim(), // ou id="email" 
                 Senha: document.getElementById("senha").value.trim() }; 

             try {
               const resposta = await fetch(`${API_URL}/api/login`, {
                 method: "POST", 
                 headers: { 
                    "Content-Type": "application/json" 
                    }, 
                    body: JSON.stringify(credenciais) }); 

                    const resultado = await resposta.json(); 

                    if (resposta.ok && resultado.sucesso) { 
                        alert("Login realizado com sucesso!"); 
                        window.location.href = "usuario.html"; 
                        // Redireciona para a página do usuário 
                        } 
                    else { 
                        alert(resultado.mensagem || "Credenciais inválidas."); 
                    } 
                } catch (erro) { 
                    console.error("Erro ao conectar com o C#:", erro); 
                    alert("Não foi possível conectar ao servidor de autenticação C#."); 
                    } }