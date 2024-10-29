# OrderAI

## Sumário
- [Integrantes;](#integrantes)
- [Arquitetura da API;](#arquitetura-da-api)
- [Instruções para uso da aplicação;](#instruções-para-uso-da-aplicação)
- [Observações importantes.](#observações-importantes)

## Integrantes
- Gabriel Augusto Fernandes - RM98986

- Kauê Fernandes Braz - RM97768

- Mariana Trentino Albano - RM551154

- Matheus Dantas de Sousa - RM98406

- Thomas Nícolas de Melo Mendonça - RM99832

## Arquitetura da API: Monolítica vs Microserviços

### Monolítica vs Microserviços

- **Arquitetura Monolítica**: Em um sistema monolítico, todas as funcionalidades da aplicação são integradas em um único código base. Isso significa que as diferentes partes, como a lógica de negócios, a interface do usuário e a camada de acesso a dados, estão todas no mesmo projeto, executadas como uma única unidade.

- **Arquitetura de Microserviços**: Essa abordagem divide a aplicação em vários serviços menores e independentes que se comunicam entre si. Cada microserviço é responsável por uma funcionalidade específica e pode ser desenvolvido, implantado e escalado de forma independente.

---

### Definição de arquitetura

Optamos pela arquitetura monolítica por alguns motivos-chave, considerando o estágio atual do projeto e as necessidades específicas da aplicação:

1. **Simplicidade no Desenvolvimento**: 
   - A arquitetura monolítica é mais simples de desenvolver e gerenciar no início de um projeto. Com tudo em um único código base, o time pode focar em entregar funcionalidades rapidamente sem a complexidade de orquestrar múltiplos serviços.

2. **Facilidade de Implantação**: 
   - Com um monólito, há apenas uma aplicação para ser implantada e mantida, simplificando o processo de deployment. Isso é ideal quando a infraestrutura da aplicação ainda é pequena e não exige soluções complexas.

3. **Custo Inicial Menor**: 
   - Arquiteturas de microserviços podem ser mais caras em termos de infraestrutura, já que cada serviço pode exigir sua própria infraestrutura de execução, como contêineres ou máquinas virtuais.

---

### Tecnologias utilizadas
- **`Linguagem de Programação`**: C#;
- **`Framework`**: .NET Core 8.0;
- **`Banco de Dados`**: Oracle Database;
- **`Design Pattern`**: Repository Pattern;

## Instruções para Uso da Aplicação

### Inicialização da Aplicação
- Para iniciar a aplicação, selecione a configuração **`https`** e execute o projeto. Isso pode ser feito diretamente no Visual Studio (Ambiente de Desenvolvimento Integrado).

### Realização de Requisições
- Após iniciar a aplicação, a documentação da API será aberta automaticamente no seu navegador padrão.
- Na página da documentação, você poderá visualizar todos os endpoints disponíveis e suas descrições.
- Para testar uma requisição, clique no endpoint desejado e, em seguida, no botão **`Try it out`**.
- Complete os campos necessários para a requisição e clique em **`Execute`** para enviar a solicitação e ver a resposta da API.
