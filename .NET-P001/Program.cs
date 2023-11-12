using System;
#region Questão 01 - Tipos de Dados
    // sbyte: Armazena inteiros de 8 bits com sinal (-128 a 127)
    sbyte mySByte = -50;

    // byte: Armazena inteiros de 8 bits sem sinal (0 a 255)
    byte myByte = 200;

    // short (ou Int16): Armazena inteiros de 16 bits com sinal (-32,768 a 32,767)
    short myShort = 1500;

    // ushort (ou UInt16): Armazena inteiros de 16 bits sem sinal (0 a 65,535)
    ushort myUShort = 60000;

    // int (ou Int32): Armazena inteiros de 32 bits com sinal (-2,147,483,648 a 2,147,483,647)
    int myInt = -200000;

    // uint (ou UInt32): Armazena inteiros de 32 bits sem sinal (0 a 4,294,967,295)
    uint myUInt = 4000000000;

    // long (ou Int64): Armazena inteiros de 64 bits com sinal (-9,223,372,036,854,775,808 a 9,223,372,036,854,775,807)
    long myLong = -9000000000000000000;

    // ulong (ou UInt64): Armazena inteiros de 64 bits sem sinal (0 a 18,446,744,073,709,551,615)
    ulong myULong = 18000000000000000000;

    // Exibindo os valores
    Console.WriteLine($"sbyte: {mySByte}");
    Console.WriteLine($"byte: {myByte}");
    Console.WriteLine($"short: {myShort}");
    Console.WriteLine($"ushort: {myUShort}");
    Console.WriteLine($"int: {myInt}");
    Console.WriteLine($"uint: {myUInt}");
    Console.WriteLine($"long: {myLong}");
    Console.WriteLine($"ulong: {myULong}");
#endregion


#region Questão 02 - Conversão de Tipos de Dados:

    double myDouble = 5.6;

    int myInt2 = (int)myDouble;

    Console.WriteLine($"Após a conversão de double para inteiro usando conversão explícita por 'cast', o valor fracionário é truncado e arredondado para baixo: {myInt2}.");

#endregion


#region Questão 04 - Operadores Aritméticos:
    int x = 10, y = 3;

    Console.WriteLine($"Adição: {x} + {y} = " + (x + y));
    Console.WriteLine($"Subtração: {x} - {y} = " + (x - y));
    Console.WriteLine($"Divisão: {x} / {y} = " + (x / y));
    Console.WriteLine($"Multiplicação: {x} * {y} = " + (x * y));
#endregion


#region Questão 05 - Operadores de Comparação:
    int a = 5, b = 8;

    if(a > b)
        Console.WriteLine($"{a} é maior do que {b}.");
    else
        Console.WriteLine($"{b} é maior do que {a}");

#endregion


#region Questão 06 - Operadores de Igualdade:

    string str1 = "Hello", str2 = "World";

    if(str1 == str2)
        Console.WriteLine("As duas strings são iguais.");
    else 
        Console.WriteLine("As duas strings não são iguais.");
#endregion


#region Questão 07 - Operadores Lógicos:
    bool condicao1 = true, condicao2 = false;

    if(condicao1 && condicao2) 
        Console.WriteLine("Ambas as condições são verdadeiras.");
    else
        Console.WriteLine("Ambas as condições não são verdadeiras");

#endregion


#region Questão 08 - Desafio de Mistura de Operadores:
    int num1 = 7, num2 = 3, num3 = 10;

    if(num1 > num2 && num3 == (num1 + num2))
        Console.WriteLine($"{num1} é maior que {num2} e {num1} + {num2} é igual a {num3}.");
    else 
        Console.WriteLine("Condição falsa");
#endregion