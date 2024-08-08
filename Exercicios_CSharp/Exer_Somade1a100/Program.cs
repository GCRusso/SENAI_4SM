using System.Diagnostics.Contracts;

int numero = 1;
int somaPares = 0;

while(numero <= 100)
{
    if(numero % 2 == 0)
    {
        somaPares += numero;
    }
    numero++;

}
    Console.WriteLine($"Soma dos numeros pares = {somaPares}");
