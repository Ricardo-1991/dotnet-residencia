 
 static void addTask (List<(string? title, string? description, DateTime expirationDate, bool isComplete)> myToDoList){
        Console.WriteLine("Digite um título para a sua tarefa:");
        string? newTitle = Console.ReadLine();

        Console.WriteLine("Digite uma descrição para a sua tarefa:");
        string? newDescription = Console.ReadLine();

        Console.WriteLine("Digite uma data de encerramento da tarefa:(formato dd/mm/aaaa)");
        string? newDate = Console.ReadLine();

        if (DateTime.TryParseExact(newDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime newExpirationDate)) {
            myToDoList.Add((newTitle, newDescription, newExpirationDate, false));
            Console.WriteLine("Tarefa adicionada com sucesso!");
            Console.WriteLine();
        } else {
            Console.WriteLine("Formato de data inválido. Certifique-se de usar o formato dd/MM/yyyy.");
            Console.WriteLine();
        }
 }

 static void printAllTasks(List<(string? title, string? description, DateTime expirationDate, bool isComplete)> myToDoList){
    for(int i = 0; i < myToDoList.Count; i++){
        Console.WriteLine($"Título: {myToDoList[i].title}\nDescrição: {myToDoList[i].description}\nData de encerramento: {myToDoList[i].expirationDate}\nStatus: {(myToDoList[i].isComplete ? "Completada" : "Incompleta")}\n");
    }
 }


List<(string? title, string? description, DateTime expirationDate, bool isComplete)> myToDoList = new List<(string?, string?, DateTime, bool)>{};

string? userInput;
int option;

do
{
    Console.WriteLine("Bem vindo ao ToDoList ResiTic18");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("1 - Criar uma tarefa.");
    Console.WriteLine("2 - Excluir uma tarefa.");
    Console.WriteLine("3 - Marcar uma tarefa como concluída.");
    Console.WriteLine("4 - Listar todas as tarefas.");
    Console.WriteLine("5 - Listar tarefas concluídas.");
    Console.WriteLine("6 - Listar tarefas não concluídas.");
    Console.WriteLine("7 - Encontrar tarefas com base em palavras chaves.");
    Console.WriteLine("8 - Estatísticas.");
    Console.WriteLine("9 - Sair do programa");
    Console.WriteLine("--------------------------------");

    Console.WriteLine("Digite a opção desejada");
    userInput = Console.ReadLine();
    int.TryParse(userInput, out option);

    switch (option)
{
    case 1:
        addTask(myToDoList);
        break;
    case 2:
  
        break;

    case 3:
  
        break;

    case 4:
        printAllTasks(myToDoList);
        break;

    case 5:
  
        break;

    case 6:
  
        break;

    case 7:
  
        break;

    case 8:
  
        break;

    case 9:
  
        break;
  
    default:
        Console.WriteLine("Opção inválida");
        break;
}

} while (option != 9);
