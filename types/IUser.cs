using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class IUser
{
    private string name;
    private string cod;
    private int idade;
    private int numLivrosEmprestados;
    private int advert;
    private string tipoUser;

    public IUser (string nome, string codg, int age, string tipo) {
        this.name = nome;
        this.cod = codg;
        this.idade = age;
        this.advert = 0;
        this.numLivrosEmprestados = 0;
        this.tipoUser = tipo;
    }

    public string getName() { return this.name; }
    public string getCod() { return this.cod; }
    public int getIdade() { return this.idade; }
    public int getAdvert() { return this.advert; }
    public void giveAdvert() { this.advert += 1; }
    public int getNumLivros() { return this.numLivrosEmprestados; }
    public void setNumLivros(int numNovo) { this.numLivrosEmprestados = numNovo; }
    public string getTipoUser() { return this.tipoUser; }

}
