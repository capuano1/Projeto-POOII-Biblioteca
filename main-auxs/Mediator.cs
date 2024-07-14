using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMediator {
    public List<Book> buscaLivro (string type, string mes);
    public IUser? buscaUser (string cod);
    public int chainCheck (Book livro, IUser user);
    public int emprestaLivro (int codLivro, string codUser);
    public int devolveLivro (int codLivro, string codUser);
    void Notify (object objA, object objB);
}

public class ConcMediator : IMediator {

    private BBD? BookBD;
    private UBD? UserBD;
    private BaseMedClass Component;
    private IHandler? approvingChain;

    public ConcMediator (BBD? book, UBD? user, BaseMedClass comp) {
        this.BookBD = book;
        this.UserBD = user;
        this.Component = comp;
    }

    public List<Book> buscaLivro (string type, string mes) {
        switch (type) {
            case "Código":
                return BookBD.getLivroCod(Convert.ToInt32(mes));

            case "Nome":
                return BookBD.getLivroNome(mes);

            case "Autor":
                return BookBD.getLivrosAutor(mes);

            case "Genre":
                return BookBD.getLivrosGenre(mes);
        }
    return null;
    }

    public IUser? buscaUser (string cod) {
        return UserBD.buscaUser(cod);
    }

    public int chainCheck (Book livro, IUser user) {
        approvingChain = new availableCheck().setNext(new advertCheck()).setNext(new maxBookCheck());
        return approvingChain.handle(livro, user);
    }

    public int emprestaLivro (int codLivro, string codUser) {
        List<Book> aux = buscaLivro("Código", codLivro.ToString());
        if (aux.Count == 0) return -1;
        Book livro = aux[0];
        IUser user;
        if (buscaUser(codUser) == null) return -2;
        user = buscaUser(codUser);
        int check = chainCheck(livro, user);
        if (check != 0) return check;

        livro.empresta();
        user.empresta(new BookReg(livro));
        return 0;
    }

    public int devolveLivro (int codLivro, string codUser) {
        List<Book> aux = buscaLivro("Código", codLivro.ToString());
        if (aux.Count == 0) return -1;
        Book livro = aux[0];
        IUser user;
        if (buscaUser(codUser) == null) return -2;
        user = buscaUser(codUser);
        
        int result = user.devolve(livro);
        if (result == -3) return -3;
        livro.devolve();
        return 0;
    }

    public void Notify (object objA, object objB) {}

}

public class BaseMedClass {
    protected IMediator? mediator;

    public BaseMedClass() {
        this.mediator = null;
    }

    public void setMediator(IMediator mediador) {
        this.mediator = mediador;
    }
}