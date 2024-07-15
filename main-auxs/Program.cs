using System;
/*
Link para o diagram UML do Projeto

https://lucid.app/lucidchart/78f42a13-1e41-4808-a02c-e1da014b16f7/edit?viewport_loc=-1429%2C-921%2C3107%2C1352%2C0_0&invitationId=inv_28a8a5b3-e2e3-4e2c-a5d2-a9b5257834a9


Imagine que você é funcionário da Biblioteca da UNIFESP, caso um user seja novo na biblioteca (este user podendo ser aluno, professor ou um novo funcionário), 
você deve registrá-lo no banco de dados da biblioteca para poder emprestar os livros.


*/

public class Program
{    
    public static void Main(){

        Facade facade = new Facade();

        var input = 0;
        while (input != 7)
        {
            Thread.Sleep(1500);
            Console.WriteLine();
            Console.WriteLine(  "1 - Registrar usuário.\n" +
                                "2 - Remover usuário.\n" +
                                "3 - Buscar usuário\n" +
                                "4 - \n" +
                                "5 - Buscar livro\n" +
                                "6 - Emprestar livro\n" +
                                "7 - Devolver livro\n");
            
            input = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine();
            
            switch(input){

                case 1: // registrarUser

                    Console.WriteLine("Digite seu nome");
                    var nome = Console.ReadLine().ToString();
                    Console.WriteLine();

                    Console.WriteLine("Digite seu código");
                    var codigo = Console.ReadLine().ToString();
                    Console.WriteLine();

                    Console.WriteLine("Digite sua idade");
                    var idade = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Console.WriteLine("Você é:\n1 - Aluno\n2 - Professor\n3 - Funcionário da Biblioteca\n");
                    var n = int.Parse(Console.ReadLine().ToString());
                    Console.WriteLine();

                    switch(n){
                        case 1: //ALUNO
                            facade.registrarAluno(nome,codigo,idade);
                            Console.WriteLine("Aluno registrado com sucesso!\n");
                            break;
                        case 2: //PROFESSOR
                            facade.registrarProfessor(nome,codigo,idade);
                            Console.WriteLine("Professor registrado com sucesso!\n");
                            break;
                        case 3: //FUNCIONARIO
                            facade.registrarFuncionario(nome,codigo,idade);
                            Console.WriteLine("Funcionário registrado com sucesso!\n");
                            break;
                    }
                    
                    break;


                case 2: // removerUser

                    Console.WriteLine("Digite o código do usuário a ser removido: \n");
                    var cod = Console.ReadLine().ToString();
                    facade.removerUser(cod);
                    break;

                case 3: // buscarUser

                    Console.WriteLine("Digite o código do usuário que você deseja observar:");
                    var code = Console.ReadLine().ToString();
                    Console.WriteLine();
                    facade.buscarUser(code);
                    break;

                case 4: // registrarLivro
                        facade.registrarLivro();
                    break;

                case 5: // buscarLivro

                    break;

                case 6: // emprestarLivro
                    break;        
                
                case 7: // deolverLivro
                    break;
            }

        }
    }
}