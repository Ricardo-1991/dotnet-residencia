using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddPeople = namespaceAddPeople.AddPeople;

namespace Reports
{
    public static class ListAndReports {
        public static void reports(){
            Console.WriteLine("Relatórios");
            int idadeA = 20, idadeB = 30;
    
            if(idadeA < idadeB){
                (idadeA, idadeB) = (idadeB, idadeA);
            }
            var filteredListCliente = AddPeople.colecaoCliente.Where(cliente => DateTime.Now.Year - cliente.dataNascimento.Year >= idadeA && DateTime.Now.Year - cliente.dataNascimento.Year <= idadeB);
            foreach(var cliente in filteredListCliente){
                Console.WriteLine($"Nome: {cliente.nome} - Data de Nascimento: {cliente.dataNascimento}");
            }

            var filteredListAdvogado = AddPeople.colecaoAdvogado.Where(advogado => DateTime.Now.Year - advogado.dataNascimento.Year >= idadeA && DateTime.Now.Year - advogado.dataNascimento.Year <= idadeB);
            Console.WriteLine("Clientes");
            foreach(var cliente in filteredListCliente){
                Console.WriteLine($"Nome: {cliente.nome} - Data de Nascimento: {cliente.dataNascimento}");
            }

            Console.WriteLine("Advogados");
            foreach(var advogado in filteredListAdvogado){
                Console.WriteLine($"Nome: {advogado.nome} - Data de Nascimento: {advogado.dataNascimento}");
            }

            Console.WriteLine("Estado Civil de CLientes");
            string estadoCivil = "Solteiro";

            var filteredListEstadoCivilCliente = AddPeople.colecaoCliente.Where(advogado => advogado.estadoCivil == estadoCivil.ToLower());
            foreach(var cliente in filteredListEstadoCivilCliente){
                Console.WriteLine($"Nome: {cliente.nome} - Data de Nascimento: {cliente.dataNascimento}");
            }
        }

        public static int CalculateAge(DateTime dataNascimento)
{
    int idade = DateTime.Now.Year - dataNascimento.Year;

    // Ajuste se a data de nascimento ainda não ocorreu este ano
    if (DateTime.Now < dataNascimento.AddYears(idade))
    {
        idade--;
    }

    return idade;
}
    }
}