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
            var filteredListValues = AddPeople.colecaoCliente.Select(cliente => cliente.dataNascimento);
            
            /* foreach(var product in filteredListValues){
                Console.WriteLine(divLine);
                Console.WriteLine($"Nome: {product.name}\nPreço: R${product.price}\nQuantidade: {product.amount}\nCódigo: {product.code}");
                Console.WriteLine(divLine);
            } */
        }
    }
}