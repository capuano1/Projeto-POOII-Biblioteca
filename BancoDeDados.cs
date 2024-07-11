using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

public class BancoDeDados{
    private List<IUser> users = new();
    public List<IUser> getUsers
    {
        get { return users; }
    }

    public void registerUser(IUser user){
        this.users.Add(user);
    }
    public void removerUser(string cod){
        this.users.Remove( this.users.Find(x => x.getCod() == cod) );
    }
    
}