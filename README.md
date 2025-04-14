# safe-travel

A safe-travel é uma API voltada para a locação de veículos, desenvolvida para oferecer uma gestão segura e eficiente no processo de locação.

## Descrição

A API safe-travel possibilita:

- Gerenciar cadastros de veículos e locatários.
- Efetuar locações e devoluções.
- Consultar status e disponibilidade dos veículos.

## Requisitos

- Docker
- Docker Compose

## Inicializando com Docker Compose

O arquivo de configuração do Docker Compose encontra-se na pasta API. Para inicializar os containers, siga os passos abaixo:

1. Navegue até a pasta API:

```bash
cd API
```

2. Inicialize os containers:

```bash
docker-compose up -d
```

## Parando os Containers

Para parar e remover os containers, execute:

```bash
docker-compose down
```

## Estrutura do Projeto

- **API/**  
  Contém o arquivo `docker-compose.yml` e demais configurações relacionadas à API.

- Outros diretórios e arquivos do projeto conforme a necessidade.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests com melhorias e correções.
