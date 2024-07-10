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
    private int advert;

    public IUser (string nome, string codg, int age) {
        this.name = nome;
        this.cod = codg;
        this.idade = age;
    }

    public string getName() { return this.name; }
    public string getCod() { return this.cod; }
    public int getIdade() { return this.idade; }
    public int gerAdvert() { return this.advert; }

}
