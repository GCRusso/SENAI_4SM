//Exercício 1
//Escreva um programa que peça ao usuário para digitar um número inteiro e informe se o número é par ou ímpar.
//Utilize uma estrutura condicional if/else para realizar o teste.

Console.WriteLine("Digite um número inteiro: ");
int numero = int.Parse(Console.ReadLine());


if(numero % 2 == 0 ){
Console.WriteLine($"o numero {numero} é par.");
}
else
{
Console.WriteLine($"o numero {numero} é impar.");
}