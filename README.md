# Pomme-site
Site a ser entregue para o trabalho interdisciplinar, desenvolvido com HTML, CSS, JS e uma API feita com ASP.NET Core

### Organização
Há uma pasta contendo o código c#, dentro dela está o slnx e outra pasta que contem o resto do código.<br>
Optamos por manter as imagens fora de uma pasta designada para ajudar com a edição do site já que construímos os sites em máquinas pessoais e achamos que assim seria mais fácil.

### Tecnologias usadas
- HTML
- CSS
- JS
- ASP.NET Core

### Atenção com o uso
- A verificação e troca de dados só ocorre com o Delivery_Carol rolando em 2° plano, caso ainda aja falhas verifique no inicio dos arquivos .js se a API está usando a porta desejada ( colocamos `"https://localhost:3006"` , mude conforme sua necessidade).
- Caso apareça um aviso de certificado rode `dotnet dev-certs https --trust` uma vez.
