# APP - lista-tarefas-react-js  🔥
App para gravar lista de tarefas.

# Ferramentas 💛

* Javascript
* React
* C# .Net Core

# Arquitetura 🔎

* DDD
* CQRS
* Event Driven

# Bibliotecas 🔔

* ```npm i react-beautiful-dnd @emotion/styled @emotion/react uuid```
* Entity Framework
* FluentValidation
* Masstransit
* MediatR
* RabbitMQ
* Redis

# TODO 👷 

- [x] Criar App Lista de tarefas
- [x] Criar API .Net
- [x] Configurar e implementar comandos iniciais / preparar CQRS
- [x] Implementar service bus
- [x] Configurar RabbitMQ
- [ ] Consumir api no App
- [ ] Dockerizar aplicações
- [ ] Configurar cache com Redis

# Tela 💥

![image](https://user-images.githubusercontent.com/8622005/148626750-3b641e8f-fa3c-48fe-95b1-7f85bc428bad.png)


# Como rodar ? 😱

```npm install ```
```npm start```

# Exemplo de mensagem que cai no RabbitMQ 👀

```
{

  "messageId": "a46a0000-66cc-d094-225a-08d9d4995ff6",

  "conversationId": "a46a0000-66cc-d094-d120-08d9d4995ffa",

  "sourceAddress": "rabbitmq://localhost:0/ListaTarefasAPI_bus_wtiyyydg3uejephebdc7jgkzy5",

  "destinationAddress": "rabbitmq://localhost:0/ListaTarefas.Application.Contracts:ICadastroSolicitado",

  "messageType": [

    "urn:message:ListaTarefas.Application.Contracts:ICadastroSolicitado"

  ],

  "message": {

    "descricao": "string",

    "timestamp": "2022-01-10T21:29:02.8899306-03:00",

    "messageType": "CadastroSolicitadoEvent"

  },

  "sentTime": "2022-01-11T00:29:05.468681Z",

  "headers": {

    "MT-Activity-Id": "00-56347590d7a78dfdbe30b6eb9043e322-06bec07666a208e7-00"

  },

  "host": {

    "machineName": "PC",

    "processName": "ListaTarefas.API",

    "processId": 15952,

    "assembly": "ListaTarefas.API",

    "assemblyVersion": "1.0.0.0",

    "frameworkVersion": "6.0.1",

    "massTransitVersion": "7.3.0.0",

    "operatingSystemVersion": "Microsoft Windows NT 10"

  }

}
```
