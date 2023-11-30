using Veiculo = VeiculoNamespace.Veiculo;


Veiculo novoVeiculo = new Veiculo();

novoVeiculo.Modelo = "Civic";
novoVeiculo.Cor = "Azul";
novoVeiculo.Ano = 2020;


Console.WriteLine($"Modelo: {novoVeiculo.Modelo}");
Console.WriteLine($"Cor: {novoVeiculo.Cor}");
Console.WriteLine($"Ano: {novoVeiculo.Ano}");

Console.WriteLine($"Idade do carro: {novoVeiculo.IdadeVeiculo}");