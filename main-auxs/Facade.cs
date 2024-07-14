using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Facade {
    
    private UBD userBD;
    private BBD bookBD;
    private IHandler approvingChain;

    private ConcMediator instanciaBuscaLivro() {
        return new ConcMediator(bookBD, null, new BuscaLivro());
    }

    private ConcMediator instanciaBuscaUser() {
        return new ConcMediator(null, userBD, new BuscaUser());
    }


    public Facade() {
        this.userBD = UserBD_static.iniciaBD();
        this.bookBD = BookBD_static.iniciaBD();
        this.approvingChain = new availableCheck().setNext(new advertCheck()).setNext(new maxBookCheck());
    }

    public void registrarAluno(string name, string cod, int idade) {
        userBD.registraUsuario(new userEstudante(name, cod, idade));
    }
    public void registrarFuncionario(string name, string cod, int idade) {
        userBD.registraUsuario(new userFuncionario(name, cod, idade));
    }
    public void registrarProfessor(string name, string cod, int idade) {
        userBD.registraUsuario(new userProfessor(name, cod, idade));
    }

    public void buscarUser(string codigo) {
        ConcMediator mediator = instanciaBuscaUser();
        mediator.buscaUser(codigo);
    }

    public bool codExiste(string codigo) {
        if (userBD.buscaUser(codigo) != null) return true;
        return false;
    }

    public void removerUser(string codigo){
        var user = userBD.buscaUser(codigo);
        if(user != null){
            userBD.removeUsuario( user );
        }
        else{
            Console.WriteLine("Usuário não encontrado.\n");
        }
    }

    public void buscaLivroCod (int cod) {
        ConcMediator mediator = instanciaBuscaLivro();
        mediator.buscaLivro("Código", cod.ToString());
    }

    public void buscaLivroNome (string name) {
        ConcMediator mediator = instanciaBuscaLivro();
        mediator.buscaLivro("Nome", name);
    }

    public void buscaLivroAuthor (string author) {
        ConcMediator mediator = instanciaBuscaLivro();
        mediator.buscaLivro("Autor", author);
    }

    public void buscaLivroGenre (string genre) {
        ConcMediator mediator = instanciaBuscaLivro();
        mediator.buscaLivro("Genre", genre);
    }

}