/* Exercício 1: Tuplas
Crie uma função que recebe um nome e uma idade como parâmetros e retorna uma tupla contendo o nome e a idade. Em
seguida, chame a função com diferentes valores e exiba os resultados. */

(string, int) tupleFunction(string nome, int idade){
    return (nome, idade);
}

var resultTuple = tupleFunction("Paulo", 32);

Console.WriteLine(resultTuple);


/* Exercício 2: Expressões Lambda
Defina uma expressão lambda que recebe dois números como parâmetros e retorna a soma dos quadrados desses números. Em
seguida, chame a expressão lambda com alguns valores diferentes e exiba os resultados */

Func<int, int, int> squareSum = (num1, num2) => (num1 * num1) + (num2 * num2);
int resultSquareSum = squareSum(3, 4);

Console.WriteLine(resultSquareSum);


/* Exercício 3: LINQ com Lista
Crie uma lista de objetos simples, por exemplo, representando pessoas com propriedades como "Nome" e "Idade". Em seguida,
use LINQ para filtrar a lista e obter todas as pessoas com idade superior a 30. */

List<(string nome, int idade)> personList = new List<(string nome, int idade)>{
    (nome: "Paulo", idade: 30),
    (nome: "Ricardo", idade: 32),
    (nome: "Santos", idade: 29),
    (nome: "Nascimento", idade: 35),
};

var filteredList = personList.Where(person => person.idade > 30);

foreach(var person in filteredList){
    Console.WriteLine(person.nome);
}

/* Exercício 4: LINQ com Array
Crie um array de números inteiros. Use LINQ para selecionar apenas os números pares e ordene-os de forma decrescente. */

int[] numbers = {1,3,2,5,4,6,7,9,8,10};

var onlyPair = numbers.Where(number => number % 2 == 0).OrderBy(x => x);

foreach(var pairNumbers in onlyPair){
    Console.Write($"{pairNumbers} ");
}