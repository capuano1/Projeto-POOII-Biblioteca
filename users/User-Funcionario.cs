using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class userFuncionario : IUser {
    
    public userFuncionario (string nome, string codg, int age, string tipo) : base(nome, codg, age, "Funcionário") {}
}