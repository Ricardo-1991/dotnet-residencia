using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliente = Personas.Cliente;
using Advogado = Personas.Advogado;

namespace Reports
{
    public static class ListAndReports {
        public static List<Cliente> colecaoCliente = new();
        public static List<Advogado> colecaoAdvogado = new();

        public static void getValidated(){
           /*  var allCpfs = colecaoCliente.Select(cliente => cliente.Cpf);
            var isUniquesCpf = allCpfs.Where(cpf => cpf.CompareTo()); */
           var cpfsValidos = colecaoCliente.Where(cliente => !string.IsNullOrEmpty(cliente.Cpf)).Select(cliente => cliente.Cpf);
           bool isUnique = cpfsValidos.Count() == new HashSet<string>(cpfsValidos).Count;

           Console.WriteLine(isUnique);

        }
        public static void reports(){
            foreach(var cliente in colecaoCliente) {
                Console.WriteLine($"{cliente.nome}");
            }
        }
    }
}