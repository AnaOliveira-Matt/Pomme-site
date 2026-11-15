// Endereço da API em C# 
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
    
// Arredonda para 2 casas o valor 
function arredondar(valor) {
    return Math.round(valor * 100) / 100;
}

async function gerarJSONPedido() {
    const nomeCliente = document.getElementById("nomeCliente").value.trim();
    if (!nomeCliente) {
        alert("Por favor, digite o nome do cliente.");
        return;
    }

    const elementosPedido = document.querySelectorAll(".pedido");
    const itens = [];
    let valorTotal = 0;

    elementosPedido.forEach(el => {
        const produto = el.getAttribute("data-produto");
        const precoUnitario = arredondar(parseFloat(el.getAttribute("data-preco")));
        const quantidade = parseInt(el.querySelector(".qtd").value) || 0;

        if (quantidade > 0) {
            const subtotal = arredondar(quantidade * precoUnitario);
            valorTotal = arredondar(valorTotal + subtotal);

            itens.push({
                produto: produto,
                quantidade: quantidade,
                preco_unitario: precoUnitario,
                subtotal: subtotal
            });
        }
    });

    if (itens.length === 0) {
        alert("Selecione pelo menos um produto.");
        return;
    }

    const agora = new Date();
    const dataFormatada = agora.getFullYear() + "-" +
        String(agora.getMonth() + 1).padStart(2, '0') + "-" +
        String(agora.getDate()).padStart(2, '0') + " " +
        String(agora.getHours()).padStart(2, '0') + ":" +
        String(agora.getMinutes()).padStart(2, '0') + ":" +
        String(agora.getSeconds()).padStart(2, '0');

    const pedidos = [{
        id_pedido: 0,
        cliente: nomeCliente,
        data_pedido: dataFormatada,
        valor_total: valorTotal,
        status: "Recebido",
        itens: itens
    }];

    try {
        // Envia o JSON direto pro C# por HTTPS (no lugar de baixar o pedidos.json)
        const resposta = await fetch(`${API_URL}/api/pedidos`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(pedidos)
        });

        const resultado = await resposta.json();

        if (resposta.ok && resultado.sucesso) {
            alert(resultado.mensagem || "Pedido enviado com sucesso!");
        } else {
            alert(resultado.mensagem || "Não foi possível enviar o pedido.");
        }
    } catch (erro) {
        console.error("Erro ao conectar com o C#:", erro);
        alert("Não foi possível conectar ao servidor C#. Verifique se o programa Delivery_Carol está aberto.");
    }
}
