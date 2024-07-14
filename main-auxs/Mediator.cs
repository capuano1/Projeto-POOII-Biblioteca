using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMediator {
    public List<Book> buscaLivro (string type, string mes);
    public IUser? buscaUser (string cod);
    void Notify (object objA, object objB);
}

public class ConcMediator : IMediator {

    private BBD? BookBD;
    private UBD? UserBD;
    private BaseMedClass Component;

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