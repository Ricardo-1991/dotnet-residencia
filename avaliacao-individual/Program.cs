using Advogado = Personas.Advogado;
using Cliente = Personas.Cliente;

Advogado advogado1 = new Advogado("Dorea", new DateTime(1989, 7, 24));
Advogado advogado2 = new Advogado("Alexandre", new DateTime(2000, 8, 30));
Advogado advogado3 = new Advogado("Paulo Ricardo", new DateTime(1991, 3, 11));
Cliente cliente1 = new Cliente("Rafaela", new DateTime(1991, 4, 11), "Solteiro", "Programador");
Cliente cliente2 = new Cliente("Rubens", new DateTime(1992, 8, 22), "Casado", "Engenheiro");
Cliente cliente3 = new Cliente("Ana", new DateTime(1997, 5, 23), "Solteiro", "Matemático");

advogado1.Cna = "852";
advogado2.Cna = "741";
advogado3.Cna = "321";

advogado1.Cpf = "8523697415";
advogado2.Cpf = "7663719272";
advogado3.Cpf = "6565738291";

cliente1.Cpf = "4545626271";
cliente2.Cpf = "8787969409";
cliente3.Cpf = "6553427593";




