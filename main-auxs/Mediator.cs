using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMediator {
    void Notify (object objA, object objB);
}

public class ConcMediator : IMediator {

    private object ObjectA;
    private object ObjectB;

    public ConcMediator (object objA, object objB) {
        this.ObjectA = objA;
        this.ObjectB = objB;
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