using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Facade {
    
    private UBD userBD;
    private BBD bookBD;

    private ConcMediator instanciaBuscaLivro() {
        BuscaLivro busc = new BuscaLivro();
        ConcMediator med = new ConcMediator(bookBD, null, busc);
        busc.setMediator(med);
        return med;
    }

    private ConcMediator instanciaBuscaUser() {
        BuscaUser busc = new BuscaUser();
        ConcMediator med = new ConcMediator(bookBD, null, busc);
        busc.setMediator(med);
        return med;
    }

    private ConcMediator instanciaEmprestaLivro() {
        EmprestaLivro emp = new EmprestaLivro();
        ConcMediator med = new ConcMediator(bookBD, null, emp);
        emp.setMediator(med);
        return med;
    }

    private ConcMediator instanciaDevolveLivro() {
        DevolveLivro dev = new DevolveLivro();
        ConcMediator med = new ConcMediator(bookBD, null, dev);
        dev.setMediator(med);
        return med;
    }

    public Facade() {
        this.userBD = UserBD_static.iniciaBD();
        this.bookBD = BookBD_static.iniciaBD();
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

    public void emprestaLivro (int codLivro, string codUser) {
        ConcMediator mediator = instanciaEmprestaLivro();
        mediator.emprestaLivro(codLivro, codUser);
    }

    public void devolveLivro (int codLivro, string codUser) {
        ConcMediator mediator = instanciaDevolveLivro();
        mediator.devolveLivro(codLivro, codUser);
    }

    public void configMaxAdvert (int value) {
        ConcMediator mediator = new ConcMediator(null, null, null);
        mediator.changeConfig("maxAdvert", value);
    }

    public void configMaxBook (int value) {
        ConcMediator mediator = new ConcMediator(null, null, null);
        mediator.changeConfig("maxBook", value);
    }

}