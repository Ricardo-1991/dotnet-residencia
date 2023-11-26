using System;
using ProductManager = ProductManagerNamespace.ProductManager;
namespace Program 
{
    class Program {
        static void Main(string[] args)
        {
           ProductManager productManager = new ProductManager();
           string? option;
        
           do { 
                Console.WriteLine("Gerenciamento de Estoque de Produtos");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1 - Cadastrar um novo Produto");
                Console.WriteLine("2 - Consultar um produto");
                Console.WriteLine("3 - Atualizar quantidade do produto");
                Console.WriteLine("4 - Gerar relatórios");
        
                Console.WriteLine("Escolha uma opção:");
                option = Console.ReadLine();
                
                switch (option)
                {
                    case "1":
                        productManager.AddProduct();
                        break;
                    case "2":
                        productManager.consultProductByCode();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
           }while(option != "0");
        }
    }
}