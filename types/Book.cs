using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Book {

    private string name;
    private int cod;
    private List<string> authors;
    private List<string> genres;
    private List<HashSet<string>> subgenres;

    private int copOwned;
    private int copEmprestadas;

    public Book(string bname, List<string> authorl, int codg) {
        this.genres = new List<string>();
        this.subgenres = new List<HashSet<string>>();
        this.name = bname;
        this.authors = authorl;
        this.cod = codg;
    }

    public string getName() { return this.name; }
    public int getCod() { return this.cod; }
    public List<string> getAuthors() { return this.authors; }
    public List<string> getGenres() { return this.genres; }
    public List<HashSet<string>> getSubgenres() { return this.subgenres; }
    public void addGenre(string gen) { this.genres.Add(gen); }
    public void addSubgenre(string gen, string subgen) { subgenres[genres.FindIndex(ind => ind == gen)].Add(subgen); }
    public void removeGenre(string gen) {
        int aux = genres.FindIndex(g => g == gen);
        genres.RemoveAt(aux);
        subgenres.RemoveAt(aux);
    }
    public void removeSubgenre(string gen, string subgen) { subgenres[genres.FindIndex(ind => ind == gen)].Remove(subgen); }
    public int getCopOwned() { return this.copOwned; }
    public void setCopOwned(int num) { this.copOwned = num; }
    public int getCopEmprestadas() { return this.copEmprestadas; }
    public int getCopAvailable() { return this.copOwned - this.copEmprestadas;}
    public void empresta() { this.copEmprestadas += 1; }
    public void devolve() { this.copEmprestadas -= 1; }

}


/*
void static Main(){
    facade.reservarLivro(string codigo, string livroTitulo);
}

public class Facade{
    private Mediator m = new Imediator();
    public void reservarLivro(string codigo, string livroTitulo){

    }
}

public class Facade{

    


}


*/