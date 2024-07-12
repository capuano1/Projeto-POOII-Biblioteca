using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Facade {
    
    private UserBD userBD;

    public Facade() {
        userBD = UserBD.instanciaBD();
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
        var user = userBD.getUsers().Find(x => x.getCod() == codigo);
        if(user != null){ 
            Console.WriteLine($"Nome: {user.getName()}\nIdade: {user.getIdade()}\nTipo de usuário: {user.getTipoUser()}");
        }
        else{
            Console.WriteLine("Usuário não encontrado.");
        }
    }

}