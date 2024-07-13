using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Facade {
    
    private UBD userBD;
    private IHandler approvingChain;

//Criar instancia do approving chain, fazendo new da primeira checagem e criando as outras.

    public Facade() {
        this.userBD = UserBD_static.iniciaBD();
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
        var user = userBD.buscaUser(codigo);
        if(user != null){ 
            Console.WriteLine($"Nome: {user.getName()}\nIdade: {user.getIdade()}\nTipo de usuário: {user.getTipoUser()}");
        }
        else{
            Console.WriteLine("Usuário não encontrado.");
        }
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
}