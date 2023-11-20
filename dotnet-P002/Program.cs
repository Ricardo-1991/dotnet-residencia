
public class Task {
     private string? _title;
    public string? Title {
        get { return _title; }
        set { _title = value; }
    }

    private string? _description;
    public string? Description {
        get { return _description; }
        set { _description = value; }
    }

    private DateTime _expirationDate;
    public DateTime ExpirationDate {
        get { return _expirationDate; }
        set { _expirationDate = value; }
    }

    private bool _isComplete;
    public bool IsComplete {
        get { return _isComplete; }
        set { _isComplete = value; }
    }
 };


 public class MyToDoList {
    List<Task> tasks = new List<Task>();

    public void addTask (){
    Task newTask = new Task();
    Console.WriteLine("Digite um título para a sua tarefa:");
    newTask.Title = Console.ReadLine();

    Console.WriteLine("Digite uma descrição para a sua tarefa:");
    newTask.Description = Console.ReadLine();

    Console.WriteLine("Digite uma data de encerramento da tarefa:(formato dd/mm/aaaa)");
    string? newDate = Console.ReadLine();
    string formatDate = "dd/MM/yyyy";
    if (DateTime.TryParseExact(newDate, formatDate, null, System.Globalization.DateTimeStyles.None, out DateTime newExpirationDate)) {
        newTask.ExpirationDate = newExpirationDate;
        tasks.Add(newTask);
        Console.WriteLine("Tarefa adicionada com sucesso!");
        Console.WriteLine();
    } else {
        Console.WriteLine("Formato de data inválido. Certifique-se de usar o formato dd/MM/yyyy.");
        Console.WriteLine();
    }
}

public void eraseTask(){
    printAllTasks();

    Console.WriteLine();
    Console.WriteLine($"Qual tarefa deseja excluir? Escolha pelos índices");
    string? userInput = Console.ReadLine();
    int.TryParse(userInput, out int option);
    bool isFind = false;
    for(int i = 1; i <= tasks.Count; i++){
        if(i == option){
            tasks.RemoveAt(i);
            Console.WriteLine("Tarefa removida com sucesso!");
            isFind = true;
            break;
        }
    }

    if(!isFind){
        Console.WriteLine("Não há tarefa com o índice informado.");
    }

}

public void printAllTasks(){
    int id = 1;
    foreach(var task in tasks){
        Console.WriteLine($"ID: {id}\nTítulo: {task.Title}\nDescrição: {task.Description}\nData de encerramento: {task.ExpirationDate}\nStatus: {(task.IsComplete ? "Completada" : "Incompleta")}\n");
        Console.WriteLine("------------------------------");
        id++;
    }
}

}

class Program {
    static void Main(){

    MyToDoList tasks = new MyToDoList();

    string? userInput;
    int option;
    do {
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
        Task task = new Task();

        switch (option) {
        case 1:
            tasks.addTask();
            break;
        case 2:
            tasks.eraseTask();
            break;

        case 3:
    
            break;

        case 4:
            tasks.printAllTasks();
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

    }
}




