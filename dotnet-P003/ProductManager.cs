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
            try {
                float? productPrice = 0;
                int? productAmount = 0, productCode = null;
                
                Console.WriteLine("Digite o nome do produto");
                string? productName = Console.ReadLine();

                Console.WriteLine("O preço unitário do produto:");
                string? inputProductFloat = Console.ReadLine();

                if(float.TryParse(inputProductFloat, out float price)){
                    productPrice = price;
                } else {
                    throw new Exception("Entrada inválida para preço. Deve ser um número válido.");
                }

                Console.WriteLine("Quantidade do produto:");
                string? inputProductAmount = Console.ReadLine();

                if(int.TryParse(inputProductAmount, out int amount)){
                    productAmount = amount;
                } else {
                    throw new Exception("Entrada inválida para quantidade do produto. Deve ser um número válido.");
                }

                Console.WriteLine("Código do produto:");
                string? inputProductCode = Console.ReadLine();

                if(int.TryParse(inputProductCode, out int code)){
                    productCode = code;
                } else {
                    throw new Exception("Entrada inválida para o código do produto. Deve ser uma entrada válida.");
                }

                var newProduct = (code: productCode, name: productName, amount: productAmount, price: productPrice);
                productList.Add(newProduct);
            }catch(Exception err){
                Console.WriteLine($"Erro: {err.Message}");
            }
        }

        public void consultProductByCode() {
            int? productCode = null;
            try {
                Console.WriteLine("Digite o código do produto que deseja consultar:");
                string? inputProductCode = Console.ReadLine();
                if(int.TryParse(inputProductCode, out int code)){
                    productCode = code;
                } else {
                    throw new Exception("Entrada inválida para código do produto. Deve ser uma entrada válida.");
                }
                var filteredProduct = productList.SingleOrDefault(product => product.code == code);

                Console.WriteLine($"Nome: {filteredProduct.name}\nPreço: R${filteredProduct.price}\nQuantidade: {filteredProduct.amount}\nCódigo: {filteredProduct.code}");

            }catch(Exception err){
                Console.WriteLine($"Error: {err.Message}");
            }
        }
    }
}