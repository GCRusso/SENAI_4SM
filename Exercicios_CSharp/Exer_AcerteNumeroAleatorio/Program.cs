using System.Runtime.CompilerServices;

Random random = new Random();

int numeroAleatorio = random.Next(1, 11);
int tentativas = 0;
bool acertou = false;
int numeroFornecido = 0;

do
{
    Console.WriteLine("Informe o número: ");
    numeroFornecido = int.Parse(Console.ReadLine());
    tentativas++;
    

    if (numeroAleatorio == numeroFornecido )
    {
        Console.WriteLine($"Parabéns acertou o número {numeroFornecido} = {numeroAleatorio} !!!!");
        Console.WriteLine($"Número de tentativas: {tentativas}");
        acertou = true;
    }


    else
    {
        Console.Clear();
        
    }

} while (acertou == false );



