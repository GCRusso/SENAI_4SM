//Exercício 4
//Crie uma função que recebe um número como parâmetro e retorna a tabuada desse número até o número 10. 
//Utilize um laço for para gerar os múltiplos do número.




static void Tabuada()
{
    int numero = 0;
    int resultado = 0;
    
    Console.WriteLine("Informe o numero que deseja a tabuada: ");
    numero = int.Parse(Console.ReadLine());

        Console.WriteLine("");
        Console.WriteLine($" ****** TABUADA DO {numero} ******");
    for (var i = 0; i < 11; i++)
    {
        resultado = numero * i;

        Console.WriteLine($"{numero} X {i} = {resultado}");

    }
}

Tabuada();