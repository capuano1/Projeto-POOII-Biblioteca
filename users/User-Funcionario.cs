using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class userFuncionario : IUser {
    
    public userFuncionario(string nome, string codg, int age) : base(nome, codg, age) {
        this.TipoUser = "Funcionário";
    }

}