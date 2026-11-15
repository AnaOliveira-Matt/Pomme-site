// Endereço da API em C# 
const API_URL = "https://localhost:3006";

function mascara_telefone() { 
    var tel = document.getElementById("telefone").value;
    tel = tel.replace(/\D/g, "");
    if (tel.length > 0) tel = "(" + tel;
    if (tel.length > 3) tel = tel.slice(0, 3) + ")" + tel.slice(3);
    if (tel.length > 9) tel = tel.slice(0, 9) + "-" + tel.slice(8, 13);
     document.getElementById("telefone").value = tel
     }
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

// O nome da função agora é o mesmo que o cadastro.html chama no onsubmit (enviarJSONCliente)
async function enviarJSONCliente(event) {
    event.preventDefault();//Não deixa a página recarregar depois de mandar o arquivo

    //Pega os valores escritos e cria uma lista para o objeto no formato do negocio do C#
    const clientes = [{
        Nome: document.getElementById("nome").value.trim(),
        Telefone: document.getElementById("telefone").value.trim(),
        Email: document.getElementById("email").value.trim(),
        Endereco: document.getElementById("endereco").value.trim(),
        Senha: document.getElementById("senha").value.trim()
    }]; 

    try {
        //Envia o JSON direto pro C# por HTTPS (sem baixar arquivo e sem importar na mão)
        const resposta = await fetch(`${API_URL}/api/clientes`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(clientes)
        });

        const resultado = await resposta.json();

        if (resposta.ok && resultado.sucesso) {
            alert(resultado.mensagem || "Cadastro realizado com sucesso!");
            document.getElementById("formCadastro").reset();
        } else {
            alert(resultado.mensagem || "Não foi possível realizar o cadastro.");
        }
    } catch (erro) {
        console.error("Erro ao conectar com o C#:", erro);
        alert("Não foi possível conectar ao servidor C#. Verifique se o programa Delivery_Carol está aberto.");
    }
}


    //Na teoria não precisa mais importar o arquivo no C# manualmente
