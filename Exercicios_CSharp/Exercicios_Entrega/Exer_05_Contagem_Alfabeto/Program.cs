// Exercício 5
//Crie um programa que peça ao usuário para digitar um texto e conte quantas vezes cada letra do alfabeto aparece no texto.



char[] alfabeto = new char[26]
{
'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
'u', 'v', 'w', 'x', 'y', 'z'
};

Console.WriteLine("Digite um texto: ");
string texto = Console.ReadLine().ToLower();

int[] contagem = new int[26];

foreach (char x in texto)
{
    for (var i = 0; i < alfabeto.Length; i++)
    {
        if (x == alfabeto[i])
        {
            contagem[i]++;
            break;
        }
    }
}

Console.WriteLine("Contagem das letras:");
for (int i = 0; i < alfabeto.Length; i++)
{

    if (contagem[i] > 0)
    {
        Console.WriteLine($"{alfabeto[i]}: {contagem[i]}");
    }
}