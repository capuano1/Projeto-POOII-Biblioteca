using System;
public class Program
{    
    public static void Main(){
        var input = 0;
        while (input != 7)
        {
            Console.WriteLine("Bem-vindo a biblioteca UNIFESP\nDigite o número da sua ação:\n\n" +
                "1 - Registrar usuário.\n" +
                "2 - Remover usuário.\n" +
                "3 - Buscar usuário\n" +
                "4 - Buscar livro\n" +
                "5 - Emprestar livro\n" +
                "6 - Devolver livro\n" +
                "7 - Sair\n\n");
            
            input = int.Parse(Console.ReadLine().ToString());
            
            switch(input){
                case 1:
                    Console.WriteLine("Digite seu nome: ");
                    var nome = Console.ReadLine().ToString();

                    Console.WriteLine("Digite seu código: ");
                    var codigo = Console.ReadLine().ToString();

                    Console.WriteLine("Digite sua idade: ");
                    var idade = Console.ReadLine().ToString();

                    Console.WriteLine("Você é:\n1 - Aluno\n2 - Professor\n 3 - Funcionário da Biblioteca");
                    var n = int.Parse(Console.ReadLine().ToString());
/*
                    switch(n){
                        case 1: //ALUNO
                            facade.registrarAluno(nome,codigo,idade);
                            break;
                        case 2: //PROFESSOR
                            facade.registrarProfessor(nome,codigo,idade);
                            break;
                        case 3: //FUNCIONARIO
                            facade.registrarFuncionario(nome,codigo,idade);
                            break;
                    }*/
                    break;


                case 2:
                    Console.WriteLine("Digite o código do usuário a ser removido: \n");
                    var cod = Console.ReadLine().ToString();
                    //facade.removerUser(cod);
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:
                    break;        
            }

        }
    }
}