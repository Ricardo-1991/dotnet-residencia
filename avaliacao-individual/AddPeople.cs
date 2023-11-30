using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliente = Personas.Cliente;
using Advogado = Personas.Advogado;

namespace namespaceAddPeople
{
    public static class AddPeople{
        public static List<Cliente> colecaoCliente = new();
        public static List<Advogado> colecaoAdvogado = new();

         public static void addCliente(Cliente _cliente){
            bool isUniqueCpf = colecaoCliente.Any(x => x.Cpf == _cliente.Cpf);
            if(isUniqueCpf){
            Console.WriteLine("Já há um cliente com este CPF no sistema");
            }else{
                colecaoCliente.Add(_cliente);
            }
        }  
        
         public static void addAdvogado(Advogado _advogado){
            bool isUniqueCpf = colecaoCliente.Any(x => x.Cpf == _advogado.Cpf);
            bool isUniqueCNA = colecaoAdvogado.Any(x => x.Cna == _advogado.Cpf);
            if(isUniqueCpf){
                Console.WriteLine("Já há um cliente com este CPF no sistema");
            }else{
                colecaoAdvogado.Add(_advogado);
            }
        }  
    }
}