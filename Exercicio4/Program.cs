using Exercicio04;
Pessoa gustavo= new Pessoa("gustavo", 17);
gustavo.ExibirDados();
gustavo.AlterarIdade(22);
gustavo.ExibirDados();
Console.WriteLine($"");
Console.WriteLine($"");
Pessoa jose = new Pessoa("jose", -5); // Idade negativa, deve ser tratada
jose.ExibirDados();
jose.AlterarIdade(-10); // Tentativa de alterar para idade negativa, deve ser tratada
jose.ExibirDados();