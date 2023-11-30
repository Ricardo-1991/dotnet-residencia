using Advogado = Personas.Advogado;
using Cliente = Personas.Cliente;
using ListAndReports = Reports.ListAndReports;
using addPeople = namespaceAddPeople.AddPeople;


Advogado advogado1 = new Advogado("Dorea", new DateTime(1989, 7, 24));
Advogado advogado2 = new Advogado("Alexandre", new DateTime(2000, 8, 30));
Advogado advogado3 = new Advogado("Paulo Ricardo", new DateTime(1991, 3, 11));
Cliente cliente1 = new Cliente("Rafaela", new DateTime(1991, 4, 11), "solteiro", "Programador");
Cliente cliente2 = new Cliente("Rubens", new DateTime(1992, 8, 22), "casado", "Engenheiro");
Cliente cliente3 = new Cliente("Ana", new DateTime(1997, 5, 23), "solteiro", "Matemático");

advogado1.Cna = "852";
advogado2.Cna = "741";
advogado3.Cna = "321";

advogado1.Cpf = "18523697415";
advogado2.Cpf = "76637192725";
advogado3.Cpf = "96565738291";

cliente1.Cpf = "24545626271";
cliente2.Cpf = "24545626271";
cliente3.Cpf = "65534275934";

addPeople.addCliente(cliente1);
addPeople.addCliente(cliente2);
addPeople.addCliente(cliente3);


ListAndReports.reports();