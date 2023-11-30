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

        public static void reports(){
            foreach(var cliente in colecaoCliente) {
                Console.WriteLine($"{cliente.nome}");
            }
        }
    }
}