Console.WriteLine("Digite um numero para mostrar a tabuada: ");
int numero = int.Parse(Console.ReadLine());

Console.WriteLine($"TABUADA DO {numero}");
for (var i = 0; i < 11; i++)
{
        
        Console.WriteLine($"{numero} X {i} = {i * numero}");
    
}
