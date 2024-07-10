
var input = 0;
while (input != 6)
{
    Console.WriteLine("Bem-vindo a biblioteca UNIFESP\nDigite o número da sua ação:\n\n" +
        "1 - Registrar usuário.\n" +
        "2 - Remover usuário.\n" +
        "3 - Buscar livro\n" +
        "4 - Emprestar livro\n" +
        "5 - Devolução do livro\n" +
        "6 - Sair");

    input = int.Parse(Console.ReadLine().ToString());
    Console.WriteLine(input);

}
