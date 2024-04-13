# DIO - Trilha .NET - Fundamentos
www.dio.me

## DISCLAIMER: Ao final desse README existe uma implementação na branch **v2** na qual há uma evolução implementada para este desafio. A versão na branch master é a básica para esse desafio.

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar

## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.

## Solução básica - **Branch Main** e **Branch Release/v1**
O Código foi alterado e foram criadas as Classes **Menu** , **EstacionamentoController** para separar o Menu da Classe Estacionamento que foi convertida em uma Classe Rica sem comportamentos de Menu para poder respeitar a Separação em Responsabilidades.
Também foi criada uma Classe **Veiculo** - que na versão 1 só tem uma propriedade chamada **Placa** para poder eliminar ao máximo os tipos primitivos, evitando assim a Primitive Obsessions.
Foram feitas intervenções pequenas no código apenas para poder resolver os **TODOs** presentes na Classe, mas a versão 2 está mais completa e foi adicionado um Mapa do Estacionamento.

## **Solução com Evolução (Incluindo Mapa do Estacionamento e onde está cada veículo) - Branch Release/v2**
Nessa versão, inseri a funcionalidade de Mapa de Estacionamento, no qual podemos cadastrar um Estacionamento fictício seguindo uma norma do WMS de Ruas (linhas) e Apartamentos (colunas), onde criamos uma estrutura matricial de Ruas, Andares e números de vaga e trabalhamos com posicionamento, no qual convertemos em coordenadas, por exemplo: Andar 1, Vaga 3 = A3.
Assim, geramos um Mapa do Estacionamento e vemos as vagas livres e as vagas ocupadas através da Placa do Veículo.
No momento do Estacionamento, podemos permitir que o Sistema sorteie aonde foi o carro ou podemos escolher em qual local o veículo pode estacionar mostrando no Mapa onde está livre ou ocupado dependendo do Andar da escolha ou visualizar todo o Mapa de Estacionamento.
