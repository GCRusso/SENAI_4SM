//Exercício 3
//Crie um programa que calcule a soma dos números pares de um vetor de 10 elementos. 
//Utilize um laço for para percorrer o vetor e uma estrutura condicional if para identificar os números pares.

int[] numeros = new int[10];
int pares = 0;

numeros = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];


for (var i = 0; i < numeros.Length; i++)
{

    if (numeros[i] % 2 == 0)
    {
        pares += numeros[i];
    }

}

Console.WriteLine($"A soma dos pares é {pares}");