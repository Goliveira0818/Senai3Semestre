using Exercicio1;

Pessoa gustavo = new pessoa
Console.WriteLine("Digite o nome da pessoa:");
gustavo.Nome = Console.ReadLine();
Console.WriteLine("Digite a idade da pessoa:");
gustavo.Idade = int.Parse(Console.ReadLine());
Console.WriteLine($"O nome da pessoa é {gustavo.Nome} e a idade é {gustavo.Idade} anos.);