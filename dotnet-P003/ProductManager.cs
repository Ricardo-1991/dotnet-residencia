using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerNamespace
{
    public class ProductManager
    {
        public List<(int? code, string? name, int? amount, float? price )> productList = new();

        public void AddProduct(){
            float? productPrice = 0;
            int? productAmount = 0, productCode = null;
            
            Console.WriteLine("Digite o nome do produto");
            string? productName = Console.ReadLine();

            Console.WriteLine("O preço unitário do produto:");
            string? inputProductFloat = Console.ReadLine();
            if(float.TryParse(inputProductFloat, out float price)){
                productPrice = price;
            } else {
                Console.WriteLine("Entrada inválida");
            }
            Console.WriteLine("Quantidade do produto:");
            string? inputProductAmount = Console.ReadLine();
            if(int.TryParse(inputProductAmount, out int amount)){
                productAmount = amount;
            } else {
                Console.WriteLine("Entrada Inválida");
            }
            Console.WriteLine("Código do produto:");
            string? inputProductCode = Console.ReadLine();
            if(int.TryParse(inputProductCode, out int code)){
                productCode = code;
            } else {
                Console.WriteLine("Entrada inválida");
            }

            var newProduct = (code: productCode, name: productName, amount: productAmount, price: productPrice);
            productList.Add(newProduct);
        }

        public void consultProductByCode() {
            int? productCode = null;
            foreach(var product in productList){
                Console.WriteLine($"Nome: {product.name}\nPreço: {product.price}\nQuantidade: {product.amount}:\nCódigo: {product.code} ");
                Console.WriteLine();
            }

            Console.WriteLine("Digite o código do produto que deseja consultar:");
            string? inputProductCode = Console.ReadLine();
        }
    }
}