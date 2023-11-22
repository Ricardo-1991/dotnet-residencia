
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

    private int _id;

    public int Id {
        get { return _id; }
        set { _id = value; }
    }
 };

public class MyToDoList {
List<Task> tasks = new List<Task>();

public bool isEmptyList() {
    if(tasks.Count == 0) {
        Console.WriteLine("Não há tarefas cadastradas para listar.");
        Console.WriteLine();
        return true;
    } else {
        return false;
    }
}
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
        if(tasks.Count > 0) {
        newTask.Id = tasks[tasks.Count - 1].Id + 1;
        } else {
            newTask.Id = 1;
        }
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
    bool isEmpty = isEmptyList();
    if(isEmpty) {
        return;
    }
    printAllTasks();

    Console.WriteLine();
    Console.WriteLine($"Qual tarefa deseja excluir? Escolha pelos índices ou digite '0' para retornar ao menu: ");
    string? userInput = Console.ReadLine();
    if(userInput == "0"){
        return;
    }
    int.TryParse(userInput, out int option);
    bool isFind = false;
    for(int i = 0; i < tasks.Count; i++){
        if(tasks[i].Id == option){
            tasks.RemoveAt(i);
            Console.WriteLine("Tarefa removida com sucesso!");
            Console.WriteLine();
            isFind = true;
            break;
        }
    }

    if(!isFind){
        Console.WriteLine("Não há tarefa com o índice informado.");
        Console.WriteLine();
    }

}

public void markTaskCompleted() {
    bool isEmpty = isEmptyList();
    if(isEmpty) {
        return;
    }

    printAllTasks();
    Console.WriteLine();
    Console.WriteLine(
        "Selecione uma tarefa para marcar como concluída escolhendo pelos índices ou digite 0 para retornar ao menu: "
    );

    string? userInput = Console.ReadLine();
    if(userInput == "0"){
        return;
    }

    int.TryParse(userInput, out int option);
    bool isFind = false;

    for(int i = 0; i < tasks.Count; i++){
        if(tasks[i].Id == option){
            tasks[i].IsComplete = true;
            Console.WriteLine($"Tarefa {tasks[i].Title} conluída! ");
            Console.WriteLine();
            isFind = true;
            break;
        }
    }

    if(!isFind){
        Console.WriteLine("Não há tarefa com o índice informado.");
        Console.WriteLine();
    }

}

public void completedTasks() {
    bool isEmpty = isEmptyList();
    if(isEmpty) {
        return;
    }
    Console.WriteLine("Lista de tarefas concluídas: ");
    Console.WriteLine("-----------------------------");
    foreach(var task in tasks) {
        if(task.IsComplete) {
             string output = String.Format("ID: {0}\nTítulo: {1}\nDescrição: {2}\nData de encerramento: {3}\nStatus: {4}\n",
                task.Id,
                formatString(task.Title),
                formatString(task.Description),
                task.ExpirationDate.ToShortDateString(),
                "Pendente ✅.\n"
            );
            Console.WriteLine(output);
        }
    }
}   

public void incompletedTasks() {
    bool isEmpty = isEmptyList();
    if(isEmpty) {
        return;
    }
    Console.WriteLine("Lista de tarefas não concluídas: ");
    Console.WriteLine("-----------------------------");
    foreach(var task in tasks) {
        if(!task.IsComplete) {
            string output = String.Format("ID: {0}\nTítulo: {1}\nDescrição: {2}\nData de encerramento: {3}\nStatus: {4}\n",
                task.Id,
                formatString(task.Title),
                formatString(task.Description),
                task.ExpirationDate.ToShortDateString(),
                "Pendente ❌.\n"
            );
            Console.WriteLine(output);
        }
    }
}

public void findTaskWithKeyWord() {
    bool isEmpty = isEmptyList();
    if(isEmpty) {
        return;
    }
    Console.WriteLine("Digite palavra chave para encontrar tarefas: ");
    string? userInput = Console.ReadLine();
    Console.WriteLine("Lista de tarefas encontradas: ");
    Console.WriteLine("-----------------------------");
    foreach(var task in tasks) {
        if(task.Title != null && userInput != null){
            if(task.Title.Contains(userInput, StringComparison.OrdinalIgnoreCase)) {
                string output = String.Format("ID: {0}\nTítulo: {1}\nDescrição: {2}\nData de encerramento: {3}\nStatus: {4}\n",
                               task.Id,
                               formatString(task.Title),
                               formatString(task.Description),
                               task.ExpirationDate.ToShortDateString(),
                               task.IsComplete ? "Concluída ✅" : "Pendente ❌");
                Console.WriteLine(output);
            }
        }   
    }
}

