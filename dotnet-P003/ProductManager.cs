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
            try
            {
                Console.WriteLine("Digite o nome do produto:");
                string? productName = Console.ReadLine();

                float productPrice = GetValidatedFloatInput("Digite o preço unitário do produto:");

                int productAmount = GetValidatedIntInput("Digite a quantidade do produto:");

                int productCode = GetValidatedIntInput("Digite o código do produto:");

                bool productExists = ProductCodeExists(productCode);

                if(productExists){
                  throw new("Ja há um produto cadastrado com este código. Cadastre o produto com um código válido");
                }

                var newProduct = (code: productCode, name: productName, amount: productAmount, price: productPrice);
                productList.Add(newProduct);
            }
            catch (Exception err){
                Console.WriteLine($"Erro: {err.Message}");
            }
        }

        public void addProductAmount(){
            string divLine = "-----------------------------------------------------------------------------------------------------";
            foreach(var product in productList){
                Console.WriteLine(divLine);
                Console.WriteLine($"Nome: {product.name}\nPreço: R${product.price}\nQuantidade: {product.amount}\nCódigo: {product.code}");
                Console.WriteLine(divLine);
            }

            try {
                int? inputProductCode = GetValidatedIntInput("Qual produto você deseja atualizar a quantidade? Digite o código:");
                
                var filteredProduct = productList.SingleOrDefault(product => product.code == inputProductCode);
                if(filteredProduct.code == null){
                    throw new ("O código informado não consta na base de dados dos produtos.");
                }

                int productAmount = GetValidatedIntInput("Qual a quantidade deseja adicionar?");
                int index = productList.IndexOf(filteredProduct);
             
                var updatedProduct = (filteredProduct.code, filteredProduct.name, filteredProduct.amount + productAmount, filteredProduct.price);
                productList[index] = updatedProduct;

                Console.WriteLine(divLine);
                Console.WriteLine($"Nome: {productList[index].name}\nPreço: R${productList[index].price}\nQuantidade: {productList[index].amount}\nCódigo: {productList[index].code}");
                Console.WriteLine(divLine);
                Console.WriteLine("Quantidade do produto atualizada!");

            }catch(Exception err){
                Console.WriteLine($"Erro: {err.Message}");
            }
        }

        public void decreaseProductAmount (){
            string divLine = "-----------------------------------------------------------------------------------------------------";
            foreach(var product in productList){
                Console.WriteLine(divLine);
                Console.WriteLine($"Nome: {product.name}\nPreço: R${product.price}\nQuantidade: {product.amount}\nCódigo: {product.code}");
                Console.WriteLine(divLine);
            }

            try {
                int? inputProductCode = GetValidatedIntInput("Qual produto você deseja atualizar a quantidade? Digite o código:");
                
                var filteredProduct = productList.SingleOrDefault(product => product.code == inputProductCode);
                if(filteredProduct.code == null){
                    throw new ("O código informado não consta na base de dados dos produtos.");
                }

                int productAmount = GetValidatedIntInput("Qual a quantidade deseja retirar?");
                int index = productList.IndexOf(filteredProduct);
                if(productList[index].amount < productAmount){
                    Console.WriteLine("A quantidade de estoque do produto é menor do que a quantidade que se deseja diminuir.");
                    return;
                }
                var updatedProduct = (filteredProduct.code, filteredProduct.name, filteredProduct.amount - productAmount, filteredProduct.price);
                productList[index] = updatedProduct;

                Console.WriteLine(divLine);
                Console.WriteLine($"Nome: {productList[index].name}\nPreço: R${productList[index].price}\nQuantidade: {productList[index].amount}\nCódigo: {productList[index].code}");
                Console.WriteLine(divLine);
                Console.WriteLine("Quantidade do produto atualizada!");

            }catch(Exception err){
                Console.WriteLine($"Erro: {err.Message}");
            }
        }

        public void consultProductByCode() {
            string divLine = "-----------------------------------------------------------------------------------------------------";
            try {
                int? productCode = GetValidatedIntInput("Qual produto você deseja atualizar a quantidade? Digite o código:");

                var filteredProduct = productList.SingleOrDefault(product => product.code == productCode);
                if(filteredProduct.code == null){
                    throw new Exception("O código informado não consta na base de dados dos produtos.");
                }
                Console.WriteLine(divLine);
                Console.WriteLine($"Nome: {filteredProduct.name}\nPreço: R${filteredProduct.price}\nQuantidade: {filteredProduct.amount}\nCódigo: {filteredProduct.code}");
                Console.WriteLine(divLine);
            }catch(Exception err){
                Console.WriteLine($"Erro: {err.Message}");
            }
        }

        public void generateReport(){
            
        }

        private float GetValidatedFloatInput(string message){
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();

                if (float.TryParse(input, out float result)){
                    return result;
                }
                throw new("Entrada inválida para preço. Deve ser um número válido.");
            }
        }

        private int GetValidatedIntInput(string message){
            while (true){
                Console.WriteLine(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int result)){
                    return result;
                }

                throw new("Entrada inválida. Deve ser um número válido.");
            }
        }

        private bool ProductCodeExists(int code){
            return productList.Any(product => product.code == code);
        }        
    }
}