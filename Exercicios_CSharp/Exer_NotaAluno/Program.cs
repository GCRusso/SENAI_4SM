Console.WriteLine($"Informe uma nota de 1 a 10: ");
int notaAluno = int.Parse(Console.ReadLine());

switch (notaAluno)
{
    case 10:
        Console.WriteLine($"Aluno Aprovado!");
        break;

    case 9:
        Console.WriteLine($"Aluno Aprovado!");
        break;

    case 8:
        Console.WriteLine($"Aluno Aprovado!");
        break;

    case 7:
        Console.WriteLine($"Aluno Aprovado!");
        break;

    case 6:
        Console.WriteLine($"Aluno de Recuperação!");
        break;

    case 5:
        Console.WriteLine($"Aluno de Recuperação!");
        break;

    case 4:
        Console.WriteLine($"Aluno Reprovado!");
        break;

    case 3:
        Console.WriteLine($"Aluno Reprovado!");
        break;

    case 2:
        Console.WriteLine($"Aluno Reprovado!");
        break;

    case 1:
        Console.WriteLine($"Aluno Reprovado!");
        break;

    default:
        Console.WriteLine($"Escolha uma nota de 1 a 10.");
        break;
}
