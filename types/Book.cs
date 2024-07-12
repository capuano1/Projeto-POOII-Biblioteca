using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Book {

    private string name;
    private List<string> authors;
    private DateTime? launchDate;
    private List<string> genres;
    private List<HashSet<string>> subgenres;

    private int copOwned;
    private int copEmprestadas;

    public Book(string bname, List<string> authorl) {
        this.genres = new List<string>();
        this.subgenres = new List<HashSet<string>>();
        this.name = bname;
        this.authors = authorl;
    }

    public string getName() { return this.name; }
    public List<string> getAuthors() { return this.authors; }
    public DateTime? getLaunchDate() { return this.launchDate; }
    public void setLaunchDate(DateTime time) { this.launchDate = time; }
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
    public void empresta() { this.copEmprestadas += 1; }
    public void devolve() { this.copEmprestadas -= 1; }

}