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
            Console.WriteLine(  "1 - Emprestar livro.\n" +
                                "2 - Devolver livro.\n" +
                                "3 - Opções de Usuário.\n" +
                                "4 - Opções de Livro\n" +
                                "5 - Configurações do Sistema.\n" +
                                "6 - Sair\n");
            
            input = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine();
            Console.WriteLine();
            
            switch(input){

                case 1: // Emprestar livro
                    Console.WriteLine("Digite o código do livro que o usuário deseja emprestar:\n");
                    var livroc = int.Parse(Console.ReadLine().ToString());
                    Console.WriteLine();
                    Console.WriteLine("Digite o código do usuário que deseja emprestar o livro:\n");
                    var userc = Console.ReadLine().ToString();
                    Console.WriteLine();
                    
                    facade.emprestaLivro(livroc,userc);
                    break;

                case 2: // Devolver livro
                    Console.WriteLine("Digite o código do livro que o usuário deseja devolver:\n");
                    var livrocod = int.Parse(Console.ReadLine().ToString());
                    Console.WriteLine();

                    Console.WriteLine("Digite o código do usuário que deseja devolver o livro:\n");
                    var usercod = Console.ReadLine().ToString();
                    Console.WriteLine();

                    facade.devolveLivro(livrocod,usercod);
                    break;

                case 3: // Opções de Usuario
                    var a = 0;
                    while(a != 4){
                        Thread.Sleep(1500);
                        Console.WriteLine();        
                        Console.WriteLine(  "1 - Buscar usuário.\n" +
                                            "2 - Adicionar usuário.\n" +
                                            "3 - Remover usuário.\n" +
                                            "4 - Voltar.\n");
                        a = int.Parse(Console.ReadLine().ToString());
                        Console.WriteLine();

                        switch(a){
                            case 1: // Buscar usuário

                                Console.WriteLine("Digite o código do usuário que você deseja observar:");
                                var code = Console.ReadLine().ToString();
                                Console.WriteLine();
                                facade.buscarUser(code);

                                break;

                            case 2: // Adicionar usuário

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
                            
                            case 3: // Remover usuário

                                Console.WriteLine("Digite o código do usuário a ser removido: \n");
                                var cod = Console.ReadLine().ToString();
                                Console.WriteLine();

                                facade.removerUser(cod);

                                break;
                            
                            case 4: // Voltar
                                break;
                        }

                    }

                    break;

                case 4: // Opções de livro
                    var b = 0;
                    while(b != 8){
                        Thread.Sleep(1500);
                        Console.WriteLine();        
                        Console.WriteLine(  "1 - Buscar livro.\n" +
                                            "2 - Adicionar livro.\n" +
                                            "3 - Remover livro.\n" +
                                            "4 - Adicionar gênero à um livro.\n"+
                                            "5 - Remover gênero de um livro.\n"+
                                            "6 - Adicionar subgênero à um livro.\n"+
                                            "7 - Remover subgênero de um livro.\n"+
                                            "8 - Voltar.\n");

                        b = int.Parse(Console.ReadLine().ToString());
                        Console.WriteLine();

                        switch(b){
                            case 1: // Buscar livro
                            Console.WriteLine("Digite a opção de busca: ");
                                Console.WriteLine(  "1 - Por código.\n" +
                                                    "2 - Por nome.\n" +
                                                    "3 - Por autor.\n" +
                                                    "4 - Por gênero.\n");

                                var str = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine();

                                switch(str){
                                    case 1:
                                        Console.Write("Digite o código do livro: ");
                                        var cod = int.Parse(Console.ReadLine().ToString());
                                        Console.WriteLine();

                                        facade.buscaLivroCod(cod);
                                        break;
                                    
                                    case 2:
                                        Console.Write("Digite o nome do livro: ");
                                        var name = Console.ReadLine().ToString();
                                        Console.WriteLine();
                                        facade.buscaLivroNome(name);
                                        break;
                                    
                                    case 3:
                                        Console.Write("Digite o(s) autor(es) do livro: ");
                                        var author = Console.ReadLine().ToString();
                                        Console.WriteLine();

                                        facade.buscaLivroNome(author);
                                        break;

                                    case 4: 
                                        Console.Write("Digite o(s) gênero(s) do livro: ");
                                        var gene = Console.ReadLine().ToString();
                                        Console.WriteLine();

                                        facade.buscaLivroNome(gene);
                                        break;
                                }
                                break;

                            case 2: // Adicionar livro
                                var x = "S";
                                String aux;
                                List<String> autores = new List<String>();

                                Console.Write("Digite o nome do livro que deseja adicionar: ");
                                String titulo = Console.ReadLine().ToString();
                                Console.WriteLine();

                                while(x != "N"){
                                    Console.WriteLine("Digite o gênero que deseja adicionar: ");
                                    aux = Console.ReadLine().ToString();
                                    Console.WriteLine();
                                    
                                    autores.Add(aux);

                                    Console.WriteLine("Deseja adicionar mais autores? (S/N)\n");
                                    x = Console.ReadLine().ToString();
                                    Console.WriteLine();
                                    
                                }

                                facade.registraLivro(titulo,autores);
                                break;

                            case 3: // Remover livro
                                Console.WriteLine("Digite o código do livro que será removido: ");
                                int codigo = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine();

                                facade.removeLivro(codigo);
                                break;

                            case 4: // Adicionar gênero de livro
                                Console.WriteLine("Digite o código do livro que você vai adicionar o gênero: ");
                                int code = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine();

                                Console.WriteLine("Digite o gênero que será inserido: ");
                                var genre = Console.ReadLine().ToString();
                                Console.WriteLine();

                                facade.adicionaGenero(code,genre);
                                break;

                            case 5: // Remover gênero de livro
                                Console.WriteLine("Digite o código do livro que você vai remover o gênero: ");
                                int codi = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine();

                                Console.WriteLine("Digite o gênero que será removido: ");
                                var genr = Console.ReadLine().ToString();
                                Console.WriteLine();

                                facade.removeGenero(codi,genr);
                                break;

                            case 6: // Adicionar subgênero de livro
                                Console.WriteLine("Digite o código do livro que você vai adicionar o subgênero: ");
                                int scode = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine("Digite o gênero em que será inserido subgênero: ");
                                var ger = Console.ReadLine().ToString();
                                Console.WriteLine("Digite o subgênero que será removido: ");
                                var sgenre = Console.ReadLine().ToString();
                                facade.adicionaSubGenero(scode,ger,sgenre);
                                break;

                            case 7: // Remover subgênero de livro
                                Console.WriteLine("Digite o código do livro que você vai remover o subgênero: ");
                                int sco = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine("Digite o gênero que será removido o subgênero: ");
                                var gener = Console.ReadLine().ToString();
                                Console.WriteLine("Digite o subgênero que será removido: ");
                                var sgen = Console.ReadLine().ToString();
                                facade.removeSubGenero(sco,gener,sgen);
                                break;

                            case 8: // Voltar
                                break;

                        }
                    }    
                    break;

                case 5: // Opções do Sistema
                    var c = 0;
                    while(c != 8){
                        Thread.Sleep(1500);
                        Console.WriteLine();
                         Console.WriteLine( "1 - Configurar o número máximo de advertências.\n" +
                                            "2 - Configurar o número máximo de livros emprestados.\n" +
                                            "3 - Voltar.\n");
                        c = int.Parse(Console.ReadLine().ToString());
                        Console.WriteLine();

                        switch(c){
                            case 1: // Configura maximo de advertências
                                Console.WriteLine("Digite o número máximo de advertências que cada aluno pode receber:");
                                int nAdvert = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine();
                                facade.configMaxAdvert(nAdvert);
                                break;
                            case 2:// Configura maximo de livros emprestados
                                Console.WriteLine("Digite o número máximo de livros que cada aluno pode emprestar:");
                                int nBooks = int.Parse(Console.ReadLine().ToString());
                                Console.WriteLine();
                                facade.configMaxAdvert(nBooks);
                                break;
                            case 3: // Voltar
                                break;

                        }
                    }

                    break;

                case 6: // sair
                    break;        

            }

        }
    }
}

