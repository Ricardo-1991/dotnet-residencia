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
             if(isListEmpty()){
                Console.WriteLine("Não há produto cadastrado para adicionar a quantidade.");
                return;
            }
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
             if(isListEmpty()){
                Console.WriteLine("Não há produto cadastrado para diminuir a quantidade.");
                return;
            }
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
             if(isListEmpty()){
                Console.WriteLine("Não há produto cadastrado para ser consultado.");
                return;
            }
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
            if(isListEmpty()){
                Console.WriteLine("Não há produto cadastrado para gerar relatório.");
                return;
            }
            string ? option;
            string divLine = "-------------------------------------------------------------------------------------";
            do {
                Console.WriteLine("Menu de relatórios");
                Console.WriteLine(divLine);
                Console.WriteLine("1 - Lista de produtos com quantidade baixo do informado.");
                Console.WriteLine("2 - Lista de produtos entre dois valores informados.");
                Console.WriteLine("3 - Valor total do estoque e valor total de cada produto de acordo com o estoque.");
                Console.WriteLine("4 - Retornar para o menu principal");
                Console.WriteLine(divLine);
                Console.WriteLine();

                Console.WriteLine("Escolha uma opção no menu de relatórios");
                option = Console.ReadLine();
        
                switch (option){
                    case "1":
                        int? amount = GetValidatedIntInput("Digite a quantidade:");
                        var filteredListAmount = productList.Where(product => product.amount < amount).ToList();
                        foreach(var product in filteredListAmount){
                            Console.WriteLine(divLine);
                            Console.WriteLine($"Nome: {product.name}\nPreço: R${product.price}\nQuantidade: {product.amount}\nCódigo: {product.code}");
                            Console.WriteLine(divLine);
                        }
                    break;

                    case "2":
                        float? firstValue = GetValidatedFloatInput("Digite o primeiro valor:"); 
                        float? secondValue = GetValidatedFloatInput("Digite o segundo valor:"); 
                        if(firstValue < secondValue){
                            (firstValue, secondValue) = (secondValue, firstValue);
                        }
                        var filteredListValues = productList.Where(product => (product.price < firstValue && product.price > secondValue));
                         foreach(var product in filteredListValues){
                            Console.WriteLine(divLine);
                            Console.WriteLine($"Nome: {product.name}\nPreço: R${product.price}\nQuantidade: {product.amount}\nCódigo: {product.code}");
                            Console.WriteLine(divLine);
                        }
                    break;

                    case "3":
                        float? total = productList.Select(product => product.amount * product.price).Sum();
                        Console.WriteLine($"Valor total do estoque: {total}");
                        Console.WriteLine(divLine);
                        Console.WriteLine("Valor total de cada produto de acordo com seu estoque");
                        foreach(var product in productList){
                                Console.WriteLine($"Produto: {product.name}");
                                Console.WriteLine($"Valor total: {product.amount * product.price}");
                            } 
                    break;

                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                    break;
                }

            }while(option != "4");
            
        }

        private bool isListEmpty(){
            if(productList.Count == 0){
                return true;
            }
            return false;
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