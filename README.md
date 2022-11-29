# Web API Curso de idiomas
.NET 7 | Clean architecture 
# Relacionamento das entidades
A Relação entre a classe Aluno e a classe Turma é de n pra n</br>
A classe Matricula faz a intermediação entre estas duas classes</br>

Em Aluno é possível ver as Turmas em que ele participa e assim consequentemente em Turma se vê os Alunos participantes dela

# Regras de negócio
Aluno Service é o responsável pelo CRUD de Aluno e por adcioná-lo a uma turma no momento de sua criação</br>

Turma Service apenas faz o CRUD de Turma, sem a responsabilidade de cadastrar os alunos</br>

Matricula Service é a classe que é responsável pelo cadastro dos alunos nas Turmas disponíveis</br>

## Todas as validações das regras de negócio foi feita com Fluent Validation
## Foi implementado Filtros para tratamento de exceptions e pesquisa por parâmetros  
## Mapping com Auto Mapper, DTOS
## Repository Pattern
## DDD
## EF Core
## Fluent API
## SQL Server