public void generalStatistics() {
    bool isEmpty = isEmptyList();
    if(isEmpty) {
        return;
    }
    int amountCompletedTasks = 0;
    int amountIncompletedTasks = 0;
    DateTime mostRecentDate = DateTime.MaxValue;
    DateTime oldestDate = DateTime.MinValue;
    int indexMax = 0;
    int indexMin = 0;
    for(int i = 0; i < tasks.Count; i++ ) {
        if(tasks[i].IsComplete) {
            amountCompletedTasks++;
        }else if(!tasks[i].IsComplete){
            amountIncompletedTasks++;
        }

        if(tasks[i].ExpirationDate < mostRecentDate){
            mostRecentDate = tasks[i].ExpirationDate;
            indexMin = i;
        }

        if(tasks[i].ExpirationDate > oldestDate){
            oldestDate = tasks[i].ExpirationDate;
            indexMax = i;
        }
    }

    Console.WriteLine("Dados estatísticos");
    Console.WriteLine("------------------");
    Console.WriteLine($"Quantidade de tarefas concluídas: {amountCompletedTasks}");
    Console.WriteLine($"Quantidade de tarefas pendentes: {amountIncompletedTasks}");
    Console.WriteLine();
    Console.WriteLine("Data da tarefa mais recente: ");
    string mostRecentDateOutput = String.Format("ID: {0}\nTítulo: {1}\nDescrição: {2}\nData de encerramento: {3}\nStatus: {4}\n",
                               tasks[indexMax].Id,
                               formatString(tasks[indexMax].Title),
                               formatString(tasks[indexMax].Description),
                               tasks[indexMax].ExpirationDate.ToShortDateString(),
                               tasks[indexMax].IsComplete ? "Concluída ✅" : "Pendente ❌");
    Console.WriteLine(mostRecentDateOutput);
    
    Console.WriteLine();

    Console.WriteLine("Data da tarefa mais antiga: ");
    string OldestDateoutput = String.Format("ID: {0}\nTítulo: {1}\nDescrição: {2}\nData de encerramento: {3}\nStatus: {4}\n",
                               tasks[indexMin].Id,
                               formatString(tasks[indexMin].Title),
                               formatString(tasks[indexMin].Description),
                               tasks[indexMin].ExpirationDate.ToShortDateString(),
                               tasks[indexMin].IsComplete ? "Concluída ✅" : "Pendente ❌");
    Console.WriteLine(OldestDateoutput);
    

}

public void printAllTasks(){
    bool isEmpty = isEmptyList();
    if(isEmpty) {
        return;
    }
    
    foreach(var task in tasks){
        string output = String.Format("ID: {0}\nTítulo: {1}\nDescrição: {2}\nData de encerramento: {3}\nStatus: {4}\n",
                               task.Id,
                               formatString(task.Title),
                               formatString(task.Description),
                               task.ExpirationDate.ToShortDateString(),
                               task.IsComplete ? "Concluída ✅" : "Pendente ❌");
                Console.WriteLine(output);
        Console.WriteLine("------------------------------");
    }   
}

public string formatString(string? input){
    if (!string.IsNullOrEmpty(input) && input[input.Length - 1] != '.') {
        input += '.';
    }
    return (input ?? string.Empty);
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
            tasks.markTaskCompleted();
            break;

        case 4:
            tasks.printAllTasks();
            break;

        case 5:
            tasks.completedTasks();
            break;

        case 6:
            tasks.incompletedTasks();
            break;

        case 7:
            tasks.findTaskWithKeyWord();
            break;

        case 8:
            tasks.generalStatistics();
            break;

        case 9:
            Console.WriteLine("Programa finalizado.");
            break;
    
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    } while (option != 9);

    }
}




