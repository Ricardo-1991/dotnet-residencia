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
    
            if(idadeA > idadeB){
                (idadeA, idadeB) = (idadeB, idadeA);
            }
            var filteredListCliente = AddPeople.colecaoCliente.Where(cliente => DateTime.Now.Year - cliente.dataNascimento.Year >= idadeA && DateTime.Now.Year - cliente.dataNascimento.Year <= idadeB).ToList();
            foreach(var cliente in filteredListCliente){
                Console.WriteLine($"Nome: {cliente.nome} - Data de Nascimento: {cliente.dataNascimento}");
            }

            var filteredListAdvogado = AddPeople.colecaoAdvogado.Where(advogado => DateTime.Now.Year - advogado.dataNascimento.Year >= idadeA && DateTime.Now.Year - advogado.dataNascimento.Year <= idadeB).ToList();
            Console.WriteLine("Clientes");
            foreach(var cliente in filteredListCliente){
                Console.WriteLine($"Nome: {cliente.nome} - Data de Nascimento: {cliente.dataNascimento}");
            }

            Console.WriteLine("Advogados");
            foreach(var advogado in filteredListAdvogado){
                Console.WriteLine($"Nome: {advogado.nome} - Data de Nascimento: {advogado.dataNascimento}");
            }

            Console.WriteLine("Estado Civil de Clientes");
            string estadoCivil = "solteiro";
            var filteredListEstadoCivilCliente = AddPeople.colecaoCliente.Where(cliente => cliente.estadoCivil == estadoCivil.ToLower()).ToList();
            foreach(var cliente in filteredListEstadoCivilCliente){
                Console.WriteLine($"Nome: {cliente.nome} - Estado civil: {cliente.estadoCivil}");
            }
        }
    }
}