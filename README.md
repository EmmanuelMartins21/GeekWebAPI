# GeekWebApi

A GeekWebApi é uma API que oferece diversos métodos GET para acessar informações sobre Animes, Filmes, Livros e Séries Geek. Esta API está sendo desenvolvida para fornecer dados detalhados e relevantes sobre os títulos mais populares e amados pelos fãs da cultura Geek.

## Endpoints

A seguir, estão listados os endpoints disponíveis na API, juntamente com as informações que eles fornecem:

### 1. Animes

#### Endpoint: `/animes`

Este endpoint retorna uma lista de Animes Geek, incluindo detalhes como título, gênero, data de lançamento e número de temporadas.

#### Exemplo de resposta:

```json
{
  "animes": [
    {
      "nome": "Attack on Titan",
      "genero": "Ação, Drama, Fantasia",
      "dataLancamento": "2013-04-07T00:00:00Z",
      "temporadas": 4
    }
  ]
}
```

### 2. Filmes

#### Endpoint: `/filmes`

Este endpoint retorna uma lista de Filmes Geek, contendo detalhes sobre cada um, como título, empresa, data de lançamento e duração em minutos.

#### Exemplo de resposta:

```json
{
  "filmes": [
    {
      "nome": "The Batman",
      "empresa": "Warner Bros. Pictures",
      "dataLancamento": "2022-03-04T00:00:00",
      "duracaoMinutos": 149
    }
  ]
}
```

### 3. Livros

#### Endpoint: `/livros`

Este endpoint retorna uma lista de Livros Geek, incluindo detalhes como título, gênero, editora, data de lançamento e número de páginas.

#### Exemplo de resposta:

```json
{
  "livros": [
    {
      "nome": "Duna",
      "genero": "Ficção Científica",
      "editora": "Editora Aleph",
      "dataLancamento": "1965-08-01T00:00:00",
      "paginas": 896
    }
  ]
}
```

### 4. Séries

#### Endpoint: `/series`

Este endpoint retorna uma lista de Séries Geek, contendo informações como título, empresa, gênero, data de lançamento e duração em minutos.

#### Exemplo de resposta:

```json
{
  "series": [
    {
      "nome": "Stranger Things",
      "empresa": "Netflix",
      "genero": "Ficção Científica, Horror",
      "dataLancamento": "2016-07-15T00:00:00",
      "duracaoMinutos": 50
    }
  ]
}
```

## Como usar a API

Para utilizar a GeekWebApi, basta fazer uma requisição GET para o endpoint desejado. A resposta será retornada em formato JSON, contendo os dados requisitados sobre Animes, Filmes, Livros ou Séries Geek.

### Exemplo de requisição utilizando cURL:

```bash
curl -X GET https://geekwebapi.com/animes
```

## Considerações Finais

A GeekWebApi foi criada com o objetivo de fornecer informações relevantes sobre Animes, Filmes, Livros e Séries Geek para entusiastas da cultura nerd. É importante mencionar que esta API é apenas para fins educacionais e não possui nenhum vínculo oficial com as obras mencionadas.

Esperamos que você aproveite o uso da GeekWebApi e que ela contribua para o seu conhecimento e diversão no mundo Geek! Caso tenha alguma sugestão ou encontre algum problema, sinta-se à vontade para abrir um problema no repositório oficial no GitHub.

Divirta-se explorando o universo Geek através da GeekWebApi! 🚀

---
## CONTATOS
[![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-0072b1?style=for-the-badge&logo=Linkedin&logoColor=white)](https://www.linkedin.com/in/emmanuel-cosme-martins-bento-3963bb1b9/ 'Contato pelo LinkedIn')
[![Gmail Badge](https://img.shields.io/badge/-gmail-c14438?style=for-the-badge&logo=Gmail&logoColor=white)](mailto:emmanuelbento6@gmail.com 'Contato via Email')
