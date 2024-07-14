using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IHandler {
    IHandler setNext (IHandler handler);
    bool handle(Book livro, IUser user);
}

public abstract class abstractHandler : IHandler {

    protected IHandler? next;

    public IHandler setNext (IHandler handler) {
        this.next = handler;
        return handler;
    }

    public abstract bool handle(Book livro, IUser user);
}

public class availableCheck : abstractHandler {

    public override bool handle(Book livro, IUser user) {
        if (livro.getCopAvailable() < 1) return false;
        if (this.next != null) return this.next.handle(livro, user);
        return true;
    }
}

public class advertCheck : abstractHandler {

    private int maxAdvert;

    public advertCheck() {
        this.maxAdvert = 3;
    }

    public void setMaxAdvert(int advert) {
        this.maxAdvert = advert;
    }

    public override bool handle(Book livro, IUser user) {
        if (user.getAdvert() > this.maxAdvert) return false;
        if (this.next != null) return this.next.handle(livro, user);
        return true;
    }
}

public class maxBookCheck : abstractHandler {

    private int maxBook;

    public maxBookCheck() {
        this.maxBook = 3;
    }

    public void setMaxBook(int maxBook) {
        this.maxBook = maxBook;
    }

    public override bool handle(Book livro, IUser user) {
        if (user.getNumLivros() >= this.maxBook) return false;
        if (this.next != null) return this.next.handle(livro, user);
        return true;
    }
}